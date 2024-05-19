import { jwtDecode } from "jwt-decode";

export const formatVND = (number) => {
  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(number);
};

export const convertDate = (inputDate) => {
  let date = new Date(inputDate);

  let year = date.getFullYear();
  let month = date.getMonth() + 1;
  let day = date.getDate();

  return day + "/" + month + "/" + year;
};

export const splitUrl = (url) => {
  url.split("/").slice(-2).join("/");
};

export const convertObjToQueryString = function (obj) {
  var str = [];
  for (var p in obj)
    if (obj.hasOwnProperty(p)) {
      str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
    }
  return str.join("&");
};

export const decodeAndSaveUserInfo = (token) => {
  const userInfo = jwtDecode(token);
  const user = {
    id: userInfo[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    ],
    username:
      userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
    email:
      userInfo[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
      ],
    role: userInfo[
      "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
    ],
  };
  localStorage.setItem("token", token);
  localStorage.setItem("user", JSON.stringify(user));
  return user;
};
