<template>
    <div class="app bg-slate-100 min-h-[95vh] overflow-hidden">
        <heatrayHeader class="z-10" />
        <heatraySidebar class="z-20" />
        <main>
            <div class="overflow-hidden absolute w-full h-[100vh] top-0 pointer-events-none">
                <div class="bigjawn"></div>
                <div class="bigjawn-second"></div>
                <div class="bigjawn-third"></div>
                <div class="bigjawn-fourth"></div>
            </div>
            <router-view v-slot="{ Component, route }" v-if="routerHeartbeat" @reload="reloadRouter">
                <Transition mode="out-in">
                    <component :is="Component" :key="route.fullPath" />
                </Transition>
            </router-view>
        </main>
    </div>
</template>

<script lang="ts">
    import {
        defineAsyncComponent,
        ref
    } from "vue"
    const heatrayHeader = defineAsyncComponent(() => import("../components/heatray/HeatrayHeader.vue"));
    const heatraySidebar = defineAsyncComponent(() => import("../components/heatray/HeatraySidebar.vue"));

    export default {
        components: {
            heatrayHeader,
            heatraySidebar
        },
        setup() {
            const routerHeartbeat = ref(true);

            function reloadRouter() {
                //ignore
            }

            return {
                routerHeartbeat,
                reloadRouter
            }
        }
    }
</script>

<style lang="scss">
  .bigjawn {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    margin: 0 auto;
    border-radius: 50%;

    &:after,
    &:before {
      content: "";
      position: absolute;
      width: 30px;
      height: 30px;
      border-radius: 50%;
    }

    &:after {
      left: -160px;
      top: -160px;
      background-color: #C7C2A6;
      transform-origin: 160px 160px;
      animation: axis 12s linear infinite;
    }

    &:before {
      left: -240px;
      top: -240px;
      background-color: #ff3b14;
      transform-origin: 240px 240px;
      animation: axis 10s linear infinite;
    }
  }

  .bigjawn-second {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    margin: 0 auto;
    border-radius: 50%;

    &:after,
    &:before {
      content: "";
      position: absolute;
      width: 40px;
      height: 40px;
      border-radius: 50%;
    }

    &:after {
      left: -280px;
      top: -280px;
      background-color: #5d9eff;
      transform-origin: 280px 280px;
      animation: axis 20s linear infinite;
    }

    &:before {
      left: -330px;
      top: -330px;
      background-color: #50312b;
      transform-origin: 330px 330px;
      animation: axis 18s linear infinite;
    }
  }

  .bigjawn-third {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    margin: 0 auto;
    border-radius: 50%;

    &:after,
    &:before {
      content: "";
      position: absolute;
      width: 65px;
      height: 65px;
      border-radius: 50%;
    }

    &:after {
      left: -380px;
      top: -380;
      background-color: #ffd95d;
      transform-origin: 380px 380px;
      animation: axis 22s linear infinite;
    }

    &:before {
      left: -435px;
      top: -435px;
      background-color: #34ffff;
      transform-origin: 435px 435px;
      animation: axis 16s linear infinite;
    }
  }

  .bigjawn-fourth {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    margin: 0 auto;
    border-radius: 50%;

    &:after,
    &:before {
      content: "";
      position: absolute;
      width: 72px;
      height: 72px;
      border-radius: 50%;
    }

    &:after {
      left: -500px;
      top: -500px;
      background-color: #3ba78c;
      transform-origin: 500px 500px;
      animation: axis 28s linear infinite;
    }

    &:before {
      left: -575px;
      top: -575px;
      background-color: #ff5234;
      transform-origin: 575px 575px;
      animation: axis 26s linear infinite;
    }
  }

  @keyframes axis {
    0% {
      transform: rotateZ(0deg) translate3d(0, 0, 0);
    }

    100% {
      transform: rotateZ(360deg) translate3d(0, 0, 0);
    }
  }
</style>