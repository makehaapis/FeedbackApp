<script>
    import LoginForm from '../components/LoginForm.vue'
    import FeedbackDeleteForm from '../components/FeedbackDeleteForm.vue'
    import { useUserStore } from '../store/user'
    import { storeToRefs } from 'pinia'
    import { useFeedbackStore } from '../store/feedbacks'

    export default {
        setup() {
            const userStore = useUserStore()
            const { user } = storeToRefs(userStore)
            return { user }
        },
        mounted() {
            const store = useUserStore()
            const { loadUser } = store
            loadUser()
        },
        components: {
            LoginForm,
            FeedbackDeleteForm
        }
    }
</script>

<template>
    <div class="container-sm">
        <div class="row">
            <div class="col-sm">
                <div v-if="user===null">
                    <LoginForm />
                </div>
                <div v-else>
                    <h1 class="display-1 text-center text-light">ADMIN PAGE</h1>
                    <p class="text-light text-center">logged in as {{ user.email }}</p>
                    <FeedbackDeleteForm />
                </div>
            </div>
        </div>
    </div>
</template>

