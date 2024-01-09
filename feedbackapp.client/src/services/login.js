import axios from 'axios'
const baseUrl = 'https://localhost:7287/api/login'

const login = async (credentials) => {
    console.log(credentials)
    const response = await axios.post(baseUrl, credentials)
    return response.data
}

export default { login }