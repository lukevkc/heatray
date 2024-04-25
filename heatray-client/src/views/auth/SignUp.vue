<template>
    <div class="flex justify-center items-center">
        <div
            class="mt-[10%] max-w-sm w-full p-6 rounded-lg shadow-lg bg-white transition-all duration-300 relative backdrop-blur-md z-10 hover:shadow-xl">
            <div class="flex justify-center items-center flex-col">
                <img :src="LogoBlack" alt="heatray.io" class="w-36 pt-8 pb-12 mr-2">
                <h1 class="text-xl font-semibold">Sign up into heatray</h1>
            </div>
            <form class="mt-6">
                <div>
                    <label for="login" class="block text-sm font-medium text-gray-700">Email</label>
                    <input type="text" id="login" name="login"
                        class="mt-1 p-2 w-full border rounded-md transition-all duration-300">
                </div>
                <div class="mt-4">
                    <label for="name" class="block text-sm font-medium text-gray-700">Name</label>
                    <input type="text" id="name" name="name"
                        class="mt-1 p-2 w-full border rounded-md transition-all duration-300">
                </div>
                <div class="mt-4">
                    <label for="password" class="block text-sm font-medium text-gray-700">Password</label>
                    <input type="password" id="password" name="password"
                        class="mt-1 p-2 w-full border rounded-md transition-all duration-300">
                </div>
                <button type="button" v-if="!showLoader"
					class="bg-black text-gray-200 mt-6 py-2 px-4 font-semibold rounded-xl button-3d self-center w-full"
					@click="signInAsync">
					Sign in</button>
				<button type="button" v-if="showLoader"
					class="bg-black text-gray-200 mt-6 py-2 px-4 font-semibold rounded-xl button-3d self-center w-full min-h-[40px]">
					<button-loader /></button>
                    <div class="mt-4 text-center">
                        <a href="#"
                            class="text-blue-500 transition-all duration-300 hover:text-gray-800 text-xs hover:underline">Have account yet? Sign in!</a>
                    </div>
            </form>
        </div>
    </div>
</template>

<script lang="ts">
    // @ts-ignore
    import {
		defineAsyncComponent,
		ref
	} from "vue";
	import LogoBlack from "../../assets/images/heatray-high-resolution-logo-black-transparent.png";
	const ButtonLoader = defineAsyncComponent(() => import("../../components/ButtonLoader.vue"));
    
    export default {
        setup() {
            const showLoader = ref(false);

			function signInAsync() {
				showLoader.value = true;
				setTimeout(() => {
					showLoader.value = false;
				}, 3000);
			}
			return {
				LogoBlack,
				showLoader,
				signInAsync
			}
        }
    }
</script>