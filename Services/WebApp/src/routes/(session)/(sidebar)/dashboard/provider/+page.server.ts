import AiRegisterAPI from '$lib/api/ai_register';
import type { FetchError, Provider } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch }) => {
    const providers: Provider[] | FetchError = await new AiRegisterAPI(fetch).getProviders();

    if ('error' in providers) {
        return {
            providers: []
        };
    }

    return {
        providers: providers
    };
}) satisfies PageServerLoad;