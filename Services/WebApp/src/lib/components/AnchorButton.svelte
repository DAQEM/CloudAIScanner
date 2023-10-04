<script lang="ts">
	export let icon: string = '';
	export let href: string;
	export let className: string = '';
</script>

<a
	{href}
	class="flex items-center justify-center gap-2 bg-primary p-3 px-5 rounded-xl text-white fill-white hover:brightness-90 {className}"
>
	{#if icon}
		<div>
			<img src={icon} alt="icon" class="w-4 h-4" />
		</div>
	{/if}
	<div>
		<slot />
	</div>
</a>
