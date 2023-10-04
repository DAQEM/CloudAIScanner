<script lang="ts">
	import type { Provider } from '$lib/api/provider';
	import type { Status } from '$lib/api/status';
	import type { System } from '$lib/api/systems';
	import Button from '$lib/components/Button.svelte';
	import DateInput from '$lib/components/DateInput.svelte';
	import DropDown from '$lib/components/DropDown.svelte';
	import DropDownOption from '$lib/components/DropDownOption.svelte';
	import Form from '$lib/components/Form.svelte';
	import FormCategory from '$lib/components/FormCategory.svelte';
	import FormItem from '$lib/components/FormItem.svelte';
	import Label from '$lib/components/Label.svelte';
	import TextInput from '$lib/components/TextInput.svelte';
	import type { PageData } from './$types';

	export let data: PageData;
	const system: System = data.system;
	const status: Status[] = data.status;
	const providers: Provider[] = data.providers;
</script>

<div class="p-12">
	<h1 class="text-2xl font-bold">AI System: {system.name}</h1>
	<div class="flex flex-col justify-center">
		<Form>
			<FormCategory>
				<FormItem>
					<Label forName="name">Name</Label>
					<TextInput name="name" value={system.name} />
				</FormItem>

				<FormItem>
					<Label forName="date">Date</Label>
					<DateInput name="date" value={system.date} />
				</FormItem>
			</FormCategory>

			<FormCategory>
				<FormItem>
					<Label forName="provider">Provider</Label>
					<DropDown name="provider" value={system.provider}>
						{#each providers as provider}
							<DropDownOption value={provider}>{provider}</DropDownOption>
						{/each}
					</DropDown>
				</FormItem>

				<FormItem>
					<Label forName="status">Status</Label>
					<DropDown name="status" value={system.status}>
						{#each status as stat}
							<DropDownOption value={stat}>{stat}</DropDownOption>
						{/each}
					</DropDown>
				</FormItem>
			</FormCategory>
			<Button type="submit">Submit</Button>
		</Form>
	</div>
</div>
