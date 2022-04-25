<template>
  <div>
    <v-row class="pa-6">
      <v-col cols="8">
        <v-text-field
          density="compact"
          variant="outlined"
          v-model="searchInput"
          clearable
          label="Balanced Brackets"
          @input="checkBalancedBrackets"
        >
          <template v-slot:append>
            <div v-if="searchInput && valid">
              <v-chip color="green">
                <template v-slot:prepend>
                  <v-icon> mdi-check-circle-outline </v-icon>
                </template>
                Valid Input
              </v-chip>
            </div>
            <div v-else-if="searchInput && !valid">
              <v-chip color="red">
                <template v-slot:prepend>
                  <v-icon> mdi-close-circle-outline </v-icon>
                </template>
                Invalid Input
              </v-chip>
            </div>
          </template>
        </v-text-field>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      loading: false,
      searchInput: null,
      valid: false,
    };
  },
  methods: {
    async checkBalancedBrackets() {
      let result = await axios.get(
        "https://contacts-application.azurewebsites.net/api/BalancedBrackets/check-balanced-brackets",
        {
          params: {
            searchInput: this.searchInput,
          },
        }
      );
      if (result) this.valid = result.data;
    },
  },
};
</script>

<style scoped>
</style>