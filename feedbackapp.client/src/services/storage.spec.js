import { beforeEach, describe, expect, test, vi } from 'vitest'
import storage from './storage'
import axios from 'axios'

describe('Storage', () => {
    beforeEach(() => {
        localStorage.removeItem('FeedbackappUser')
    })

    describe('user storage', () => {
        test('saves user to window local storage', () => {
            const newUserMock = {
                email: "email@email.com",
                token: "x23423"
            }

            storage.saveUser(newUserMock)
            expect(newUserMock).toStrictEqual(JSON.parse(window.localStorage.getItem('FeedbackappUser')))
        })
    })

    describe('user storage', () => {
        test('loads user from window local storage', () => {
            const newUserMock = {
                email: "email@email.com",
                token: "x23423"
            }

            storage.saveUser(newUserMock)
            const user = storage.loadUser()
            expect(newUserMock).toStrictEqual(user)
        })
    })

    describe('user storage', () => {
        test('removes user from window local storage', () => {
            const newUserMock = {
                email: "email@email.com",
                token: "x23423"
            }
            storage.saveUser(newUserMock)
            storage.removeUser()
            expect(window.localStorage.getItem('FeedbackappUser')).equal(null)
        })
    })
})