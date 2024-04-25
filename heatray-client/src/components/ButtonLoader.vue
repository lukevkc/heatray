<template>
    <div class="jawn"></div>
</template>

<style lang="scss">
    .jawn {
        position: relative;
        background-color: #F8E71C;
        width: 10px;
        height: 10px;
        margin: 0 auto;
        border-radius: 50%;

        &:after,
        &:before {
            content: "";
            position: absolute;
            width: 5px;
            height: 5px;
            border-radius: 50%;
        }

        &:after {
            left: -4px;
            top: -2px;
            background-color: #C7C2A6;
            transform-origin: 10px 6px;
            animation: axis 1.2s linear infinite;
        }

        &:before {
            left: -8px;
            top: -6px;
            background-color: #ff3b14;
            transform-origin: 14px 12px;
            animation: axis 2s linear infinite;
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