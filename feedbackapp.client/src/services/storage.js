const KEY = 'FeedbackappUser'
let token = null

//Saves user token to localstorage
const saveUser = (user) => {
    localStorage.setItem(KEY, JSON.stringify(user))
    console.log(loadUser())
}

//load user token from local storage
const loadUser = () => {
    const loggedUserJSON = window.localStorage.getItem(KEY)
    if (loggedUserJSON) {
        const user = JSON.parse(loggedUserJSON)
        token = user.token
        return user
    }
    return null
}

//removes user token from local storage
const removeUser = () => {
    localStorage.removeItem(KEY)
    token = null

    const loggedUserJSON = window.localStorage.getItem(KEY)
    console.log(loggedUserJSON)
}
const getToken = () => token

export default {
    saveUser,
    loadUser,
    removeUser,
    getToken
}