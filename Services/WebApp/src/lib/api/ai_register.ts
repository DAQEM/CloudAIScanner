import type {
	AISystem,
	AISystemStatus,
	ApprovalStatus,
	FetchError,
	MemberStates,
	Pagination,
	Provider
} from '$lib/types/types';

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
			: `http://ai-register:8080/api/${url}`;
	}

	logError(error: string, err: any) {
		if (this.logErrors) {
			console.error(error, err);
		}
	}

	async getAiSystems(page: number, pageSize: number): Promise<Pagination<AISystem[]> | FetchError> {
		return await this.fetch(
			this.getUrl(
				'AISystem?' + new URLSearchParams({ page: page.toString(), pageSize: pageSize.toString() })
			)
		)
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as Pagination<AISystem[]>)
			.catch((err) => {
				const error = 'Error fetching AI systems';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getAiSystemById(id: string): Promise<AISystem | FetchError> {
		return await this.fetch(this.getUrl(`AISystem/${id}`))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as AISystem)
			.catch((err) => {
				const error = 'Error fetching AI system';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getProviders(): Promise<Provider[] | FetchError> {
		return await this.fetch(this.getUrl('Provider'))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as Provider[])
			.catch((err) => {
				const error = 'Error fetching providers';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getProviderById(id: string): Promise<Provider | FetchError> {
		return await this.fetch(this.getUrl(`Provider/${id}`))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as Provider)
			.catch((err) => {
				const error = 'Error fetching provider';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getApprovalStatuses(): Promise<ApprovalStatus[] | FetchError> {
		return await this.fetch(this.getUrl('ApprovalStatus'))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as ApprovalStatus[])
			.catch((err) => {
				const error = 'Error fetching approval statuses';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getAISystemStatuses(): Promise<AISystemStatus[] | FetchError> {
		return await this.fetch(this.getUrl('AISystemStatus'))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as AISystemStatus[])
			.catch((err) => {
				const error = 'Error fetching AI system statuses';
				this.logError(error, err);
				return { error: error };
			});
	}

	async getMemberStates(): Promise<MemberStates[] | FetchError> {
		return await this.fetch(this.getUrl('MemberState'))
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as MemberStates[])
			.catch((err) => {
				const error = 'Error fetching member states';
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
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as Provider)
			.catch((err) => {
				const error = 'Error creating provider';
				this.logError(error, err);
				return { error: error };
			});
	}

	async editAiSystem(
		id: string,
		name: string,
		status: number,
		description: string,
		url: string,
		technicalDocumentationLink: string,
		memberStates: number
	): Promise<AISystem | FetchError> {
		return await this.fetch(this.getUrl(`AISystem`), {
			method: 'PUT',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				guid: id,
				name: name,
				status: status,
				url: url,
				technicalDocumentationLink: technicalDocumentationLink,
				description: description,
				memberState: memberStates
			})
		})
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as AISystem)
			.catch((err) => {
				const error = 'Error editing AI system';
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
			.then((res) => res.ok ? res.json() : Promise.reject(res))
			.then((json) => json as AISystem)
			.catch((err) => {
				const error = 'Error editing approval status';
				this.logError(error, err);
				return { error: error };
			});
	}

	async deleteAiSystem(id: string): Promise<void> {
		await this.fetch(this.getUrl(`AISystem?id=${id}`), {
			method: 'DELETE'
		})
	}
}
