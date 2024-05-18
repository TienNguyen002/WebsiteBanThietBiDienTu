import { convertObjToQueryString } from "../Common/function";
import { delete_api, get_api, post_api, put_api } from "./method";

export function getAllCategory() {
  return get_api(process.env.REACT_APP_API_ALL_CATEGORIES);
}

export function getAllBranch() {
  return get_api(process.env.REACT_APP_API_ALL_BRANCHES);
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
  return get_api(process.env.REACT_APP_API_BRANCH + `${limit}/${category}`);
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

export function getCategoryById(id) {
  return get_api(process.env.REACT_APP_API_CATEGORY + `${id}`);
}

export function editCategory(formData) {
  return post_api(process.env.REACT_APP_API_CATEGORY, formData);
}

export function deleteCategory(id) {
  return delete_api(process.env.REACT_APP_API_CATEGORY + `${id}`);
}

export function getBranchById(id) {
  return get_api(process.env.REACT_APP_API_BRANCH + `${id}`);
}

export function editBranch(formData) {
  return post_api(process.env.REACT_APP_API_BRANCH, formData);
}

export function deleteBranch(id) {
  return delete_api(process.env.REACT_APP_API_BRANCH + `${id}`);
}

export function updateSaleDate(formData) {
  return post_api(process.env.REACT_APP_API_ALL_SALES, formData);
}

export function removeProductSale(id) {
  return put_api(process.env.REACT_APP_API_REMOVE_PRODUCT_SALE + `${id}`);
}

export function getAllSerie() {
  return get_api(process.env.REACT_APP_API_ALL_SERIES);
}

export function getAllOrders() {
  return get_api(process.env.REACT_APP_API_ALL_ORDERS);
}
