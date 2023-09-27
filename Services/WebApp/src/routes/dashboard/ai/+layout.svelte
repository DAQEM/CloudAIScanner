<script lang="ts">
	import logo from '$lib/images/logo.png';
	import ai_register_icon from '$lib/images/icon/ai_register.svg';
	import setting_icon from '$lib/images/icon/setting.svg';
	import logout_icon from '$lib/images/icon/logout.svg';

	interface Links {
		name: string;
		link: string;
		icon: string;
	}

	const links: Links[] = [
		{
			name: 'AI Register',
			link: '/dashboard/ai/register',
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
		class="bg-white px-8 absolute w-64 h-full flex flex-col justify-between text-[#030229] fill-[#030229]"
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
		<div class="grid grid-cols-[3rem,minmax(10px,100rem),max-content] h-12 mb-4 gap-2">
			<div>
				<img
					src="https://images.peopleimages.com/picture/202304/2693419-portrait-thumbs-up-and-wink-by-asian-man-in-studio-with-positive-feedback-or-review-on-blue-background.-face-smile-and-hand-gesture-by-male-showing-yes-agreement-and-vote-emoji-while-isolated-box_175_175.jpg"
					alt="profile"
					class="rounded-2xl"
				/>
			</div>
			<div>
				<h1>Username</h1>
				<h2 class="opacity-40 text-xs truncate">example@longemail.com</h2>
			</div>
			<div class="flex justify-center items-center">
				<a href="/logout">
					<img src={logout_icon} alt="Logout" class="opacity-40" />
				</a>
			</div>
		</div>
	</div>
	<slot />
</div>

<style>
</style>
