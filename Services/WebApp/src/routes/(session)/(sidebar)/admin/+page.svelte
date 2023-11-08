<script lang="ts">
	import UserTable from '$lib/components/UserTable.svelte';
	import type { PageData } from './$types';

	export let data: PageData;

	const session = data.session;
	const associatedUser = data.associatedUser;

	const users = data.users;
	const pendingSystems = data.pendingSystems;
</script>

<div class=" p-2 md:p-16">
	<h1 class="text-2xl font-bold">Admin Dashboard</h1>
	<div class="grid lg:grid-cols-2 gap-16 mt-4">
		<div>
			<h1>Pending Systems</h1>
			{#each pendingSystems as system}
				<div>{system.name}</div>
			{/each}
		</div>
		<div class="flex flex-col gap-4">
			<UserTable {users} {session} {associatedUser} url="/admin" />
		</div>
	</div>
</div>
