// stores/feedbacks.js
import { defineStore } from 'pinia'
import feedbackService from '../services/FeedbackService'

export const useFeedbackStore = defineStore("feedbacks", {
    state: () => ({
        feedbacks: [],
    }),
    getters: {
        getFeedbacks(state) {
            console.log(state)
            return state.feedbacks
        }
    },
    actions: {
        async fetchFeedbacks() {
            try {
                const data = await feedbackService.getAll()
                this.feedbacks = data;
            }
            catch (error) {
                alert(error)
                console.log(error)
            }
        },
        async createContents(payload) {
            console.log(payload)
            try {
                const data = await feedbackService.create(payload);
                this.feedbacks.push(data);
            } catch (err) {
                console.error('Post ERROR!', err);
            }
        }
    },
})