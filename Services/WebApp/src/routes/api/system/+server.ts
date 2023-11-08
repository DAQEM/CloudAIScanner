import { systems } from '$lib/api/systems';
import type { User } from '$lib/database/userDatabase';
import { error, json } from '@sveltejs/kit';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ url: { searchParams }, fetch }) => {
	const user: User | null = await fetch('/api/auth?user=true')
		.then((res) => res.json())
		.catch(() => null);

	if (!user) throw error(401, 'Unauthorized');

	const systemList = searchParams.get('status')
		? systems.filter(
				(system) => system.status.toLowerCase() === searchParams.get('status')?.toLowerCase()
		  )
		: systems;

	return json(systemList);
};
