import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';

export const load = (async ({ params, fetch }) => {
	const id = params.id;
	const system: AISystem | FetchError = await new AiRegisterAPI(fetch).getAiSystemById(id);

	if (!('error' in system)) {
		if (system) {
			return {
				system
			};
		}
	}
	throw redirect(302, '/dashboard/register');
}) satisfies PageServerLoad;
