export const API_URL = import.meta.env.VITE_VUE_APP_STAGING === "true" ? "https://dev-api.heatray.io/api/" : (
  process.env.NODE_ENV === "development"
    ? "https://localhost:7188/api/"
    : "https://api.heatray.io/api/");