import { systems } from '$lib/api/systems';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({url: { searchParams }}) => {
	const systemList = searchParams.get('status') ? systems.filter(system => system.status.toLowerCase() === searchParams.get('status')?.toLowerCase()) : systems;
	
	return new Response(JSON.stringify(systemList), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
