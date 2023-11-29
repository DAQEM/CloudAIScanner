import clientPromise from "$lib/database/clientPromise";
import type { Account, FetchError } from "$lib/types/types";
import { ObjectId, type Collection, type WithId } from "mongodb";

export default class AccountsAPI {
    private logErrors: boolean;

    constructor(logErrors: boolean = true) {
        this.logErrors = logErrors;
    }

    private logError(error: string, err: any) {
        if (this.logErrors) {
            console.error(error, err);
        }
    }

    private async getCollection(): Promise<Collection> {
        const client = await clientPromise;
        const db = client.db("accounts");
        return db.collection("accounts");
    }

    async getAccountsByProvider(regex: RegExp): Promise<Account[] | FetchError> {
        const collection = await this.getCollection();

        return await collection
            .find({ provider: { $regex: regex } })
            .map((account) => {
                return {
                    id: account._id.toString(),
                    access_token: account.access_token,
                };
            })
            .toArray()
            .catch((err) => {
                const error = "Error fetching accounts";
                this.logError(error, err);
                return { error: error };
            });
    }

    async deleteAccountById(id: string): Promise<void | FetchError> {
        const collection = await this.getCollection();

        await collection.deleteOne({ _id: new ObjectId(id) }).catch((err) => {
            const error = "Error deleting account";
            this.logError(error, err);
            return { error: error };
        });
    }
}
