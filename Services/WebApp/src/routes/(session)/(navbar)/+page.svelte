<script lang="ts">
	import homepage_image from '$lib/images/homepage.svg';
	import type { Session } from '@auth/core/types';
	import { Button } from 'flowbite-svelte';
	import type { PageData } from './$types';

	export let data: PageData;
	const session: Session | null = data.session;
	const associatedUser = data.associatedUser;

	type Service = {
		name: string;
		description: string;
		icon: string;
	};

	const services: Service[] = [
		{
			name: 'AI Register',
			description:
				'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam at interdum dui, nec tristique augue. Praesent diam lectus, pharetra ut nibh blandit, sagittis bibendum diam. Morbi tincidunt lectus sed sapien vulputate interdum. Suspendisse sed luctus enim. Sed porttitor non libero quis consectetur.',
			icon: 'https://i.pravatar.cc/150'
		},
		{
			name: 'AI Scanner',
			description:
				'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum vitae tincidunt massa, non pulvinar quam. Sed a scelerisque nibh. Aenean fringilla finibus diam, sit amet condimentum enim venenatis eu. Donec nisi purus, mattis sed condimentum non, mattis et dui. Pellentesque vulputate sagittis mi.',
			icon: 'https://i.pravatar.cc/150'
		}
	];
</script>

<div>
	<div class="flex flex-col items-center">
		<div class="flex max-w-7xl w-full px-4 my-28 gap-16">
			<div class="flex-1">
				<div class="h-full flex flex-col justify-center w-full max-w-lg gap-6">
					<h1 class="lg:text-5xl text-4xl font-bold">Cloud AI Scanner</h1>
					<p class="lg:text-xl text-lg">
						The leading AI-scanner for the EU AI Act. Scan, analyze, and comply with the latest
						regulations on artificial intelligence with ease and confidence.
					</p>
					<Button href="/login" class="lg:w-max lg:text-lg">Get Started</Button>
				</div>
			</div>
			<div class="flex-1 lg:block hidden">
				<img src={homepage_image} alt="" />
			</div>
		</div>
		<div class="w-full text-black dark:text-white bg-gray-100 pb-24 dark:bg-gray-900">
			<div class="w-full flex flex-col items-center">
				<div class="w-full flex flex-col max-w-7xl text-center px-4 py-12 gap-24">
					<div class="w-full text-primary">
						<h1 class="text-6xl font-bold">Services</h1>
					</div>
					<div class="flex flex-wrap justify-center gap-16">
						{#each services as service}
							<div
								class="max-w-sm bg-white p-6 rounded-xl bg-opacity-80 border-[3px] border-primary border-opacity-25 dark:bg-gray-800 dark:border-gray-700 dark:te"
							>
								<div
									class="absolute ml-[136px] rounded-full overflow-hidden mt-[-64px] w-[64px] h-[64px]"
								>
									<img src={service.icon} alt={service.name} />
								</div>
								<div class="mt-4">
									<h1 class="text-2xl font-bold">{service.name}</h1>
									<p>{service.description}</p>
								</div>
							</div>
						{/each}
					</div>
				</div>
			</div>
		</div>
		<div>
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
		</div>
	</div>
</div>
