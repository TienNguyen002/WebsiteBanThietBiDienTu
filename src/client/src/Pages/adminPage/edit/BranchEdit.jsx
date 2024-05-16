import React, { useState, useCallback, useEffect } from "react";
import "../../../styles/adminLayout.scss";
import { editBranch, getBranchById } from "../../../Api/Controller";
import { Input } from "antd";
import toast from "react-hot-toast";

const BranchEdit = ({ id, onOk, setReloadData }) => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    imageUrl: "",
  };

  const [branch, setBranch] = useState(initialState);
  const editImageFrame =
    "https://t4.ftcdn.net/jpg/04/81/13/43/360_F_481134373_0W4kg2yKeBRHNEklk4F9UXtGHdub3tYk.jpg";

  useEffect(() => {
    if (id === 0) {
      resetState();
    }
    if (id > 0) {
      getBranchById(id).then((data) => {
        if (data) {
          setBranch(data);
        } else setBranch(initialState);
      });
    }
  }, [id]);

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onloadend = async () => {
      if (reader.result) {
        setBranch({ ...branch, imageUrl: reader.result });
      }
    };
    reader.readAsDataURL(file);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    editBranch(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
        setReloadData(true);
        if (id === 0) {
          toast.success("Thêm thành công");
        } else toast.success("Chỉnh sửa thành công");
      } else {
        if (id === 0) {
          toast.success("Thêm thất bại");
        } else toast.success("Chỉnh sửa thất bại");
      }
    });
  };

  const resetState = () => {
    setBranch(initialState);
  };

  return (
    <>
      <div className="edit">
        {id === 0 ? (
          <h1 className="edit-title">Thêm thương hiệu</h1>
        ) : (
          <h1 className="edit-title">Chỉnh sửa thương hiệu</h1>
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
              value={branch.id}
              onChange={(e) => setBranch({ ...branch, id: e.target.value })}
            ></input>
            <label htmlFor="uploadGallery">
              {branch.imageUrl === "" || branch.imageUrl === null ? (
                <img
                  src={editImageFrame}
                  className="edit-form-gallery-image"
                  alt={branch.name}
                />
              ) : (
                <img
                  src={branch.imageUrl}
                  className="edit-form-gallery-image"
                  alt={branch.name}
                />
              )}
              <input
                id="uploadGallery"
                type="file"
                name="ImageFile"
                title="ImageFile"
                onChange={handleImageChange}
                accept=".png, .jpg, .jpeg"
                className="setGallery"
                hidden
              />
            </label>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên thương hiệu</p>
            <Input
              name="name"
              value={branch.name}
              placeholder={"Nhập tên thương hiệu"}
              className="edit-form-title-input"
              onChange={(e) => setBranch({ ...branch, name: e.target.value })}
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

export default BranchEdit;
