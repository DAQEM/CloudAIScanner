import { UserDatabase, type User } from '$lib/database/userDatabase';
import { redirect } from '@sveltejs/kit';
import { ObjectId } from 'mongodb';
import type { Actions, PageServerLoad } from './$types';

export const load = (async ({fetch}) => {
	let users: User[] = await (await UserDatabase.get()).getAllUsers();

	return {
		users: structuredClone(
			users.map((user) => ({ ...user, _id: user._id?.toString(), userId: user.userId?.toString() }))
		)
	};
}) satisfies PageServerLoad;

export const actions = {
	remove_role: async ({ request, url }) => {
		const data: FormData = await request.formData();
		const role: string = data.get('role') as string;
		const user_id: string = data.get('user_id') as string;

		await UserDatabase.get().then((userDatabase) => {
			userDatabase.deleteRole(new ObjectId(user_id), role);
		});

		throw redirect(302, url.searchParams.get('redirect_url') || '/admin/users');
	},
	add_role: async ({ request, url }) => {
		const data: FormData = await request.formData();
		const role: string = data.get('role') as string;
		const user_id: string = data.get('user_id') as string;

		await UserDatabase.get().then((userDatabase) => {
			userDatabase.addRole(new ObjectId(user_id), role);
		});

		throw redirect(302, url.searchParams.get('redirect_url') || '/admin/users');
	},
	add_user: async ({ request, url }) => {
		const data: FormData = await request.formData();
		const email: string = data.get('email') as string;
		const roles: string[] = data.getAll('roles') as string[];

		await UserDatabase.get().then((userDatabase) => {
			userDatabase.addUser({ email, roles });
		});

		throw redirect(302, url.searchParams.get('redirect_url') || '/admin/users');
	},
	delete_user: async ({ request, url }) => {
		const data: FormData = await request.formData();
		const user_id: string = data.get('user_id') as string;

		await UserDatabase.get().then((userDatabase) => {
			userDatabase.deleteUser(new ObjectId(user_id));
		});

		throw redirect(302, url.searchParams.get('redirect_url') || '/admin/users');
	}
} satisfies Actions;
