const KEY = 'FeedbackappUser'
let token = null

const saveUser = (user) => {
    localStorage.setItem(KEY, JSON.stringify(user))
    console.log(loadUser())
}

const loadUser = () => {
    const loggedUserJSON = window.localStorage.getItem(KEY)
    if (loggedUserJSON) {
        const user = JSON.parse(loggedUserJSON)
        token = user.token
        return user
    }
    return null
}

const removeUser = () => {
    localStorage.removeItem(KEY)
}

export default {
    saveUser,
    loadUser,
    removeUser
}