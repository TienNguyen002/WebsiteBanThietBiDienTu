import React from "react";
import { convertDate } from "../../../../Common/function";
import StarRating from "../../product/starRating/StarRating";
import "../../styles/homePage.scss";
import { User2Icon } from "lucide-react";

const CommentDetail = ({ name, detail, rating, commentDate }) => {
  return (
    <div className="comment-detail">
      <div className="comment-detail-top">
        <User2Icon />
        <b>{name}</b>
      </div>

      <div className="comment-detail-middle">
        <b>Ngày bình luận:</b> {convertDate(commentDate)}
        <StarRating rating={rating} />
      </div>
      <p>{detail}</p>
    </div>
  );
};

export default CommentDetail;
