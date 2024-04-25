//import {
//    useApiStore
//} from "..//store/api.store";
//import { getApiToken } from "../../services/jwt.service";

export const isAuthenticated = (to, from, next) => {
    //var store = useApiStore();
    //if(store.userAccount != null && getApiToken() != null) {
    //    next();
    //    return;
    //}
    //
    //next({path: "/auth/login"});
    next();
};

export const isNotAuthenticated = (to, from, next) => {
    //var store = useApiStore();
    //if(getApiToken() == null) {
    //    store.PurgeAuthAsync();
    //}
    //
    //if(store.userAccount == null || getApiToken() == null) {
    //    next();
    //    return;
    //}
    //
    //next({path: "/admin"});
    next();
};

export default { isAuthenticated, isNotAuthenticated }