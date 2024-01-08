import { defineStore } from 'pinia'
import feedbackService from '../services/FeedbackService'

export const useFeedbackStore = defineStore("feedbacks", {
    state: () => ({
        feedbacks: [],
        randomFeedbacks: [],
        notification: '',
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
                this.notification = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
        async randomizeFeedbacks() {
            try {
                const data = await feedbackService.getAll()
                this.randomFeedbacks = data
                    .map(value => ({ value, sort: Math.random() }))
                    .sort((a, b) => a.sort - b.sort)
                    .map(({ value }) => value);
            }
            catch (error) {
                this.notification = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
        async createContents(payload) {
            console.log(payload)
            try {
                const data = await feedbackService.create(payload);
                this.feedbacks.push(data);
                this.notification = "Thank you for your feedback"
                setTimeout(() => this.notification = '', 5000);
            } catch (error) {
                this.errorMessage = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
    },
})