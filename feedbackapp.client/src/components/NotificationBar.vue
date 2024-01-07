<template>
    <div class="container">
        <h3 class="text-light text-center" v-if="errorMessage">{{errorMessage}}</h3>
    </div>
</template>

<script setup>
    import { useFeedbackStore } from '../store/feedbacks'
    import { storeToRefs } from 'pinia'

    const store = useFeedbackStore()
    const { errorMessage } = storeToRefs(store)
</script>