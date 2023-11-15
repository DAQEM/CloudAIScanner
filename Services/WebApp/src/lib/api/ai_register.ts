import type { AISystem, ApprovalStatus, FetchError, Pagination, Provider } from '$lib/types/types';

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

	async getAiSystems(page: number, pageSize: number): Promise<Pagination<AISystem[]> | FetchError> {
		return await this.fetch(
			this.getUrl(
				'AISystem?' + new URLSearchParams({ page: page.toString(), pageSize: pageSize.toString() })
			)
		)
			.then((res) => res.json())
			.then((json) => json as Pagination<AISystem[]>)
			.catch((err) => {
				const error = 'Error fetching AI systems';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getAiSystemById(id: string): Promise<AISystem | FetchError> {
		return await this.fetch(this.getUrl(`AISystem/${id}`))
			.then((res) => res.json())
			.then((json) => json as AISystem)
			.catch((err) => {
				const error = 'Error fetching AI system';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getProviders(): Promise<Provider[] | FetchError> {
		return await this.fetch(this.getUrl('Provider'))
			.then((res) => res.json())
			.then((json) => json as Provider[])
			.catch((err) => {
				const error = 'Error fetching providers';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getApprovalStatuses(): Promise<ApprovalStatus[] | FetchError> {
		return await this.fetch(this.getUrl('ApprovalStatus'))
			.then((res) => res.json())
			.then((json) => json as ApprovalStatus[])
			.catch((err) => {
				const error = 'Error fetching approval statuses';
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

	async editApprovalStatus(id: string, approvalStatus: number): Promise<AISystem | FetchError> {
		return await this.fetch(this.getUrl(`AISystem`), {
			method: 'PUT',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				guid: id,
				approvalStatus: approvalStatus
			})
		})
			.then((res) => res.json())
			.then((json) => json as AISystem)
			.catch((err) => {
				const error = 'Error editing approval status';
				this.logError(error, err);
				return { error: error };
			});
	}
}
