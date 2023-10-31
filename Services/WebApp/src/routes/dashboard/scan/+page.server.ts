import type { PageServerLoad } from './$types';

export const load = (async ({url: { searchParams }}) => {
	return {
		provider: searchParams.get('provider'),
		success: searchParams.get('success')
	};
}) satisfies PageServerLoad;
