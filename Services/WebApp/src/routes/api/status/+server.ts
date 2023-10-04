import { status } from '$lib/api/status';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async () => {
	const statusList = status;
	
	return new Response(JSON.stringify(statusList), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
