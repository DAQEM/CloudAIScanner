<script lang="ts">
	import ProviderLogo from '$lib/components/ProviderLogo.svelte';
	import type { Provider } from '$lib/types/types';
	import { signIn } from '@auth/sveltekit/client';
	import { Button, Toast } from 'flowbite-svelte';
	import { CheckCircleSolid } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';
	import type { PageData } from './$types';

	export let data: PageData;

	const providers: Provider[] = data.providers;
	const success: string | null = data.success;
	const aiData: string[] | undefined = data.data?.split(',');

	interface SupportedProvider {
		guid: string;
		provider?: Provider;
		slug: string;
		loginType: LoginType;
	}

	enum LoginType {
		OAuth,
		APIKey
	}

	const supportedProviders: SupportedProvider[] = [
		{
			guid: '6147de64-95ee-4040-86e5-a3c0a2b32573',
			slug: 'google',
			provider: providers.find((p) => p.guid === '6147de64-95ee-4040-86e5-a3c0a2b32573'),
			loginType: LoginType.OAuth
		},
		{
			guid: '15085208-a80f-42c8-8a75-c39c87384941',
			slug: 'openai',
			provider: providers.find((p) => p.guid === '15085208-a80f-42c8-8a75-c39c87384941'),
			loginType: LoginType.APIKey
		}
	];
</script>

<div class="flex justify-center">
	<div class="max-w-lg my-32">
		{#if aiData && aiData.length > 0 && !success}
			<Toast
				color="red"
				defaultIconClass="bg-opacity-0"
				class="mb-4 shadow-none rounded-xl bg-red-400 bg-opacity-25 max-w-none"
				contentClass="w-full text-lg font-normal text-gray-700"
				transition={slide}
			>
				<CheckCircleSolid slot="icon" class="w-6 h-6 mr-2" />
				<p class="font-bold">Error:</p>
				{#if aiData[0] === 'ECONNREFUSED'}
					<p>The AI Extraction service is currently unavailable. Please try again later.</p>
				{:else}
					<p>Something went wrong. Please try again later.</p>
				{/if}
			</Toast>
		{/if}
		<div class="bg-white dark:bg-gray-900 rounded-xl p-16">
			<div class="mb-8">
				<h1 class="text-2xl font-bold text-center mb-4">Login to an AI provider</h1>
				<p>
					CAIS requires you to login to your AI-provider in order for us to extract the data
					required by the EU AI Act. Your login details will only be used once and will not be
					stored in our system.
				</p>
			</div>
			<div>
				<div>
					<h2 class="text-xl font-bold text-center mb-4">Login options</h2>
				</div>
				<div id="login_buttons" class="grid grid-cols-2 gap-4">
					{#each supportedProviders as supportedProvider}
						{#if supportedProvider.loginType === LoginType.OAuth}
							<Button
								on:click={() =>
									signIn(supportedProvider.slug + '-aiextraction', {
										callbackUrl: '/hook/extraction/' + supportedProvider.slug + '/callback',
										redirect: true
									})}
								color="primary"
								class="text-lg"
							>
								<div class="m-4">
									{#if supportedProvider.provider}
										<ProviderLogo provider={supportedProvider.provider} size={500} />
									{/if}
									<div class="mt-4">
										<span class="font-bold text-lg">{supportedProvider.provider?.name}</span>
									</div>
								</div>
							</Button>
						{:else}
							<a
								class="bg-primary-700 flex justify-center items-center rounded-lg text-lg text-white text-center dark:bg-primary-600 hover:bg-primary-800 dark:hover:bg-primary-700 cursor-pointer"
								href="/dashboard/scan/{supportedProvider.slug}"
							>
								<div class="m-4">
									{#if supportedProvider.provider}
										<ProviderLogo provider={supportedProvider.provider} size={500} />
									{/if}
									<div class="mt-4">
										<span class="font-bold text-lg">{supportedProvider.provider?.name}</span>
									</div>
								</div>
							</a>
						{/if}
					{/each}
				</div>
			</div>
		</div>
	</div>
</div>
