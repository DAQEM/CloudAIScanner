<script lang="ts">
	import DeviceTable from '$lib/components/DeviceTable.svelte';
	import type { Provider } from '$lib/types/types';
	import type { PageData } from './$types';
	import google_logo from '$lib/images/icon/google_logo.svg';
	import openai_logo from '$lib/images/icon/openai.svg';

	export let data: PageData;

	const provider: Provider = data.provider;

	interface SupportedProvider {
		name: string;
		image: string;
	}

	const supportedProviders: SupportedProvider[] = [
		{
			name: 'Google Cloud',
			image: google_logo
		},
		{
			name: 'OpenAI',
			image: openai_logo
		}
	];
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-12">
	{#each supportedProviders as supportedProvider}
		{#if supportedProvider.name === provider.name}
			<div>
				<div class="flex flex-row items-end gap-4">
					<img src={supportedProvider.image} class="w-20 h-20" alt={supportedProvider.name} />
					<h1 class="text-4xl font-bold mb-2">{supportedProvider.name}</h1>
				</div>
				<hr class="mt-4 border-primary-400 border-[1px]" />
			</div>
		{/if}
	{/each}

	<div class="grid grid-cols-1 md:grid-cols-2 gap-4">
		<div class="bg-white rounded-xl py-4 px-6">
			<h2 class="text-xl font-bold">Address</h2>
			<p>{provider.address}</p>
		</div>
		<div class="bg-white rounded-xl py-4 px-6">
			<h2 class="text-xl font-bold">Phone Number</h2>
			<p>{provider.phoneNumber}</p>
		</div>
		<div class="bg-white rounded-xl py-4 px-6">
			<h2 class="text-xl font-bold">Email</h2>
			<p>{provider.email}</p>
		</div>
	</div>

	{#if provider.aiSystemDtos}
		<div class="grid gap-4">
			<DeviceTable
				title="AI Systems"
				systems={{
					data: provider.aiSystemDtos,
					page: 1,
					pageSize: provider.aiSystemDtos.length,
					totalPages: 1
				}}
				showPagination={false}
				showCheckboxes={false}
				showActions={false}
			/>
		</div>
	{/if}
</div>
