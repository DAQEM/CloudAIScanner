import clientPromise from '$lib/database/clientPromise';
import Google from '@auth/core/providers/google';
import { MongoDBAdapter } from '@auth/mongodb-adapter';
import { SvelteKitAuth } from '@auth/sveltekit';
import type { Handle } from '@sveltejs/kit';

export const handle = SvelteKitAuth(async () => {
	const authOptions = {
		providers: [
			Google({
				clientId: import.meta.env.VITE_GOOGLE_CLIENT_ID,
				clientSecret: import.meta.env.VITE_GOOGLE_SECRET,
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
}) satisfies Handle;
