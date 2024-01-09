<script lang="ts">
	import FileCard from '$lib/components/FileCard.svelte';
	import ProviderLogo from '$lib/components/ProviderLogo.svelte';
	import type { AISystem } from '$lib/types/types';
	import { A, Button, Fileupload, Input, Label, Modal } from 'flowbite-svelte';
	import {
		ArrowRightOutline,
		EditOutline,
		FileCirclePlusOutline,
		TrashBinSolid
	} from 'flowbite-svelte-icons';
	import type { PageData } from './$types';

	export let data: PageData;
	const system: AISystem = data.system;

	let showUploadModal: boolean = false;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-4">
	<div class="flex gap-8 bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
		<div class="flex justify-center items-center">
			{#if system.provider}
				<ProviderLogo provider={system.provider} size={320} />
			{/if}
		</div>
		<div class="flex w-full justify-between">
			<div class="flex flex-col justify-between my-2">
				<h1 class="text-4xl font-bold flex items-center gap-8">
					{system.name}
					<span
						class="text-2xl font-normal px-4 py-2 rounded-full bg-opacity-75 {system.approvalStatus
							?.id === 1
							? 'bg-green-500'
							: system.approvalStatus?.id === 2
							? 'bg-yellow-500'
							: 'bg-red-500'} }}">{system.approvalStatus?.name}</span
					>
				</h1>
				<div class="flex flex-col justify-between">
					<p class="text-xl">{system.provider?.name}</p>
					<p class="text-lg">
						<span class="font-bold">Scanned on:</span>
						<span>{system.dateAdded}</span>
					</p>
				</div>
			</div>
			<div class="flex items-end gap-4">
				<Button color="blue" class="h-min" href="/dashboard/system/{system.guid}/edit">
					<EditOutline class="w-4 h-4 mr-2" />
					Edit System
				</Button>

				<form method="POST" action="/dashboard/register?/delete">
					<Input type="hidden" name="id" bind:value={system.guid} />
					<Button color="red" class="h-min" type="submit">
						<TrashBinSolid class="w-4 h-4 mr-2" />
						Delete System
					</Button>
				</form>
			</div>
		</div>
	</div>

	<div class="grid gap-4">
		<div class="bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
			<h2 class="font-bold text-xl">Description:</h2>
			<p>
				{system.description === '' ||
				system.description === null ||
				system.description === undefined
					? `No description provided by ${system.provider?.name}.`
					: system.description}
			</p>
		</div>
		<div class="bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
			<h2 class="font-bold text-2xl">Provider</h2>
			<div class="grid grid-cols-1 md:grid-cols-2">
				<div class="p-2">
					<h2 class="font-bold">Name</h2>
					<p>{system.provider?.name}</p>
				</div>
				<div class="p-2">
					<h2 class="font-bold">Address</h2>
					<p>{system.provider?.address}</p>
				</div>
				<div class="p-2">
					<h2 class="font-bold">Email</h2>
					<p>{system.provider?.email}</p>
				</div>
				<div class="p-2">
					<h2 class="font-bold">Phone Number</h2>
					<p>{system.provider?.phoneNumber}</p>
				</div>
			</div>
			<div class="flex justify-end">
				<Button href={`/dashboard/provider/${system.provider?.guid}`} color="primary">
					<ArrowRightOutline class="mr-2 w-4 h-4" />
					More Info
				</Button>
			</div>
		</div>
		<div class="bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
			<div class="flex justify-between">
				<h2 class="font-bold text-xl">Attached Files</h2>
				<Button color="primary" on:click={() => (showUploadModal = true)}>
					<FileCirclePlusOutline class="mr-2 w-4 h-4" />
					Add File
				</Button>
			</div>
			<div class="my-4 grid gap-4">
				{#each system.files ?? [] as file}
					<FileCard {file} systemId={system.guid ?? '1'} />
				{:else}
					<p>There are currently no files attached to this system.</p>
				{/each}
			</div>
		</div>
		<div class="bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
			<h2 class="font-bold text-xl">Certificate:</h2>
			<div>
				<p>Type: {system.certificate?.type}</p>
				<p>Notified Body: {system.certificate?.nameNotifiedBody}</p>
				<p>number: {system.certificate?.number}</p>
				<p>
					Expiry Date: {new Date(system.certificate?.expiryDate ?? 0).toLocaleDateString('en-us', {
						year: 'numeric',
						month: 'long',
						day: 'numeric'
					})}
				</p>
			</div>
		</div>
		<div class="bg-white dark:bg-gray-900 py-4 px-8 rounded-xl">
			<h2 class="font-bold text-xl">Additional:</h2>
			<div>
				<p>Link: <A href={system.url}>Click Here</A></p>
				<p>Technical Documentation: <A href={system.technicalDocumentationLink}>Click Here</A></p>
				<p>Member States: {system.memberState?.name}</p>
			</div>
		</div>
	</div>
</div>
<Modal title="Upload File" open={showUploadModal} on:close={() => (showUploadModal = false)}>
	<form action="?/upload_file" method="post" class="grid gap-4" enctype="multipart/form-data">
		<div>
			<Label for="name" class="font-bold ml-1">File description*</Label>
			<Input type="text" name="name" placeholder="File description" required />
		</div>
		<div>
			<Label for="file" class="font-bold ml-1">File*</Label>
			<Fileupload
				type="file"
				name="file"
				accept=".jpg, .jpeg, .png, .pdf, .txt, .doc, .docx, .docm, .xls, .xlsx, .xlsm, .ppt, .pptx, .pptm"
				required
			/>
		</div>
		<div class="flex justify-end">
			<Button type="submit" color="primary" class="mt-4">Upload</Button>
		</div>
	</form>
</Modal>
