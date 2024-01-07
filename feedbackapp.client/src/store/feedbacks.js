import { defineStore } from 'pinia'
import feedbackService from '../services/FeedbackService'

export const useFeedbackStore = defineStore("feedbacks", {
    state: () => ({
        feedbacks: [],
        randomFeedbacks: [],
        errorMessage: '',
    }),
    getters: {
        getFeedbacks(state) {
            return state.feedbacks
        }
    },
    actions: {
        async fetchFeedbacks() {
            try {
                const data = await feedbackService.getAll()
                this.feedbacks = data
            }
            catch (error) {
                this.errorMessage = error.message
            }
        },
        async randomFeedbacks() {
            try {
                const data = await feedbackService.getAll()
                this.feedbacks = data
                    .map(value => ({ value, sort: Math.random() }))
                    .sort((a, b) => a.sort - b.sort)
                    .map(({ value }) => value);
            }
            catch (error) {
                this.errorMessage = error.message
            }
        },
        async createContents(payload) {
            console.log(payload)
            try {
                const data = await feedbackService.create(payload);
                this.feedbacks.push(data);
            } catch (error) {
                this.errorMessage = error.message
            }
        },
    },
})