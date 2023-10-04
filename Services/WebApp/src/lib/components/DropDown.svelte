<script lang="ts">
	export let name: string;
	export let value: string;
</script>

<select {name} {value} class="bg-white px-5 py-3 rounded-xl focus:outline-none">
	<slot />
</select>
