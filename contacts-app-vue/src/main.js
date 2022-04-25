import { createApp } from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
// import { loadFonts } from './plugins/webfontloader'
import router from './router'
import { createStore } from 'vuex'

// Create a new store instance.
const store = createStore({
  state () {
    return {
      loading: false
    }
  },
  mutations: {
    setLoader (state, value) {
      state.loading = value
    }
  }
})

// loadFonts()

createApp(App)
  .use(vuetify)
  .use(router)
  .use(store)
  .mount('#app')
