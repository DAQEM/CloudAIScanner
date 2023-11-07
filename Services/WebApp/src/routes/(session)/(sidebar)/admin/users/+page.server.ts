import { UserDatabase, type User } from '$lib/database/userDatabase';
import { ObjectId } from 'mongodb';
import type { Actions, PageServerLoad } from './$types';
import { redirect } from '@sveltejs/kit';

export const load = (async () => {
    let users: User[] = await (await UserDatabase.get()).getAllUsers();

    return {
        users: structuredClone(users.map(user => ({ ...user, _id: user._id?.toString(), userId: user.userId?.toString() })))
    };
}) satisfies PageServerLoad;

export const actions = {
    remove_role: async ({ request }) => {
        const data: FormData = await request.formData();
        const role: string = data.get('role') as string;
        const user_id: string = data.get('user_id') as string;

        await UserDatabase.get().then((userDatabase) => {
            userDatabase.deleteRole(new ObjectId(user_id), role);
        });

        throw redirect(302, '/admin/users');
    },
    add_role: async ({ request }) => {
        const data: FormData = await request.formData();
        const role: string = data.get('role') as string;
        const user_id: string = data.get('user_id') as string;

        await UserDatabase.get().then((userDatabase) => {
            userDatabase.addRole(new ObjectId(user_id), role);
        });

        throw redirect(302, '/admin/users');
    },
    add_user: async ({ request }) => {
        const data: FormData = await request.formData();
        const email: string = data.get('email') as string;
        const roles: string[] = data.getAll('roles') as string[];

        await UserDatabase.get().then((userDatabase) => {
            userDatabase.addUser({ email, roles });
        });

        throw redirect(302, '/admin/users');
    }
} satisfies Actions;