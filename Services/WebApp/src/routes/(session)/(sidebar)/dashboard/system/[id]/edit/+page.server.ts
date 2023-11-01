import { getProviders, type Provider } from '$lib/api/provider';
import { getStatus, type Status } from '$lib/api/status';
import { editSystem, getSystem, type System } from '$lib/api/systems';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

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
