import { createApp } from 'vue'
import App from './views/App.vue'
import router from './router'

import './assets/tailwind.css'  // <--- импорт стилей Tailwind здесь

const app = createApp(App)
app.use(router)
app.mount('#app')
