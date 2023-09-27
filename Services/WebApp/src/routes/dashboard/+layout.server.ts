import type { ISession } from '$lib/types/session';
import { redirect } from '@sveltejs/kit';
import type { LayoutServerLoad } from './$types';

export const load = (async ({ locals }) => {
	const session: ISession | null = await locals.getSession();
	if (session !== null) {
		return {
			session: structuredClone(session)
		};
	} else {
		throw redirect(301, '/login');
	}
}) satisfies LayoutServerLoad;
