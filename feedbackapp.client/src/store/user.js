import { defineStore } from 'pinia'
import storageService from '../services/storage'
import loginService from '../services/login'

export const useUserStore = defineStore("user", {
    state: () => ({
        user: null,
        errorMessage: ''
    }),
    getters: {
        userState(state) {
            return state.user
        }
    },
    actions: {
        async setUser(email, password) {
            try {
                const userFromDb = await loginService.login({ email, password })
                this.user = userFromDb
                storageService.saveUser(userFromDb)
            } catch (error) {
                this.errorMessage = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
        loadUser() {
            const user = storageService.loadUser()
            if (user) {
                this.user = user
            }
        },
        logOutUser() {
            storageService.removeUser()
            this.user = null
            this.notification = "Logged out"
            setTimeout(() => this.notification = '', 5000);
        }
    },
})