<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let type: 'button' | 'submit' | 'reset' | null | undefined = 'button';
	export let icon: string = '';
	export let className: string = '';
	export let iconStyle: string = '';
	export let iconImgStyle: string = '';

	let dispatch = createEventDispatcher();

	function handleClick() {
		dispatch('click');
	}
</script>

<button
	{type}
	on:click={handleClick}
	class="flex items-center gap-2 bg-primary p-3 px-5 rounded-xl text-white fill-white hover:brightness-90 {className}"
>
	{#if icon}
		<div class={iconStyle}>
			<img src={icon} alt="icon" class="w-4 h-4 {iconImgStyle}" />
		</div>
	{/if}
	<div class=" w-full text-center">
		<slot />
	</div>
</button>
