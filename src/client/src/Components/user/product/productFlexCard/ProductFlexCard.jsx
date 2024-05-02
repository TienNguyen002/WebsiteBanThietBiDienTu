import React from "react";
import "./productFlexCard.scss";
import StarRating from "../starRating/StarRating";
import { ShoppingCart, Heart, Eye } from "lucide-react";
import { formatVND } from "../../../../Common/function";
import ColorSquare from "../colorSquare/ColorSquare";
import { useNavigate } from "react-router-dom";

const ProductFlexCard = (props) => {
  const { name, image, current, orPrice, star, color, shortDes } = props;
  const navigate = useNavigate();

  const handleLink = () => {
    navigate("/detail");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="product-flex">
        <div className="product-flex-card">
          <img src={image} alt={name} className="product-flex-card-image" />
          <div className="product-flex-card-detail">
            <h3 className="product-flex-card-detail-name">{name} </h3>
            <div className="product-flex-card-detail-color">
              {color.map((item, index) => (
                <ColorSquare key={index} color={item.name} />
              ))}
            </div>
            <StarRating
              rating={star}
              className="product-flex-card-detail-rating"
            />
            <div className="product-flex-card-detail-price">
              <div className="product-flex-card-detail-price-discount">
                <p>{formatVND(current)}</p>
              </div>
              <div className="product-flex-card-detail-price-current">
                <s>{formatVND(orPrice)}</s>
              </div>
            </div>
            <div className="product-flex-card-detail-action">
              <div
                onClick={handleLink}
                className="product-flex-card-detail-action-more"
              >
                <Eye />
              </div>
              <ShoppingCart className="product-flex-card-detail-action-cart" />
              <Heart className="product-flex-card-detail-action-heart" />
            </div>
          </div>
          <div className="product-flex-card-description">{shortDes}</div>
        </div>
      </div>
    </>
  );
};

export default ProductFlexCard;
