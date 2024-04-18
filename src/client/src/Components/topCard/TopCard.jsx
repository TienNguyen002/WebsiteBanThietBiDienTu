import React from "react";
import StarRating from "../starRating/StarRating";
import { Award, ChevronRight } from "lucide-react";
import "./topCard.scss";
import product from "../../Shared/data/product.json";

const TopCard = (props) => {
  const { title } = props;

  return (
    <>
      <div className="top-card">
        <div className="top-card-header">
          <div className="top-card-header-title">
            <Award />
            {title}
          </div>
          {/* <div className="top-card-header-more">
            Xem tất cả <ChevronRight />
          </div> */}
        </div>
        <div className="top-card-product">
          {product.result.slice(0, 4).map((item, index) => (
            <div className="top-card-product-detail" key={index}>
              <img
                src={item.image}
                alt={item.name}
                className="top-card-product-detail-image"
              />
              <div className="top-card-product-detail-item">
                <h3 className="top-card-product-detail-item-name">
                  {item.name}
                </h3>
                <div className="top-card-product-detail-item-price">
                  <div className="top-card-product-detail-item-price-current">
                    <p>{item.discout}</p>
                  </div>
                  <div className="top-card-product-detail-item-price-original">
                    <s>{item.current}</s>
                  </div>
                </div>
                <StarRating rating={4} className="product-box-detail-rating" />
              </div>
            </div>
          ))}
        </div>
        <div className="top-card-more">Xem tất cả</div>
      </div>
    </>
  );
};

export default TopCard;
