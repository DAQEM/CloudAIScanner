<script lang="ts">
	import Navbar from '$lib/components/Navbar.svelte';
	import type { User } from '$lib/database/userDatabase';
	import type { LayoutData } from './$types';

	export let data: LayoutData;

	const session = data.session;
	const associatedUser: User | null = data.associatedUser;

</script>

<Navbar {session} {associatedUser} />

<slot />
