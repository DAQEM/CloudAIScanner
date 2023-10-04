<script lang="ts">
	import Checkbox from '$lib/components/Checkbox.svelte';
	import delete_icon from '$lib/images/icon/delete.svg';
	import dots_icon from '$lib/images/icon/dots.svg';
	import dropdown_arrow_icon from '$lib/images/icon/dropdown_arrow.svg';
	import type AiSystemListModel from '$lib/model/register/AiSystemListModel';
	import AnchorButton from '../AnchorButton.svelte';
	import Button from '../Button.svelte';
	import Modal from '../Modal.svelte';

	export let list: AiSystemListModel[];

	let isModalOpen = false;
	let modalAiSystem: AiSystemListModel | undefined;

	function openModel(id: string) {
		modalAiSystem = list.find((item) => item.id === id);
		isModalOpen = true;
	}

	function closeModal() {
		isModalOpen = false;
		modalAiSystem = undefined;
	}

	function onKeyDown(e: KeyboardEvent) {
		if (e.key === 'Escape') {
			closeModal();
		}
	}

	function handleCheckboxClick(e: CustomEvent) {
		const checkboxes: HTMLInputElement[] = Array.from(
			document.querySelectorAll('#register-table input[type="checkbox"]')
		);
		checkboxes.forEach((checkbox) => {
			checkbox.checked = e.detail.value;
		});
	}
</script>

<svelte:window on:keydown={onKeyDown} />
<table id="register-table" class="table-auto w-full border-separate border-spacing-y-4">
	<thead class="text-left">
		<tr>
			<th class="font-normal !pl-8"
				><Checkbox className="w-5 h-5" on:click={handleCheckboxClick} /></th
			>
			<th class="font-normal">
				<div class="flex gap-2">
					<div>AI Id</div>
					<img src={dropdown_arrow_icon} alt="Drop down" class="opacity-75" />
				</div>
			</th>
			<th class="font-normal">
				<div class="flex gap-2">
					<div>Name</div>
					<img src={dropdown_arrow_icon} alt="Drop down" class="opacity-75" />
				</div>
			</th>
			<th class="font-normal">
				<div class="flex gap-2">
					<div>Provider</div>
					<img src={dropdown_arrow_icon} alt="Drop down" class="opacity-75" />
				</div>
			</th>
			<th class="font-normal">
				<div class="flex gap-2">
					<div>Date</div>
					<img src={dropdown_arrow_icon} alt="Drop down" class="opacity-75" />
				</div>
			</th>
			<th class="font-normal">
				<div class="flex gap-2">
					<div>Status</div>
					<img src={dropdown_arrow_icon} alt="Drop down" class="opacity-75" />
				</div>
			</th>
			<th class="font-normal">
				<img src={delete_icon} alt="Delete icon" class="opacity-40" />
			</th>
		</tr>
	</thead>
	<tbody class="font-semibold">
		{#each list as item}
			<tr id={item.id} class="bg-white">
				<td class="!pl-8"><Checkbox className="w-5 h-5" /></td>
				<td>{item.id}</td>
				<td>{item.name}</td>
				<td>{item.provider}</td>
				<td>{item.date}</td>
				<td>
					{#if item.status === 'Approved'}
						<div
							class="bg-[#3A974C] mr-8 max-w-[12rem] text-center py-3 rounded-full bg-opacity-10 text-[#3A974C]"
						>
							{item.status}
						</div>
					{:else if item.status === 'Pending'}
						<div
							class="bg-[#F29339] mr-8 max-w-[12rem] text-center py-3 rounded-full bg-opacity-10 text-[#F29339]"
						>
							{item.status}
						</div>
					{/if}
				</td>
				<td>
					<button class="flex items-center w-full h-12" on:click={() => openModel(item.id)}>
						<img src={dots_icon} alt="More actions" />
					</button>
				</td>
			</tr>
		{/each}
	</tbody>
</table>
<Modal bind:isOpen={isModalOpen}>
	{#if modalAiSystem !== undefined}
		<div class="flex flex-col gap-4">
			<div class="flex flex-col">
				<div class="text-2xl font-bold">{modalAiSystem.name}</div>
			</div>
			<div class="flex flex-col gap-4">
				<table id="modal-table" class="table-auto text-left border-spacing-y-0">
					<tbody>
						<tr>
							<th>Id:</th>
							<td>{modalAiSystem.id}</td>
						</tr>
						<tr>
							<th>Provider:</th>
							<td>{modalAiSystem.provider}</td>
						</tr>
						<tr>
							<th>Date:</th>
							<td>{modalAiSystem.date}</td>
						</tr>
						<tr>
							<th>Status:</th>
							<td>{modalAiSystem.status}</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div class="flex flex-col gap-2">
				<div class="flex gap-2">
					<Button icon={undefined} className="w-full !bg-red-600" on:click={closeModal}
						>Delete</Button
					>
					<AnchorButton icon={undefined} className="w-full !bg-blue-600" href="/dashboard/system/{modalAiSystem.id}/edit"
						>Edit</AnchorButton
					>
				</div>
				<Button icon={undefined} className="w-full" on:click={closeModal}>Close</Button>
			</div>
		</div>
	{/if}
</Modal>

<style>
	#register-table td {
		padding: 0.75rem 0rem;
	}

	#modal-table td {
		padding: 0.25rem 2rem;
	}

	td:first-child,
	th:first-child {
		border-radius: 10px 0 0 10px;
	}

	td:last-child,
	th:last-child {
		border-radius: 0 10px 10px 0;
	}
</style>
