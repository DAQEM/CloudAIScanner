<script lang="ts">
	import type { System } from '$lib/api/systems';
	import AnchorButton from '$lib/components/AnchorButton.svelte';
	import Searchbar from '$lib/components/Searchbar.svelte';
	import AiSystemList from '$lib/components/register/AiSystemList.svelte';
	import plus_icon from '$lib/images/icon/plus.svg';
	import type { PageData } from './$types';

	export let data: PageData; 
	const systems = data.systems;

	let searchList: System[] = systems;
</script>

<div class="grid grid-rows-[5rem,1fr] p-12">
	<div class="flex justify-between">
		<div>
			<h1 class="text-2xl font-bold">AI Register</h1>
		</div>
		<div class="flex gap-8">
			<div>
				<Searchbar
					on:search={(event) => {
						searchList = systems.filter((item) => {
							return Object.values(item).some((value) =>
								value.toString().toLowerCase().includes(event.detail.value.toLowerCase())
							);
						});
					}}
				/>
			</div>
			<div>
				<AnchorButton href="/dashboard/scan" icon={plus_icon}>Add New</AnchorButton>
			</div>
		</div>
	</div>
	<div class="w-full">
		<AiSystemList list={searchList} />
	</div>
</div>
