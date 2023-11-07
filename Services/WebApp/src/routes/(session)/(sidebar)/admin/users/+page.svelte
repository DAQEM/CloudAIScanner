<script lang="ts">
	import {
		Button,
		Input,
		Label,
		Modal,
		MultiSelect,
		Select,
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';
	import type { PageData } from './$types';
	import type { Session } from '@auth/core/types';
	import { CloseSolid, PlusSolid, SearchOutline } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';
	import type { User } from '$lib/database/userDatabase';
	import { roles } from '$lib/types/role';

	export let data: PageData;
	const session: Session | null = data.session;
	const associatedUser: User | null = data.associatedUser;
	let users: User[] = data.users;

	let filteredItems: User[] = users;

	let search = '';

	$: filteredItems = users.filter((user) => {
		return Object.values(user).some((value) =>
			value.toString().toLowerCase().includes(search.toLowerCase())
		);
	});

	let openRow: number | null = null;
	let details: any = null;

	const toggleRow = (i: number) => {
		selectedUser = filteredItems[i];
		openRow = openRow === i ? null : i;
	};

	let selectedUser: User | null = null;

	let showRoleModel = false;
	let roleModalUser: User | null = null;

	let showAddUserModel = false;
	let AddUserModelRoles: string[] = ['user'];
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-4 md:p-16 gap-4">
	<div class="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-between">
		<div class="flex items-center">
			<h1 class="text-lg md:text-2xl font-bold">Users</h1>
		</div>
		<div class="flex flex-col md:flex-row gap-4 md:gap-8">
			<div>
				<Input
					size="lg"
					type="text"
					placeholder="Search"
					class="bg-white border-0"
					bind:value={search}
				>
					<SearchOutline slot="right" class="w-4 h-4 text-gray-500 dark:text-gray-400" />
				</Input>
			</div>
			<Button
				color="primary"
				on:click={() => {
					showAddUserModel = true;
				}}
			>
				<PlusSolid class="w-4 h-4 mr-4 text-white" />
				Add New
			</Button>
		</div>
	</div>
	<Table hoverable={true} divClass="rounded-lg overflow-hidden w-full">
		<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
			<TableHeadCell class="hidden sm:table-cell"><span class="sr-only">Id</span></TableHeadCell>
			<TableHeadCell>Name</TableHeadCell>
			<TableHeadCell>Email</TableHeadCell>
		</TableHead>
		<TableBody tableBodyClass="divide-y">
			{#each filteredItems as item, i}
				<TableBodyRow class="cursor-pointer" on:click={() => toggleRow(i)}>
					<TableBodyCell class="hidden sm:table-cell"
						><img src={item.image} alt="Profile" class="h-12 w-12 rounded-full" /></TableBodyCell
					>
					<TableBodyCell
						>{item.name}
						<span class="text-gray-400">{session?.user?.email == item.email ? '(You)' : ''}</span
						></TableBodyCell
					>
					<TableBodyCell>{item.email}</TableBodyCell>
				</TableBodyRow>
				{#if openRow === i && selectedUser?._id === item._id}
					<TableBodyRow on:dblclick={() => (details = item)}>
						<TableBodyCell colspan="5" class="p-0">
							<div
								class="p-6 grid grid-rows-[max-content,max-content,max-content] lg:grid-cols-[12rem,1fr,1fr] gap-8"
								transition:slide={{ duration: 300, axis: 'y' }}
							>
								<Table hoverable divClass="rounded-lg overflow-hidden w-full">
									<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
										<TableHeadCell>Roles</TableHeadCell>
										<TableHeadCell class="flex justify-center px-0">
											{#if roles.filter((role) => !item.roles.includes(role)).length > 0}
												<Button
													color="none"
													class="focus:ring-0 p-0 mr-2"
													on:click={() => {
														showRoleModel = true;
														roleModalUser = item;
													}}
												>
													<PlusSolid class="w-4 h-4 text-white focus:ring-0" />
												</Button>
											{/if}
										</TableHeadCell>
									</TableHead>
									<TableBody>
										{#each item.roles.sort((a, b) => a.localeCompare(b)) as role}
											<TableBodyRow>
												<TableBodyCell>{role[0].toUpperCase() + role.slice(1)}</TableBodyCell>
												<TableBodyCell class="flex justify-center px-0">
													{#if (session?.user?.email !== item.email && role === 'admin') || role !== 'admin'}
														<form method="POST" action="?/remove_role">
															<Input type="hidden" name="role" value={role} />
															<Input type="hidden" name="user_id" value={item._id?.toString()} />
															<Button color="none" type="submit" class="focus:ring-0 p-0 mr-2">
																<CloseSolid
																	class="w-4 h-4 text-primary-500 focus:ring-0 focus:border-0"
																/>
															</Button>
														</form>
													{/if}
												</TableBodyCell>
											</TableBodyRow>
										{/each}
									</TableBody>
								</Table>
							</div>
						</TableBodyCell>
					</TableBodyRow>
				{/if}
			{/each}
		</TableBody>
	</Table>
	<Modal
		class="w-full max-w-md"
		on:close={() => {
			showRoleModel = false;
			roleModalUser = null;
		}}
		open={showRoleModel}
	>
		<Label defaultClass="text-base">Add Role</Label>
		<p class="text-sm !m-0">Adding a role to a user will give them access to the dashboard.</p>
		<form class="flex gap-4" method="POST" action="?/add_role">
			<Select
				required
				name="role"
				items={roles
					.filter((role) => !roleModalUser?.roles.includes(role))
					.map((role) => ({ value: role, name: role[0].toUpperCase() + role.slice(1) }))}
			/>
			<Input type="hidden" name="user_id" value={roleModalUser?._id?.toString()} />
			<Button color="primary" type="submit">Add</Button>
		</form>
	</Modal>
	<Modal
		class="w-full max-w-md"
		on:close={() => {
			showAddUserModel = false;
		}}
		open={showAddUserModel}
	>
		<form
			action="?/add_user"
			method="POST"
			class="space-y-6 flex-1 overflow-y-auto overscroll-contain"
		>
			<Label defaultClass="text-base">Add User</Label>
			<p class="text-sm !m-0">Adding a user will give them access to the dashboard.</p>
			<Label>Email</Label>
			<Input type="email" name="email" required class="!m-0 bg-white" size="lg" />
			<Label>Roles</Label>
			<MultiSelect
				required
				name="roles"
				class="!m-0"
				dropdownClass="text-sm"
				size="lg"
				bind:value={AddUserModelRoles}
				items={roles
					.filter((role) => !roleModalUser?.roles.includes(role))
					.map((role) => ({ value: role, name: role[0].toUpperCase() + role.slice(1) }))}
			/>
			<div class="flex gap-4 w-full">
				<Button
					color="alternative"
					type="button"
					class="flex-1"
					on:click={() => {
						showAddUserModel = false;
					}}>Cancel</Button
				>
				<Button color="primary" type="submit" class="flex-1">Add User</Button>
			</div>
		</form>
	</Modal>
</div>
