<script lang="ts">
	export let method: string = 'POST';
	export let action: string = '';
</script>

<form {method} {action} class="w-full flex flex-col gap-8">
	<slot />
</form>
