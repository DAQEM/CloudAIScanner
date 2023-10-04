import { getStatus, type Status } from '$lib/api/status';
import { getSystem, type System } from '$lib/api/systems';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';
import { getProviders, type Provider } from '$lib/api/provider';

export const load = (async ({ params }) => {
	const id = params.id;
	const system: System | undefined = await getSystem(id);
	const status: Status[] = await getStatus();
	const providers: Provider[] = await getProviders();
	if (system && status) {
		return {
			system,
			status,
			providers
		};
	}
	throw redirect(302, '/dashboard/register');
}) satisfies PageServerLoad;

export const actions = {
	default: async ({ request }) => {
		const data = await request.formData();

		data.forEach((value, key) => {
			console.log(key, value);
		});
	}
} satisfies Actions;
