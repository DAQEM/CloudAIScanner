<script lang="ts">
	import type { System } from '$lib/api/systems';
	import {
		Button,
		Input,
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';
	import { PlusSolid, SearchOutline } from 'flowbite-svelte-icons';
	import type { PageData } from './$types';
	import { slide } from 'svelte/transition';

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
		openRow = openRow === i ? null : i;
	};
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
							class="!rounded-full !overflow-hidden {item.status === 'Approved'
								? 'bg-[#3A974C] text-[#3A974C] hover:bg-[#3A974C] hover:text-[#3A974C] dark:bg-[#3A974C]'
								: 'bg-[#F29339] text-[#F29339] hover:bg-[#F29339] hover:text-[#F29339] dark:bg-[#F29339]'} bg-opacity-10 hover:bg-opacity-10 dark:bg-opacity-10 focus:ring-0"
							size="sm"
						>
							{item.status}
						</Button>
					</TableBodyCell>
				</TableBodyRow>
				{#if openRow === i}
					<TableBodyRow on:dblclick={() => (details = item)}>
						<TableBodyCell colspan="5" class="p-4">
							<div class="px-2 py-3" transition:slide={{ duration: 300, axis: 'y' }}>
								<div class="flex flex-col gap-2">
									<p class="font-bold">Quick Actions</p>
									<div class="flex gap-2">
										<Button color="primary" href="/dashboard/system/{item.id}">View Details</Button>
										<Button color="blue" href="/dashboard/system/{item.id}/edit">Edit</Button>
										<Button color="red" href="/dashboard/system/{item.id}/delete">Delete</Button>
									</div>
								</div>
							</div>
						</TableBodyCell>
					</TableBodyRow>
				{/if}
			{/each}
		</TableBody>
	</Table>
</div>
