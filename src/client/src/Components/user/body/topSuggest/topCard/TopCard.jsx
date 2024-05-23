import React from "react";
import StarRating from "../../../product/starRating/StarRating";
import { Award } from "lucide-react";
import { formatVND } from "../../../../../Common/function";
import "../../../styles/homePage.scss";
import { useNavigate } from "react-router-dom";

const TopCard = (props) => {
  const { title, isNew, products, isHighRating, isTop } = props;
  const navigate = useNavigate();

  const handleLink = (urlSlug) => {
    if (isHighRating) {
      navigate("/high-rating");
    }
    if (isNew) {
      navigate("/new");
    }
    if (isTop) {
      navigate("/top");
    }
    if (urlSlug !== "") {
      navigate(`/detail/${urlSlug}`);
    }
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

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
          {products ? (
            <>
              {products.map((item, index) => (
                <div
                  className="top-card-product-detail"
                  key={index}
                  onClick={() => handleLink(item.urlSlug)}
                >
                  <img
                    src={item.imageUrl}
                    alt={item.name}
                    className="top-card-product-detail-image"
                  />
                  <div className="top-card-product-detail-item">
                    <h3 className="top-card-product-detail-item-name">
                      {item.name}
                    </h3>
                    <div className="top-card-product-detail-item-price">
                      {item.price === 0 ? (
                        <div className="top-card-product-detail-item-price-original">
                          <p>{formatVND(item.orPrice)}</p>
                        </div>
                      ) : (
                        <>
                          <div className="top-card-product-detail-item-price-current">
                            <p>{formatVND(item.price)}</p>
                          </div>
                          <div className="top-card-product-detail-item-price-original">
                            <s>{formatVND(item.orPrice)}</s>
                          </div>
                        </>
                      )}
                    </div>
                    {isNew ? null : (
                      <StarRating
                        rating={item.rating}
                        className="product-box-detail-rating"
                      />
                    )}
                  </div>
                </div>
              ))}
            </>
          ) : null}
        </div>
        <div onClick={() => handleLink("")} className="top-card-more">
          Xem tất cả
        </div>
      </div>
    </>
  );
};

export default TopCard;
