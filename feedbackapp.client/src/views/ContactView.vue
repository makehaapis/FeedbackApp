<script setup>
    import { useFeedbackStore } from "../store/feedbacks.js";
    import { storeToRefs } from 'pinia';
    import { onMounted } from 'vue';
    import FeedbackForm from '../components/FeedbackForm.vue'

    const store = useFeedbackStore();
    const { feedbacks } = storeToRefs(store);
    const { fetchFeedbacks, randomizeFeedbacks } = store;

    onMounted(() => {
        fetchFeedbacks();
    });
</script>

<template>
    <div class="row">
        <div v-for="item in feedbacks" :key="item.id">
            <div class="text-white">{{ item.name }} {{ item.description }} {{ item.rating }}</div>
        </div>
    </div>
    <div>
        <FeedbackForm />
    </div>
</template>

<style>
    .mydiv {
        height: 40px;
    }
    .myImg {
        width: 100%;
        height: auto;
    }
</style>