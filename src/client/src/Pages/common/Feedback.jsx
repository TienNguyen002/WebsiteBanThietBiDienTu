import { Input } from "antd";
import { CircleHelp, MapPinned } from "lucide-react";
import React, { useEffect, useState } from "react";
import "../../styles/commonPage.scss";
import TextArea from "antd/es/input/TextArea";
import { sendFeedback } from "../../Api/Controller";
import toast, { Toaster } from "react-hot-toast";
import { useSelector } from "react-redux";

const Feedback = () => {
  const initialState = {
    username: "",
    title: "",
    description: "",
  };
  const [feedback, setFeedback] = useState(initialState);
  const [open, setOpen] = useState(false);
  let user = useSelector((state) => state.auth.login.currentUser);

  useEffect(() => {
    document.title = "Trang gửi Feedback";
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    let data = new FormData(e.target);
    sendFeedback(data).then((data) => {
      if (data) {
        toast.success("Gửi feedback thành công");
        setFeedback(initialState);
      } else {
        toast.error("Gửi feedback thất bại");
      }
    });
  };

  return (
    <>
      <Toaster />
      <div className="feedback">
        <div className="feedback-form">
          <div className="top-title">
            <CircleHelp />
            <span>Gửi ý kiến của bạn tại đây</span>
          </div>
          <form
            method="post"
            encType="multipart/form-data"
            onSubmit={handleSubmit}
            className="feedback-form-contact"
          >
            <div className="feedback-form-contact-box">
              <label className="title">Tên người dùng</label>
              <Input
                type="text"
                name="username"
                title="Username"
                value={user !== null ? user.username : feedback.username}
                required
                onChange={(e) =>
                  setFeedback({ ...feedback, username: e.target.value })
                }
              />
            </div>
            <div className="feedback-form-contact-box">
              <label className="title">Chủ đề</label>
              <Input
                type="text"
                name="title"
                title="Title"
                required
                value={feedback.title || ""}
                onChange={(e) =>
                  setFeedback({ ...feedback, title: e.target.value })
                }
              />
            </div>
            <div className="feedback-form-contact-box">
              <label className="title">Nội dung</label>
              <TextArea
                rows={7}
                type="text"
                name="description"
                title="Description"
                required
                value={feedback.description || ""}
                onChange={(e) =>
                  setFeedback({ ...feedback, description: e.target.value })
                }
              />
            </div>
            <button variant="success" type="submit" className="button-submit">
              Gửi phản hồi
            </button>
          </form>
          <div className="feedback-form-map">
            <div
              className="feedback-form-map-top top-title"
              onClick={() => setOpen(!open)}
            >
              <MapPinned />
              <span class="text-success">Bản đồ</span>
            </div>
            {open ? (
              <div className="feedback-form-map-detail">
                <iframe
                  src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3903.2877902405253!2d108.44201621412589!3d11.95456563961217!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317112d959f88991%3A0x9c66baf1767356fa!2zVHLGsOG7nW5nIMSQ4bqhaSBI4buNYyDEkMOgIEzhuqF0!5e0!3m2!1svi!2s!4v1633261535076!5m2!1svi!2s"
                  width="100%"
                  height="360px"
                  frameborder="0"
                  style={{ border: 0 }}
                  allowfullscreen=""
                  aria-hidden="false"
                  tabindex="0"
                ></iframe>
              </div>
            ) : null}
          </div>
        </div>
      </div>
    </>
  );
};

export default Feedback;
