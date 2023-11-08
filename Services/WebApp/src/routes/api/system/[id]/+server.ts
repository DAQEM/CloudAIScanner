import { systems, type System } from '$lib/api/systems';
import type { User } from '$lib/database/userDatabase';
import { error, json } from '@sveltejs/kit';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ params }) => {
	const user: User | null = await fetch('/api/auth?user=true')
		.then((res) => res.json())
		.catch(() => null);

	if (!user) throw error(401, 'Unauthorized');

	const system: System | undefined = systems.find((system) => system.id === params.id);

	if (!system) return json({ error: 'Invalid ID' });

	return json(system);
};

export const PUT: RequestHandler = async ({ params, request, fetch }) => {
	const user: User | null = await fetch('/api/auth?user=true')
		.then((res) => res.json())
		.catch(() => null);

	if (!user) throw error(401, 'Unauthorized');

	const system: System | undefined = systems.find((system) => system.id === params.id);

	if (!system) return json({ error: 'Invalid ID' });

	const { name, provider, date, status, description, description2 } = await request.json();

	system.name = name;
	system.provider = provider;
	system.date = date;
	system.status = status;
	system.description = description;
	system.description2 = description2;

	return json(system);
};
