/** @type {import('tailwindcss').Config} */
export default {
	content: ['./src/**/*.{html,js,svelte,ts}', './node_modules/flowbite-svelte/**/*.{html,js,svelte,ts}'],

	plugins: [require('flowbite/plugin')],

	darkMode: 'class',

	theme: {
		extend: {
			colors: {
				primary: {
					DEFAULT: '#605BFF',
					50: '#FFFFFF',
					100: '#E6E5FF',
					200: '#DCDBFF',
					300: '#C9C7FF',
					400: '#ABA8FF',
					500: '#9794FF',
					600: '#7E7AFF',
					700: '#605BFF',
					800: '#2A23FF',
					900: '#0700EA',
					950: '#0600CE'
				},
				blue: {
					DEFAULT: '#3B82F6',
					50: '#FFFFFF',
					100: '#FFFFFF',
					200: '#FEFEFF',
					300: '#D7E6FD',
					400: '#B0CDFB',
					500: '#89B4FA',
					600: '#629BF8',
					700: '#3B82F6',
					800: '#0B61EE',
					900: '#084BB8',
					950: '#07409E'
				},
				red: {
					DEFAULT: '#F44336',
					50: '#FFFFFF',
					100: '#FFFFFF',
					200: '#FFF8F7',
					300: '#FCD4D1',
					400: '#FAB0AA',
					500: '#F88B83',
					600: '#F6675D',
					700: '#F44336',
					800: '#E51B0D',
					900: '#B0150A',
					950: '#961208'
				},
				green: {
					DEFAULT: '#3A974C',
					50: '#E5F5E8',
					100: '#D6EFDB',
					200: '#B9E4C1',
					300: '#9BD9A7',
					400: '#7ECD8D',
					500: '#60C273',
					600: '#45B45B',
					700: '#3A974C',
					800: '#2A6E38',
					900: '#1B4623',
					950: '#133219'
				},
				yellow: {
					DEFAULT: '#F29339',
					50: '#FBDCBF',
					100: '#FAD2AC',
					200: '#F7BD86',
					300: '#F5A85F',
					400: '#F29339',
					500: '#E4770F',
					600: '#AF5B0C',
					700: '#7B4008',
					800: '#462405',
					900: '#110901',
					950: '#000000'
				}
			}
		}
	}
};
