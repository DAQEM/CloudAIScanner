import AiRegisterAPI from '$lib/api/ai_register';
import clientPromise from '$lib/database/clientPromise';
import { UserDatabase, type User } from '$lib/database/userDatabase';
import type { AISystem, FetchError, Pagination } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch, url: { searchParams } }) => {
	const page: string | null = searchParams.get('page');
	const pageSize: string | null = searchParams.get('pageSize');

	const pageInt: number = page ? parseInt(page) : 1;
	const pageSizeInt: number = pageSize ? parseInt(pageSize) : 20;
	
	const users: User[] = await (await UserDatabase.fromClient(clientPromise)).getAllUsersLimited(10);
	let pendingSystems: Pagination<AISystem[]> | FetchError = await new AiRegisterAPI(fetch).getAiSystems(pageInt, pageSizeInt);

	if ('error' in pendingSystems) {
		return {
			pendingSystems: {
				data: [],
				page: 1,
				pageSize: 20,
				totalPages: 1
			}
		};
	}

	pendingSystems.data = pendingSystems.data.filter((system) => system.approvalStatus?.name?.toLocaleLowerCase() === 'pending').slice(0, 10);

	return {
		users: structuredClone(
			users.map((user) => ({ ...user, _id: user._id?.toString(), userId: user.userId?.toString() }))
		),
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;
