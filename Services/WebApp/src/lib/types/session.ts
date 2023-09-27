import type { IUser } from '$lib/types/user';

export class Session implements ISession {
	id: string;
	user: IUser;

	constructor({ id, user }: { id: string; user: IUser }) {
		this.id = id;
		this.user = user;
	}
}

export interface ISession {
	id: string;
	user: IUser;
}
