import axios from "axios";

export async function get_api(your_api) {
  try {
    const response = await axios.get(your_api);
    const data = response.data;
    if (data.isSuccess) return data.result;
    else return null;
  } catch (error) {
    // alert("Error", error.message);
  }
}

export async function delete_api(your_api) {
  try {
    const response = await axios.delete(your_api);
    const data = response.data;
    if (data.isSuccess) return data.result;
    else return null;
  } catch (error) {
    alert("Error", error.message);
  }
}

export async function post_api(your_api, formData) {
  try {
    const response = await axios({
      method: "post",
      url: your_api,
      data: formData,
      headers: {
        accept: "multipart/form-data",
        "Content-Type": "multipart/form-data",
      },
    });
    const data = response.data;
    if (data.isSuccess) {
      return data.result;
    } else return null;
  } catch (error) {
    alert("Can't post the request", error.message);
  }
}
