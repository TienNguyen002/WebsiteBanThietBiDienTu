import React from "react";
import { Rate } from "antd";

const StarRating = (props) => {
  const { rating } = props;

  return (
    <div>
      <Rate allowHalf disabled defaultValue={rating} />
    </div>
  );
};

export default StarRating;
