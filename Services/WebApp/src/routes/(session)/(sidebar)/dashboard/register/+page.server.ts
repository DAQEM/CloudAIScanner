import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError, Pagination } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

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

export const actions: Actions = {
	delete: async ({ request, fetch }) => {
		const data = await request.formData();

		const id = data.get('id') as string;

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		await api.deleteAiSystem(id);

		throw redirect(302, `/dashboard/register`);
	},
	bulk_delete: async ({ request, fetch }) => {
		const data = await request.formData();

		const ids = data.getAll('ids');

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		for (let index = 0; index < ids.length; index++) {
			const id = ids[index];
			await api.deleteAiSystem(id.toString());
		}

		throw redirect(302, `/dashboard/register`);
	}
};
