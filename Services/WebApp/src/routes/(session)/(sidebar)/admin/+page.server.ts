import { getSystemsByStatus, type System } from '$lib/api/systems';
import clientPromise from '$lib/database/clientPromise';
import { UserDatabase, type User } from '$lib/database/userDatabase';
import type { PageServerLoad } from './$types';

export const load = (async () => {
	const users: User[] = await (await UserDatabase.fromClient(clientPromise)).getAllUsersLimited(10);
	const pendingSystems: System[] = await getSystemsByStatus('pending');

	return {
		users: structuredClone(users),
		pendingSystems: structuredClone(pendingSystems)
	};
}) satisfies PageServerLoad;
