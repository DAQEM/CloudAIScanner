<script lang="ts">
	import google_logo from '$lib/images/icon/google_logo.svg';
	import openai_logo from '$lib/images/icon/openai.svg';
	import azure_logo from '$lib/images/icon/azure.png';
	import aws_logo from '$lib/images/icon/aws.png';
	import { goto } from '$app/navigation';
	import type { Provider } from '$lib/types/types';
	import {
		Table,
		TableBody,
		TableBodyCell,
		TableBodyRow,
		TableHead,
		TableHeadCell
	} from 'flowbite-svelte';

	export let providers: Provider[];

	function getImage(name: string): string {
		if (name === 'Google Cloud') {
			return google_logo;
		}
		if (name === 'OpenAI') {
			return openai_logo;
		}
		if (name === 'Azure') {
			return azure_logo;
		}
		if (name === 'AWS') {
			return aws_logo;
		}
		return '';
	}
</script>

<div class="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-between">
	<div class="flex items-center">
		<h1 class="text-lg md:text-2xl font-bold">Providers</h1>
	</div>
</div>
<Table hoverable={true} divClass="rounded-lg overflow-hidden w-full">
	<TableHead class="text-white dark:text-white bg-primary-500 dark:bg-primary-600">
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4"><span class="sr-only">Logo</span></TableHeadCell>
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Name</TableHeadCell>
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Address</TableHeadCell>
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Email</TableHeadCell>
		<TableHeadCell class="p-0 pl-4 py-2 md:p-4">Phone Number</TableHeadCell>
	</TableHead>
	<TableBody tableBodyClass="divide-y">
		{#each providers as provider}
			<TableBodyRow
				class="cursor-pointer dark:bg-gray-900 md:text-sm text-[10px]"
				on:click={() => goto(`/dashboard/provider/${provider.guid}`)}
			>
				<TableBodyCell class="p-0 pl-4 py-2 md:p-4">
					<img
						src={getImage(provider.name || '')}
						alt={provider.name}
						class="w-8 h-8 md:w-12 md:h-12"
					/>
				</TableBodyCell>
				<TableBodyCell class="p-0 pl-4 py-2 md:p-4">{provider.name}</TableBodyCell>
				<TableBodyCell class="p-0 pl-4 py-2 md:p-4">{provider.address}</TableBodyCell>
				<TableBodyCell class="p-0 pl-4 py-2 md:p-4">{provider.email}</TableBodyCell>
				<TableBodyCell class="p-0 pl-4 py-2 md:p-4">{provider.phoneNumber}</TableBodyCell>
			</TableBodyRow>
		{/each}
	</TableBody>
</Table>
