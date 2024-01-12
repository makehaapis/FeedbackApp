<script setup>

    import { useFeedbackStore } from '../store/feedbacks'
    import { useUserStore} from '../store/user'
    import { storeToRefs } from 'pinia'

    const userStore = useUserStore()
    const store = useFeedbackStore()
    const { notification } = storeToRefs(store)
    const { errorMessage } = storeToRefs(userStore)

</script>

<template>
    <div class="container">
        <h3 class="text-light text-center" v-if="notification">{{ notification }}</h3>
        <h3 class="text-light text-center" v-if="errorMessage">{{ errorMessage }}</h3>
    </div>
</template>