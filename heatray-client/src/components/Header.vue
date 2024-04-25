<template>
	<header :class="y > 80 ? 'sticky z-50' : 'z-50'">
		<div :class="y > 80 ? 'headbar-transparent pb-0 w-full' : 'headbar w-full'">
			<div
				:class="y > 80 ? 'header-container bg-white p-3 pl-8 pr-8 rounded-3xl flex items-center' : 'flex items-center'">
				<div class="headbar-logo">
					<img :src="y > 80 ? LogoBlack : Logo" class="h-14" alt="heatray" />
				</div>
				<div class="headbar-nav">
					<a href="#" :class="y > 80 ? 'text-sm !text-gray-900 font-bold' : 'text-sm font-bold'">Hooks</a>
					<a href="#" :class="y > 80 ? 'text-sm !text-gray-900 font-bold' : 'text-sm font-bold'">Features</a>
					<a href="#"
						:class="y > 80 ? 'text-sm !text-gray-900 font-bold' : 'text-sm font-bold'">Integrations</a>
					<div class="pl-64 pr-64"></div>
					<a href="#"><button
							class="bg-white text-gray-900 py-2 px-4 font-semibold rounded-xl button-3d">CREATE NEW
							HOOK</button></a>
					<a href="#"><button class="bg-black text-gray-200 py-2 px-4 font-semibold rounded-xl button-3d">SIGN
							OUT</button></a>
				</div>
			</div>
		</div>
	</header>
</template>

<script lang="ts">
	import Logo from "../assets/images/heatray-high-resolution-logo-white-transparent.png";
	import LogoBlack from "../assets/images/heatray-high-resolution-logo-black-transparent.png";
	import {
		ref,
		onMounted,
		onBeforeUnmount
	} from 'vue';

	export default {
		setup() {
			const y = ref(0);

			const handleScroll = () => {
				y.value = window.scrollY;
			};

			onMounted(() => {
				window.addEventListener('scroll', handleScroll);
			});

			onBeforeUnmount(() => {
				window.removeEventListener('scroll', handleScroll);
			});
			return {
				Logo,
				LogoBlack,
				y
			}
		}
	}
</script>

<style>
	header.sticky {
		top: 0;
		animation: slideDown 0.3s;
	}

	header::after {
		animation: slideUp 0.3s;
	}

	header {
		display: flex;
		justify-content: space-between;
		transition: top 0.5s;
	}

	@keyframes slideDown {
		from {
			top: -60px;
		}

		to {
			top: 0;
		}
	}

	@keyframes slideUp {
		from {
			top: 0;
		}

		to {
			top: -60px;
		}
	}

	.header-container {
		box-shadow: 0 6px 8px rgba(0, 0, 0, 0.2);
	}

	.button-3d {
		box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
	}
</style>