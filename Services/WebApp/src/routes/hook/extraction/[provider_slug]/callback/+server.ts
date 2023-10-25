import { redirect } from '@sveltejs/kit';
import type { RequestHandler } from './$types';
import type { Collection, Db, MongoClient, WithId } from 'mongodb';
import clientPromise from '$lib/database/clientPromise';

export const GET: RequestHandler = async ({ params }) => {
	const provider_slug = params.provider_slug;

	interface Account extends WithId<Document> {
		provider: string;
	}

	const client: MongoClient = await clientPromise;
	const db: Db = client.db('accounts');
	const collection: Collection = db.collection('accounts');
	const regex = /.*-aiextraction/;
	const accounts: Account[] = (await collection
		.find({ provider: { $regex: regex } })
		.toArray()) as Account[];
	for (const account of accounts) {
		await collection.deleteOne({ _id: account._id });
	}

	throw redirect(302, '/dashboard/scan?success=true&provider=' + provider_slug);
};
