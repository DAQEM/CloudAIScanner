<script lang="ts">
	import logo from '$lib/images/logo.png';
	import type { Session } from '@auth/core/types';
	import { signOut } from '@auth/sveltekit/client';
	import { Sidebar, SidebarWrapper, SidebarItem, SidebarGroup } from 'flowbite-svelte';
	import { ArrowLeftToBracketOutline, BarsSolid, SearchOutline } from 'flowbite-svelte-icons';

	export let session: Session;
</script>

<Sidebar>
	<SidebarWrapper divClass="bg-white h-full flex flex-col justify-between dark:bg-gray-900">
		<SidebarGroup>
			<a class="flex justify-center items-center my-12" href="/">
				<img src={logo} alt="logo" class="w-[60%]" />
			</a>
			<SidebarItem label="Scan Provider" href="/dashboard/scan">
				<svelte:fragment slot="icon">
					<SearchOutline
						class="w-5 h-5 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
					/>
				</svelte:fragment>
			</SidebarItem>
			<SidebarItem label="AI Register" href="/dashboard/register">
				<svelte:fragment slot="icon">
					<BarsSolid
						class="w-5 h-5 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
					/>
				</svelte:fragment>
			</SidebarItem>
		</SidebarGroup>
		<SidebarGroup>
			{#if session.user}
				<div class="grid grid-cols-[3rem,minmax(10px,100rem),max-content] h-12 mb-4 gap-2">
					<div>
						<img
							src={session.user.image || 'https://i.pravatar.cc/150'}
							alt="profile"
							class="rounded-2xl"
						/>
					</div>
					<div class="flex flex-col justify-center">
						<h1 class="truncate">{session.user.name}</h1>
						<h2 class="opacity-40 text-xs truncate">{session.user.email}</h2>
					</div>
					<div class="flex justify-center items-center">
						<button on:click={() => signOut()}>
							<ArrowLeftToBracketOutline
								class="w-5 h-5 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
							/>
						</button>
					</div>
				</div>
			{/if}
		</SidebarGroup>
	</SidebarWrapper>
</Sidebar>
