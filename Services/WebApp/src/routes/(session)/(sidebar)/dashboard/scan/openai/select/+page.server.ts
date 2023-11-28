import type { OpenAiModel } from '$lib/types/types';
import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';

export const load = (async () => {
    return {};
}) satisfies PageServerLoad;

export const actions: Actions = {
    submit_api_key: async ({ request }) => {
        const data: FormData = await request.formData();

        const api_key: string = data.get('api_key') as string;

        if (api_key === null) {
            throw redirectBack();
        }

        if (isValidApiKey(api_key)) {
            const models: OpenAiModel[] = [
                {
                    id: "davinci",
                    object: "model",
                    created: 1686935002,
                    owned_by: "openai"
                },
                {
                    id: "curie",
                    object: "model",
                    created: 1686935002,
                    owned_by: "openai"
                },
                {
                    id: "babbage",
                    object: "model",
                    created: 1686935002,
                    owned_by: "openai"
                },
                {
                    id: "ada",
                    object: "model",
                    created: 1686935002,
                    owned_by: "openai"
                },
                {
                    id: "cursing-filter-v6",
                    object: "model",
                    created: 1686935002,
                    owned_by: "openai"
                }
            ];
            return { models };
        }
        throw redirectBack();
    }
}

function redirectBack() {
    throw redirect(
        302,
        '/dashboard/scan/openai?error=true'
    );
}

function isValidApiKey(apiKey: string): boolean {
    const regex = new RegExp('^sk-[A-Za-z0-9]{48}$');
    return regex.test(apiKey);
}