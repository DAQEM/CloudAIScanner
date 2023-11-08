import { UserDatabase, type User } from '$lib/database/userDatabase';
import type { Session } from '@auth/core/types';
import type { RequestHandler } from './$types';
import { error } from '@sveltejs/kit';

export const GET: RequestHandler = async ({ locals, url }) => {
	const session: Session | null = await locals.getSession();

	if (!session?.user?.email) {
		throw error(401, 'Unauthorized')
	}

	const requiresAdmin = url.searchParams.get('admin') === 'true' ?? false;
	const requiresUser = url.searchParams.get('user') === 'true' ?? false;

	const associatedUser: User | null = await (
		await UserDatabase.get()
	).getUserByEmail(session.user.email);

	if (
		!associatedUser ||
		(requiresAdmin && !associatedUser.roles.includes('admin')) ||
		(requiresUser &&
			(!associatedUser.roles.includes('admin') || !associatedUser.roles.includes('user')))
	) {
		return new Response(null, {
			status: 401,
			headers: {
				'content-type': 'application/json'
			}
		});
	}

	return new Response(JSON.stringify(associatedUser), {
		headers: {
			'content-type': 'application/json'
		}
	});
};
