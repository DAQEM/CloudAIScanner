<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let className: string = '';

	let dispatch = createEventDispatcher();

	function handleClick(e: MouseEvent) {
		dispatch('click', {
			value: (e.target as HTMLInputElement).checked
		});
	}
</script>

<input type="checkbox" class="accent-[#605BFF] border-red-900 {className}" on:click={handleClick} />
