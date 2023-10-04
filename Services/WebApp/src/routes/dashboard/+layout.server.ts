import type { Session } from '@auth/core/types';
import { redirect } from '@sveltejs/kit';
import type { LayoutServerLoad } from './$types';

export const load = (async ({ locals }) => {
	const session: Session | null = await locals.getSession();
	if (session !== null) {
		return {
			session: structuredClone(session)
		};
	} else {
		throw redirect(302, '/login');
	}
}) satisfies LayoutServerLoad;
