<script setup>
    import NavigationBar from './components/NavigationBar.vue'
    import NotificationBar from './components/NotificationBar.vue'
</script>

<template>
    <body>
        <NavigationBar />
        <NotificationBar />
        <div class="mydiv"></div>
        <div class="container">
            <router-view />
        </div>
    </body>
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
</style>