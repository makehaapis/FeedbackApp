import { beforeEach, describe, expect, test, vi } from 'vitest'
import loginService from './login'
import axios from 'axios'

vi.mock('axios')

describe('Login Service', () => {
    beforeEach(() => {
        axios.post.mockReset()
    })

    describe('postLogin', () => {
        test('makes a POST request to login', async () => {
            const newCredentialsPayload = {
                email: "email@email.com",
                password: "password"
            }

            const newCredentialsMock = {
                id: 1,
                ...newCredentialsPayload
            }

            axios.post.mockResolvedValue({
                data: newCredentialsMock,
            })

            const result = await loginService.login(newCredentialsPayload)

            expect(axios.post).toHaveBeenCalledWith('https://localhost:7287/api/login', newCredentialsPayload)
            expect(result).toStrictEqual(newCredentialsMock)
        })
    })
})