export class User implements IUser {
	id: string;
	name: string;
	email: string;
	roles: string[];

    constructor({ id, name, email, roles }: { id: string; name: string; email: string; roles: string[] }) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.roles = roles;
    }
}

export interface IUser {
    id: string;
    name: string;
    email: string;
    roles: string[];
}
