import { convertObjToQueryString } from "../Common/function";
import {
  delete_api,
  get_api,
  post_api,
  post_api_json,
  post_api_login,
  put_api,
  put_api_form,
  upload_image,
} from "./method";

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
  return get_api(process.env.REACT_APP_API_PRODUCT + `${limit}/${category}`);
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

export function createOrder(data) {
  return post_api_json(process.env.REACT_APP_API_ORDER, data);
}

export function getDiscountByCodeName(codeName) {
  return get_api(process.env.REACT_APP_API_DISCOUNT_CODENAME + `${codeName}`);
}

export function getUserById(id) {
  return get_api(process.env.REACT_APP_API_USER + `${id}`);
}

export function getCommentsByProductSlug(slug) {
  return get_api(process.env.REACT_APP_API_ALL_COMMENTS + `${slug}`);
}

export function countAllComment(slug) {
  return get_api(process.env.REACT_APP_API_COUNT_COMMENTS + `${slug}`);
}

export function createComment(formData) {
  return post_api(process.env.REACT_APP_API_COMMENT, formData);
}

export function getAllDiscounts() {
  return get_api(process.env.REACT_APP_API_ALL_DISCOUNTS);
}

export function createDiscount(formData) {
  return post_api(process.env.REACT_APP_API_DISCOUNT, formData);
}

export function deletDiscount(id) {
  return delete_api(process.env.REACT_APP_API_DISCOUNT + `${id}`);
}

export function getAllUsers() {
  return get_api(process.env.REACT_APP_API_ALL_USERS);
}

export function getOrderItemsByOrderId(id) {
  return get_api(process.env.REACT_APP_API_ORDER + `${id}`);
}

export function createUser(formData) {
  return post_api(process.env.REACT_APP_API_CREATE, formData);
}

export function deleteUser(id) {
  return delete_api(process.env.REACT_APP_API_USER + `${id}`);
}

export function updateUser(formData) {
  return post_api_login(process.env.REACT_APP_API_UPDATE, formData);
}

export function changePassword(formData) {
  return post_api(process.env.REACT_APP_API_CHANGE_PASS, formData);
}

export function updateRole(id) {
  return put_api(process.env.REACT_APP_API_UPDATE_ROLE + `${id}`);
}

export function moveToNextStep(id) {
  return put_api(process.env.REACT_APP_API_NEXT_STEP + `${id}`);
}

export function cancelOrder(id) {
  return put_api(process.env.REACT_APP_API_CANCEL + `${id}`);
}

export function getSerieBySlug(slug) {
  return get_api(process.env.REACT_APP_API_SERIE_DETAIL + `${slug}`);
}

export function getAllFilters() {
  return get_api(process.env.REACT_APP_API_ALL_FILTERS);
}

export function uploadImageEditor(file) {
  return upload_image(process.env.REACT_APP_CLOUDINARY_NAME, file);
}

export function getSerieById(id) {
  return get_api(process.env.REACT_APP_API_SERIE + `${id}`);
}

export function editSerie(formData) {
  return post_api(process.env.REACT_APP_API_SERIE, formData);
}

export function deleteSerie(id) {
  return delete_api(process.env.REACT_APP_API_SERIE + `${id}`);
}

export function editProduct(formData) {
  return post_api(process.env.REACT_APP_API_PRODUCT, formData);
}

export function deleteProduct(id) {
  return delete_api(process.env.REACT_APP_API_PRODUCT + `${id}`);
}

export function addProductSale(formData) {
  return put_api_form(process.env.REACT_APP_API_ADD_PRODUCT_SALE, formData);
}

export function addAmount(formData) {
  return put_api_form(process.env.REACT_APP_API_ADD_AMOUNT, formData);
}

export function getProductById(id) {
  return get_api(process.env.REACT_APP_API_PRODUCT + `${id}`);
}
