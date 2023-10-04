import { type System, getSystems } from '$lib/api/systems';
import type { PageServerLoad } from './$types';

export const load = (async () => {
	const systemList: System[] = await getSystems();

	return {
		systems: systemList
	};
}) satisfies PageServerLoad;
