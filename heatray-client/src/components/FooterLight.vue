<script lang="ts">
    import LogoBlack from "../assets/images/heatray-high-resolution-logo-black-transparent.png";
    export default {
        setup() {
            return {
                LogoBlack
            }
        }
    }
</script>

<template>
    <footer class="footer">
        <div class="footer-content justify-center">
            <div class="footer-logo">
                <img class="h-8" :src="LogoBlack" alt="Logo">
            </div>
        </div>
        <div class="footer-bottom text-xs">
            &copy; 2024 heatray. All rights reserved.
        </div>
    </footer>
</template>

<style>
    .footer {
        background-color: #fff;
        color: #3d2d28;
        padding: 30px 0;
    }

    .footer-content {
        max-width: 1200px;
        margin: 0 auto;
        display: flex;
        flex-wrap: wrap;
    }

    .footer-links ul {
        list-style: none;
        padding: 0;
        margin: 0;
    }

    .footer-links li {
        margin-bottom: 10px;
    }

    .footer-links a {
        color: #3d2d28;
        text-decoration: none;
        transition: color 0.2s;
    }

    .footer-links a:hover {
        color: #bbb;
    }

    .footer-social {
        margin-top: 20px;
    }

    .social-icon {
        display: inline-block;
        width: 40px;
        height: 40px;
        background-color: #3d2d28;
        color: #fff;
        text-align: center;
        line-height: 40px;
        font-size: 20px;
        margin-right: 10px;
        border-radius: 50%;
        transition: background-color 0.2s;
    }

    .social-icon:hover {
        background-color: #444;
    }

    .footer-bottom {
        text-align: center;
        margin-top: 20px;
        color: #ccc;
    }
</style>