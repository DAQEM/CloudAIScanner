import { systems } from '$lib/api/systems';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async () => {
	const systemList = systems;
	
	return new Response(JSON.stringify(systemList), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
