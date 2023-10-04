<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let icon: string = '';
	export let className: string = '';

	let dispatch = createEventDispatcher();

	function handleClick() {
		dispatch('click');
	}
</script>

<button
	on:click={handleClick}
	class="flex items-center gap-2 bg-[#605BFF] p-3 px-5 rounded-xl text-white fill-white hover:brightness-90 {className}"
>
	{#if icon}
		<div>
			<img src={icon} alt="icon" class="w-4 h-4" />
		</div>
	{/if}
	<div class=" w-full text-center">
		<slot />
	</div>
</button>
