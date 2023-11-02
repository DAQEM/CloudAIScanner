<script lang="ts">
	import type { Session } from '@auth/core/types';
	import logo from '$lib/images/logo.png';
	import {
		Navbar,
		NavBrand,
		NavLi,
		NavUl,
		NavHamburger,
		Avatar,
		Dropdown,
		DropdownItem,
		DropdownHeader,
		DarkMode
	} from 'flowbite-svelte';
	export let session: Session | null;
</script>

<Navbar>
	<NavBrand href="/">
		<img src={logo} class="mr-3 h-9 sm:h-12" alt="Flowbite Logo" />
	</NavBrand>
	<div class="flex gap-2 items-center md:order-2">
		<DarkMode />
		{#if session && session.user}
			<Avatar id="avatar-menu" src={session.user.image ?? ''} />
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
		</Dropdown>
	{/if}
	<NavUl>
		<NavLi href="/about">About</NavLi>
		<NavLi href="/contact">Contact</NavLi>
	</NavUl>
</Navbar>
