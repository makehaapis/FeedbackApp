const KEY = 'FeedbackappUser'
let token = null

//Saves user token to localstorage
const saveUser = (user) => {
    localStorage.setItem(KEY, JSON.stringify(user))
}

//load user token from local storage
const loadUser = () => {
    if (window !== undefined) {
        // browser code
    const loggedUserJSON = window.localStorage.getItem(KEY)
    if (loggedUserJSON) {
        const user = JSON.parse(loggedUserJSON)
        token = user.token
        return user
    }
        return null
    }
}

//removes user token from local storage
const removeUser = () => {
    localStorage.removeItem(KEY)
    token = null
}
const getToken = () => token

export default {
    saveUser,
    loadUser,
    removeUser,
    getToken
}