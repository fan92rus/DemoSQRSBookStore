import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios, { AxiosStatic } from 'axios';
import { UserApi } from './api/api/UserApi';
import { BooksApi } from './api/api/BooksApi';

axios.defaults.baseURL = 'https://localhost:5001';

const Axios = axios;

App.prototype.$userApi = new UserApi(Axios);
App.prototype.$booksApi = new BooksApi(Axios);

createApp(App).use(store).use(router).mount('#app')
