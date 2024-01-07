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
                    <a href="https://twitter.com/?lang=en" class="my-auto"><font-awesome-icon :icon="['fab', 'twitter']" class="nav-link" /></a>
                    <a href="https://facebook.com/" class="my-auto"><font-awesome-icon :icon="['fab', 'facebook']" class="nav-link" /></a>
                    <a href="https://instagram.com/?lang=en" class="my-auto"><font-awesome-icon :icon="['fab', 'instagram']" class="nav-link" /></a>
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