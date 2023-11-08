import { getSystemsByStatus, type System } from '$lib/api/systems';
import type { PageServerLoad } from './$types';

export const load = (async () => {
	const pendingSystems: System[] = await getSystemsByStatus('pending');

	return {
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;
