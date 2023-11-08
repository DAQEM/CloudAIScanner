import { systems, type System } from '$lib/api/systems';
import type { User } from '$lib/database/userDatabase';
import { error, json } from '@sveltejs/kit';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ params, fetch }) => {
	const user: User | null = await fetch('/api/auth?admin=true')
		.then((res) => res.json())
		.catch(() => null);

	if (!user) throw error(401, 'Unauthorized');

	const system: System | undefined = systems.find((system) => system.id === params.id);

	if (!system) {
		return json({ error: 'Invalid ID' });
	}

	system.status = 'Rejected';

	return json(system);
};
