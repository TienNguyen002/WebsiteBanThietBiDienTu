import React from "react";
import { ChevronRight } from "lucide-react";
import "./productList.scss";
import ProductCard from "../productCard/ProductCard";
import branch from "../../../../Shared/data/branch.json";
import product from "../../../../Shared/data/product.json";
import { useNavigate } from "react-router-dom";

const ProductList = (props) => {
  const { title } = props;
  const navigate = useNavigate();

  const handleLink = () => {
    navigate("/more");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleBranchLink = () => {
    navigate("/branch");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      {title === "Điện thoại" ? (
        <div className="product">
          <div className="product-branch">
            <h2 className="product-branch-title">Thương hiệu</h2>
            <div className="product-branch-list">
              {branch.result.slice(0, 5).map((item, index) => (
                <div
                  className="product-branch-list-detail"
                  key={index}
                  onClick={handleBranchLink}
                >
                  <img
                    src={item.logo}
                    alt={item.name}
                    className="product-branch-list-detail-logo"
                  />
                  <div className="product-branch-list-detail-name">
                    {item.name}
                  </div>
                </div>
              ))}
              <div onClick={handleLink} className="product-branch-list-all">
                Xem tất cả
              </div>
            </div>
          </div>
          <div className="product-comp">
            <div className="product-comp-header">
              <h2 className="product-comp-header-title">{title}</h2>
              <div onClick={handleLink} className="product-comp-header-more">
                Xem tất cả <ChevronRight />
              </div>
            </div>
            <div className="product-comp-item">
              {product.result.map((item, index) => (
                <ProductCard
                  className="product-comp-item-detail"
                  key={index}
                  name={item.name}
                  image={item.image}
                  discount={item.discount}
                  current={item.current}
                  star={item.star}
                  color={item.colors}
                />
              ))}
            </div>
          </div>
        </div>
      ) : (
        <div className="product">
          <div className="product-branch">
            <h2 className="product-branch-title">Thương hiệu</h2>
            <div className="product-branch-list">
              Chưa có thương hiệu nào!!
              {/* {branch.result.slice(0, 5).map((item, index) => (
                <div
                  className="product-branch-list-detail"
                  key={index}
                  onClick={handleBranchLink}
                >
                  <img
                    src={item.logo}
                    alt={item.name}
                    className="product-branch-list-detail-logo"
                  />
                  <div className="product-branch-list-detail-name">
                    {item.name}
                  </div>
                </div>
              ))} */}
              <div onClick={handleLink} className="product-branch-list-all">
                Xem tất cả
              </div>
            </div>
          </div>
          <div className="product-comp">
            <div className="product-comp-header">
              <h2 className="product-comp-header-title">{title}</h2>
              <div onClick={handleLink} className="product-comp-header-more">
                Xem tất cả <ChevronRight />
              </div>
            </div>
            <div className="product-comp-item">
              Chưa có sản phẩm nào!!
              {/* {product.result.map((item, index) => (
                <ProductCard
                  className="product-comp-item-detail"
                  key={index}
                  name={item.name}
                  image={item.image}
                  discount={item.discount}
                  current={item.current}
                  star={item.star}
                  color={item.colors}
                />
              ))} */}
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default ProductList;
