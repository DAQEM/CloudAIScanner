import clientPromise from '$lib/database/clientPromise';
import { redirect } from '@sveltejs/kit';
import type { Collection, Db, MongoClient, WithId } from 'mongodb';
import type { RequestHandler } from './$types';

const ECONNREFUSED: string = 'ECONNREFUSED';

export const GET: RequestHandler = async ({ params, fetch }) => {
	const provider_slug = params.provider_slug;

	interface Account extends WithId<Document> {
		provider: string;
		access_token: string;
	}

	const client: MongoClient = await clientPromise;
	const db: Db = client.db('accounts');
	const collection: Collection = db.collection('accounts');
	const regex = /.*-aiextraction/;
	const accounts: Account[] = (await collection
		.find({ provider: { $regex: regex } })
		.toArray()) as Account[];
	let result = '';
	for (const account of accounts) {
		var url = 'http://ai-extraction-service:80/api/AiService?';
		if (process.env.NODE_ENV === 'development') {
			url = 'http://localhost:5001/api/AiService?';
		}

		await fetch(url + new URLSearchParams({ accessToken: account.access_token }))
			.then((res) => res.json())
			.then((json) => (result = json.map((item: any) => item.tradeName).join(',')))
			.catch(() => (result = ECONNREFUSED));
		await collection.deleteOne({ _id: account._id });
	}

	// if (result === ECONNREFUSED) {
	// 	throw redirect(
	// 		302,
	// 		'/dashboard/scan?' +
	// 			new URLSearchParams({ success: 'false', provider: provider_slug, data: result })
	// 	);
	// }
	// throw redirect(
	// 	302,
	// 	'/dashboard/scan?' +
	// 		new URLSearchParams({ success: 'true', provider: provider_slug, data: result })
	// );
	throw redirect(
		302,
		'/dashboard/register'
	);
};
