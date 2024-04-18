import React, { useState, useEffect, useRef } from "react";
import "./productCard.scss";
import StarRating from "../starRating/StarRating";
import { ShoppingCart, Heart, Eye } from "lucide-react";
import { Link } from "react-router-dom";

const ProductCard = (props) => {
  const [showAction, setShowAction] = useState(false);
  const productCardRef = useRef(null);
  const { name, image, current, discout, star } = props;
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

  return (
    <>
      <div ref={productCardRef} className="product-box">
        <Link to={"/detail"} className="product-box-detail">
          <img src={image} alt={name} className="product-box-detail-image" />
          <h3 className="product-box-detail-name">{name} </h3>
          <div className="product-box-detail-price">
            <div className="product-box-detail-price-discount">
              <p>{discout}</p>
            </div>
            <div className="product-box-detail-price-current">
              <s>{current}</s>
            </div>
          </div>
          <div className="product-box-info">
            <StarRating rating={star} className="product-box-info-rating" />
            <div to={"/detail"}>
              <Eye className="product-box-info-more" />
            </div>
          </div>
        </Link>
        {showAction && (
          <div className="product-box-action">
            <ShoppingCart className="product-box-action-cart" />
            <Heart className="product-box-action-heart" />
          </div>
        )}
      </div>
    </>
  );
};

export default ProductCard;
