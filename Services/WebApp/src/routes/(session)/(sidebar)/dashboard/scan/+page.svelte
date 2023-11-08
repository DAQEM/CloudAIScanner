<script lang="ts">
	import aws_logo from '$lib/images/icon/aws.png';
	import azure_logo from '$lib/images/icon/azure.png';
	import google_logo from '$lib/images/icon/google_logo.svg';
	import openai_logo from '$lib/images/icon/openai.svg';
	import { signIn } from '@auth/sveltekit/client';
	import { Button, Toast } from 'flowbite-svelte';
	import { CheckCircleSolid } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';
	import type { PageData } from './$types';

	export let data: PageData;

	const success: string | null = data.success;
	const provider: string | null = data.provider;
	const aiData: string[] | undefined = data.data?.split(',');

	interface Provider {
		name: string;
		logo: string;
		slug: string;
	}

	const providers: Provider[] = [
		{
			name: 'Google',
			logo: google_logo,
			slug: 'google'
		},
		{
			name: 'Open AI',
			logo: openai_logo,
			slug: 'openai'
		},
		{
			name: 'Azure',
			logo: azure_logo,
			slug: 'azure'
		},
		{
			name: 'AWS',
			logo: aws_logo,
			slug: 'aws'
		}
	];
</script>

<div class="flex justify-center">
	<div class="max-w-lg my-32">
		{#if success && provider}
			<Toast
				color="green"
				class="mb-4 shadow-none rounded-xl bg-green-400 bg-opacity-25 max-w-none"
				contentClass="w-full text-lg font-normal text-gray-700"
				transition={slide}
			>
				<CheckCircleSolid slot="icon" class="w-6 h-6 mr-2" />
				<p class="font-bold">Success!</p>
				<p>You have successfully logged in to <strong class="">{provider}</strong>.</p>
			</Toast>
		{/if}
		{#if aiData && aiData.length > 0}
			{#if success === 'true'}
				<Toast
					color="green"
					class="mb-4 shadow-none rounded-xl bg-green-400 bg-opacity-25 max-w-none"
					contentClass="w-full text-lg font-normal text-gray-700"
					transition={slide}
				>
					<CheckCircleSolid slot="icon" class="w-6 h-6 mr-2" />
					<p class="font-bold">AI's Found:</p>
					{#each aiData as ai}
						<p>{ai}</p>
					{/each}
				</Toast>
			{:else}
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
		{/if}
		<div class="bg-white rounded-xl p-16">
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
					{#each providers as provider}
						<Button
							on:click={() =>
								signIn(provider.slug + '-aiextraction', {
									callbackUrl: '/hook/extraction/' + provider.name + '/callback',
									redirect: true
								})}
							color="primary"
							class="text-lg"
						>
							<div class="m-4">
								<img
									src={provider.logo}
									alt="{provider.name} logo"
									class="w-24 h-24 p-4 rounded-full bg-white object-contain mb-4"
								/>
								<span class="font-bold text-xl">{provider.name}</span>
							</div>
						</Button>
					{/each}
				</div>
			</div>
		</div>
	</div>
</div>
