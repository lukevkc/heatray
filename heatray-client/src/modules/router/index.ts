import {
  createRouter,
  createMemoryHistory,
  createWebHistory,
} from "vue-router";
// @ts-ignore
import { isAuthenticated, isNotAuthenticated } from "./router-guards.js";

//blank layout and views
// @ts-ignore
const BlankLayout = () => import("../../layouts/Blank.vue");
//const ForbiddenPage = () => import("../../views/shared/403.vue");
//const NotFoundPage = () => import("../../views/shared/404.vue");
//const ServerErrorPage = () => import("../../views/shared/500.vue");

//auth layout and views
// @ts-ignore
const AuthLayout = () => import("../../layouts/Auth.vue");
// @ts-ignore
const LoginPage = () => import("../../views/auth/SignIn.vue");
// @ts-ignore
const RegisterPage = () => import("../../views/auth/SignUp.vue");

//admin layout and views
// @ts-ignore
const DefaultLayout = () => import("../../layouts/Default.vue");
// @ts-ignore
const Home = () => import("../../views/Home.vue");

//admin layout and views
// @ts-ignore
const heatrayWorkspaceLayout = () => import("../../layouts/heatrayWorkspace.vue");
// @ts-ignore
const Overview = () => import("../../views/heatray_workspace/Overview.vue");

const isServer = typeof window === "undefined";
const history = isServer ? createMemoryHistory() : createWebHistory();
const routes = [
  {
    path: "/",
    component: DefaultLayout,
    beforeEnter: isAuthenticated,
    children: [
    {
      path: "/",
      name: "home",
      component: Home,
      beforeEnter: isAuthenticated
    }
  ],
  },
  {
    path: "/app",
    component: heatrayWorkspaceLayout,
    beforeEnter: isAuthenticated,
    children: [
    {
      path: "/app",
      name: "app_overview",
      component: Overview,
      beforeEnter: isAuthenticated
    }
  ],
  },
  {
    path: "/signin",
    component: AuthLayout,
    beforeEnter: isNotAuthenticated,
    children: [{
      path: "/signin",
      name: "login",
      component: LoginPage,
      beforeEnter: isNotAuthenticated
    }],
  },
  {
    path: "/signup",
    component: AuthLayout,
    beforeEnter: isNotAuthenticated,
    children: [{
      path: "/signup",
      name: "register",
      component: RegisterPage,
      beforeEnter: isNotAuthenticated
    }],
  },
];

const router = createRouter({
  history,
  routes,
});

export default router;