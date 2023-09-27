<script lang="ts">
	import type { Session } from '@auth/core/types';
	import { signIn, signOut } from '@auth/sveltekit/client';
	import type { PageData } from './$types';

	export let data: PageData;
	const session: Session | null = data.session;
</script>

<div>
	{#if session?.user}
		<div>{session.user.name}</div>
		<div>{session.user.email}</div>
		<div>{session.user.image}</div>
		<button on:click={() => signOut()}>Logout</button>
	{:else}
		<div>Not logged in</div>
		<button on:click={() => signIn()}>Login</button>
	{/if}
</div>
