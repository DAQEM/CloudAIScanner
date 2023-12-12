<script lang="ts">
	import AiRegisterAPI from '$lib/api/ai_register';
	import type { File } from '$lib/types/types';
	import { Button, Card, Input } from 'flowbite-svelte';
	import {
		CloseSolid,
		DownloadSolid,
		FileCsvSolid,
		FileLinesSolid,
		FilePdfSolid,
		FilePowerpointSolid,
		FileSolid,
		FileWordpressSolid,
		ImageSolid
	} from 'flowbite-svelte-icons';

	export let systemId: string;
	export let file: File;

	const imageExtensions: string[] = ['png', 'jpg', 'jpeg', 'gif', 'svg'];
	const csvExtensions: string[] = ['csv', 'xls', 'xlsx', 'xlsm'];
	const powerpointExtensions: string[] = ['ppt', 'pptx', 'pptm'];
	const wordExtensions: string[] = ['docx', 'doc', 'docm'];
	const pdfExtensions: string[] = ['pdf'];
	const txtExtensions: string[] = ['txt'];

	function getFileName(): string {
		let path: string = file.filepath ?? '';
		let pathArray: string[] = path.split('/');
		return pathArray[pathArray.length - 1];
	}

	function getFileExtension(): string {
		let fileName: string = getFileName();
		let fileNameArray: string[] = fileName.split('.');
		return fileNameArray[fileNameArray.length - 1];
	}

	async function downloadData() {
		const fileId = file.guid;
		if (fileId) {
			const response = await new AiRegisterAPI(fetch).downloadFile(fileId);
			const blob = await response.blob();
			const a = document.createElement('a');

			document.body.append(a);

			a.download = getFileName();

			a.href = URL.createObjectURL(blob);

			a.click();

			a.remove();
		}
	}
</script>

<Card class="max-w-none shadow-none text-neutral-800">
	<div class="grid grid-cols-[max-content,1fr,max-content] gap-4">
		<div class="flex items-center">
			{#if imageExtensions.includes(getFileExtension())}
				<ImageSolid class="w-12 h-12" />
			{:else if csvExtensions.includes(getFileExtension())}
				<FileCsvSolid class="w-12 h-12" />
			{:else if powerpointExtensions.includes(getFileExtension())}
				<FilePowerpointSolid class="w-12 h-12" />
			{:else if wordExtensions.includes(getFileExtension())}
				<FileWordpressSolid class="w-12 h-12" />
			{:else if pdfExtensions.includes(getFileExtension())}
				<FilePdfSolid class="w-12 h-12" />
			{:else if txtExtensions.includes(getFileExtension())}
				<FileLinesSolid class="w-12 h-12" />
			{:else}
				<FileSolid class="w-12 h-12" />
			{/if}
		</div>
		<div>
			<h1 class="text-xl font-bold">{file.filetype}</h1>
			<p>{getFileName()}</p>
		</div>
		<div class="flex items-center gap-4">
			<Input type="hidden" name="fileId" value={file.guid} />
			<Button color="light" class="p-4 h-12" on:click={async () => downloadData()}>
				<DownloadSolid class="w-4 h-4 mr-4" />
				Download
			</Button>
			<form action="/dashboard/system/{systemId}?/delete_file" method="post">
				<Input type="hidden" name="fileId" value={file.guid} />
				<Button color="light" class="p-4 h-12" type="submit">
					<CloseSolid class="w-4 h-4 focus:ring-0 focus:border-0 focus:stroke-none" />
				</Button>
			</form>
		</div>
	</div>
</Card>
