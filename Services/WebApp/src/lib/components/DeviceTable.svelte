<script lang="ts">
	import type { AISystem, Pagination } from '$lib/types/types';
	import {
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

	export let systems: Pagination<AISystem[]>;
	export let title: string = 'AI Register';
	export let showId: boolean = true;
	export let showStatus: boolean = true;
	export let approvable: boolean = false;

	const page = systems.page;
	let pageSize = systems.pageSize;
	const totalPages = systems.totalPages;

	let filteredItems: AISystem[] = systems.data;

	let search = '';

	$: filteredItems = systems.data.filter((system) => {
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

	function pages(): Array<number> {
		if (totalPages <= 5) {
			return Array.from({ length: totalPages }, (x, i) => i + 1);
		} else {
			if (page <= 2) {
				return [1, 2, 3, 4, totalPages];
			} else if (page >= totalPages - 2) {
				return [1, totalPages - 3, totalPages - 2, totalPages - 1, totalPages];
			} else {
				return [1, page - 1, page, page + 1, totalPages];
			}
		}
	}
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
		{#if showId}
			<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Unambiguous Reference</TableHeadCell>
		{/if}
		<TableHeadCell class="p-0 md:p-4">Name</TableHeadCell>
		<TableHeadCell class="hidden sm:table-cell p-0 md:p-4">Provider</TableHeadCell>
		<TableHeadCell class="hidden md:table-cell p-0 md:p-4">Date</TableHeadCell>
		{#if showStatus}
			<TableHeadCell class="p-0 md:p-4">Status</TableHeadCell>
		{/if}
	</TableHead>
	<TableBody tableBodyClass="divide-y">
		{#each filteredItems as item, i}
			<TableBodyRow
				class="cursor-pointer md:text-sm text-[10px] dark:bg-gray-900"
				on:click={() => toggleRow(i)}
			>
				{#if showId}
					<TableBodyCell class="max-w-xs">{item.unambiguousReference}</TableBodyCell>
				{/if}
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
<section class="flex justify-center gap-8">
	<nav aria-label="Page navigation">
		<ul
			class="inline-flex -space-x-px items-center border-[1px] border-gray-200 dark:border-gray-800 bg-white dark:bg-gray-900 rounded-lg"
		>
			{#if page - 1 > 0}
				<li class="w-28 h-10 flex justify-center items-center">
					<a href={'?page=' + (page - 1).toString() + '&pageSize=' + pageSize} data-sveltekit-reload
						>Previous</a
					>
				</li>
			{/if}
			{#each pages() as pge}
				<li
					class="w-10 h-10 border-x-[1px] border-gray-200 dark:border-gray-800 flex justify-center items-center"
				>
					<a href={'?page=' + pge + '&pageSize=' + pageSize} data-sveltekit-reload>{pge}</a>
				</li>
			{/each}
			{#if page + 1 <= totalPages}
				<li class="w-28 h-10 flex justify-center items-center">
					<a href={'?page=' + (page + 1).toString() + '&pageSize=' + pageSize} data-sveltekit-reload
						>Next</a
					>
				</li>
			{/if}
		</ul>
	</nav>
	<div class="flex gap-4">
		<div
			class="h-10 flex gap-4 justify-center items-center bg-white dark:bg-gray-900 rounded-lg border-[1px] border-gray-200 dark:border-gray-800 py-2"
		>
			<div class="h-10 border-r-[1px] border-gray-200 dark:border-gray-800 flex items-center">
				<p class="px-4">Page size:</p>
			</div>
			<input
				type="number"
				min="20"
				max="500"
				bind:value={pageSize}
				class="border-none h-8 focus:ring-0 p-0 w-12 dark:bg-gray-900"
			/>
		</div>
		<Button color="primary" href={'?page=' + page + '&pageSize=' + pageSize} data-sveltekit-reload>
			Apply
		</Button>
	</div>
</section>
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
