import AiExtractionAPI from '$lib/api/ai_extraction';
import type { FetchError, OpenAiModel } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions } from './$types';

export const actions: Actions = {
	submit_api_key: async ({ request, fetch }) => {
		const data: FormData = await request.formData();

		const api_key: string = data.get('api_key') as string;

		if (api_key === null) {
			throw redirectBack();
		}

		if (isValidApiKey(api_key)) {
			const models: OpenAiModel[] | FetchError = await new AiExtractionAPI(
				fetch
			).getAllOpenAIModels(api_key);

			if ('error' in models) {
				throw redirectBack();
			}

			return { models };
		}
		throw redirectBack();
	},
    submit_models: async ({ request, fetch }) => {
        const data: FormData = await request.formData();
        const modelIds = data.getAll('models[]');
        let models: OpenAiModel[] = [];

        modelIds.forEach((model) => {
            const id: string = model as string;
            models.push({ 
                id: id,
                object: data.get(`${id}.object`) as string,
                created: parseInt(data.get(`${id}.created`) as string),
                owned_by: data.get(`${id}.owned_by`) as string
            });
        });

        await new AiExtractionAPI(fetch).postSelectedOpenAIModels(models);
        throw redirect(302, '/dashboard/register');
    }
};

function redirectBack() {
	throw redirect(302, '/dashboard/scan/openai?error=true');
}

function isValidApiKey(apiKey: string): boolean {
	const regex = new RegExp('^sk-[A-Za-z0-9]{48}$');
	return regex.test(apiKey);
}
