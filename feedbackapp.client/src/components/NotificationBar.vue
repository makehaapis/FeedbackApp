<template>
    <div class="container">
        <h3 class="text-light text-center" v-if="notification">{{ notification }}</h3>
    </div>
</template>

<script setup>
    import { useFeedbackStore } from '../store/feedbacks'
    import { storeToRefs } from 'pinia'

    const store = useFeedbackStore()
    const { notification } = storeToRefs(store)
</script>