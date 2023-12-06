<script lang="ts">
	import type { Provider } from '$lib/types/types';
	import { Button, Input, Label } from 'flowbite-svelte';
	import type { PageData } from './$types';

	export let data: PageData;
	const provider: Provider = data.provider;
</script>

<div class="flex justify-center items-center h-[90vh]">
	<div class="p-12 max-w-4xl w-full">
		<h1 class="text-2xl font-bold">Editing provider: {provider.name}</h1>
		<div class="flex flex-col justify-center mt-8">
			<form method="post" class="flex flex-col gap-6">
				<div>
					<Label for="name">Name</Label>
					<Input type="text" name="name" value={provider.name} />
				</div>
				<div>
					<Label for="address">Address</Label>
					<Input type="text" name="address" value={provider.address} />
				</div>
				<div>
					<Label for="email">Email</Label>
					<Input type="email" name="email" value={provider.email} />
				</div>
				<div>
					<Label for="phoneNumber">Phone Number</Label>
					<Input type="tel" name="phoneNumber" value={provider.phoneNumber} />
				</div>
				<div class="flex w-full gap-8 mt-4">
					<Button href="/dashboard/provider" color="light" class="w-full border-2	border-primary-500"
						>Back</Button
					>
					<Button type="submit" color="primary" class="w-full">Save Changes</Button>
				</div>
			</form>
		</div>
	</div>
</div>
