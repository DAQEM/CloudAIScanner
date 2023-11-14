<script lang="ts">
	import access_denied from '$lib/images/access_denied.png';
	import { Button } from 'flowbite-svelte';
</script>

<div class="grid sm:grid-cols-2 sm:grid-rows-1 grid-cols-1 grid-rows-[max-content,max-content] m-4">
	<div class="flex flex-col justify-center gap-4">
		<h1 class="font-bold text-2xl">You do not have the rights to view this page.</h1>
		<p>Please contact the system administrator for more information.</p>
		<Button class="w-max" color="primary" size="xl" href="/">Go back to home page</Button>
	</div>
	<div class="flex justify-center items-center">
		<img src={access_denied} alt="Access Denied" class="p-8" />
	</div>
</div>
