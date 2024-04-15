import React from "react";
import StarRating from "../starRating/StarRating";
import { Award, ChevronRight } from "lucide-react";
import "./topCard.scss";

const TopCard = (props) => {
  return (
    <>
      <div className="top-card">
        <div className="top-card-header">
          <div className="top-card-header-title">
            <Award />
            Top Rating
          </div>
          <div className="top-card-header-more">
            Xem tất cả <ChevronRight />
          </div>
        </div>
        <div className="top-card-product">
          <div className="top-card-product-detail">
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-s23-ulatra_2__1.png"
              alt="anh"
              className="top-card-product-detail-image"
            />
            <StarRating rating={4} className="product-box-detail-rating" />
            <h3 className="top-card-product-detail-name">Tên sản phẩm</h3>
            <div className="top-card-product-detail-price">
              <div className="top-card-product-detail-price-current">
                <p>8.000.000đ</p>
              </div>
              <div className="top-card-product-detail-price-original">
                <s>10.000.000đ</s>
              </div>
            </div>
          </div>
          <div className="top-card-product-detail">
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-s23-ulatra_2__1.png"
              alt="anh"
              className="top-card-product-detail-image"
            />
            <StarRating rating={4} className="product-box-detail-rating" />
            <h3 className="top-card-product-detail-name">Tên sản phẩm</h3>
            <div className="top-card-product-detail-price">
              <div className="top-card-product-detail-price-current">
                <p>8.000.000đ</p>
              </div>
              <div className="top-card-product-detail-price-original">
                <s>10.000.000đ</s>
              </div>
            </div>
          </div>
          <div className="top-card-product-detail">
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-s23-ulatra_2__1.png"
              alt="anh"
              className="top-card-product-detail-image"
            />
            <StarRating rating={4} className="product-box-detail-rating" />
            <h3 className="top-card-product-detail-name">Tên sản phẩm</h3>
            <div className="top-card-product-detail-price">
              <div className="top-card-product-detail-price-current">
                <p>8.000.000đ</p>
              </div>
              <div className="top-card-product-detail-price-original">
                <s>10.000.000đ</s>
              </div>
            </div>
          </div>
          <div className="top-card-product-detail">
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-s23-ulatra_2__1.png"
              alt="anh"
              className="top-card-product-detail-image"
            />
            <StarRating rating={4} className="product-box-detail-rating" />
            <h3 className="top-card-product-detail-name">Tên sản phẩm</h3>
            <div className="top-card-product-detail-price">
              <div className="top-card-product-detail-price-current">
                <p>8.000.000đ</p>
              </div>
              <div className="top-card-product-detail-price-original">
                <s>10.000.000đ</s>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default TopCard;
