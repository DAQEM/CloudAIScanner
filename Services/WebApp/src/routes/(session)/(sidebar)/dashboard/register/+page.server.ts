import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError, Pagination } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch, url: { searchParams } }) => {
	const page: string | null = searchParams.get('page');
	const pageSize: string | null = searchParams.get('pageSize');

	const pageInt: number = page ? parseInt(page) : 1;
	const pageSizeInt: number = pageSize ? parseInt(pageSize) : 20;

	const systems: Pagination<AISystem[]> | FetchError = await new AiRegisterAPI(fetch).getAiSystems(
		pageInt,
		pageSizeInt
	);

	if ('error' in systems) {
		return {
			systems: {
				data: [],
				page: 1,
				pageSize: 20,
				totalPages: 1
			}
		};
	}

	return {
		systems
	};
}) satisfies PageServerLoad;
