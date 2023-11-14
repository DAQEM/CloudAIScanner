import clientPromise from '$lib/database/clientPromise';
import { UserDatabase, type User } from '$lib/database/userDatabase';
import type { Session } from '@auth/core/types';
import type { LayoutServerLoad } from './$types';
import AiRegisterAPI from '$lib/api/ai_register';

/**
 * This is the server-side load function for the layout.
 * It is used to get the session and associated user.
 */

export const load = (async ({ locals, fetch }) => {
	new AiRegisterAPI(fetch).getAiSystems();
	const session = await locals.getSession();
	let associatedUser = await getAssociatedUser(session);

	return {
		session: structuredClone(session),
		associatedUser: structuredClone(associatedUser)
	};
}) satisfies LayoutServerLoad;

// This function is used to get the associated user from the session.
async function getAssociatedUser(session: Session | null): Promise<User | null> {
	if (session === null || !session.user || !session.user.email) {
		return null;
	}

	const userDatabase: UserDatabase = await UserDatabase.fromClient(clientPromise);
	const user: User | null = await userDatabase.getUserByEmail(session.user.email);

	return user;
}
