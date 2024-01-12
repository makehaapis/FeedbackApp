<script>
    import useVuelidate from '@vuelidate/core'
    import { required, email, minLength, maxLength, minValue, maxValue } from '@vuelidate/validators'
    import { useFeedbackStore } from '../store/feedbacks';


    export default {
        setup() {
            return { v$: useVuelidate() }
        },
        methods: {
            submit: function () {
                const store = useFeedbackStore();
                const { createContents } = store;
                createContents(this.form)
                this.$refs.feedbackForm.reset();
            }
        },
        data() {
            return {
                form: {
                    name: '',
                    email: '',
                    description: '',
                    rating: 1,
                },
            }
        },
        validations() {
            return {
                form: {
                    email: { required, email },
                    name: { required, min: minLength(3), max: maxLength(20) },
                    description: { required, min: maxLength(500) },
                    rating: { required, min: minValue(1), max: maxValue(5) }
                },
            }
        },
    }
</script>

<template>
    <form @submit.prevent="submit" ref="feedbackForm">
        <div class="form-group">
            <div :class="{ error: v$.form.description.$errors.length }">
                <label class="text-white">Feedback: </label>
                <textarea class="form-control" placeholder="Give us feedback" type="text" v-model="v$.form.description.$model"></textarea>
                <div class="pre-icon os-icon os-icon-user-male-circle"></div>
                <div class="input-errors" v-for="(error, index) of v$.form.description.$errors" :key="index">
                    <div class="error-msg text-danger">{{ error.$message }}</div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div :class="{ error: v$.form.name.$errors.length }">
                <label class="text-white">Name: </label>
                <input class="form-control" placeholder="Enter your name" type="text" v-model="v$.form.name.$model">
                <div class="pre-icon os-icon os-icon-user-male-circle"></div>
                <div class="input-errors" v-for="(error, index) of v$.form.name.$errors" :key="index">
                    <div class="error-msg text-danger">{{ error.$message }}</div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div :class="{ error: v$.form.email.$errors.length }">
                <label class="text-white">Email: </label>
                <input class="form-control" placeholder="Enter your email" type="email" v-model="v$.form.email.$model">
                <div class="pre-icon os-icon os-icon-user-male-circle"></div>
                <div class="input-errors" v-for="(error, index) of v$.form.email.$errors" :key="index">
                    <div class="error-msg text-danger">{{ error.$message }}</div>
                </div>
                <label class="text-white">Give us rating!</label>
            </div>
        </div>
        <div class="form-check form-check-inline">
            <div :class="{ error: v$.form.rating.$errors.length }">
                <input class="form-check-input" type="radio" value=1 v-model="v$.form.rating.$model">
                <label class="form-check-label text-white" for="inlineRadio1">1</label>
            </div>
        </div>
        <div class="form-check form-check-inline">
            <div :class="{ error: v$.form.rating.$errors.length }">
                <input class="form-check-input" type="radio" value=2 v-model="v$.form.rating.$model">
                <label class="form-check-label text-white" for="inlineRadio1">2</label>
            </div>
        </div>
        <div class="form-check form-check-inline">
            <div :class="{ error: v$.form.rating.$errors.length }">
                <input class="form-check-input" type="radio" value=3 v-model="v$.form.rating.$model">
                <label class="form-check-label text-white" for="inlineRadio1">3</label>
            </div>
        </div>
        <div class="form-check form-check-inline">
            <div :class="{ error: v$.form.rating.$errors.length }">
                <input class="form-check-input" type="radio" value=4 v-model="v$.form.rating.$model">
                <label class="form-check-label text-white" for="inlineRadio1">4</label>
            </div>
        </div>
        <div class="form-check form-check-inline">
            <div :class="{ error: v$.form.rating.$errors.length }">
                <input class="form-check-input" type="radio" value=5 v-model="v$.form.rating.$model">
                <label class="form-check-label text-white" for="inlineRadio1">5 / 5</label>
            </div>
        </div>
        <div class="input-errors" v-for="(error, index) of v$.form.rating.$errors" :key="index">
            <div class="error-msg">{{ error.$message }}</div>
        </div>
            <div class="buttons-w">
                <button :disabled="v$.form.$invalid" class="btn btn-primary">SUBMIT</button>
            </div>
    </form>
</template>