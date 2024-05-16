import React, { useState, useEffect, useRef } from "react";
import "../../styles/homePage.scss";
import StarRating from "../starRating/StarRating";
import { ShoppingCart, Heart, Eye } from "lucide-react";
import { formatVND } from "../../../../Common/function";
import ColorSquare from "../../common/ColorSquare";
import { useNavigate } from "react-router-dom";

const ProductItem = (props) => {
  const [showAction, setShowAction] = useState(false);
  const productCardRef = useRef(null);
  const { name, image, slug, current, orPrice, star, color } = props;
  const navigate = useNavigate();

  const discountAmount = orPrice - current;
  const discountPercentage = (discountAmount / orPrice) * 100;

  useEffect(() => {
    const handleMouseEnter = () => {
      setShowAction(true);
    };

    const handleMouseLeave = () => {
      setShowAction(false);
    };

    if (productCardRef.current) {
      productCardRef.current.addEventListener("mouseenter", handleMouseEnter);
      productCardRef.current.addEventListener("mouseleave", handleMouseLeave);
    }
  }, []);

  const handleLink = () => {
    navigate(`/detail/${slug}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div ref={productCardRef} className="product-box">
        <div className="product-box-discount">
          Giảm {discountPercentage.toFixed(0)}%
        </div>
        <div to={"/detail"} className="product-box-detail">
          <div className="product-box-detail-top">
            <img
              src={image}
              alt={name}
              className="product-box-detail-top-image"
            />
            {showAction && (
              <div className="product-box-detail-top-action">
                <li className="product-box-detail-top-action-item">
                  <ShoppingCart className="product-box-detail-top-action-item-cart" />
                </li>
                <li className="product-box-detail-top-action-item">
                  <Eye
                    className="product-box-detail-top-action-item-more"
                    onClick={handleLink}
                  />
                </li>
                <li className="product-box-detail-top-action-item">
                  <Heart className="product-box-detail-top-action-item-heart" />
                </li>
              </div>
            )}
          </div>
          <p className="product-filter-line"></p>
          <h3 className="product-box-detail-name">{name} </h3>
          <div className="product-box-detail-color">
            {color.map((item, index) => (
              <ColorSquare key={index} color={item.name} />
            ))}
          </div>
          <div className="product-box-detail-price">
            <div className="product-box-detail-price-discount">
              <p>{formatVND(current)}</p>
            </div>
            <div className="product-box-detail-price-current">
              <s>{formatVND(orPrice)}</s>
            </div>
          </div>
          <div className="product-box-info">
            <StarRating rating={star} className="product-box-info-rating" />
          </div>
        </div>
        {/* {showAction && (
          <div className="product-box-action">
            <ShoppingCart className="product-box-action-cart" />
            <Heart className="product-box-action-heart" />
          </div>
        )} */}
      </div>
    </>
  );
};

export default ProductItem;
