<script lang="ts">
	import UserTable from '$lib/components/UserTable.svelte';
	import type { User } from '$lib/database/userDatabase';
	import type { Session } from '@auth/core/types';
	import type { PageData } from './$types';

	export let data: PageData;
	const session: Session | null = data.session;
	const users: User[] = data.users;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-4">
	<UserTable {users} {session} url="/admin/users" />
</div>
