import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import { library } from "@fortawesome/fontawesome-svg-core";
import { faInstagram, faFacebook, faTwitter } from "@fortawesome/free-brands-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faPhone, faHome, faStar, faLock } from "@fortawesome/free-solid-svg-icons";

library.add(faTwitter, faPhone, faFacebook, faInstagram, faHome, faStar, faLock);

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

const pinia = createPinia();

createApp(App)
    .use(router)
    .use(pinia)
    .component('font-awesome-icon', FontAwesomeIcon)
    .mount('#app')
