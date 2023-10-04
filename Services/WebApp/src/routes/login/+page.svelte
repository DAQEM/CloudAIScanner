<script lang="ts">
	import Button from '$lib/components/Button.svelte';
	import google_logo from '$lib/images/icon/google_logo.svg';
	import login_image from '$lib/images/login.svg';
	import logo from '$lib/images/logo.png';
	import { signIn } from '@auth/sveltekit/client';
</script>

<div class="h-screen">
	<div class="flex bg-[#F7F7F7] h-full">
		<div class="lg:w-[28rem] w-full p-16 bg-white h-full">
			<div class="h-full">
				<div class="flex justify-center items-center">
					<a href="/">
						<img src={logo} alt="logo" class="w-[12rem]" />
					</a>
				</div>
				<div class="flex flex-col justify-center items-center h-[80%]">
					<div class="text-2xl font-bold text-center mb-4">
						<h1>Log in</h1>
					</div>
					<Button
						on:click={() => signIn('google')}
						icon={google_logo}
						iconImgStyle="!w-11 !h-8 bg-white p-1 rounded-full">Log in with Google</Button
					>
				</div>
			</div>
		</div>
		<div class="lg:flex hidden flex-grow justify-center items-center">
			<img src={login_image} alt="Man sitting behind laptop" />
		</div>
	</div>
</div>
