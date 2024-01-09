<script lang="ts">
	import DeviceTable from '$lib/components/DeviceTable.svelte';
	import ProviderLogo from '$lib/components/ProviderLogo.svelte';
	import type { Provider } from '$lib/types/types';
	import { Button } from 'flowbite-svelte';
	import { EditOutline } from 'flowbite-svelte-icons';
	import type { PageData } from './$types';

	export let data: PageData;

	const provider: Provider = data.provider;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-12">
	<div>
		<div class="flex flex-row items-end gap-4">
			<ProviderLogo {provider} size={250} />
			<div class="flex w-full justify-between mb-2">
				<h1 class="text-4xl font-bold">{provider.name}</h1>
				<div class="flex items-end">
					<Button color="blue" class="h-min" href="/dashboard/provider/{provider.guid}/edit">
						<EditOutline class="w-4 h-4 mr-2" />
						Edit Provider
					</Button>
				</div>
			</div>
		</div>
		<hr class="mt-4 border-primary-400 border-[1px]" />
	</div>

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
