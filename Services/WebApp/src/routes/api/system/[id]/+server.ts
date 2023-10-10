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

export const PUT: RequestHandler = async ({ params, request }) => {
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

	const data = await request.json();
	const { name, provider, date, status } = data;

	system.name = name;
	system.provider = provider;
	system.date = date;
	system.status = status;

	return new Response(JSON.stringify(system), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
