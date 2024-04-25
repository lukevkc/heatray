const API_TOKEN_KEY = '_t';

export const getApiToken = () => {
  return window.localStorage.getItem(API_TOKEN_KEY);
};

export const saveApiToken = (token) => {
  window.localStorage.setItem(API_TOKEN_KEY, token);
};

export const destroyApiToken = () => {
  window.localStorage.removeItem(API_TOKEN_KEY);
};

export default {
  getApiToken,
  saveApiToken,
  destroyApiToken,
};