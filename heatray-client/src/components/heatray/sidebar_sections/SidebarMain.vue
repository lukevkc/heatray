<template>
    <div class="sidebar-container w-full">
        <div class="buttons-menu flex self-start p-2 pb-1 pl-4">
            <div @click="$emit('goWide', 1)" class="btn btn1"></div>
            <div @click="$emit('goFull', 1)" class="btn btn2"></div>
            <div @click="$emit('selectionReset', 1)" class="btn btn3"></div>
        </div>
        <div class="workspace w-full flex flex-row p-4 justify-between">
            <div class="workspace-icon">
                <img src="../../../assets/images/heatray-favicon-color.png" alt="Workspace Icon">
            </div>
            <span v-show="!wideMode" class="ml-3">Workspace</span>
            <i v-show="!wideMode" class="pt-2 fa-solid fa-cog text-white selectable cursor-pointer"></i>
        </div>
        <ul class="content-list w-full text-left p-2">
            <li :class="wideMode ? 'text-center' : ''" class="pb-4 project-active p-4">
                <div :class="wideMode ? 'text-center !place-content-center pb-2' : ''" class="flex flex-row justify-between items-baseline pb-1">
                    <div :class="wideMode ? '' : 'pr-2'" class="project-icon">
                        <img src="../../../assets/images/heatray-favicon-color.png" alt="Workspace Icon">
                    </div>
                    <span v-show="!wideMode">Ecologic.io</span>
                    <i v-show="!wideMode" class="fa-solid fa-bars text-white selectable cursor-pointer"></i>
                </div>
                <ul :class="wideMode ? 'text-center' : ''" class="!pl-1">
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable section-active">
                        <p v-if="!wideMode">#secrets</p><i v-if="wideMode"
                            class="fa-solid fa-question text-white selectable cursor-pointer"></i>
                    </li>
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable">
                        <p v-if="!wideMode">#threads</p><i v-if="wideMode"
                        class="fa-solid fa-book text-white selectable cursor-pointer"></i>
                    </li>
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable">
                        <p v-if="!wideMode">#logs</p><i v-if="wideMode"
                        class="fa-solid fa-eye text-white selectable cursor-pointer"></i>
                    </li>
                </ul>
            </li>
            <li :class="wideMode ? 'text-center' : ''" class="pb-4 p-1">
                <div :class="wideMode ? 'text-center !place-content-center pb-2' : ''" class="flex flex-row justify-between items-baseline pb-1">
                    <div :class="wideMode ? '' : 'pr-2'" class="project-icon">
                        <img src="../../../assets/images/heatray-favicon-color.png" alt="Workspace Icon">
                    </div>
                    <span v-show="!wideMode">Vaiap.io</span>
                    <i v-show="!wideMode" class="fa-solid fa-bars text-white selectable cursor-pointer"></i>
                </div>
                <ul :class="wideMode ? 'text-center' : ''" class="!pl-1">
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable">
                        <p v-if="!wideMode">#secrets</p><i v-if="wideMode"
                            class="fa-solid fa-question text-white selectable cursor-pointer"></i>
                    </li>
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable">
                        <p v-if="!wideMode">#threads</p><i v-if="wideMode"
                        class="fa-solid fa-book text-white selectable cursor-pointer"></i>
                    </li>
                    <li :class="wideMode ? 'text-center' : ''" @click="$emit('selected', 1)" class="pb-1 cursor-pointer selectable">
                        <p v-if="!wideMode">#logs</p><i v-if="wideMode"
                        class="fa-solid fa-eye text-white selectable cursor-pointer"></i>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>

<script lang="ts">
    import {
        toRef
    } from "vue";

    export default {
        props: ['wideMode'],
        setup(props) {
            const wideMode = toRef(props, 'wideMode');
            return {
                wideMode
            }
        }
    }
</script>