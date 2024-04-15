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
      {/* <Link to={"/detail"}> */}
      <div ref={productCardRef} className="product-box">
        <img
          src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/e/tecno-spark-20-pro-plus_1__2.png"
          alt="Tên sản phẩm"
          className="product-box-image"
        />
        <h3 className="product-box-name">
          <Link to={"/detail"} className="product-box-name-detail">
            Tên sản phẩm
          </Link>
        </h3>
        <div className="product-box-price">
          <div className="product-box-price-discount">
            <p>8.000.000đ</p>
          </div>
          <div className="product-box-price-current">
            <s>10.000.000đ</s>
          </div>
        </div>
        <div className="product-box-detail">
          <StarRating rating={4} className="product-box-detail-rating" />
          <Link to={"/detail"}>
            <Eye className="product-box-detail-more" />
          </Link>
        </div>
        {showAction && (
          <div className="product-box-action">
            <ShoppingCart className="product-box-action-cart" />
            <Heart className="product-box-action-heart" />
          </div>
        )}
      </div>
      {/* </Link> */}
    </>
  );
};

export default ProductCard;
