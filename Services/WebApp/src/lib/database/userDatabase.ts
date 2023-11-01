import { ObjectId } from 'bson';
import type { Collection, Db, MongoClient, WithId } from 'mongodb';

export interface User {
	_id?: ObjectId;
	userId?: ObjectId;
	name?: string;
	email?: string;
	image?: string;
	roles: string[];
}

interface DatabaseUser {
	_id?: ObjectId;
	email: string;
	roles: string[];
}

interface DatabaseAccount {
	_id?: ObjectId;
	name: string;
	email: string;
	image: string;
}

const allRoles = ['admin', 'editor', 'user'];

export class UserDatabase {
	private db: Db;
	private userCollection: Collection<DatabaseUser>;
	private accountCollection: Collection<DatabaseAccount>;

	constructor(db: Db) {
		this.db = db;
		this.userCollection = this.db.collection('added_users');
		this.accountCollection = this.db.collection('users');
	}

	static async fromClient(client: Promise<MongoClient>): Promise<UserDatabase> {
		return new UserDatabase((await client).db("accounts"));
	}

	async addUser(user: DatabaseUser): Promise<User | WithId<User> | null> {
		//check if email is already in use
		await this.userCollection.findOne({ email: user.email }).then((result) => {
			if (result) {
				throw new Error('Email already in use');
			}
		});

		//check if roles are valid
		user.roles.forEach((role) => {
			if (!allRoles.includes(role)) {
				throw new Error('Invalid role ' + role);
			}
		});

		//add user
		return await this.userCollection.insertOne(user).then(async (result) => {
			return await this.userCollection.findOne({ _id: result.insertedId });
		});
	}

	async getUserById(id: string): Promise<User | null> {
		const user = await this.userCollection.findOne({ _id: new ObjectId(id) });
		const account = await this.accountCollection.findOne({ email: user?.email });

		return {
			_id: user?._id,
			userId: account?._id,
			name: account?.name,
			email: account?.email,
			image: account?.image,
			roles: user?.roles || []
		};
	}

	async getUserByEmail(email: string): Promise<User | null> {
		const user = await this.userCollection.findOne({ email });
		const account = await this.accountCollection.findOne({ email });

		return {
			_id: user?._id,
			userId: account?._id,
			name: account?.name,
			email: account?.email,
			image: account?.image,
			roles: user?.roles || []
		};
	}

	async getAllUsers(): Promise<User[]> {
		const users: DatabaseUser[] = await this.userCollection.find().toArray();
		const emails = users.map((user) => user.email);
		const accounts: DatabaseAccount[] = await this.accountCollection.find({ email: { $in: emails } }).toArray();

		return users.map((user) => {
			const account = accounts.find((account) => account.email === user.email);

			return {
				_id: user._id,
				userId: account?._id,
				name: account?.name,
				email: account?.email,
				image: account?.image,
				roles: user.roles
			};
		});
	}

	async getAllUsersLimited(limit: number): Promise<User[]> {
		const users: DatabaseUser[] = await this.userCollection.find().limit(limit).toArray();
		const emails = users.map((user) => user.email);
		const accounts: DatabaseAccount[] = await this.accountCollection.find({ email: { $in: emails } }).toArray();

		return users.map((user) => {
			const account = accounts.find((account) => account.email === user.email);

			return {
				_id: user._id,
				userId: account?._id,
				name: account?.name,
				email: account?.email,
				image: account?.image,
				roles: user.roles
			};
		});
	}

	async updateUser(id: ObjectId, user: DatabaseUser): Promise<DatabaseUser | null> {
		const result = await this.userCollection.findOneAndUpdate(
			{ _id: id },
			{ $set: user },
			{ returnDocument: 'after' }
		);

		return result;
	}

	async deleteUser(id: ObjectId): Promise<boolean> {
		const result = await this.userCollection.findOneAndDelete({ _id: id });
		return !!result;
	}
}
