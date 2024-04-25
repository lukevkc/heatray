import './assets/main.css';

import { createApp } from 'vue';
import { createPinia } from 'pinia';
import "./assets/main.css";

// @ts-ignore
import App from "./App.vue";
import router from './modules/router';
// @ts-ignore
import VueTransitions from '@morev/vue-transitions';
import '@morev/vue-transitions/styles';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(VueTransitions, {});

app.mount('#app');
