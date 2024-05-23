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
    console.log("Can't post the request", error.message);
  }
}

export async function post_api_login(your_api, formData) {
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
      return data;
    } else return null;
  } catch (error) {
    console.log("Can't post the request", error.message);
  }
}

export async function post_api_json(your_api, data) {
  try {
    const response = await axios.post(your_api, data, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    const responseData = response.data;
    if (responseData.isSuccess) return responseData.result;
    else return null;
  } catch (error) {
    console.log("Error", error.message);
    return null;
  }
}

export async function put_api(your_api) {
  try {
    const response = await axios.put(your_api);
    const data = response.data;
    if (data.isSuccess) return data.result;
    else return null;
  } catch (error) {
    console.log("Error ", error.message);
    return null;
  }
}

export async function put_api_form(your_api, formData) {
  try {
    const response = await axios({
      method: "put",
      url: your_api,
      data: formData,
      headers: {
        accept: "multipart/form-data",
        "Content-Type": "multipart/form-data",
      },
    });
    const data = response.data;
    if (data.isSuccess) return data.result;
    else return null;
  } catch (error) {
    console.log("Error ", error.message);
    return null;
  }
}

export async function upload_image(your_api, file) {
  let result = null;

  const formData = new FormData();
  formData.append("file", file);
  formData.append("upload_preset", process.env.REACT_APP_CLOUDINARY_PRESET);

  await fetch(your_api, {
    method: "POST",
    "Content-Type": "multipart/form-data",
    body: formData,
  })
    .then((response) => response.json())
    .then((data) => {
      result = data;
    })
    .catch((error) => {
      alert("Lỗi", error);
    });

  return result;
}
