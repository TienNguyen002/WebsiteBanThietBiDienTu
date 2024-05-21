import TextArea from "antd/es/input/TextArea";
import React, { useEffect, useState } from "react";
import { Input, Rate } from "antd";
import "../../styles/homePage.scss";
import { useSelector } from "react-redux";
import { createComment, getUserById } from "../../../../Api/Controller";
import toast from "react-hot-toast";

const CommentBox = ({ slug, setReload, reload }) => {
  const userInitialState = {
    id: "",
    username: "",
  };
  const initialState = {
    userId: "",
    rating: "",
    detail: "",
    commentSlug: "",
    productSlug: "",
  };
  const [value, setValue] = useState(0);
  const [comment, setComment] = useState(initialState);
  const [userInfo, setUserInfo] = useState(userInitialState);
  let user = useSelector((state) => state.auth.login.currentUser);

  useEffect(() => {
    if (user !== null) {
      getUserById(user.id).then((data) => {
        setUserInfo({
          id: user.id,
          username: data.name,
        });
      });
    }
  }, []);

  useEffect(() => {
    setValue(0);
    resetState();
  }, [reload]);

  const resetState = () => {
    setComment(initialState);
  };

  const handleRating = (value) => {
    setValue(value);
    setComment({ ...comment, rating: value });
  };

  const handleComment = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    formData.set("Rating", comment.rating);
    createComment(formData).then((data) => {
      if (user === null) {
        toast.error("Vui lòng đăng nhập trước khi bình luận");
      } else {
        if (data) {
          toast.success("Bình luận thành công");
          setReload(true);
        } else toast.error("Bình luận thất bại!!");
      }
    });
  };

  return (
    <div>
      {/* <Toaster /> */}
      <form
        method="post"
        encType="multipart/form-data"
        onSubmit={handleComment}
        className="comment-form"
      >
        <input
          hidden
          name="UserId"
          value={userInfo.id}
          onChange={(e) => setComment({ ...comment, userId: e.target.value })}
        ></input>
        <input
          hidden
          name="ProductSlug"
          value={slug}
          onChange={(e) =>
            setComment({ ...comment, productSlug: e.target.value })
          }
        ></input>
        <div className="comment-form-name">
          <h3 className="title">Tên của bạn</h3>
          <Input
            placeholder="Nhập tên của bạn"
            value={userInfo.username}
          ></Input>
        </div>
        <div className="comment-form-content">
          <div>
            <h3 className="title">Đánh giá của bạn</h3>
            <Rate
              name="rating"
              allowHalf
              onChange={handleRating}
              value={value}
            />
          </div>
          <div>
            <h3 className="title">Bình luận của bạn</h3>
            <TextArea
              placeholder="Nhập bình luận của bạn"
              name="detail"
              value={comment.detail}
              className="comment-form-content-textarea"
              onChange={(e) =>
                setComment({ ...comment, detail: e.target.value })
              }
            />
          </div>
        </div>
        <button type="submit" className="comment-form-button">
          Gửi
        </button>
      </form>
    </div>
  );
};

export default CommentBox;
