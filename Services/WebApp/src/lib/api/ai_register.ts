import type { AISystem, FetchError, Provider } from '$lib/types/types';

export default class AiRegisterAPI {
	private fetch: typeof fetch;
	private logErrors: boolean;

	constructor(customFetch: typeof fetch, logErrors: boolean = true) {
		this.fetch = customFetch;
		this.logErrors = logErrors;
	}

	getUrl(url: string): string {
		return process.env.NODE_ENV === 'development'
			? `http://localhost:5052/api/${url}`
			: `http://ai-register-service/api/${url}`;
	}

	logError(error: string, err: any) {
		if (this.logErrors) {
			console.log(error, err);
		}
	}

	async getAiSystems(): Promise<AISystem[] | FetchError> {
		return await this.fetch(this.getUrl('AISystem'))
			.then((res) => res.json())
			.then((json) => json as AISystem[])
			.catch((err) => {
				const error = 'Error fetching AI systems';
				this.logError(error, err);
				return { error: error };
			});
	}

	async createProvider(provider: Provider): Promise<Provider | FetchError> {
		return await this.fetch(this.getUrl('Provider'), {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(provider)
		})
			.then((res) => res.json())
			.then((json) => json as Provider)
			.catch((err) => {
				const error = 'Error creating provider';
				this.logError(error, err);
				return { error: error };
			});
	}
}
