<script lang="ts">
	import { setSystemStatusToApproved, setSystemStatusToRejected, type System } from '$lib/api/systems';
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
	import type { PageData } from './$types';

	export let data: PageData;
	const systems = data.systems;

	let filteredItems: System[] = systems;

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

	let showConfirmModal = false;
	let selectedSystem: System | null = null;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-4 md:p-12 gap-4">
	<div class="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-between">
		<div class="flex items-center">
			<h1 class="text-lg md:text-2xl font-bold">AI Register</h1>
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
	<Table hoverable={true} divClass="w-full">
		<TableHead>
			<TableHeadCell>ID</TableHeadCell>
			<TableHeadCell>Name</TableHeadCell>
			<TableHeadCell class="hidden sm:table-cell">Provider</TableHeadCell>
			<TableHeadCell class="hidden md:table-cell">Date</TableHeadCell>
			<TableHeadCell>Status</TableHeadCell>
		</TableHead>
		<TableBody tableBodyClass="divide-y">
			{#each filteredItems as item, i}
				<TableBodyRow class="cursor-pointer" on:click={() => toggleRow(i)}>
					<TableBodyCell>{item.id}</TableBodyCell>
					<TableBodyCell>{item.name}</TableBodyCell>
					<TableBodyCell class="hidden sm:table-cell">{item.provider}</TableBodyCell>
					<TableBodyCell class="hidden md:table-cell">{item.date}</TableBodyCell>
					<TableBodyCell>
						<Button
							color={item.status === 'Approved' ? 'green' : item.status === 'Pending' ? 'yellow' : 'red'}
							class="!rounded-full !overflow-hidden focus:ring-0 bg-opacity-70 text-white"
							size="sm"
						>
							{item.status}
						</Button>
					</TableBodyCell>
				</TableBodyRow>
				{#if openRow === i && selectedSystem?.id === item.id}
					<TableBodyRow on:dblclick={() => (details = item)}>
						<TableBodyCell colspan="5" class="p-0">
							<div class="p-6 grid grid-rows-[max-content,max-content,max-content] lg:grid-cols-[12rem,1fr,1fr] gap-8" transition:slide={{ duration: 300, axis: 'y' }}>
								<div class="flex flex-col gap-8">
									<div class="flex flex-col gap-2">
										<p class="font-bold">Quick Actions</p>
										<div class="grid grid-rows-2 gap-2">
											<div>
												<Button class="w-full" color="primary" href="/dashboard/system/{item.id}">View Details</Button>
											</div>
											<div class="grid grid-cols-2 gap-2">
												<Button class="w-full" color="blue" href="/dashboard/system/{item.id}/edit">Edit</Button>
												<Button class="w-full" color="red" href="/dashboard/system/{item.id}/delete">Delete</Button>
											</div>
										</div>
									</div>
									{#if item.status === 'Pending'}
										<div class="flex flex-col gap-2">
										<p class="font-bold">Status options</p>
										<div class="grid grid-cols-2 gap-2">
											<Button color="green" on:click={async () => {
												await setSystemStatusToApproved(selectedSystem?.id ?? "");
												location.reload();
												}
												}>Approve</Button>
											<Button color="red" on:click={() => showConfirmModal = true}>Reject</Button>
										</div>
									</div>
									{/if}
								</div>
								<div class="whitespace-normal w-full text-justify">
									<h1 class="font-bold">Description</h1>
									<p>{item.description}</p>
								</div>
								<div class="whitespace-normal w-full text-justify">
									<h1 class="font-bold">Description 2</h1>
									<p>{item.description2}</p>
								</div>
							</div>
						</TableBodyCell>
					</TableBodyRow>
				{/if}
			{/each}
		</TableBody>
	</Table>
	<Modal 
		title="Confirm Reject"
		open={showConfirmModal}
		on:close={() => showConfirmModal = false}
	>
		{#if selectedSystem}
		<div transition:slide={{ duration: 150, axis: 'y' }}>
			<div class="flex items-center flex-col gap-4">
				<p>Are you sure you want to reject this system?</p>
				<div class="flex gap-2">
					<p class="font-bold">Name:</p>
					<p>{selectedSystem.name}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Provider:</p>
					<p>{selectedSystem.provider}</p>
				</div>
				<div class="flex gap-2">
					<p class="font-bold">Date:</p>
					<p>{selectedSystem.date}</p>
				</div>
				<div class="flex gap-4">
					<Button color="primary" on:click={async () => {
						await setSystemStatusToRejected(selectedSystem?.id ?? "");
						location.reload();
						}
					}>Yes</Button>
					<Button color="red" on:click={() => showConfirmModal = false}>No</Button>
				</div>
			</div>
		</div>
		{/if}
	</Modal>
</div>
