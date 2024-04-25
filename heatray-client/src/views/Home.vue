<template>
	<section>
		<h1 class="text-5xl text-white text-left font-bold pt-4 flex flex-row items-center"><img :src="heatrayIcon"
				class="h-16 pr-2 heatray-icon" alt="heatray" />Explore your hooks</h1>
		<div class="tile p-0 mt-8">
			<p class="p-6 tile-header font-bold text-sm">Hooks for lukasz.kuc@it-solve.pl</p>
			<div class="p-4">
				<ul class="items">
					<li>
						<img src="https://avatars.slack-edge.com/2016-12-22/120836260775_6cff115a130b070fe184_88.png"
							alt="Icon 1">
						<span class="name">Ecologic</span>
						<button
							class="bg-black text-gray-200 py-2 px-4 font-semibold rounded-xl min-w-[100px] min-h-[40px]"
							@click="showLoader"><a v-if="!displayLoader">EXPLORE</a>
							<button-loader v-if="displayLoader" /></button>
					</li>
					<li>
						<img src="https://avatars.slack-edge.com/2016-12-22/120836260775_6cff115a130b070fe184_88.png"
							alt="Icon 2">
						<span class="name">VAIAP</span>
						<button class="bg-black text-gray-200 py-2 px-4 font-semibold rounded-xl">EXPLORE</button>
					</li>
				</ul>
			</div>
		</div>
		<div class="tile mt-8 flex flex-row justify-between">
			<img class="h-24 -ml-4 -mt-4 -mb-4" :src="heatray" />
			<p class="text-md font-semibold self-center">Want to use heatray for another organization?</p>
			<button class="bg-black text-gray-200 py-2 px-6 font-semibold rounded-3xl min-w-[204px]" @click="showLoader"><a
					v-if="!displayLoader">CREATE NEW HOOK</a>
				<button-loader v-if="displayLoader" /></button>
		</div>
		<h1 class="text-sm text-white text-center pt-8 pb-4">Invite your coworkers. <a href="#"
				style="color: #36c5f0;">Send
				invitation to an email.</a></h1>
		<div class="tile mt-8 min-h-[300px] flex flex-row rounded-sm">
			<img class="h-60 -ml-6" :src="Rocket" />
			<div class="flex flex-col pt-4">
				<p class="text-sm font-semibold pb-2">heatray CONNECT</p>
				<p class="text-xl font-semibold pb-2">Integrate your all apps using heatray.integration</p>
				<p>One plugin for fastest loging with highest security. <br /> Insanely fast. <br /> Insanely
					secure.</p>
			</div>
		</div>
	</section>
</template>

<script lang="ts">
	import {
		defineAsyncComponent,
		ref
	} from "vue";
	import heatrayIcon from "../assets/images/heatray-favicon-white.png";
	import heatray from "../assets/images/heatray_cutted.png";
	import Rocket from "../assets/images/rocket_heatray.png";
	const ButtonLoader = defineAsyncComponent(() => import("../components/ButtonLoader.vue"));

	export default {
		components: {
			ButtonLoader
		},
		setup() {
			const displayLoader = ref(false);

			function showLoader() {
				displayLoader.value = true;
				setTimeout(() => {
					displayLoader.value = false;
				}, 3000);
			}
			return {
				heatrayIcon,
				heatray,
				Rocket,
				displayLoader,
				showLoader
			}
		}
	}
</script>

<style>
	.items li {
		display: flex;
		align-items: center;
		margin-bottom: 10px;
		padding: 10px;
		border: 1px solid #ccc;
		border-radius: 5px;
		transition: transform 0.2s;
	}

	.items li:hover {
		transform: translateY(-5px);
		box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
	}

	.items li img {
		width: 40px;
		height: 40px;
		margin-right: 10px;
	}

	.name {
		flex: 1;
		font-size: 18px;
	}

	.tile-header {
		background-color: #d1ffee;
	}

	.heatray-icon:hover {
		animation: shake 0.5s;
	}

	@keyframes shake {
		0% {
			transform: translateX(0) rotate(0);
		}

		10% {
			transform: translateX(-5px) rotate(-5deg);
		}

		20% {
			transform: translateX(5px) rotate(5deg);
		}

		30% {
			transform: translateX(-5px) rotate(-5deg);
		}

		40% {
			transform: translateX(5px) rotate(5deg);
		}

		50% {
			transform: translateX(-5px) rotate(-5deg);
		}

		60% {
			transform: translateX(5px) rotate(5deg);
		}

		70% {
			transform: translateX(-5px) rotate(-5deg);
		}

		80% {
			transform: translateX(5px) rotate(5deg);
		}

		90% {
			transform: translateX(-5px) rotate(-5deg);
		}

		100% {
			transform: translateX(0) rotate(0);
		}
	}
</style>