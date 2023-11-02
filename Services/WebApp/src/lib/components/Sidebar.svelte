<script lang="ts">
	import logo from '$lib/images/logo.png';
	import type { Session } from '@auth/core/types';
	import { signOut } from '@auth/sveltekit/client';
	import { Button, DarkMode, DropdownDivider, Sidebar, SidebarGroup, SidebarItem, SidebarWrapper } from 'flowbite-svelte';
	import { BarsSolid, SearchOutline } from 'flowbite-svelte-icons';
	import { slide } from 'svelte/transition';

	export let session: Session;

	let user_popup_shown = false;
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
				<div class="bg-gray-200 dark:bg-gray-800 rounded-xl p-3 mb-4">
					<div class="flex flex-col gap-2">
						<button class="grid grid-cols-[3rem,minmax(5rem,10rem)] gap-2" on:click={() => user_popup_shown = !user_popup_shown}>
							<div>
								<img
									src={session.user.image || 'https://i.pravatar.cc/150'}
									alt="profile"
									class="rounded-2xl"
								/>
							</div>
							<div class="text-start h-full flex flex-col justify-center">
								<h1 class="truncate">{session.user.name}</h1>
								<h2 class="opacity-40 text-xs truncate">{session.user.email}</h2>
							</div>
						</button>
						{#if user_popup_shown}
							<div class="p-0 max-h-14 flex flex-col gap-2" transition:slide={{ duration: 150, axis: 'y' }}>
								<DropdownDivider class="bg-primary-700 dark:bg-primary-700" />
								<div class="w-full grid grid-cols-[3rem,1fr] gap-2">
									<div transition:slide={{ delay: 50, duration: 100, axis: 'x'}}>
										<Button color="primary" size="sm" class="w-full">
											<DarkMode class="text-white p-0 m-0 bg-opacity-0 dark:bg-opacity-0 hover:bg-opacity-0 dark:hover:bg-opacity-0 focus:ring-0 dark:text-white" />
										</Button>
									</div>
									<div transition:slide={{ delay: 50, duration: 100, axis: 'x'}}>
										<Button on:click={() => signOut()} color="primary" size="sm" class="w-full">
											Sign Out
										</Button>
									</div>
								</div>
							</div>
						{/if}
					</div>
				</div>
			{/if}
		</SidebarGroup>
	</SidebarWrapper>
</Sidebar>
