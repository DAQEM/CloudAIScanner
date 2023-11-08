<script lang="ts">
	import type { Session } from '@auth/core/types';
	import type { LayoutData } from './$types';
	import Sidebar from '$lib/components/Sidebar.svelte';
	import Navbar from '$lib/components/Navbar.svelte';
	import type { User } from '$lib/database/userDatabase';

	export let data: LayoutData;
	const session: Session | null = data.session;
	const associatedUser: User | null = data.associatedUser;
</script>

<div>
	<div class="bg-white w-full lg:hidden flex px-3 dark:bg-gray-900">
		<Navbar {session} {associatedUser} />
	</div>
	<div class="bg-white w-64 fixed h-full lg:flex hidden px-3 dark:bg-gray-900">
		<Sidebar {session} {associatedUser} />
	</div>

	<div class="lg:ml-64">
		<slot />
	</div>
</div>
