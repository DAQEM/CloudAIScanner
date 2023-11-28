import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError, Pagination } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

export const load = (async ({ fetch, url: { searchParams } }) => {
	const page: string | null = searchParams.get('page');
	const pageSize: string | null = searchParams.get('pageSize');

	const pageInt: number = page ? parseInt(page) : 1;
	const pageSizeInt: number = pageSize ? parseInt(pageSize) : 20;

	let pendingSystems: Pagination<AISystem[]> | FetchError = await new AiRegisterAPI(
		fetch
	).getAiSystems(pageInt, pageSizeInt);

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

	pendingSystems.data = pendingSystems.data.filter(
		(system) => system.approvalStatus?.name?.toLocaleLowerCase() === 'pending'
	);

	return {
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;

export const actions = {
	reject: async ({ request, fetch }) => {
		const formData = await request.formData();
		const id = formData.get('id') as string;

		await new AiRegisterAPI(fetch).editApprovalStatus(id, 3);

		throw redirect(302, `/admin/approval`);
	},
	approve: async ({ request, fetch }) => {
		const formData = await request.formData();
		const id = formData.get('id') as string;

		await new AiRegisterAPI(fetch).editApprovalStatus(id, 1);

		throw redirect(302, `/admin/approval`);
	},
	bulk_reject: async ({ request, fetch }) => {
		const formData = await request.formData();
		const ids = formData.getAll('ids');

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		for (let index = 0; index < ids.length; index++) {
			const id = ids[index];
			await api.editApprovalStatus(id.toString(), 3);
		}

		throw redirect(302, `/admin/approval`);
	},
	bulk_approve: async ({ request, fetch }) => {
		const formData = await request.formData();
		const ids = formData.getAll('ids');

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		for (let index = 0; index < ids.length; index++) {
			const id = ids[index];
			await api.editApprovalStatus(id.toString(), 1);
		}

		throw redirect(302, `/admin/approval`);
	}
} satisfies Actions;
