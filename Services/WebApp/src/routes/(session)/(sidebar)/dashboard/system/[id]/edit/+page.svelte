<script lang="ts">
	import type { Provider } from '$lib/api/provider';
	import type { Status } from '$lib/api/status';
	import type { System } from '$lib/api/systems';
	import { Button, Input, Label, Select, Textarea } from 'flowbite-svelte';
	import type { PageData } from './$types';
	import type { AISystem, ApprovalStatus } from '$lib/types/types';
	export let data: PageData;
	const system: AISystem = data.system;
	const status: ApprovalStatus[] = data.status;
	const providers: Provider[] = data.providers;

	console.log(system);
</script>

<div class="flex justify-center">
	<div class="p-12 max-w-4xl w-full">
		<h1 class="text-2xl font-bold">Edit AI System: {system.name}</h1>
		<div class="flex flex-col justify-center">
			<form method="post" class="flex flex-col gap-4">
				<div>
					<Input type="hidden" name="id" value={system.id} />
				</div>
				<div class="flex w-full gap-8">
					<div class="flex-1">
						<Label for="name">Name</Label>
						<Input type="text" name="name" value={system.name} />
					</div>
					<div class="flex-1">
						<Label for="date">Date</Label>
						<Input type="date" name="date" value={system.dateAdded} />
					</div>
				</div>
				<div class="flex w-full gap-8">
					<div class="flex-1">
						<Label for="status">Status</Label>
						<Select name="status" value={system.approvalStatus?.id}>
							{#each status as item}
								<option value={item.id}>{item.name}</option>
							{/each}
						</Select>
					</div>
					<div class="flex-1">
						<Label for="provider">Provider</Label>
						<Select name="provider" value={system.provider?.name}>
							{#each providers as item}
								<option value={item}>{item}</option>
							{/each}
						</Select>
					</div>
				</div>
				<div>
					<Label for="description">Description</Label>
					<Textarea name="description" value={system.description} class="h-48" />
				</div>
				<div class="flex w-full gap-8">
					<Button href="/dashboard/register" color="light" class="w-full border-2	border-primary-500"
						>Back</Button
					>
					<Button type="submit" color="primary" class="w-full">Save Changes</Button>
				</div>
			</form>
		</div>
	</div>
</div>
