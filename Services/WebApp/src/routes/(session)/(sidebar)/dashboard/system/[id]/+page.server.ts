import { getSystem, type System } from "$lib/api/systems";
import { redirect } from "@sveltejs/kit";
import type { PageServerLoad } from "./$types";
import { status } from "$lib/api/status";

export const load = (async ({ params }) => {
	const id = params.id;
	const system: System | undefined = await getSystem(id);
	if (system && status) {
		return {
			system
		};
	}
	throw redirect(302, '/dashboard/register');
}) satisfies PageServerLoad;
