import React, { useEffect, useState } from "react";
import { createUser } from "../../../Api/Controller";
import toast from "react-hot-toast";
import { Input } from "antd";

const UserEdit = ({ onOk, setReloadData }) => {
  const initialState = {
    name: "",
    email: "",
    password: "",
  };

  const [user, setUser] = useState(initialState);

  const resetState = () => {
    setUser(initialState);
  };

  useEffect(() => {
    resetState();
  }, [onOk]);

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    createUser(formData).then((data) => {
      if (data.flag === true) {
        onOk();
        resetState();
        setReloadData(true);
        toast.success("Thêm thành công");
      } else {
        toast.error("Thêm thất bại");
      }
    });
  };
  return (
    <>
      <div className="edit">
        <h1 className="edit-title">Thêm người dùng</h1>
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="edit-form"
        >
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên người dùng</p>
            <Input
              name="name"
              value={user.name}
              placeholder={"Nhập tên người dùng"}
              className="edit-form-title-input"
              onChange={(e) => setUser({ ...user, name: e.target.value })}
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Email người dùng</p>
            <Input
              name="email"
              value={user.email}
              placeholder={"Nhập email người dùng"}
              className="edit-form-title-input"
              onChange={(e) => setUser({ ...user, email: e.target.value })}
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Mật khẩu người dùng</p>
            <Input
              name="password"
              type="password"
              value={user.password}
              placeholder={"Nhập mật khẩu người dùng"}
              className="edit-form-title-input"
              onChange={(e) => setUser({ ...user, password: e.target.value })}
            ></Input>
          </div>
          <div className="edit-form-button">
            <button type="submit" className="edit-form-button-submit">
              Thêm
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default UserEdit;
