<script lang="ts">
	import type { AISystem, MemberStates } from '$lib/types/types';
	import { Button, Input, Label, MultiSelect, Textarea } from 'flowbite-svelte';
	import { onMount } from 'svelte';
	import type { PageData } from './$types';
	export let data: PageData;
	const system: AISystem = data.system;
	const memberStates: MemberStates[] = data.memberStates;
	let memberStatesFromDevice: number[] = getMemberStatesFromDevice().map(
		(memberState) => memberState.id ?? 0
	);

	let init = false;

	onMount(() => {
		init = true;
	});

	function addSpaces(inputString: string) {
		var spacedString = inputString.replace(/([A-Z])/g, ' $1');
		return spacedString.trim();
	}

	function getMemberStatesFromDevice(): MemberStates[] {
		let returnValue: MemberStates[] = [];
		let id: number = system.memberState?.id ?? 0;
		let members: MemberStates[] = memberStates;

		members.sort((a, b) => (b.id ?? 0) - (a.id ?? 0));

		for (let i = 0; i < members.length; i++) {
			let memberStateValue: number = members[i].id ?? 0;
			if (id - memberStateValue >= 0) {
				returnValue.push(members[i]);
				id -= memberStateValue;
			}
		}

		return returnValue;
	}
</script>

<div class="flex justify-center">
	<div class="p-12 max-w-4xl w-full">
		<h1 class="text-2xl font-bold">Edit AI System: {system.name}</h1>
		<div class="flex flex-col justify-center">
			<form method="post" class="flex flex-col gap-6">
				<div>
					<Input type="hidden" name="id" value={system.id} />
				</div>
				<div>
					<Label for="name">Name</Label>
					<Input type="text" name="name" value={system.name} />
				</div>
				<div class="flex w-full gap-8">
					<div class="flex-1">
						<Label for="date">Date</Label>
						<Input type="date" name="date" value={system.dateAdded} />
					</div>
				</div>
				<div>
					<Label for="description">Description</Label>
					<Textarea name="description" value={system.description} class="h-48" />
				</div>
				<div>
					<Label for="url">URL</Label>
					<Input type="text" name="url" value={system.url} />
				</div>
				<div>
					<Label for="technicalDocumentationLink">Technical Documentation Link</Label>
					<Input
						type="text"
						name="technicalDocumentationLink"
						value={system.technicalDocumentationLink}
					/>
				</div>
				{#if init}
					<div>
						<Label for="memberStates">Member States</Label>
						<MultiSelect
							size="lg"
							class="dark:bg-gray-700"
							name="memberStates"
							items={memberStates.map((memberState) => {
								return {
									value: memberState.id ?? '',
									name: memberState.name ?? ''
								};
							})}
							bind:value={memberStatesFromDevice}
						/>
					</div>
				{/if}
				<div class="flex w-full gap-8 mt-4">
					<Button href="/dashboard/register" color="light" class="w-full border-2	border-primary-500"
						>Back</Button
					>
					<Button type="submit" color="primary" class="w-full">Save Changes</Button>
				</div>
			</form>
		</div>
	</div>
</div>
