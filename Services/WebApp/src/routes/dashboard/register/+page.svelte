<script lang="ts">
	import AnchorButton from '$lib/components/AnchorButton.svelte';
	import Searchbar from '$lib/components/Searchbar.svelte';
	import AiSystemList from '$lib/components/register/AiSystemList.svelte';
	import plus_icon from '$lib/images/icon/plus.svg';
	import type AiSystemListModel from '$lib/model/register/AiSystemListModel';

	const list: AiSystemListModel[] = [
		{
			id: '#876364',
			name: 'AI System 1',
			provider: 'Google Cloud',
			date: '2021-08-12',
			status: 'Approved'
		},
		{
			id: '#876365',
			name: 'AI System 2',
			provider: 'Google Cloud',
			date: '2021-08-12',
			status: 'Pending'
		},
		{
			id: '#876366',
			name: 'AI System 3',
			provider: 'Google Cloud',
			date: '2021-08-12',
			status: 'Pending'
		},
		{
			id: '#876367',
			name: 'AI System 4',
			provider: 'Google Cloud',
			date: '2021-08-12',
			status: 'Approved'
		},
		{
			id: '#876368',
			name: 'AI System 5',
			provider: 'Google Cloud',
			date: '2021-08-12',
			status: 'Pending'
		}
	];

	let searchList: AiSystemListModel[] = list;
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
						searchList = list.filter((item) => {
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
