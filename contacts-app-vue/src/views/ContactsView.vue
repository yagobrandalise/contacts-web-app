<template>
  <div>
    <contact-dialog @on-save="getAll" ref="contactDialog"></contact-dialog>
    <confirmation-dialog
      @on-confirm="deleteContact"
      @on-cancel="contactToDelete = null"
      title="Atention"
      message="Are you sure you want to delete this contact?"
      ref="confirmationDialog"
    ></confirmation-dialog>
    <v-row class="mt-0 pl-4 mb-0">
      <v-col>
        <h2>My Contacts</h2>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="8" class="px-6 pt-6">
        <v-text-field
          variant="outlined"
          density="compact"
          v-model="keyword"
          outlined
          dense
          clearable
          @click:clear="getAll()"
          @change="getAll()"
          @keypress.enter="getAll()"
          label="Search"
        />
      </v-col>
      <v-col cols="4" class="pt-6 pr-6">
        <v-btn prepend-icon="mdi-account-plus-outline" variant="outlined" @click="openContactDialog()">
          Add new Contact
        </v-btn>
      </v-col>
    </v-row>

    <v-row class="py-1 pl-4 pr-4 mt-0 mb-0">
      <v-col
        v-for="contact in contacts"
        :key="contact.id"
        cols="12"
        sm="4"
        md="2"
      >
        <v-card variant="outlined" class="text-center">
          <div class="pt-2">
            <v-icon size="150" v-if="!contact.pictureContent">
              mdi-account
            </v-icon>
            <v-avatar size="150" v-else>
              <v-img
                height="200"
                width="200"
                cover
                :src="'data:image/png;base64, ' + contact.pictureContent"
                :lazy-src="'data:image/png;base64, ' + contact.pictureContent"
              />
            </v-avatar>
            <v-card-title
              class="justify-center"
              v-text="truncate(contact.name, 20)"
            ></v-card-title>
          </div>

          <span>
            <v-icon size="18px">mdi-email</v-icon>
            Email: {{ truncate(contact.email, 21) }}
          </span>
          <br />
          <span>
            <v-icon size="18px">mdi-phone</v-icon>
            Phone Number:
            {{ contact.phoneNumber ? contact.phoneNumber : "-" }}
          </span>
          <br />
          <span>
            <v-icon size="18px">mdi-whatsapp</v-icon>
            Whatsapp: {{ contact.whatsapp ? contact.whatsapp : "-" }}
          </span>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn variant="outlined" icon @click="editContact(contact.id)">
              <v-tooltip activator="parent" anchor="bottom"
                >Edit Contact</v-tooltip
              >
              <v-icon>mdi-square-edit-outline</v-icon>
            </v-btn>
            <v-btn variant="outlined" icon @click="prepareToDelete(contact.id)">
              <v-tooltip activator="parent" anchor="bottom"
                >Delete Contact</v-tooltip
              >
              <v-icon>mdi-delete-outline</v-icon>
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import ContactDialog from "../components/dialogs/ContactDialog.vue";
import ConfirmationDialog from "../components/dialogs/ConfirmationDialog.vue";
import axios from "axios";

export default {
  components: {
    ContactDialog,
    ConfirmationDialog,
  },
  name: "ContactsApp",

  data: () => ({
    contact: {
      name: "",
      email: "",
      phoneNumber: "",
      whatsapp: "",
      image: "",
    },
    keyword: null,
    contacts: [],
    loading: false,
    contactToDelete: null,
  }),

  methods: {
    truncate(value, lenght) {
      if (!value) return "";
      return value.length <= lenght
        ? value
        : String(value).slice(0, lenght).concat(["..."]);
    },
    openContactDialog() {
      this.$refs.contactDialog.dialog = true;
    },
    openConfirmationDialog() {
      this.$refs.confirmationDialog.dialog = true;
    },
    async getAll() {
      this.$store.commit("setLoader", true);
      let result = await axios.get(
        "https://contacts-application.azurewebsites.net/api/Contact/get-all",
        {
          params: {
            keyword: this.keyword,
          },
        }
      );

      if (result) {
        this.contacts = result.data;
      }

      this.$store.commit("setLoader", false);
    },
    prepareToDelete(id) {
      this.contactToDelete = id;
      this.openConfirmationDialog();
    },
    async deleteContact() {
      this.$store.commit("setLoader", true);
      let result = await axios.delete(
        `https://contacts-application.azurewebsites.net/api/Contact/delete/${this.contactToDelete}`
      );
      if (result) await this.getAll();
      this.$store.commit("setLoader", false);
    },
    editContact(id) {
      this.$refs.contactDialog.edit = true;
      this.$refs.contactDialog.getContact(id);
      this.openContactDialog();
    },
  },
  created() {
    this.getAll();
  },
};
</script>
