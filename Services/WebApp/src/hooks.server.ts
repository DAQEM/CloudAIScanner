import AiRegisterAPI from '$lib/api/ai_register';
import clientPromise from '$lib/database/clientPromise';
import { UserDatabase } from '$lib/database/userDatabase';
import { roles } from '$lib/types/role';
import type { Provider } from '$lib/types/types';
import Google from '@auth/core/providers/google';
import { MongoDBAdapter } from '@auth/mongodb-adapter';
import { SvelteKitAuth, type SvelteKitAuthConfig } from '@auth/sveltekit';
import type { Handle } from '@sveltejs/kit';
import { sequence } from '@sveltejs/kit/hooks';

const providers: Provider[] = [
	{
		guid: '6147de64-95ee-4040-86e5-a3c0a2b32573',
		name: 'Google Cloud',
		address: 'Mountain View, California, USA',
		email: 'cloud-support@google.com',
		phoneNumber: '+1 650-253-0000',
		authorizedRepresentitives: [
			{
				guid: '6147de64-95ee-4040-86e5-a3c0a2b32574',
				name: 'Google Cloud Employee',
				email: 'google-employee@google.com',
				phoneNumber: '+1 650-253-0001'
			}
		]
	},
	{
		guid: '15085208-a80f-42c8-8a75-c39c87384941',
		name: 'OpenAI',
		address: '3180 18th Street, San Francisco, USA',
		email: 'openai-support@openai.com',
		phoneNumber: '(800) 217-3145',
		authorizedRepresentitives: [
			{
				guid: '15085208-a80f-42c8-8a75-c39c87384942',
				name: 'Google Cloud Employee',
				email: 'openai-employee@openai.com',
				phoneNumber: '(800) 217-3146'
			}
		]
	}
];

const initialize = async () => {
	initializeProviders();
	initDefaultUser();
};

export const defaultHandle: Handle = async ({ event, resolve }) => {
	await initialize();
	const response = await resolve(event);
	return response;
};

export const authHandle: Handle = SvelteKitAuth(async () => {
	const authOptions: SvelteKitAuthConfig = {
		providers: [
			Google({
				clientId: import.meta.env.VITE_GOOGLE_CLIENT_ID,
				clientSecret: import.meta.env.VITE_GOOGLE_SECRET,
				authorization: {
					params: {
						redirect_uri: import.meta.env.VITE_GOOGLE_REDIRECT_URI
					}
				}
			}),
			Google({
				id: 'google-aiextraction',
				clientId: import.meta.env.VITE_GOOGLE_AI_EXTRACTION_CLIENT_ID,
				clientSecret: import.meta.env.VITE_GOOGLE_AI_EXTRACTION_SECRET,
				authorization: {
					params: {
						redirect_uri: import.meta.env.VITE_GOOGLE_AI_EXTRACTION_REDIRECT_URI,
						scope:
							'openid https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/cloud-platform.read-only'
					}
				}
			})
		],
		adapter: MongoDBAdapter(clientPromise, {
			databaseName: 'accounts'
		}),
		secret: import.meta.env.VITE_SECRET,
		trustHost: true,
	};
	return authOptions;
});

export const handle: Handle = sequence(defaultHandle, authHandle);

function initializeProviders() {
	const api = new AiRegisterAPI(fetch, true);
	api.getProviders().then((res) => {
		let p = res as Provider[];
		if (!Array.isArray(p)) {
			p = [];
		}
		for (const provider of providers) {
			if (!p.find((x) => x.guid === provider.guid)) {
				console.info('Provider ' + provider.name + ' not found, creating...');
				initializeProvider(provider, api);
			}
		}
	});
}

function initializeProvider(provider: Provider, api: AiRegisterAPI) {
	api.createProvider(provider).then((res) => {
		if ((res as Provider).guid) {
			console.info('Provider ' + provider.name + ' created');
		} else {
			console.error('Error creating provider ' + provider.name);
			console.error('result', res);
		}
	});
}

async function initDefaultUser() {
	const api: UserDatabase = await UserDatabase.get();
	const email: string | undefined = import.meta.env.VITE_DEFAULT_USER_EMAIL;
	if (!email) {
		return;
	}
	await api.getUserByEmail(email).then((user) => {
		if (!user || !user._id) {
			api.addUser({
				email,
				roles: roles
			});
		}
	});
}