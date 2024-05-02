import { convertObjToQueryString } from "../Common/function";
import { delete_api, get_api, post_api } from "./method";

export function getAllCategory() {
  return get_api(process.env.REACT_APP_API_ALL_CATEGORIES);
}

export function getAllSale() {
  return get_api(process.env.REACT_APP_API_ALL_SALES);
}

export function getTop(limit) {
  return get_api(process.env.REACT_APP_API_TOP_RATING + `${limit}`);
}

export function getNew(limit) {
  return get_api(process.env.REACT_APP_API_NEW_ITEM + `${limit}`);
}

export function getSold(limit) {
  return get_api(process.env.REACT_APP_API_TOP_SOLD + `${limit}`);
}

export function getProductList(limit, category) {
  return get_api(
    process.env.REACT_APP_API_ITEM_CATEGORY + `${limit}/${category}`
  );
}

export function getBranchList(limit, category) {
  return get_api(
    process.env.REACT_APP_API_BRANCH_CATEGORY + `${limit}/${category}`
  );
}

export function getPagedProduct(payload) {
  return get_api(
    process.env.REACT_APP_API_ITEM_PAGE + `?${convertObjToQueryString(payload)}`
  );
}

export function getProductDetail(slug) {
  return get_api(process.env.REACT_APP_API_ITEM_DETAIL + `${slug}`);
}

export function getProductFilter(payload) {
  return get_api(
    process.env.REACT_APP_API_ITEM_FILTER +
      `?${convertObjToQueryString(payload)}`
  );
}
