import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError } from '$lib/types/types';
import type { PageServerLoad, Actions } from './$types';

export const load = (async ({ fetch }) => {
	let pendingSystems: AISystem[] | FetchError = await new AiRegisterAPI(fetch).getAiSystems();

	if ('error' in pendingSystems) {
		return {
			pendingSystems: []
		};
	}

	pendingSystems = pendingSystems.filter((system) => system.approvalStatus?.name?.toLocaleLowerCase() === 'pending');

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

		console.log(id);

		await new AiRegisterAPI(fetch).editApprovalStatus(id, 1);

		return {
			status: 302,
			redirect: '/admin/approval'
		};
	}
} satisfies Actions;
