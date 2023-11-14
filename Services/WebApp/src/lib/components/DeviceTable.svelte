<script lang="ts">
	import AiRegisterAPI from '$lib/api/ai_register';
	import { setSystemStatusToApproved, setSystemStatusToRejected } from '$lib/api/systems';
	import type { AISystem } from '$lib/types/types';
	import {
		A,
		Button,
		Input,
		Modal,
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';
	import { PlusSolid, SearchOutline } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';

	export let systems: AISystem[];
	export let title: string = 'AI Register';
	export let showStatus: boolean = true;
	export let approvable: boolean = false;

	let filteredItems: AISystem[] = systems;

	let search = '';

	$: filteredItems = systems.filter((system) => {
		return Object.values(system).some((value) =>
			value.toString().toLowerCase().includes(search.toLowerCase())
		);
	});

	let openRow: number | null = null;
	let details: any = null;

	const toggleRow = (i: number) => {
		selectedSystem = filteredItems[i];
		openRow = openRow === i ? null : i;
	};

	let showRejectModal = false;
	let showApproveModal = false;
	let selectedSystem: AISystem | null = null;
</script>

<div class="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-between">
	<div class="flex items-center">
		<h1 class="text-lg md:text-2xl font-bold">{title}</h1>
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
		<Button href="/dashboard/scan" color="primary">
			<PlusSolid class="w-4 h-4 mr-4 text-white" />
			Add New
		</Button>
	</div>
</div>
<Table hoverable={true} divClass="rounded-lg overflow-hidden w-full">
	<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4">ID</TableHeadCell>
		<TableHeadCell class="p-0 md:p-4">Name</TableHeadCell>
		<TableHeadCell class="hidden sm:table-cell p-0 md:p-4">Provider</TableHeadCell>
		<TableHeadCell class="hidden md:table-cell p-0 md:p-4">Date</TableHeadCell>
		{#if showStatus}
			<TableHeadCell class="p-0 md:p-4">Status</TableHeadCell>
		{/if}
	</TableHead>
	<TableBody tableBodyClass="divide-y">
		{#each filteredItems as item, i}
			<TableBodyRow class="cursor-pointer md:text-sm text-[10px]" on:click={() => toggleRow(i)}>
				<TableBodyCell>{item.id}</TableBodyCell>
				<TableBodyCell>{item.name}</TableBodyCell>
				<TableBodyCell class="hidden sm:table-cell">{item.provider?.name}</TableBodyCell>
				<TableBodyCell class="hidden md:table-cell">{item.dateAdded}</TableBodyCell>
				{#if showStatus}
					<TableBodyCell>
						<Button
							color={item.approvalStatus?.name?.toLowerCase() === 'approved'
								? 'green'
								: item.approvalStatus?.name?.toLowerCase() === 'pending'
								? 'yellow'
								: 'red'}
							class="!rounded-full !overflow-hidden focus:ring-0 bg-opacity-70 text-white"
							size="sm"
						>
							{item.approvalStatus?.name}
						</Button>
					</TableBodyCell>
				{/if}
			</TableBodyRow>
			{#if openRow === i && selectedSystem?.id === item.id}
				<TableBodyRow on:dblclick={() => (details = item)}>
					<TableBodyCell colspan="5" class="p-0">
						<div
							class="p-6 grid grid-rows-[max-content,max-content,max-content] lg:grid-cols-[12rem,1fr,1fr] gap-8"
							transition:slide={{ duration: 300, axis: 'y' }}
						>
							<div class="flex flex-col gap-8">
								<div class="flex flex-col gap-2">
									<p class="font-bold">Quick Actions</p>
									<div class="grid grid-rows-2 gap-2">
										<div>
											<Button class="w-full" color="primary" href="/dashboard/system/{item.id}"
												>View Details</Button
											>
										</div>
										<div class="grid grid-cols-2 gap-2">
											<Button class="w-full" color="blue" href="/dashboard/system/{item.id}/edit"
												>Edit</Button
											>
											<Button class="w-full" color="red" href="/dashboard/system/{item.id}/delete"
												>Delete</Button
											>
										</div>
									</div>
								</div>
								{#if item.approvalStatus?.name === 'Pending' && approvable}
									<div class="flex flex-col gap-2">
										<p class="font-bold">Status options</p>
										<div class="grid grid-cols-2 gap-2">
											<Button color="green" on:click={() => (showApproveModal = true)}
												>Approve</Button
											>
											<Button color="red" on:click={() => (showRejectModal = true)}>Reject</Button>
										</div>
									</div>
								{/if}
							</div>
							<div class="whitespace-normal w-full text-justify">
								<h1 class="font-bold">Description</h1>
								<p>
									{item.description === undefined ||
									item.description === '' ||
									item.description === null
										? `No description provided by ${item.provider?.name}.`
										: item.description}
								</p>
							</div>
							<div class="whitespace-normal w-full text-justify">
								<h1 class="font-bold">More usefull information</h1>
								<p>
									Lorem ipsum dolor sit, amet consectetur adipisicing elit. Velit autem illum eum
									pariatur cupiditate omnis qui quaerat quidem blanditiis porro perferendis nisi,
									excepturi amet! Perferendis ipsum magnam voluptatum dolorem quaerat.
								</p>
							</div>
						</div>
					</TableBodyCell>
				</TableBodyRow>
			{/if}
		{:else}
			<TableBodyRow>
				<TableBodyCell colspan="50">
					<p class="text-center text-base">No systems found.</p>
				</TableBodyCell>
			</TableBodyRow>
		{/each}
	</TableBody>
</Table>
<Modal title="Confirm Reject" open={showRejectModal} on:close={() => (showRejectModal = false)}>
	{#if selectedSystem}
		<div transition:slide={{ duration: 150, axis: 'y' }}>
			<form class="flex items-center flex-col gap-4" method="POST" action="/admin/approval?/reject">
				<p>Are you sure you want to reject this system?</p>
				<Input type="hidden" name="id" bind:value={selectedSystem.id} />
				<div class="flex gap-2">
					<p class="font-bold">Name:</p>
					<p>{selectedSystem.name}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Provider:</p>
					<p>{selectedSystem.provider?.name}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Date:</p>
					<p>{selectedSystem.dateAdded}</p>
				</div>
				<div class="flex gap-4">
					<Button color="primary" type="submit">Yes</Button>
					<Button color="red" on:click={() => (showRejectModal = false)}>No</Button>
				</div>
			</form>
		</div>
	{/if}
</Modal>
<Modal title="Confirm Reject" open={showApproveModal} on:close={() => (showApproveModal = false)}>
	{#if selectedSystem}
		<div transition:slide={{ duration: 150, axis: 'y' }}>
			<form
				class="flex items-center flex-col gap-4"
				method="POST"
				action="/admin/approval?/approve"
			>
				<p>Are you sure you want to approve this system?</p>
				<Input type="hidden" name="id" bind:value={selectedSystem.id} />
				<div class="flex gap-2">
					<p class="font-bold">Name:</p>
					<p>{selectedSystem.name}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Provider:</p>
					<p>{selectedSystem.provider?.name}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Date:</p>
					<p>{selectedSystem.dateAdded}</p>
				</div>
				<div class="flex gap-4">
					<Button color="primary" type="submit">Yes</Button>
					<Button color="red" on:click={() => (showApproveModal = false)}>No</Button>
				</div>
			</form>
		</div>
	{/if}
</Modal>
