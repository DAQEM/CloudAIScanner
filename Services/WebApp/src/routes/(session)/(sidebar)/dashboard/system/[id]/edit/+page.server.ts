import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

export const load = (async ({ params, fetch }) => {
	const id = params.id;
	const api: AiRegisterAPI = new AiRegisterAPI(fetch);
	const system: AISystem | FetchError = await api.getAiSystemById(id);
	const memberStates = await api.getMemberStates();
	if (!('error' in system) && !('error' in memberStates)) {
		if (system) {
			return {
				system,
				memberStates
			};
		}
	}
	throw redirect(302, '/dashboard/register');
}) satisfies PageServerLoad;

export const actions = {
	default: async ({ request, params }) => {
		const data = await request.formData();

		const guid = params.id;
		const name = data.get('name') as string;
		const description = data.get('description') as string;
		const url = data.get('url') as string;
		const technicalDocumentationLink = data.get('technicalDocumentationLink') as string;
		const memberStates: number = data
			.getAll('memberStates')
			.map((memberState) => parseInt(memberState.toString()))
			.filter((memberState) => !isNaN(memberState))
			.reduce((a, b) => a + b, 0);

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		await api.editAiSystem(
			guid,
			name,
			description,
			url,
			technicalDocumentationLink,
			memberStates
		);

		throw redirect(302, `/dashboard/register`);
	}
} satisfies Actions;
