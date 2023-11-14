import { getProviders, type Provider } from '$lib/api/provider';
import { getStatus, type Status } from '$lib/api/status';
import { editSystem, getSystem, type System } from '$lib/api/systems';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';
import type { AISystem, ApprovalStatus, FetchError } from '$lib/types/types';
import AiRegisterAPI from '$lib/api/ai_register';

export const load = (async ({ params, fetch }) => {
	const id = params.id;
	const api: AiRegisterAPI = new AiRegisterAPI(fetch);
	const system: AISystem | FetchError = await api.getAiSystemById(id);
	const status: ApprovalStatus[] | FetchError = await api.getApprovalStatuses();
	const providers: Provider[] = await getProviders();
	if (!("error" in system) && !("error" in status)) {
		if (system) {
			return {
				system,
				status,
				providers
			};
		}
	}
	throw redirect(302, '/dashboard/register');
}) satisfies PageServerLoad;

export const actions = {
	//TODO: This is not working anymore and should be fixed later
	default: async ({ request, params }) => {
		const data = await request.formData();

		const id = params.id;
		const name = data.get('name') as string;
		const provider = data.get('provider') as string;
		const date = data.get('date') as string;
		const status = data.get('status') as 'Pending' | 'Approved' | 'Rejected';
		const description = data.get('description') as string;
		const description2 = data.get('description2') as string;

		const system: System = {
			id,
			name,
			provider,
			date,
			status,
			description,
			description2
		};

		await editSystem(system);
	}
} satisfies Actions;
