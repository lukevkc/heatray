<template>
    <header class="bg-transparent backdrop-blur-md">
        <div class="header-container w-full flex flex-row pl-32">
            <div class="lg:w-7/12"></div>
            <div class="user-profile lg:w-5/12 place-content-end">
                <img src="../../assets/images/heatray-favicon-color.png" alt="Account">
            </div>
        </div>
    </header>
</template>

<style>
header {
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    height: 42px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 0 20px;
}

.header-container {
    display: flex;
    align-items: center;
}

.search-bar {
    padding: 5px 20px;
    margin-right: 20px;
    display: flex;
    align-items: center;
}

.search-bar input {
    border: none;
    background-color: transparent;
    color: white;
    outline: none;
    width: 100%;
}

.user-profile {
    display: flex;
    align-items: center;
}

.user-profile img {
    width: 30px;
    height: 30px;
    border-radius: 50%;
    margin-left: 10px;
}
</style>