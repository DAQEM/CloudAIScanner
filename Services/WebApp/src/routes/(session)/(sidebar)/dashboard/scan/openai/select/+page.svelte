<script lang="ts">
	import type { ActionData } from './$types';
	import {
		Button,
		Checkbox,
		Input,
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';
	import { SearchOutline } from 'flowbite-svelte-icons';
	import type { OpenAiModel } from '$lib/types/types';
	import { writable } from 'svelte/store';

	export let form: ActionData;

	const models: OpenAiModel[] = form?.models ?? [];

	let search = '';

	$: filteredItems = models.filter((model) => {
		return Object.values(model).some((value) =>
			value.toString().toLowerCase().includes(search.toLowerCase())
		);
	});

	let checkedRows = writable<string[]>([]);

	function checkOne(event: Event, id: string) {
		const isChecked: boolean = (event.target as HTMLInputElement).checked;
		if (isChecked) {
			checkedRows.set([...$checkedRows, id]);
		} else {
			checkedRows.set($checkedRows.filter((row) => row !== id));
		}
	}

	function checkAll(event: Event) {
		const isChecked: boolean = (event.target as HTMLInputElement).checked;
		if (isChecked) {
			filteredItems.forEach((model) => {
				if (!$checkedRows.includes(model.id)) checkedRows.set([...$checkedRows, model.id]);
			});
		} else {
			filteredItems.forEach((model) =>
				checkedRows.set($checkedRows.filter((row) => row !== model.id))
			);
		}
	}
</script>

<div class="flex justify-center items-center p-2 pt-20">
	<div class="max-w-7xl w-full">
		<div class="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-between">
			<div class="flex flex-col justify-center">
				<h1 class="text-lg md:text-2xl font-bold">Open AI Models</h1>
				<p>Please select the models you would like to add to the AI register.</p>
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
			</div>
		</div>
		<Table hoverable={true} divClass="rounded-lg overflow-hidden w-full mt-8">
			<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
				<TableHeadCell class="p-0 pl-4 py-2 md:p-4">
					<Checkbox
						id="mainCheckbox"
						on:change={(e) => checkAll(e)}
						checked={filteredItems.length > 0 &&
							filteredItems.every((model) => $checkedRows.includes(model.id))}
					/>
				</TableHeadCell>
				<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Id</TableHeadCell>
				<TableHeadCell class="p-0 md:p-4">Created On</TableHeadCell>
				<TableHeadCell class="p-0 md:p-4">Owner</TableHeadCell>
			</TableHead>
			<TableBody tableBodyClass="divide-y">
				{#each filteredItems as item}
					<TableBodyRow class="cursor-pointer dark:bg-gray-900 md:text-sm text-[10px]">
						<TableBodyCell class="p-0 pl-4 py-2 md:p-4">
							<Checkbox
								id={item.id}
								checked={$checkedRows.includes(item.id)}
								on:change={(e) => checkOne(e, item.id)}
							/>
						</TableBodyCell>
						<TableBodyCell class="p-0 pl-4 py-2 md:p-4">{item.id}</TableBodyCell>
						<TableBodyCell class="p-0 md:p-4">{item.created}</TableBodyCell>
						<TableBodyCell class="p-0 md:p-4">{item.owned_by}</TableBodyCell>
					</TableBodyRow>
				{/each}
			</TableBody>
		</Table>
		<form action="?/submit_models" method="post" class="flex justify-end">
			{#each $checkedRows as selectedModel}
				<input type="hidden" name="models[]" value={selectedModel} />
			{/each}
			{#if $checkedRows.length > 0}
				<Button type="submit" class="mt-4" color="primary">Submit models</Button>
			{/if}
		</form>
	</div>
</div>
