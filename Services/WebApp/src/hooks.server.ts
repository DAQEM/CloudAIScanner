import AiRegisterAPI from '$lib/api/ai_register';
import clientPromise from '$lib/database/clientPromise';
import type { Provider } from '$lib/types/types';
import Google from '@auth/core/providers/google';
import { MongoDBAdapter } from '@auth/mongodb-adapter';
import { SvelteKitAuth } from '@auth/sveltekit';
import type { Handle } from '@sveltejs/kit';
import { sequence } from '@sveltejs/kit/hooks';

const providers: Provider[] = [
	{
		guid: '6147de64-95ee-4040-86e5-a3c0a2b32573',
		name: 'Google Cloud',
		address: 'Mountain View, Californië, Verenigde Staten',
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
	}
];

const initialize = async () => {
	initializeProviders();
};

export const defaultHandle: Handle = async ({ event, resolve }) => {
	await initialize();
	const response = await resolve(event);
	return response;
};

export const authHandle: Handle = SvelteKitAuth(async () => {
	const authOptions = {
		providers: [
			Google({
				clientId: import.meta.env.VITE_GOOGLE_CLIENT_ID,
				clientSecret: import.meta.env.VITE_GOOGLE_SECRET
			}),
			Google({
				id: 'google-aiextraction',
				clientId: import.meta.env.VITE_GOOGLE_AI_EXTRACTION_CLIENT_ID,
				clientSecret: import.meta.env.VITE_GOOGLE_AI_EXTRACTION_SECRET,
				authorization: {
					params: {
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
		trustHost: true
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
