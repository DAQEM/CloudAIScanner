import type { RequestHandler } from './$types';

export const GET: RequestHandler = async (res) => {
	console.log(res);
	return new Response();
};
