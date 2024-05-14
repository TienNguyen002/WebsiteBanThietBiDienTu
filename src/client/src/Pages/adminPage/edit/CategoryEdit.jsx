import React, { useState, useRef, useCallback, useEffect } from "react";
import "../../../styles/adminLayout.scss";
import { getCategoryById } from "../../../Api/Controller";
import { useParams } from "react-router-dom";
import { Input } from "antd";

const CategoryEdit = () => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    imageUrl: "",
  };

  const [previewUrl, setPreviewUrl] = useState(null);
  const [category, setCategory] = useState(initialState);
  const imageRef = useRef(null);
  const editImageFrame =
    "https://www.digitalcitizen.life/wp-content/uploads/2020/10/photo_gallery-1-596x225.jpg";

  let { id } = useParams();
  id = id ?? 0;

  useEffect(() => {
    getCategoryById(id).then((data) => {
      if (data) {
        setCategory(data);
      } else setCategory([]);
    });
  }, []);

  const goBack = () => {
    window.history.go(-1);
  };

  const handleImageChange = useCallback(
    (e) => {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.onloadend = async () => {
        if (reader.result) {
          const filename = reader.result;
          //   const formData = new FormData();
          //   formData.append("file", filename);
          //   formData.append(
          //     "upload_preset",
          //     process.env.REACT_APP_CLOUDINARY_PRESET
          //   );
          //   const url = await uploadToCloudinary(formData);
          //   setBanner({ ...banner, imageUrl: url });
          setPreviewUrl(reader.result);
        }
      };
      reader.readAsDataURL(file);
    },
    [initialState]
  );

  return (
    <>
      <div className="edit">
        {id === 0 ? (
          <h1 className="edit-title">Thêm danh mục</h1>
        ) : (
          <h1 className="edit-title">Chỉnh sửa danh mục</h1>
        )}

        <form className="edit-form">
          <div className="gallery">
            <label htmlFor="uploadGallery">
              <img
                src={previewUrl || category.imageUrl || editImageFrame}
                className="img-glalery z-20"
              />
              <input
                id="uploadGallery"
                type="file"
                name="BackgroundImage"
                title="BackgroundImage"
                ref={imageRef}
                onChange={handleImageChange}
                accept=".png, .jpg, .jpeg"
                className="setGallery"
                hidden
              />
            </label>
          </div>
          <Input value={category.name}></Input>
          <div className="edit-form-button">
            <p onClick={goBack}>Quay lại</p>
            <h1>{id === 0 ? "Thêm" : "Chỉnh sửa"}</h1>
          </div>
        </form>
      </div>
    </>
  );
};

export default CategoryEdit;
