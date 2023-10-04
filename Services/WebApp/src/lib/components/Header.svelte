<script lang="ts">
	import AnchorButton from '$lib/components/AnchorButton.svelte';
	import logo from '$lib/images/logo.png';
	import type { Session } from '@auth/core/types';

	export let session: Session | null;
</script>

<div class="bg-white flex justify-center w-full">
	<div class="flex py-4 max-w-7xl w-full justify-between">
		<div class="w-32">
			<a href="/">
				<img src={logo} alt="logo" />
			</a>
		</div>
		<ul class="flex items-center gap-8 text-xl">
			<li>
				<a href="/about">About</a>
			</li>
			<li>
				<a href="/contact">Contact</a>
			</li>
			{#if session && session.user}
				<li>
					<a href="/dashboard/register">Dashboard</a>
				</li>
			{/if}
		</ul>

		{#if session && session.user}
			<div class="flex items-center">
				<div class="w-8 h-8 rounded-full overflow-hidden">
					<img src={session.user.image} alt="avatar" />
				</div>
			</div>
		{:else}
			<div class="flex items-center text-xl">
				<AnchorButton href="/login" className="max-h-12">Login</AnchorButton>
			</div>
		{/if}
	</div>
</div>
