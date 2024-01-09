<script lang="ts">
	import DeviceTable from '$lib/components/DeviceTable.svelte';
	import type { AISystem, Pagination } from '$lib/types/types';
	import type { PageData } from './$types';

	export let data: PageData;
	const pendingSystems: Pagination<AISystem[]> = data.pendingSystems;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-4">
	<DeviceTable systems={pendingSystems} title="Pending Systems" showStatus={false} approvable={true} showCheckboxes={true}/>
</div>
