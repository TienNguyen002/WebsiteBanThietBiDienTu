import React, { useState, useRef, useCallback } from "react";
import "../../../styles/adminLayout.scss";

const CategoryEdit = () => {
  const [previewUrl, setPreviewUrl] = useState(null);
  const imageRef = useRef(null);
  const editImageFrame =
    "https://www.digitalcitizen.life/wp-content/uploads/2020/10/photo_gallery-1-596x225.jpg";

  const initialState = {
    id: 0,
    boldTitle: "",
    title: "",
    urlSlug: "",
    description: "",
    imageUrl: "",
    Locale: "",
  };

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
        <h1 className="edit-title">Chỉnh sửa danh mục</h1>
        <form className="edit-form">
          <div className="gallery">
            <label htmlFor="uploadGallery">
              <img
                src={previewUrl || /*banner.imageUrl*/ editImageFrame}
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
          <input></input>
          <input></input>
          <div className="edit-form-button">
            <p onClick={goBack}>Quay lại</p>
            <p>Lưu</p>
          </div>
        </form>
      </div>
    </>
  );
};

export default CategoryEdit;
