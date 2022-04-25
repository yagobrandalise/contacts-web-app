<template>
  <v-app>
    <v-card>
      <v-navigation-drawer expand-on-hover rail>
        <v-list density="compact" nav>
          <v-list-item
            @click="$router.push('/')"
            prepend-icon="mdi-account-box-multiple"
            title="My Contacts"
            value="myContacs"
          ></v-list-item>
          <v-list-item
            @click="$router.push('/balanced-brackets')"
            prepend-icon="mdi-code-brackets"
            title="Balanced brackets"
            value="balancedBrackets"
          ></v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-main>
        <router-view></router-view>
      </v-main>
    </v-card>
    <v-fade-transition>
      <loader v-if="$store.state.loading" />
    </v-fade-transition>
  </v-app>
</template>

<script>
import "./styles/global.scss";
import Loader from "./components/Loader.vue";

export default {
  name: "App",

  components: {
    Loader,
  },

  data: () => ({}),
};
</script>
