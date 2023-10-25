<script lang="ts">
	import search_icon from '$lib/images/icon/search.svg';
	import { createEventDispatcher } from 'svelte';

	const dispatch = createEventDispatcher();
	let value = '';

	function search() {
		dispatch('search', {
			value
		});
	}
</script>

<div class="grid grid-cols-[1fr,max-content] bg-white rounded-xl px-5">
	<div>
		<form on:submit|preventDefault={search}>
			<input type="text" placeholder="Search" class="p-3 focus:outline-none" bind:value />
		</form>
	</div>
	<button on:click={search}>
		<img src={search_icon} alt="Search" class="w-4 h-4" />
	</button>
</div>
