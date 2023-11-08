import { providers } from '$lib/api/provider';
import type { User } from '$lib/database/userDatabase';
import { error, json } from '@sveltejs/kit';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ fetch }) => {
	const user: User | null = await fetch('/api/auth?user=true')
		.then((res) => res.json())
		.catch(() => null);

	if (!user) throw error(401, 'Unauthorized');
	
	return json(providers);
};
