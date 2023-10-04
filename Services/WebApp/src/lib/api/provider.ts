export type Provider = string;

export const providers: Provider[] = ['Google Cloud', 'AWS', 'Azure', 'OpenAI'];

export const getProviders = async (): Promise<Provider[]> => {
	const response = await fetch(`http://localhost:5050/api/provider`);

	if (response?.ok) {
		const providers: Provider[] = await response.json();
		return providers;
	}

	return [];
};
