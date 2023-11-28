import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, AISystemStatus, FetchError } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

export const load = (async ({ params, fetch }) => {
	const id = params.id;
	const api: AiRegisterAPI = new AiRegisterAPI(fetch);
	const system: AISystem | FetchError = await api.getAiSystemById(id);
	const statuses: AISystemStatus[] | FetchError = await api.getAISystemStatuses();
	const memberStates = await api.getMemberStates();
	if (!('error' in system) && !('error' in statuses) && !('error' in memberStates)) {
		if (system) {
			return {
				system,
				statuses,
				memberStates
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
		const status = data.get('status') as string;
		const date = data.get('date') as string;
		const description = data.get('description') as string;
		const url = data.get('url') as string;
		const technicalDocumentationLink = data.get('technicalDocumentationLink') as string;
		const memberStates: number = data
			.getAll('memberStates')
			.map((memberState) => parseInt(memberState.toString()))
			.filter((memberState) => !isNaN(memberState))
			.reduce((a, b) => a + b, 0);

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		const result = await api.editAiSystem(
			id,
			name,
			parseInt(status),
			description,
			url,
			technicalDocumentationLink,
			memberStates
		);

		throw redirect(302, `/dashboard/register`);
	}
} satisfies Actions;
