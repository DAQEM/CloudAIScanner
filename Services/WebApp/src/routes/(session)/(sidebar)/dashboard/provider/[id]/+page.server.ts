import AiRegisterAPI from '$lib/api/ai_register';
import type { FetchError, Provider } from '$lib/types/types';
import { error } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch, params: { id } }) => {
    const provider: Provider | FetchError = await new AiRegisterAPI(fetch).getProviderById(id);

    if ('error' in provider) {
        throw error(404, "Provider doesn't exist");
    }

    return {
        provider,
    };
}) satisfies PageServerLoad;