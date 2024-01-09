<script lang="ts">
	import google_logo from '$lib/images/icon/google_logo.svg';
	import login_image from '$lib/images/login.svg';
	import logo from '$lib/images/logo.png';
	import { signIn } from '@auth/sveltekit/client';
	import { Button } from 'flowbite-svelte';
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
						color="primary"
						size="lg"
						class="text-lg"
						iconStyle="!w-5 !h-5"
					>
						<img
							src={google_logo}
							alt="Google logo"
							class="w-8 h-8 p-1 mr-4 rounded-full bg-white"
						/>
						Log in with Google
					</Button>
				</div>
			</div>
		</div>
		<div class="lg:flex hidden flex-grow justify-center items-center">
			<img src={login_image} alt="Man sitting behind laptop" />
		</div>
	</div>
</div>
