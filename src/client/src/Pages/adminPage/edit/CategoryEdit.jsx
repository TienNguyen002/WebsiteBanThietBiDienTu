import React, { useState, useRef, useCallback, useEffect } from "react";
import "../../../styles/adminLayout.scss";
import { editCategory, getCategoryById } from "../../../Api/Controller";
import { Input } from "antd";

const CategoryEdit = ({ id, onOk }) => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    imageUrl: "",
  };

  const [category, setCategory] = useState(initialState);
  const imageRef = useRef(null);
  const editImageFrame =
    "https://t4.ftcdn.net/jpg/04/81/13/43/360_F_481134373_0W4kg2yKeBRHNEklk4F9UXtGHdub3tYk.jpg";

  useEffect(() => {
    if (id === 0) {
      resetState();
    }
    if (id > 0) {
      getCategoryById(id).then((data) => {
        if (data) {
          setCategory(data);
        } else setCategory(initialState);
      });
    }
  }, [id]);

  const handleImageChange = useCallback(
    (e) => {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.onloadend = async () => {
        if (reader.result) {
          setCategory({ ...category, imageUrl: reader.result });
        }
      };
      reader.readAsDataURL(file);
    },
    [initialState]
  );

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    editCategory(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
      } else {
      }
    });
  };

  const resetState = () => {
    setCategory(initialState);
  };

  return (
    <>
      <div className="edit">
        {id === 0 ? (
          <h1 className="edit-title">Thêm danh mục</h1>
        ) : (
          <h1 className="edit-title">Chỉnh sửa danh mục</h1>
        )}

        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="edit-form"
        >
          <div className="edit-form-gallery">
            <input
              hidden
              name="Id"
              title="Id"
              value={category.id}
              onChange={(e) => setCategory({ ...category, id: e.target.value })}
            ></input>
            <label htmlFor="uploadGallery">
              {category.imageUrl === "" || category.imageUrl === null ? (
                <img
                  src={editImageFrame}
                  className="edit-form-gallery-image"
                  alt={category.name}
                />
              ) : (
                <img
                  src={category.imageUrl}
                  className="edit-form-gallery-image"
                  alt={category.name}
                />
              )}
              <input
                id="uploadGallery"
                type="file"
                name="ImageFile"
                title="ImageFile"
                ref={imageRef}
                onChange={handleImageChange}
                accept=".png, .jpg, .jpeg"
                className="setGallery"
                hidden
              />
            </label>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên danh mục</p>
            <Input
              name="name"
              value={category.name}
              placeholder={"Nhập tên danh mục"}
              className="edit-form-title-input"
              onChange={(e) =>
                setCategory({ ...category, name: e.target.value })
              }
            ></Input>
          </div>
          <div className="edit-form-button">
            <button type="submit" className="edit-form-button-submit">
              {id === 0 ? "Thêm" : "Chỉnh sửa"}
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default CategoryEdit;
