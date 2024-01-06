<template>
    <form>
        <label>asd<input v-model="postData.Description" type="text" /></label>
        <label>asd<input v-model="postData.Name" type="text" /></label>
        <label>asd<input v-model="postData.Email" type="text" /></label>
        <input type="text" :value="Name" @input="setName">
        <input type="text" :value="Description" @input="setDescription">
        <input type="text" :value="Email" @input="setEmail">
        <button @click.prevent="addPostData">submit</button>
    </form>
</template>

<script setup>
    import {useFeedbackStore} from '../store/feedbacks';
    import {ref} from 'vue';
    import { useVuelidate } from '@vuelidate/core'
    import { required } from '@vuelidate/validators'

    // store
    const store = useFeedbackStore();
    const {createContents} = store;

   // form
    const postData = ref({
        Name: '',
        Description: '',
        Email: ''
    });

    const addPostData = () => {
        createContents(postData.value);
            postData.value.Name = '';
            postData.value.Email = '';
            postData.value.Description = '';
    };
</script>