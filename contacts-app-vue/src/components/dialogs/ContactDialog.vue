<template>
  <div>
    <v-dialog v-model="dialog" @keypress.esc="closeDialog" persistent>
      <v-card @keypress.enter="save">
        <v-card-title>
          <span>
            {{ !edit ? "Add" : "Edit" }}
            <strong>
              {{ "Contact" }}
            </strong>
          </span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="valid" lazy-validation ref="form">
            <v-row>
              <v-col>
                <Image v-model="contact.pictureContent"></Image>
              </v-col>
              <v-col>
                <v-text-field
                  density="comfortable"
                  v-model="contact.name"
                  variant="outlined"
                  autofocus
                  clearable
                  :rules="nameRules"
                  label="Name"
                />
                <v-text-field
                  density="comfortable"
                  :rules="emailRules"
                  v-model="contact.email"
                  variant="outlined"
                  clearable
                  label="E-mail"
                />
                <v-text-field
                  density="comfortable"
                  v-model.number="contact.phoneNumber"
                  variant="outlined"
                  clearable
                  label="Phone"
                  maxlength="11"
                />
                <v-text-field
                  density="comfortable"
                  v-model.number="contact.whatsapp"
                  variant="outlined"
                  clearable
                  label="Whatsapp"
                  maxlength="11"
                />
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn variant="outlined" @click="save"> OK </v-btn>
          <v-btn variant="outlined" @click="closeDialog"> CANCEL </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import Image from "../Image.vue";
import axios from "axios";

export default {
  components: {
    Image,
  },
  methods: {
    async save() {
      let form = await this.$refs.form.validate();
      if (form.valid) {
        this.$store.commit("setLoader", true);

        let contact = {
          name: this.contact.name,
          email: this.contact.email,
          phoneNumber: this.contact.phoneNumber
            ? this.contact.phoneNumber.toString()
            : "",
          whatsapp: this.contact.whatsapp
            ? this.contact.whatsapp.toString()
            : "",
          pictureContent: this.contact.pictureContent,
        };
        if (!this.edit) {
          await axios.post(
            "https://contacts-application.azurewebsites.net/api/Contact/add-contact",
            contact
          );
        } else {
          await axios.put(
            `https://contacts-application.azurewebsites.net/api/Contact/update/${this.contact.id}`,
            contact
          );
        }
        this.$store.commit("setLoader", false);

        this.$emit("on-save");
        this.closeDialog();
      }
    },
    async getContact(id) {
      this.$store.commit("setLoader", true);

      let result = await axios.get(
        `https://contacts-application.azurewebsites.net/api/Contact/get/${id}`
      );
      if (result) {
        this.contact = result.data;
      }
      this.$store.commit("setLoader", false);
    },
    closeDialog() {
      this.edit = false;
      this.contact = {};
      this.dialog = false;
    },
  },
  data: () => ({
    valid: true,
    edit: false,
    dialog: false,
    contact: {
      id: null,
      name: null,
      email: null,
      phoneNumber: null,
      whatsapp: null,
      pictureContent: null,
    },
    nameRules: [(v) => !!v || "Name is required"],
    emailRules: [
      (v) => !!v || "E-mail is required",
      (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
    ],
  }),
};
</script>

<style scoped>
.v-card {
  width: 1000px;
  height: 520px;
}
</style>
