import React, { useState, useEffect, useRef } from "react";
import "./productCard.scss";
import StarRating from "../starRating/StarRating";
import { ShoppingCart, Heart, Eye } from "lucide-react";
import { Link } from "react-router-dom";

const ProductCard = () => {
  const [showAction, setShowAction] = useState(false);
  const productCardRef = useRef(null);

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
          <img
            src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/e/tecno-spark-20-pro-plus_1__2.png"
            alt="Tên sản phẩm"
            className="product-box-detail-image"
          />
          <h3 className="product-box-detail-name">Tên sản phẩm </h3>
          <div className="product-box-detail-price">
            <div className="product-box-detail-price-discount">
              <p>8.000.000đ</p>
            </div>
            <div className="product-box-detail-price-current">
              <s>10.000.000đ</s>
            </div>
          </div>
          <div className="product-box-info">
            <StarRating rating={4} className="product-box-info-rating" />
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
