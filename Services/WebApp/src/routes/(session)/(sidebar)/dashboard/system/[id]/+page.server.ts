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

export const actions = {
	delete_file: async ({ fetch, request }) => {
		const formData = await request.formData();
		const id = formData.get('fileId') as string;

		await new AiRegisterAPI(fetch).deleteFile(id);
	},
	upload_file: async ({ fetch, request, params: { id } }) => {
		const formData = await request.formData();

		const name = formData.get('name') as string;
		const file = formData.get('file') as File;

		await new AiRegisterAPI(fetch).uploadFile(name, id, file);
	}
};
