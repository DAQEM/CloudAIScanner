import type { FetchError, OpenAiModel } from "$lib/types/types";

export default class AiExtractionAPI {
	private fetch: typeof fetch;
	private logErrors: boolean;

	constructor(customFetch: typeof fetch, logErrors: boolean = true) {
		this.fetch = customFetch;
		this.logErrors = logErrors;
	}

	getUrl(url: string): string {
		return process.env.NODE_ENV === 'development'
			? `http://localhost:5001/api/${url}`
			: `http://ai-extraction-service:80/api/${url}`;
	}

	logError(error: string, err: any) {
		if (this.logErrors) {
			console.error(error, err);
		}
	}

    async scanGoogleCloud(accessToken: string): Promise<void | FetchError> {
        await this.fetch(this.getUrl(`GoogleCloud?` + new URLSearchParams({ accessToken: accessToken })))
            .catch((err) => {
                const error = 'Error scanning Google Cloud';
                this.logError(error, err);
            });
    }

    async getAllModels(apiKey: string): Promise<OpenAiModel[] | FetchError> {
        return await this.fetch(this.getUrl(`OpenAi`) + new URLSearchParams({ apiKey: apiKey }))
            .then((res) => res.json())
            .then((json) => json as OpenAiModel[])
            .catch((err) => {
                const error = 'Error fetching OpenAI models';
                this.logError(error, err);
                return { error: error };
            });
    }

    async postSelectedModels(models: OpenAiModel[]): Promise<void | FetchError> {
        await this.fetch(this.getUrl(`OpenAi`), {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(models)
        })
            .catch((err) => {
                const error = 'Error posting OpenAI models';
                this.logError(error, err);
                return { error: error };
            });
    }
}
