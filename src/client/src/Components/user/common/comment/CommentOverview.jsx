import React, { useEffect } from "react";
import "../../styles/homePage.scss";

const CommentOverview = ({ rating, total }) => {
  useEffect(() => {}, []);

  return (
    <>
      <div className="comment-overview">
        <div className="comment-overview-total">
          <div>
            {rating}/5
            <i class="fa-solid fa-star star-icon"></i>
          </div>
          <div>{total.totalRating} đánh giá</div>
        </div>
        <div className="comment-overview-rating">
          <div>
            5<i class="fa-solid fa-star star-icon"></i>: {total.total5Rating}{" "}
            đánh giá
          </div>
          <div>
            4<i class="fa-solid fa-star star-icon"></i>: {total.total4Rating}{" "}
            đánh giá
          </div>
          <div>
            3<i class="fa-solid fa-star star-icon"></i>: {total.total3Rating}{" "}
            đánh giá
          </div>
          <div>
            2<i class="fa-solid fa-star star-icon"></i>: {total.total2Rating}{" "}
            đánh giá
          </div>
          <div>
            1<i class="fa-solid fa-star star-icon"></i>: {total.total1Rating}{" "}
            đánh giá
          </div>
        </div>
      </div>
    </>
  );
};

export default CommentOverview;
