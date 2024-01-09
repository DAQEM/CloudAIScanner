<script lang="ts">
	import { Button, DropdownDivider, Input, Label, Toast, Tooltip } from 'flowbite-svelte';
	import { CheckCircleSolid, InfoCircleSolid } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';
	import { page } from '$app/stores';

	let apiKey: string = '';

	function isValidApiKey(apiKey: string): boolean {
		const regex = new RegExp('^sk-[A-Za-z0-9]{48}$');
		return regex.test(apiKey);
	}
</script>

<div class="flex flex-col justify-center items-center p-2 h-[calc(100vh-4rem)]">
	{#if $page.url.searchParams.get('error') === 'true'}
		<Toast
			color="red"
			class="mb-4 shadow-none rounded-xl bg-red-400 bg-opacity-25 max-w-lg"
			defaultIconClass="bg-none bg-oppacity-0"
			contentClass="w-full text-lg font-normal text-gray-700"
			transition={slide}
		>
			<CheckCircleSolid slot="icon" class="w-6 h-6 mr-2" />
			<p class="font-bold">Invalid API key.</p>
		</Toast>
	{/if}
	<section class="max-w-lg p-8 bg-white dark:bg-gray-900 rounded-xl flex flex-col gap-4">
		<div>
			<h1 class="font-bold text-xl">We require an API Key</h1>
			<DropdownDivider class="my-1 bg-primary-500 h-[2px] rounded-full" />
			<div class="flex flex-col gap-4">
				<p>
					Open AI requires an api key to retrieve the Open AI models from their system. Your API key
					will not be stored in our systems and will only be used once.
				</p>
				<p>
					Not sure where you can find your API key? Take a look at <a
						href="https://help.openai.com/en/articles/4936850-where-do-i-find-my-api-key"
						class="text-primary-700"
						target="_blank">this article from Open AI</a
					>.
				</p>
			</div>
		</div>
		<form action="/dashboard/scan/openai/select?/submit_api_key" method="POST">
			<Label class="mt-4 font-bold" for="api_key">API Key</Label>
			<Input
				class="mt-1"
				type="text"
				name="api_key"
				placeholder="Your API key here"
				bind:value={apiKey}
			/>
			{#if !(apiKey.length > 0)}
				<div transition:slide>
					<Button class="mt-4" color="primary" disabled>
						<CheckCircleSolid class="mr-2 w-4 h-4" />
						Continue
					</Button>
				</div>
			{:else if isValidApiKey(apiKey)}
				<div transition:slide>
					<Button type="submit" class="mt-4" color="primary">
						<CheckCircleSolid class="mr-2 w-4 h-4" />
						Continue
					</Button>
				</div>
			{:else}
				<div transition:slide>
					<Button type="submit" class="mt-4" color="red">
						<InfoCircleSolid class="mr-2 w-4 h-4" />
						Continue Anyway
					</Button>
					<Tooltip class="mt-2">
						<p>Your API key does not match our requirements.</p>
					</Tooltip>
				</div>
			{/if}
		</form>
	</section>
</div>
