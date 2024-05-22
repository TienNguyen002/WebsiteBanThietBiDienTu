import React, { useEffect, useState } from "react";
import "../../styles/commonPage.scss";
import { Button, Input } from "antd";
import { useSelector } from "react-redux";
import { changePassword, getUserById, updateUser } from "../../Api/Controller";
import toast, { Toaster } from "react-hot-toast";

const ProfilePage = () => {
  const initialState = {
    id: 0,
    imageUrl: "",
    name: "",
    email: "",
    address: "",
    phoneNumber: "",
  };

  const initialPass = {
    id: 0,
    oldPassword: "",
    password: "",
    confirmPassword: "",
  };
  const [change, setChange] = useState(false);
  const [userInfo, setUserInfo] = useState(initialState);
  const [password, setPassword] = useState(initialPass);
  const [reload, setReloadData] = useState(false);
  let user = useSelector((state) => state.auth.login.currentUser);
  let id = user !== null ? user.id : 0;

  const editImageFrame =
    "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";

  useEffect(() => {
    document.title = "Trang cá nhân";
    resetState();
    getUserById(id).then((data) => {
      if (data) {
        setUserInfo(data);
      } else setUserInfo(initialState);
    });
  }, [reload]);

  const resetState = () => {
    setUserInfo(initialState);
    setPassword(initialPass);
    setReloadData(false);
  };

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onloadend = async () => {
      if (reader.result) {
        setUserInfo({ ...userInfo, imageUrl: reader.result });
      }
    };
    reader.readAsDataURL(file);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    updateUser(formData).then((data) => {
      if (data) {
        resetState();
        setReloadData(true);
        toast.success("Thay đổi thông tin thành công");
      } else {
        toast.error("Thay đổi thông tin thất bại");
      }
    });
  };

  const handleChange = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    if (password.password !== password.confirmPassword) {
      toast.error("Mật khẩu xác nhận không trùng khớp");
    } else {
      changePassword(formData).then((data) => {
        if (data) {
          resetState();
          setReloadData(true);
          toast.success("Đổi mật khẩu thành công");
        } else {
          toast.error("Đổi mật khẩu thất bại");
        }
      });
    }
  };

  return (
    <>
      <Toaster />
      <div className="profile-page">
        <h2 className="profile-page-header title">Thông tin cá nhân</h2>
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="profile-page-detail"
        >
          <div className="profile-page-detail-image">
            <input
              hidden
              name="Id"
              title="Id"
              value={id}
              onChange={(e) => setUserInfo({ ...userInfo, id: e.target.value })}
            ></input>
            <div className="profile-page-detail-image-show">
              <label htmlFor="uploadGallery">
                {userInfo.imageUrl === "" || userInfo.imageUrl === null ? (
                  <img
                    src={editImageFrame}
                    className="edit-form-gallery-image"
                    alt={userInfo.name}
                  />
                ) : (
                  <img
                    src={userInfo.imageUrl}
                    className="edit-form-gallery-image"
                    alt={userInfo.name}
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
            <h3>{userInfo.name}</h3>
          </div>
          <div className="profile-page-detail-info">
            <div className="input-form">
              <label className="title">Họ và tên</label>
              <Input
                name="name"
                value={userInfo.name}
                placeholder={"Nhập họ và tên của bạn"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, name: e.target.value })
                }
              ></Input>
            </div>
            <div className="input-form">
              <label className="title">Email</label>
              <Input
                name="email"
                value={userInfo.email}
                placeholder={"Nhập email của bạn"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, email: e.target.value })
                }
              ></Input>
            </div>
            <div className="input-form">
              <label className="title">Địa chỉ</label>
              <Input
                name="address"
                value={userInfo.address}
                placeholder={"Nhập địa chỉ của bạn"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, address: e.target.value })
                }
              ></Input>
            </div>
            <div className="input-form">
              <label className="title">Số điện thoại</label>
              <Input
                name="phone"
                value={userInfo.phoneNumber}
                placeholder={"Nhập số điện thoại của bạn"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, phoneNumber: e.target.value })
                }
              ></Input>
            </div>
            <button type="submit" className="button-form">
              Cập nhật thông tin
            </button>
          </div>
        </form>
        <div className="line"></div>
        <div className="profile-page-password">
          <div className="profile-page-password-top">
            <h3 className="title">Đổi mật khẩu</h3>
            <Button type="primary" onClick={() => setChange(!change)}>
              {change ? "Hủy" : "Thay đổi"}
            </Button>
          </div>
          <form
            method="post"
            encType="multipart/form-data"
            onSubmit={handleChange}
            className="profile-page-password-change"
          >
            <input
              hidden
              name="Id"
              title="Id"
              value={id}
              onChange={(e) => setUserInfo({ ...password, id: e.target.value })}
            ></input>
            <div className="input-form">
              <label className="title">Mật khẩu hiện tại</label>
              {change ? (
                <Input
                  name="oldPassword"
                  type="password"
                  value={password.oldPassword}
                  placeholder={"Nhập mật khẩu hiện tại của bạn"}
                  onChange={(e) =>
                    setPassword({ ...password, oldPassword: e.target.value })
                  }
                ></Input>
              ) : (
                <Input disabled />
              )}
            </div>
            <div className="input-form">
              <label className="title">Mật khẩu mới</label>
              {change ? (
                <Input
                  name="password"
                  type="password"
                  value={password.password}
                  placeholder={"Nhập mật khẩu mới của bạn"}
                  onChange={(e) =>
                    setPassword({ ...password, password: e.target.value })
                  }
                ></Input>
              ) : (
                <Input value={password.password} disabled />
              )}
            </div>
            <div className="input-form">
              <label className="title">Xác nhận mật khẩu</label>
              {change ? (
                <Input
                  name="confirmPassword"
                  type="password"
                  value={password.confirmPassword}
                  placeholder={"Xác nhận mật khẩu của bạn"}
                  onChange={(e) =>
                    setPassword({
                      ...password,
                      confirmPassword: e.target.value,
                    })
                  }
                ></Input>
              ) : (
                <Input disabled />
              )}
            </div>
            {change ? (
              <button type="submit" className="button-pass">
                Đổi mật khẩu
              </button>
            ) : (
              <Button type="submit" className="button-disable" disabled>
                Đổi mật khẩu
              </Button>
            )}
          </form>
        </div>
      </div>
    </>
  );
};

export default ProfilePage;
