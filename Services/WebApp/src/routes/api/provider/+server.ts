import { providers } from '$lib/api/provider';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async () => {
	const providersList = providers;
	
	return new Response(JSON.stringify(providersList), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
