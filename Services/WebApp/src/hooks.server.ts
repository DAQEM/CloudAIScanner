import clientPromise from '$lib/database/clientPromise';
import Google from '@auth/core/providers/google';
import { MongoDBAdapter } from '@auth/mongodb-adapter';
import { SvelteKitAuth } from '@auth/sveltekit';
import type { Handle } from '@sveltejs/kit';

export const handle = SvelteKitAuth(async () => {
	const authOptions = {
		providers: [
			Google({
				clientId: '851505541857-1h5g89v9otcjcp34hmi1hrdnqknbmhbb.apps.googleusercontent.com',
				clientSecret: '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'
			})
		],
		adapter: MongoDBAdapter(clientPromise, {
			databaseName: 'accounts'
		}),
		secret: '67c095d073427d9cd60e6c9b75577057',
		trustHost: true
	};
	return authOptions;
}) satisfies Handle;
