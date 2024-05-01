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
  url.split("/").slice(-3).join("/");
};

export const convertObjToQueryString = function (obj) {
  var str = [];
  for (var p in obj)
    if (obj.hasOwnProperty(p)) {
      str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
    }
  return str.join("&");
};
