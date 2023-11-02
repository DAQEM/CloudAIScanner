<script lang="ts">
	import type { System } from '$lib/api/systems';
	import google_logo from '$lib/images/icon/google_logo.svg';
	import type { PageData } from './$types';

	export let data: PageData;
	const system: System = data.system;

	function getImage(): string {
		return google_logo;
	}
</script>

<div class="p-12">
	<div class="flex flex-col gap-8">
		<div class="flex gap-8">
			<div class="w-32 h-32">
				<img src={getImage()} alt={system.provider} class="w-32 h-32" />
			</div>
			<div class="mt-4">
				<h1 class="text-4xl font-bold">{system.name}</h1>
				<p class="text-xl">{system.provider}</p>
			</div>
		</div>

		<div>
			<h2 class="font-bold">Scanned on:</h2>
			<p>{system.date}</p>
		</div>
	</div>
</div>
