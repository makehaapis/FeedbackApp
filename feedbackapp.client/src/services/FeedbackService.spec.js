import { beforeEach, describe, expect, test, vi } from 'vitest'
import feedbackService from './FeedbackService'
import axios from 'axios'

vi.mock('axios')

describe('Users Service', () => {
    beforeEach(() => {
        axios.get.mockReset()
        axios.post.mockReset()
    })

    describe('getFeedbacks', () => {
        test('makes a GET request to get Feedbacks', async () => {
            const feedbacksMock = [{ id: 1, Name: 'Name 1' }, { id: 2, Name: 'Name 2' }]

            axios.get.mockResolvedValue({
                data: feedbacksMock,
            })

            const feedbacks = await feedbackService.getAll()
            expect(axios.get).toHaveBeenCalledWith('https://localhost:7287/api/Feedbacks')
            expect(feedbacks).toStrictEqual(feedbacksMock)
        })
    })

    describe('addFeedback', () => {
        test('makes a POST request to create a new feedback', async () => {
            const newFeedbackPayload = {
                name: 'john doe',
            }

            const newFeedbackMock = {
                id: 1,
                ...newFeedbackPayload,
            }

            axios.post.mockResolvedValue({
                data: newFeedbackMock,
            })

            const newFeedback = await feedbackService.create(newFeedbackPayload)

            expect(axios.post).toHaveBeenCalledWith('https://localhost:7287/api/Feedbacks', newFeedbackPayload)
            expect(newFeedback).toStrictEqual(newFeedbackMock)
        })
    })
})