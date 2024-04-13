import React from "react";
import StarIcon from "@mui/icons-material/Star";

const StarRating = ({ rating }) => {
  const stars = Array(5)
    .fill(0)
    .map((_, index) => index + 1);

  return (
    <div>
      {stars.map((star) => (
        <StarIcon
          key={star}
          style={{ color: star <= rating ? "gold" : "grey" }}
        />
      ))}
    </div>
  );
};

export default StarRating;
