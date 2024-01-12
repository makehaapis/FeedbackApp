<script>
    import { useFeedbackStore } from '../store/feedbacks'
    import { storeToRefs } from 'pinia'

    export default {
        setup() {
            const store = useFeedbackStore()
            const { fetchFeedbacks } = store
            fetchFeedbacks()
            const { feedbacks } = storeToRefs(store)
            return { feedbacks }
        },
        methods: {
            submit: function (id) {
                const store = useFeedbackStore();
                const { removeContent } = store;
                removeContent(id)
                const { feedbacks } = storeToRefs(store)
                return { feedbacks }
            }
        },
    }

</script>

<template>
    <table class="table table-dark table-striped">
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Name</th>
                <th scope="col">Description</th>
                <th scope="col">Email</th>
                <th scope="col">Rating</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="feedback in feedbacks" :key="feedback.id">
                <th scope="row">{{ feedback.id }}</th>
                <td>{{ feedback.name }}</td>
                <td>{{ feedback.description }}</td>
                <td>{{ feedback.email }}</td>
                <td>{{ feedback.rating }}</td>
                <td><button @click="submit(feedback.id)" class="btn btn-danger">DELETE</button></td>
            </tr>
        </tbody>
    </table>
</template>