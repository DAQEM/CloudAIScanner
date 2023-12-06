<script lang="ts">
	import type { Provider } from '$lib/types/types';

	import google_logo from '$lib/images/icon/google_logo.svg';
	import openai_logo from '$lib/images/icon/openai.svg';

	export let provider: Provider;
	export let size: number = 20;

	function getLogo(): string {
		switch (provider.guid) {
			case '6147de64-95ee-4040-86e5-a3c0a2b32573':
				return google_logo;
			case '15085208-a80f-42c8-8a75-c39c87384941':
				return openai_logo;
			default:
				return '';
		}
	}
</script>

<img src={getLogo()} alt={provider.name} height={size / 4} width={size / 4} />
