<script>
    import { defineComponent } from 'vue'
    import { Carousel, Navigation, Slide } from 'vue3-carousel'
    import { useFeedbackStore } from '../store/feedbacks'
    import { storeToRefs } from 'pinia'
    import { onMounted } from 'vue'
    import 'vue3-carousel/dist/carousel.css'

    export default defineComponent({
        name: 'FeedbackCarousel',
        components: {
            Carousel,
            Navigation,
            Slide
        },
        setup() {
            const store = useFeedbackStore()
            const { randomFeedbacks } = storeToRefs(store)
            return { randomFeedbacks }
        },
        mounted() {
            const store = useFeedbackStore()
            const { randomizeFeedbacks } = store
            randomizeFeedbacks()
        },
        data: () => ({
            // carousel settings
            settings: {
                itemsToShow: 1,
                snapAlign: 'center',
            },
            // breakpoints are mobile first
            // any settings not specified will fallback to the carousel settings
            breakpoints: {
                // 700px and up
                700: {
                    itemsToShow: 2,
                    snapAlign: 'center',
                },
                // 1024 and up
                1024: {
                    itemsToShow: 3,
                    snapAlign: 'center',
                },
            },
        }),
    })

</script>

<template>
    <div class="mydiv"></div>
    <h2 class="text-light text-center">What our customers say:</h2>
    <div class="card-group pt-2 pb-2">
        <Carousel :autoplay="5000" :wrap-around="true" v-bind="settings" :breakpoints="breakpoints">
            <Slide v-for="feedback in randomFeedbacks" :key="feedback.id">
                <div class="card-body text-light h-100">
                    <div class="d-inline h-25" v-for="n in feedback.rating">
                        <div class="pt-1 pb-1 d-inline" style="color:lightgray">
                            <font-awesome-icon icon="star" class="my-auto d-inline" />
                        </div>
                    </div>
                    <h5 class="card-text h-auto">{{ feedback.name }}</h5>
                    <p class="card-text text-center h-auto">"{{ feedback.description}}"</p>
                </div>
            </Slide>
        <template #addons>
                <Navigation />
            </template>
        </Carousel>
    </div>
</template>