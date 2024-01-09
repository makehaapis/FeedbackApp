import { defineStore } from 'pinia'
import feedbackService from '../services/FeedbackService'

export const useFeedbackStore = defineStore("feedbacks", {
    state: () => ({
        feedbacks: [],
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
        async createContents(payload) {
            try {
                const data = await feedbackService.create(payload);
                this.feedbacks.push(data);
                this.notification = "Thank you for your feedback"
                setTimeout(() => this.notification = '', 5000);
            } catch (error) {
                this.notification = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
        async removeContent(payload) {
            try {
                const data = await feedbackService.remove(payload);
                console.log(data.status)
                if (data.status == 204) {
                    this.feedbacks = this.feedbacks.filter((e) => e.id !== payload)
                    this.notification = "Deleted feedback id: "+ payload
                    setTimeout(() => this.notification = '', 5000);
                }
            } catch (error) {
                this.errorMessage = error.message
                setTimeout(() => this.notification = '', 5000);
            }
        },
    },
})