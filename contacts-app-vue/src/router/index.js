import { createWebHistory, createRouter } from "vue-router";
import ContactsView from "@/views/ContactsView.vue";
import BalancedBrackets from "@/views/BalancedBracketsView.vue";

const routes = [
  {
    path: "/",
    name: "ContactsView",
    component: ContactsView,
  },
  {
    path: "/balanced-brackets",
    name: "BalancedBrackets",
    component: BalancedBrackets,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;