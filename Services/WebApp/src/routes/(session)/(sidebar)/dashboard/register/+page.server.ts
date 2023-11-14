import AiRegisterAPI from '$lib/api/ai_register';
import type { AISystem, FetchError } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch }) => {
	const systems: AISystem[] | FetchError = await new AiRegisterAPI(fetch).getAiSystems();

	if ('error' in systems) {
		return {
			systems: []
		};
	}

	return {
		systems
	};
}) satisfies PageServerLoad;
