import React from "react";
import { convertDate } from "../../../../Common/function";
import StarRating from "../../product/starRating/StarRating";
import "../../styles/homePage.scss";

const CommentDetail = ({ image, name, detail, rating, commentDate }) => {
  const editImageFrame =
    "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";

  return (
    <div className="comment-detail">
      <div className="comment-detail-image">
        {image === "" || image === null ? (
          <img src={editImageFrame} alt={name} />
        ) : (
          <img src={image} alt={name} />
        )}
      </div>
      <div className="comment-detail-info">
        <b>{name}</b>
        <div className="comment-detail-middle">
          <b>Ngày bình luận:</b> {convertDate(commentDate)}
          <StarRating rating={rating} />
        </div>
        <p>{detail}</p>
      </div>
    </div>
  );
};

export default CommentDetail;
