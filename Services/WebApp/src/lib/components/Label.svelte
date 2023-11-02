<script lang="ts">
	export let forName: string;
</script>

<label class="text-sm font-bold" for={forName}>
	<slot />
</label>
