<script setup>
    import NavigationBar from './components/NavigationBar.vue'
    import NotificationBar from './components/NotificationBar.vue'
</script>

<template>
    <NavigationBar />
    <div class="mydiv"></div>
    <NotificationBar />
    <router-view />
</template>

<style>
    .html {
        height: 100vh;
    }
    body {
        background-image: url("./assets/pizza-3007395.jpg");
        background-position: center center;
        background-repeat: no-repeat;
        background-attachment: fixed;
        background-size: cover;
        background-color: #464646;
        margin: 0 0 0 0;
        height: 100vh;
    }
    .mydiv {
        height: 40px;
    }
    .myImg {
        width: 20%;
        height: auto;
    }
</style>