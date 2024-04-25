import JwtService from "./jwt.service";
import {
  API_URL
} from "./config";
import {
  app
} from "../main";
import {
  useProgress
} from '@marcoschulte/vue3-progress';
import router from "../modules/router/router";
import {
  useApiStore
} from "../modules/store/api.store";
import {
  useAppStateStore
} from "../modules/store/appstate.store";
import {
  useToast
} from "vue-toastification";

const heatrayerApiService = {
  apiClient: {},
  init() {
    this.apiClient = app.axios.create({
      baseURL: API_URL,
      withCredentials: true
    });
    const progresses = [];
    const toast = useToast();
    const apiStore = useApiStore();
    const appStateStore = useAppStateStore();

    this.apiClient.interceptors.request.use(config => {
      progresses.push(useProgress().start());
      appStateStore.ShowLoader();
      return config;
    });

    this.apiClient.interceptors.response.use(
      function (response) {
        progresses.pop()?.finish();
        setTimeout(appStateStore.HideLoader(), 300);
        return response;
      },
      function (error) {
        progresses.pop()?.finish();
        setTimeout(appStateStore.HideLoader(), 300);

        if (error.response.status != 401) {
          toast.clear();
          toast.error("Wystąpił błąd.", {
            timeout: 3000
          });
        }

        if (error.response.status == 401) {
          apiStore.PurgeAuthAsync().then((result) => {
            router.push({
              path: "/login"
            });
          }, (reason) => {});
          return;
        }
        if (error.response.status == 403) {
          router.push({
            path: "/403"
          });
          return;
        }

        throw error.response.data;
      }
    );
  },

  setHeader() {
    if (JwtService.getApiToken() != null) {
      this.apiClient.defaults.headers.common[
        "Authorization"
      ] = `Bearer ${JwtService.getApiToken()}`;
    }
  },

  query(resource, params) {
    return this.apiClient.get(resource, params);
  },

  get(resource, slug = "") {
    var path = slug != "" ? `${resource}/${slug}` : resource;
    return this.apiClient.get(path);
  },

  getFile(resource, params) {
    return this.apiClient.get(resource, params, {
      responseType: "blob"
    });
  },

  post(resource, params) {
    return this.apiClient.post(`${resource}`, params, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  },

  post_download_file(resource, params) {
    return this.apiClient.post(`${resource}`, params, {
      headers: {
        "Content-Type": "application/json",
      },
      responseType: "blob",
    });
  },

  update(resource, slug, params) {
    return this.apiClient.put(`${resource}/${slug}`, params);
  },

  put(resource, params) {
    return this.apiClient.put(`${resource}`, params, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  },

  delete(resource, params) {
    return this.apiClient.delete(resource, {
      data: params,
      headers: {
        "Content-Type": "application/json",
      },
    });
  },
};

export default BillingsApiService;