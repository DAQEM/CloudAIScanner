<script lang="ts">
	import type { Provider } from '$lib/api/provider';
	import type { Status } from '$lib/api/status';
	import type { System } from '$lib/api/systems';
	import { Input, Select, Button, Label } from 'flowbite-svelte';
	import type { PageData } from './$types';
	export let data: PageData;
	const system: System = data.system;
	const status: Status[] = data.status;
	const providers: Provider[] = data.providers;
</script>

<div class="flex justify-center">
	<div class="p-12 w-[32rem]">
		<h1 class="text-2xl font-bold">Edit AI System: {system.name}</h1>
		<div class="flex flex-col justify-center">
			<form method="post" class="flex flex-col gap-4">
				<div>
					<Input type="hidden" name="id" value={system.id} />
				</div>
				<div>
					<Label for="name">Name</Label>
					<Input type="text" name="name" value={system.name} />
				</div>
				<div>
					<Label for="date">Date</Label>
					<Input type="date" name="date" value={system.date} />
				</div>
				<div>
					<Label for="status">Status</Label>
					<Select name="status" value={system.status}>
						{#each status as item}
							<option value={item}>{item}</option>
						{/each}
					</Select>
				</div>
				<div>
					<Label for="provider">Provider</Label>
					<Select name="provider" value={system.provider}>
						{#each providers as item}
							<option value={item}>{item}</option>
						{/each}
					</Select>
				</div>
				<Button type="submit" color="primary" class="w-full">Save</Button>
			</form>
		</div>
	</div>
</div>
