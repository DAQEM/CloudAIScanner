import { redirect } from '@sveltejs/kit';
import type { RequestHandler } from './$types';
import AiExtractionAPI from '$lib/api/ai_extraction';
import AccountsAPI from '$lib/api/accounts';

export const GET: RequestHandler = async ({ params, fetch }) => {
	const provider_slug: string = params.provider_slug.toLowerCase();

	const accountsApi = new AccountsAPI();
	const regex = new RegExp(`${provider_slug}-aiextraction`);
	const accounts = await accountsApi.getAccountsByProvider(regex);
	
	if ('error' in accounts) {
		throw redirectToDashboard();
	}

	for (const account of accounts) {
		if (provider_slug === 'google') {
			await new AiExtractionAPI(fetch).scanGoogleCloud(account.access_token);
		} else {
			throw redirectToDashboard();
		}
		await accountsApi.deleteAccountById(account.id);
	}

	throw redirectToDashboard();
};

function redirectToDashboard() {
	throw redirect(
		302,
		'/dashboard/register'
	);
}
