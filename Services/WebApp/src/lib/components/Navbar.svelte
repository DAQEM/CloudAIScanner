<script lang="ts">
	import logo from '$lib/images/logo.png';
	import type { Session } from '@auth/core/types';
	import { signOut } from '@auth/sveltekit/client';
	import {
		Avatar,
		Button,
		DarkMode,
		Dropdown,
		DropdownDivider,
		DropdownHeader,
		DropdownItem,
		NavBrand,
		NavHamburger,
		NavLi,
		NavUl,
		Navbar
	} from 'flowbite-svelte';
	import { ChevronDownOutline } from 'flowbite-svelte-icons';
	export let session: Session | null;
	export let associatedUser: any;
</script>

<Navbar>
	<NavBrand href="/">
		<img src={logo} class="mr-3 h-9 sm:h-12" alt="Cloud AI Scanner Logo" />
	</NavBrand>
	<div class="flex gap-2 items-center md:order-2">
		<Button
			class="w-10 p-0 h-10 bg-primary-400 dark:bg-primary-700 hover:bg-primary-500 dark:hover:bg-primary-800"
		>
			<DarkMode
				class="flex justify-center items-center w-full h-full p-0 m-0 bg-opacity-0 dark:bg-opacity-0 hover:bg-opacity-0 dark:hover:bg-opacity-0 focus:ring-0 text-primary-700 dark:text-primary-200"
			/>
		</Button>
		{#if session && session.user}
			<Avatar id="avatar-menu" src={session.user.image ?? ''} />
		{:else}
			<Button href="/login" color="primary">Login</Button>
		{/if}
		<NavHamburger class="m-0" />
	</div>
	{#if session && session.user}
		<Dropdown placement="bottom" triggeredBy="#avatar-menu">
			<DropdownHeader>
				<span class="block text-sm font-bold">{session.user.name}</span>
				<span class="block truncate text-sm">{session.user.email}</span>
			</DropdownHeader>
			<DropdownItem href="/dashboard/scan">Scan Provider</DropdownItem>
			<DropdownItem href="/dashboard/register">AI Register</DropdownItem>
			<DropdownDivider />
			{#if associatedUser && associatedUser.roles.includes('admin')}
				<DropdownItem href="/admin">Admin</DropdownItem>
				<DropdownDivider />
			{/if}
			<DropdownItem on:click={() => signOut()}>Logout</DropdownItem>
		</Dropdown>
	{/if}
	<NavUl>
		<NavLi href="/about">About</NavLi>
		<NavLi href="/contact">Contact</NavLi>
		{#if session && session.user}
			<NavLi class="cursor-pointer">
				AI Dashboard<ChevronDownOutline
					class="w-3 h-3 ml-2 text-primary-800 dark:text-white inline"
				/>
			</NavLi>
			<Dropdown class="w-44 z-20">
				<DropdownItem href="/dashboard/scan">Scan Provider</DropdownItem>
				<DropdownItem href="/dashboard/register">AI Register</DropdownItem>
			</Dropdown>
			{#if associatedUser && associatedUser.roles.includes('admin')}
				<NavLi href="/admin">Admin</NavLi>
			{/if}
		{/if}
	</NavUl>
</Navbar>
