import axios from 'axios'
import storageService from './storage'

//use this for local build
const baseUrl = 'https://localhost:7287/api/Feedbacks'

//use this for azure web app
//const baseUrl = '/api/Feedbacks'

//bearer token set to headers if in local storage
const headers = {
    Authorization: storageService.loadUser() ? `Bearer ${storageService.loadUser().token}` : null
}

//get https://localhost:7287/api/Feedbacks
const getAll = async () => {
    const request = await axios.get(baseUrl)
    return request.data
}

//post https://localhost:7287/api/Feedbacks
const create = async (object) => {
    const request = await axios.post(baseUrl, object)
    return request.data
}

//delete https://localhost:7287/api/Feedbacks
const remove = async (id) => {
    const response = await axios.delete(`${baseUrl}/${id}`, { headers })
    return response
}

export default { getAll, create, remove }