import constants from '$lib/constants';
import { MongoClient } from 'mongodb';

function getUri() {
	if (constants.isDev) {
		return 'mongodb://root:mongopwd@localhost:8080';
	}
	return 'mongodb://root:mongopwd@account-db:27017';
}

const options = {};

const clientPromise: Promise<MongoClient> = new MongoClient(getUri(), options).connect();

export default clientPromise;
