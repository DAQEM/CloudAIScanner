import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError, Pagination } from '$lib/types/types';
import type { PageServerLoad, Actions } from './$types';

export const load = (async ({ fetch, url: { searchParams } }) => {
	const page: string | null = searchParams.get('page');
	const pageSize: string | null = searchParams.get('pageSize');

	const pageInt: number = page ? parseInt(page) : 1;
	const pageSizeInt: number = pageSize ? parseInt(pageSize) : 20;

	let pendingSystems: Pagination<AISystem[]> | FetchError = await new AiRegisterAPI(fetch).getAiSystems(pageInt, pageSizeInt);

	if ('error' in pendingSystems) {
		return {
			pendingSystems: {
				data: [],
				page: 1,
				pageSize: 20,
				totalPages: 1
			}
		};
	}

	pendingSystems.data = pendingSystems.data.filter((system) => system.approvalStatus?.name?.toLocaleLowerCase() === 'pending');

	return {
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;

export const actions = {
	reject: async ({ request, fetch }) => {
		const formData = await request.formData();
		const id = formData.get('id') as string;

		await new AiRegisterAPI(fetch).editApprovalStatus(id, 3);

		return {
			status: 302,
			redirect: '/admin/approval'
		};
	},
	approve: async ({ request, fetch }) => {
		const formData = await request.formData();
		const id = formData.get('id') as string;

		await new AiRegisterAPI(fetch).editApprovalStatus(id, 1);

		return {
			status: 302,
			redirect: '/admin/approval'
		};
	}
} satisfies Actions;
