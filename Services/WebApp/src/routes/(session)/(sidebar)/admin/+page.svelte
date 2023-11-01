<script lang="ts">
	import {
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';
	import type { PageData } from './$types';

	export let data: PageData;

	const session = data.session;
	const associatedUser = data.associatedUser;

	const users = data.users;
	const pendingSystems = data.pendingSystems;
</script>

<div class="px-16 py-16">
	<h1 class="text-2xl font-bold">Admin Dashboard</h1>
	<div class="grid lg:grid-cols-2 gap-16">
		<div>
			<h1>Users</h1>
			<Table divClass="rounded-lg overflow-hidden bg">
				<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
					<TableHeadCell><span class="sr-only">Id</span></TableHeadCell>
					<TableHeadCell>Name</TableHeadCell>
					<TableHeadCell>Email</TableHeadCell>
				</TableHead>
				<TableBody tableBodyClass="divide-y">
					{#each users as user}
						<TableBodyRow color="custom" class="bg-gray-900 hover:bg-opacity-50">
							<TableBodyCell>
								<img src={user.image} alt="Profile" class="h-12 w-12 rounded-full" />
							</TableBodyCell>
							<TableBodyCell>
								{user.name}
								{#if user.email === session?.user?.email}
									<span class="ml-1 text-gray-500 dark:text-gray-400"> (You)</span>
								{/if}
							</TableBodyCell>
							<TableBodyCell>
								{user.email}
							</TableBodyCell>
						</TableBodyRow>
					{/each}
				</TableBody>
			</Table>
		</div>
		<div>
			<h1>Pending Systems</h1>
			{#each pendingSystems as system}
				<div>{system.name}</div>
			{/each}
		</div>
	</div>
</div>
