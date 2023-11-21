<script lang="ts">
	import google_logo from '$lib/images/icon/google_logo.svg';
	import openai_logo from '$lib/images/icon/openai.svg';
	import azure_logo from '$lib/images/icon/azure.png';
	import aws_logo from '$lib/images/icon/aws.png';
	import type { AISystem } from '$lib/types/types';
	import type { PageData } from './$types';
	import { A } from 'flowbite-svelte';

	export let data: PageData;
	const system: AISystem = data.system;

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

<div class="p-12">
	<div class="flex flex-col gap-8 p-8 bg-white dark:bg-gray-900 rounded-xl">
		<div class="flex gap-8">
			<div class="w-32 h-32">
				<img
					src={getImage(system.provider?.name ?? '')}
					alt={system.provider?.name}
					class="w-32 h-32"
				/>
			</div>
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
			<div></div>
		</div>

		<div class="grid gap-8">
			<div>
				<h2 class="font-bold text-xl">Description:</h2>
				<p>
					{system.description === '' ||
					system.description === null ||
					system.description === undefined
						? `No description provided by ${system.provider?.name}.`
						: system.description}
				</p>
			</div>
			<div>
				<h2 class="font-bold text-xl">Provider:</h2>
				<div>
					<p>Name: {system.provider?.name}</p>
					<p>Address: {system.provider?.address}</p>
					<p>Email: {system.provider?.email}</p>
					<p>Phone: {system.provider?.phoneNumber}</p>
				</div>
			</div>
			<div>
				<h2 class="font-bold text-xl">Certificate:</h2>
				<div>
					<p>Type: {system.certificate?.type}</p>
					<p>Notified Body: {system.certificate?.nameNotifiedBody}</p>
					<p>number: {system.certificate?.number}</p>
					<p>
						Expiry Date: {new Date(system.certificate?.expiryDate ?? 0).toLocaleDateString(
							'en-us',
							{
								year: 'numeric',
								month: 'long',
								day: 'numeric'
							}
						)}
					</p>
				</div>
			</div>
			<div>
				<h2 class="font-bold text-xl">Additional:</h2>
				<div>
					<p>Link: <A href={system.url}>Click Here</A></p>
					<p>Technical Documentation: <A href={system.technicalDocumentationLink}>Click Here</A></p>
					<p>Member States: {system.memberState?.name}</p>
				</div>
			</div>
		</div>
	</div>
</div>
