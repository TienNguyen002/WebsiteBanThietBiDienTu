import { delete_api, get_api, post_api } from "./method";

export function getAllCategory() {
  return get_api(process.env.REACT_APP_API_ALL_CATEGORIES);
}
