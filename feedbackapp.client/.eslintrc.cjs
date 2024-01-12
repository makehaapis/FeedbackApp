/* eslint-env node */
module.exports = {
    env: {
        node: true,
    },
    extends: [
        'eslint:recommended',
        "plugin:vue/vue3-recommended",
        "prettier"
    ],
    rules: {
        'linebreak-style': 0,
    },
}