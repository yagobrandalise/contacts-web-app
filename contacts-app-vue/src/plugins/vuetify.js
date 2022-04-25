// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Vuetify
import { createVuetify } from 'vuetify'
import { aliases, mdi } from 'vuetify/lib/iconsets/mdi'

export default createVuetify(
  {
    icons: {
      defaultSet: 'mdi',
      aliases,
      sets: {
        mdi,
      }
    },
    theme: {
      defaultTheme: 'dark'
    }
  }
)
