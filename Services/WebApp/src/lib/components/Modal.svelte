<script lang="ts">

	export let isOpen: boolean;
</script>

<div
	class="fixed inset-0 flex items-center justify-center z-50"
	style="display: {isOpen ? 'flex' : 'none'};"
>
	<div class="modal-content bg-white p-8 rounded-xl">
		<slot />
	</div>
	<div class="modal-background fixed inset-0 bg-black opacity-50 -z-10" />
</div>
