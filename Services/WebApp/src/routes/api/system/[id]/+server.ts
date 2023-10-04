import { systems, type System } from '$lib/api/systems';
import { json } from '@sveltejs/kit';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ params }) => {
	const systemList: System[] = systems;
	const id = params.id;
	const system: System | undefined = systemList.find((system) => system.id === id);

	if (!system) {
		return new Response(
			JSON.stringify({ error: 'Invalid ID' }),
			{
				headers: {
					'content-type': 'application/json'
				}
			}
		);
	}

	return new Response(JSON.stringify(system), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
