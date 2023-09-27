<script lang="ts">
	import ai_register_icon from '$lib/images/icon/ai_register.svg';
	import logout_icon from '$lib/images/icon/logout.svg';
	import setting_icon from '$lib/images/icon/setting.svg';
	import logo from '$lib/images/logo.png';
	import type { Session } from '@auth/core/types';
	import type { LayoutData } from './$types';

	export let data: LayoutData;
	const session: Session = data.session;

	interface Links {
		name: string;
		link: string;
		icon: string;
	}

	const links: Links[] = [
		{
			name: 'AI Register',
			link: '/dashboard/register',
			icon: ai_register_icon
		},
		{
			name: 'Settings',
			link: '/dashboard/settings',
			icon: setting_icon
		}
	];
</script>

<div>
	<div
		class="bg-white px-8 fixed w-64 h-full flex flex-col justify-between text-[#030229] fill-[#030229]"
	>
		<div class="flex flex-col">
			<div class="flex justify-center py-8">
				<img src={logo} alt="logo" />
			</div>
			<div class="flex flex-col gap-4 font-semibold text-xl">
				{#each links as link}
					<a href={link.link} class="flex flex-row gap-4 opacity-40 hover:opacity-50">
						<div class="flex items-center">
							<img src={link.icon} alt={link.name} />
						</div>
						<div>
							<h1>{link.name}</h1>
						</div>
					</a>
				{/each}
			</div>
		</div>
		{#if session.user}
			<div class="grid grid-cols-[3rem,minmax(10px,100rem),max-content] h-12 mb-4 gap-2">
				<div>
					<img
						src="https://images.peopleimages.com/picture/202304/2693419-portrait-thumbs-up-and-wink-by-asian-man-in-studio-with-positive-feedback-or-review-on-blue-background.-face-smile-and-hand-gesture-by-male-showing-yes-agreement-and-vote-emoji-while-isolated-box_175_175.jpg"
						alt="profile"
						class="rounded-2xl"
					/>
				</div>
				<div class="flex flex-col justify-center">
					<h1>{session.user.name}</h1>
					<h2 class="opacity-40 text-xs truncate">{session.user.email}</h2>
				</div>
				<div class="flex justify-center items-center">
					<a href="/logout">
						<img src={logout_icon} alt="Logout" class="opacity-40" />
					</a>
				</div>
			</div>
		{/if}
	</div>
	<div class="ml-64">
		<slot />
	</div>
</div>

<style>
</style>
