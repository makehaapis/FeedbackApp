import axios from 'axios'
//use this for local build
const baseUrl = 'https://localhost:7287/api/login'

//use this for azure web app
//const baseUrl = '/api/login'


//post https://localhost:7287/api/login with email and password
const login = async (credentials) => {
    const response = await axios.post(baseUrl, credentials)
    return response.data
}

export default { login }