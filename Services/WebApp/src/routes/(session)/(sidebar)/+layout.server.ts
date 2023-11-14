import type { Session } from '@auth/core/types';
import { redirect } from '@sveltejs/kit';
import type { LayoutServerLoad } from './$types';

/**
 * This is the server-side load function for the layout.
 * It is used to get the session and associated user.
 *
 * If the user is not logged in, they will be redirected to the login page.
 */

export const load = (async ({ parent }) => {
	const parentData = await parent();
	const session: Session | null = parentData.session;

	// If the user is not logged in, redirect to the login page.
	if (session === null) {
		throw redirect(302, '/login');
	}
	if (!(parentData.associatedUser?.roles.includes('admin') || parentData.associatedUser?.roles.includes('user'))) {
		throw redirect(302, `/access-denied/request-access`);
	}
}) satisfies LayoutServerLoad;
 