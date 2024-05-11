import React from "react";
import "../../styles/homePage.scss";

const CategoryIcon = ({ item }) => {
  const icons = {
    "Điện thoại": (
      <img
        src="https://i.pinimg.com/564x/42/ec/44/42ec44d7b589755e3d79a4d0a89dc305.jpg"
        className="category-icon"
        alt={item.name}
      />
    ),
    Tablet: (
      <img
        src="https://cdn4.iconfinder.com/data/icons/modern-future-technology-2/128/android-tablet-512.png"
        className="category-icon"
        alt={item.name}
      />
    ),
    Laptop: (
      <img
        src="https://thumbs.dreamstime.com/b/laptop-hand-icon-laptop-icon-laptop-vector-laptop-icon-vector-laptop-screen-icon-laptop-computer-icon-laptop-icon-logo-223247125.jpg"
        className="category-icon"
        alt={item.name}
      />
    ),
    "Âm thanh": (
      <img
        src="https://cdn-icons-png.freepik.com/512/2223/2223233.png"
        className="category-icon"
        alt={item.name}
      />
    ),
    "Đồng hồ": (
      <img
        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkpxBwYQ-DKXqxK8ghRafF-TlrFC8rgV1B2ina1TtVGA&s"
        className="category-icon"
        alt={item.name}
      />
    ),
    Camera: (
      <img
        src="https://icons.iconarchive.com/icons/iconsmind/outline/512/Gopro-icon.png"
        className="category-icon"
        alt={item.name}
      />
    ),
    "Phụ kiện": (
      <img
        src="https://tanvietgroup.com/wp-content/uploads/2023/01/hXzjgwyuu3_mMbosnd11toeFXX6ciJ0Rps_cate_icon_1571463701_201.png"
        className="category-icon"
        alt={item.name}
      />
    ),
    PC: (
      <img
        src="https://simpleicon.com/wp-content/uploads/pc.png"
        className="category-icon"
        alt={item.name}
      />
    ),
    "Màn hình": (
      <img
        src="https://png.pngtree.com/png-clipart/20190903/original/pngtree-computer-icon-png-image_4421688.jpg"
        className="category-icon"
        alt={item.name}
      />
    ),
    TV: (
      <img
        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQvkxX_tktdyZ_kytMwIpzsTxx7fSoPsC3gVcnFSQQZcg&s"
        className="category-icon"
        alt={item.name}
      />
    ),
  };

  return icons[item.name];
};

export default CategoryIcon;
