<script>
    import { useUserStore } from '../store/user'
    import { storeToRefs } from 'pinia'

    export default {
        setup() {
            const store = useUserStore()
            const { user } = storeToRefs(store)
            return { user }
        },
        methods: {
            logout() {
                console.log("clicked")
                const store = useUserStore()
                store.logOutUser()
            }
        },
        mounted() {
            const store = useUserStore()
            const { loadUser } = store
            loadUser()
        }
    }
</script>

<template>
    <nav class="navbar navbar-expand-lg navbar-dark">
        <div class="container fluid">
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-center" id="navbarNavAltMarkup">
                <div class="navbar-nav ml-auto text-center">
                    <router-link to="/" class="nav-link text-center">HOME</router-link>
                    <router-link to="/about" class="nav-link text-center">ABOUT</router-link>
                    <router-link to="/contact" class="nav-link text-center">CONTACT</router-link>
                    <router-link to="/admin" v-if="user" class="nav-link text-center">ADMIN PAGE</router-link>
                    <a href="https://twitter.com/?lang=en" class="nav-link text-center my-auto"><font-awesome-icon :icon="['fab', 'twitter']" /></a>
                    <a href="https://facebook.com/" class="nav-link text-center my-auto"><font-awesome-icon :icon="['fab', 'facebook']" /></a>
                    <a href="https://instagram.com/?lang=en" class="nav-link text-center my-auto"><font-awesome-icon :icon="['fab', 'instagram']" /></a>
                    <router-link to="/admin" class="nav-link text-center my-auto" v-if="user === null"><font-awesome-icon icon="lock"/>LOGIN</router-link>
                    <button @click="logout" class="nav-link text-center my-auto" v-if="user"><font-awesome-icon icon="lock" />LOGOUT</button>
                    </div>
                </div>
            </div>
    </nav>
</template>

<style>
    .nav-link {
        font-size: 1.5em;
    }

    .navbar-brand {
        font-size: 2em;
    }
</style>