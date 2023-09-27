<script lang="ts">
	export let icon: string;
    export let href: string;
</script>

<a {href} class="flex items-center gap-2 bg-[#605BFF] p-3 px-5 rounded-xl text-white fill-white hover:bg-[#4F4CFF]">
	<div>
		<img src={icon} alt="icon" class="w-4 h-4" />
	</div>
	<div>
		<slot />
	</div>
</a>
