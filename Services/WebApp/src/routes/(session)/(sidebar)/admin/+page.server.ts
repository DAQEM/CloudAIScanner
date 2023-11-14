import AiRegisterAPI from '$lib/api/ai_register';
import { getSystemsByStatus, type System } from '$lib/api/systems';
import clientPromise from '$lib/database/clientPromise';
import { UserDatabase, type User } from '$lib/database/userDatabase';
import type { AISystem, FetchError } from '$lib/types/types';
import type { PageServerLoad } from './$types';

export const load = (async ({ fetch }) => {
	const users: User[] = await (await UserDatabase.fromClient(clientPromise)).getAllUsersLimited(10);
	let pendingSystems: AISystem[] | FetchError = await new AiRegisterAPI(fetch).getAiSystems();

	if ('error' in pendingSystems) {
		return {
			pendingSystems: []
		};
	}

	pendingSystems = pendingSystems.filter((system) => system.approvalStatus?.name?.toLocaleLowerCase() === 'pending').slice(0, 10);

	return {
		users: structuredClone(
			users.map((user) => ({ ...user, _id: user._id?.toString(), userId: user.userId?.toString() }))
		),
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;
