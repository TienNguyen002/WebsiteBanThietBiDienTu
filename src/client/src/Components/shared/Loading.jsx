import React from "react";
import loading from "../../Shared/images/preloader.gif";
import "./shared.scss";

const Loading = () => {
  return (
    <>
      <div className="loading">
        <p>ĐANG TẢI</p>
        <img src={loading} alt="Loading" />
      </div>
    </>
  );
};

export default Loading;
