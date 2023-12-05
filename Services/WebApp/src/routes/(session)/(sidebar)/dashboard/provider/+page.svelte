<script lang="ts">
	import ProviderTable from '$lib/components/ProviderTable.svelte';
import type { Provider } from '$lib/types/types';
	import type { PageData } from './$types';

	export let data: PageData;
	const providers: Provider[] = data.providers;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-4">
	<ProviderTable {providers} />
</div>
