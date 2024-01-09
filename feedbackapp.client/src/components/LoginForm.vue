<script>
    import useVuelidate from '@vuelidate/core'
    import { required, email } from '@vuelidate/validators'
    import { useUserStore } from '../store/user'
    import loginService from '../services/login'
    import storageService from '../services/storage'
    import { storeToRefs } from 'pinia'
    const store = useUserStore()
    const { setUser } = store

    export default {
        setup() {
            const store = useUserStore()
            const { user } = storeToRefs(store)
            return { v$: useVuelidate(), user }
        },
        methods: {
            submit: async function () {
                try {
                    const email = this.form.email
                    const password = this.form.password
                    setUser(email, password)
                    this.$refs.loginForm.reset();
                } catch (error) {
                    console.log(error)
                    this.$refs.loginForm.reset();
                }
            },
        },
        data() {
            return {
                form: {
                    email: '',
                    password: '',
                },
            }
        },
        validations() {
            return {
                form: {
                    email: { required, email },
                    password: { required }
                },
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
    <div class="container-sm">
        <div class="row">
            <div class="col-sm"></div>
            <div class="col-sm">
                    <form @submit.prevent="submit" ref="loginForm">
                        <div class="form-group" :class="{ error: v$.form.email.$errors.length }">
                            <label class="text-white">Email: </label>
                            <input class="form-control" placeholder="Enter your email" type="text" v-model="v$.form.email.$model"></input>
                            <div class="pre-icon os-icon os-icon-user-male-circle"></div>
                            <div class="input-errors" v-for="(error, index) of v$.form.email.$errors" :key="index">
                                <div class="error-msg text-danger">{{ error.$message }}</div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="text-white">Password: </label>
                            <input class="form-control" placeholder="Enter password" type="password" v-model="v$.form.password.$model">
                            <div class="pre-icon os-icon os-icon-user-male-circle"></div>
                            <div class="input-errors" v-for="(error, index) of v$.form.password.$errors" :key="index">
                                <div class="error-msg text-danger">{{ error.$message }}</div>
                            </div>
                        </div>
                        <div class="buttons-w">
                            <button :disabled="v$.form.$invalid" class="btn btn-primary">Login</button>
                        </div>
                    </form>
            </div>
            <div class="col-sm"></div>
        </div>
    </div>
</template>