<script setup>
    import FeedbackForm from '../components/FeedbackForm.vue'
</script>

<template>
    <div class="container">
        <div class="row">
            <div class="col-sm"></div>
            <div class="col-sm text-center">
                <div class="pt-1 pb-1" style="color:lightgray">
                    <font-awesome-icon icon="phone" class="my-auto d-inline" /><p class="d-inline text-light my-auto">  010-100100</p>
                </div>
            </div>
            <div class="col-sm"></div>
        </div>
        <div class="row">
            <div class="col-sm"></div>
            <div class="col-sm text-center">
                <div class="pt-1 pb-1" style="color:lightgray">
                    <font-awesome-icon icon="home" class="my-auto d-inline" />
                    <p class="d-inline text-light my-auto"></p>  Address 1, 01000 Helsinki
                </div>
            </div>
            <div class="col-sm"></div>
        </div>
        <div class="row">
            <div class="col-sm"></div>
            <div class="col-sm">
                <FeedbackForm />
            </div>
            <div class="col-sm"></div>
        </div>
    </div>
</template>