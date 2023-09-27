import type { Handle } from '@sveltejs/kit';
import { Session } from '$lib/types/session';
import { User } from '$lib/types/user';

export const handle: Handle = async ({ event, resolve }) => {
	event.locals.getSession = async () => {
        return Promise.resolve(new Session({
            id: '123',
            user: new User({
                id: '123',
                name: 'John Doe',
                email: 'test@gmail.com',
                roles: ['admin']
            })
        }));
    };
	const response = await resolve(event);
	return response;
};