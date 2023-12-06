import AiRegisterAPI from '$lib/api/ai_register';
import type { FetchError, Provider } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { PageServerLoad, Actions } from './$types';

export const load = (async ({ fetch, params: { id } }) => {
	const provider: Provider | FetchError = await new AiRegisterAPI(fetch).getProviderById(id);

	if ('error' in provider) {
		throw redirect(302, '/dashboard/provider');
	}

	return {
		provider
	};
}) satisfies PageServerLoad;

export const actions = {
	default: async ({ request, params }) => {
		const data = await request.formData();

		const guid = params.id;
		const name = data.get('name') as string;
		const address = data.get('address') as string;
		const email = data.get('email') as string;
		const phoneNumber = data.get('phoneNumber') as string;;

		const api: AiRegisterAPI = new AiRegisterAPI(fetch);

		await api.editProvider(
			guid,
			name,
			address,
			email,
			phoneNumber
		);

		throw redirect(302, `/dashboard/provider`);
	}
} satisfies Actions;
