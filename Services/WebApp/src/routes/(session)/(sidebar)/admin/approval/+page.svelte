<script lang="ts">
	import type { System } from '$lib/api/systems';
	import DeviceTable from '$lib/components/DeviceTable.svelte';
	import type { PageData } from './$types';

	export let data: PageData;
	const pendingSystems: System[] = data.pendingSystems;
</script>

<div class="grid grid-rows-[max-content,1fr] text-xs md:text-base lg:text-lg p-2 md:p-16 gap-4">
	<DeviceTable systems={pendingSystems} title="Pending Systems" showStatus={false} approvable={true} />
</div>
