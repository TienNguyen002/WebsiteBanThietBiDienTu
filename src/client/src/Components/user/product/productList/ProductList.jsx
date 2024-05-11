import React, { useEffect, useState } from "react";
import { ChevronRight } from "lucide-react";
import "../../styles/homePage.scss";
import { useNavigate } from "react-router-dom";
import { getBranchList, getProductList } from "../../../../Api/Controller";
import ProductItem from "../productCard/ProductItem";

const ProductList = (props) => {
  const { title, category } = props;
  const [products, setProducts] = useState();
  const [branches, setBranches] = useState();
  const navigate = useNavigate();

  useEffect(() => {
    getProductList(6, category).then((data) => {
      if (data) {
        setProducts(data);
      } else setProducts([]);
    });

    getBranchList(6, category).then((data) => {
      if (data) {
        setBranches(data);
      } else setBranches([]);
    });
  }, []);

  const handleLink = () => {
    navigate(`/${category}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleBranchLink = (urlSlug) => {
    navigate(`/${category}/${urlSlug}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="product">
        <div className="product-branch">
          <h2 className="product-branch-title">Thương hiệu</h2>
          <div className="product-branch-list">
            {branches ? (
              <>
                {branches.map((item, index) => (
                  <div
                    className="product-branch-list-detail"
                    key={index}
                    onClick={() => handleBranchLink(item.urlSlug)}
                  >
                    <img
                      src={item.imageUrl}
                      alt={item.name}
                      className="product-branch-list-detail-logo"
                    />
                    <div className="product-branch-list-detail-name">
                      {item.name}
                    </div>
                  </div>
                ))}
              </>
            ) : null}

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
            {products ? (
              <>
                {products.map((item, index) => (
                  <ProductItem
                    className="product-comp-item-detail"
                    key={index}
                    name={item.name}
                    slug={item.urlSlug}
                    image={item.imageUrl}
                    current={item.price}
                    orPrice={item.orPrice}
                    star={item.rating}
                    color={item.colors}
                  />
                ))}
              </>
            ) : null}
          </div>
        </div>
      </div>
    </>
  );
};

export default ProductList;
