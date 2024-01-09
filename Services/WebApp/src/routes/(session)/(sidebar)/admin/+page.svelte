<script lang="ts">
	import DeviceTable from '$lib/components/DeviceTable.svelte';
	import UserTable from '$lib/components/UserTable.svelte';
	import type { User } from '$lib/database/userDatabase';
	import type { PageData } from './$types';

	export let data: PageData;

	const session = data.session;

	const users: User[] = data.users ?? [];
	const pendingSystems = data.pendingSystems;
</script>

<div class=" p-2 md:p-16">
	<div class="mb-8">
		<h1 class="text-3xl font-bold">Admin Dashboard</h1>
	</div>
	<div class="grid lg:grid-cols-2 gap-16 mt-4">
		<div class="flex flex-col gap-4">
			<DeviceTable
				systems={pendingSystems}
				title="Pending Systems"
				showId={false}
				showStatus={false}
				approvable={true}
			/>
		</div>
		<div class="flex flex-col gap-4">
			<UserTable {users} {session} url="/admin" />
		</div>
	</div>
</div>
