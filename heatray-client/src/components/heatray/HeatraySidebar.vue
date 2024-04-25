<template>
    <aside :class="wideMode ? 'wide' : ''" class="rounded-r-xl sidebar backdrop-blur-md">
        <transition-slide class="w-full" :offset="['100%', 0]" group>
            <SidebarMain v-if="!contentSelected" @selected="selectContent()" @selectionReset="selectionReset()" :wideMode="wideMode"
                @goWide="goWide()" @goFull="goFull()" />
            <SidebarContent v-if="contentSelected" @selected="selectContent()" @selectionReset="selectionReset()" :wideMode="wideMode"
                @goWide="goWide()" @goFull="goFull()" />
        </transition-slide>
    </aside>
</template>

<script lang="ts">
    import {
        defineAsyncComponent,
        ref
    } from "vue";
    // @ts-ignore
    import { TransitionSlide } from '@morev/vue-transitions';
    const SidebarMain = defineAsyncComponent(() => import("./sidebar_sections/SidebarMain.vue"));
    const SidebarContent = defineAsyncComponent(() => import("./sidebar_sections/SidebarContent.vue"));

    export default {
        components: {
            SidebarMain,
            SidebarContent,
            TransitionSlide
        },
        setup() {
            const contentSelected = ref(false);
            const wideMode = ref(false);

            function selectContent() {
                contentSelected.value = !contentSelected.value;
            }

            function selectionReset() {
                contentSelected.value = false;
            }

            function goWide() {
                wideMode.value = true;
            }

            function goFull() {
                wideMode.value = false;
            }
            return {
                contentSelected,
                wideMode,
                selectContent,
                selectionReset,
                goWide,
                goFull
            };
        }
    }
</script>

<style>
    aside {
        background-color: #082f49e8;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        position: fixed;
        top: 0;
        left: 0;
        bottom: 0;
        width: 250px;
        display: flex;
        flex-direction: column;
        align-items: center;
        overflow-y: auto;
    }

    aside.wide {
        width: 80px;
    }

    .project-active {
        background-color: #093958;
        border-radius: 20px;
        ;
    }

    .section-active {
        background-color: #093958;
        border-radius: 20px;
        padding: 3px;
        margin: -3px;
    }

    .selectable:hover {
        background-color: #093958;
        border-radius: 20px;
    }

    .sidebar-container {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .workspace {
        display: flex;
        align-items: center;
        margin-bottom: 20px;
    }

    .project-icon img {
        width: 20px;
        height: 20px;
        background-color: #F8F8F9;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .workspace-icon img {
        width: 45px;
        height: 45px;
        background-color: #F8F8F9;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .workspace span {
        color: #ffffff;
        font-size: 18px;
        font-weight: bold;
        margin-top: 10px;
        text-align: center;
    }

    .content-list {
        list-style-type: none;
    }

    .content-list li {
        margin-bottom: 10px;
    }

    .content-list li span {
        color: #ffffff;
        font-size: 16px;
        font-weight: bold;
        margin-bottom: 5px;
    }

    .content-list li ul {
        list-style-type: none;
        padding-left: 20px;
    }

    .content-list li ul li {
        color: #ffffff;
        font-size: 14px;
        margin-bottom: 5px;
    }

    .btn {
        height: 12px;
        width: 12px;
        margin: 3px;
        border-radius: 50%;
        cursor: pointer;
    }

    .btn1 {
        background: #fac536;
        position: relative;
        overflow: hidden;
    }

    .btn1::before {
        content: '';
        position: absolute;
        top: 100%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 50%;
        height: 10%;
        opacity: 0;
        background: #222;
        transition: 300ms;
    }

    .btn1:hover::before {
        opacity: 1;
        top: 50%;
    }

    .btn2 {
        background: #39ea49;
        position: relative;
        overflow: hidden;
    }

    .btn2::before {
        content: '';
        position: absolute;
        top: 100%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 45%;
        height: 45%;
        opacity: 0;
        background: #222;
        transition: 300ms;
    }

    .btn2::after {
        content: '';
        position: absolute;
        top: 100%;
        left: 50%;
        transform: translate(-50%, -50%) rotate(-45deg);
        width: 15%;
        height: 80%;
        opacity: 0;
        background: #39ea49;
        transition: 300ms;
    }

    .btn2:hover::before,
    .btn2:hover::after {
        opacity: 1;
        top: 50%;
    }

    .btn3 {
        background: #f25056;
        position: relative;
        overflow: hidden;
    }

    .btn3::before {
        content: '';
        position: absolute;
        top: 100%;
        left: 50%;
        transform: translate(-50%, -50%) rotate(-45deg);
        width: 15%;
        height: 50%;
        opacity: 0;
        background: #222;
        transition: 300ms;
    }

    .btn3::after {
        content: '';
        position: absolute;
        top: 100%;
        left: 50%;
        transform: translate(-50%, -50%) rotate(45deg);
        width: 15%;
        opacity: 0;
        height: 50%;
        background: #222;
        transition: 300ms;
    }

    .btn3:hover::before,
    .btn3:hover::after {
        opacity: 1;
        top: 50%;
    }

    .sidebar {
        -webkit-transition: width 1s ease-in-out;
        -moz-transition: width 1s ease-in-out;
        -o-transition: width 1s ease-in-out;
        transition: width 1s ease-in-out;
    }
</style>