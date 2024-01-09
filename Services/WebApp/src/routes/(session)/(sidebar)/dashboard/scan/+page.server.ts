import AiRegisterAPI from '$lib/api/ai_register';
import type { FetchError, Provider } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';

export const load = (async ({ url: { searchParams }, fetch }) => {
	const providers: Provider[] | FetchError = await new AiRegisterAPI(fetch).getProviders();

	if ('error' in providers) {
		throw redirect(302, '/');
	}

	return {
		providers,
		success: searchParams.get('success'),
		data: searchParams.get('data')
	};
}) satisfies PageServerLoad;
