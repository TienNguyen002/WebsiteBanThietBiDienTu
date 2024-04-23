import React, { useState } from "react";
import "./productColumn.scss";
import PageComponent from "../../common/pagination/PageComponent";
import { Grip, List } from "lucide-react";
import ProductCard from "../productCard/ProductCard";
import ProductFlexCard from "../productFlexCard/ProductFlexCard";
import product from "../../../../Shared/data/product.json";
import DropDown from "./dropDown/DropDown";

const ProductColumn = () => {
  const [grid, setGrid] = useState(true);
  const [selected, setSelected] = useState("");

  const onClickGrid = () => {
    setGrid(true);
  };

  const onClickFlex = () => {
    setGrid(false);
  };

  return (
    <>
      <div className="product-list">
        <div className="product-list-top">
          <div className="product-list-top-view">
            <button
              className={
                grid
                  ? `product-list-top-view-grid-show`
                  : `product-list-top-view-grid`
              }
              onClick={onClickGrid}
            >
              <Grip />
            </button>
            <button
              className={
                grid
                  ? `product-list-top-view-flex`
                  : `product-list-top-view-flex-show`
              }
              onClick={onClickFlex}
            >
              <List />
            </button>
          </div>
          <DropDown selected={selected} setSelected={setSelected} />
        </div>
        <div className={grid ? "product-list-grid" : ""}>
          {product.result.map((item, index) =>
            grid ? (
              <ProductCard
                key={index}
                name={item.name}
                image={item.image}
                current={item.current}
                discount={item.discount}
                star={item.star}
                color={item.colors}
              />
            ) : grid === false ? (
              <ProductFlexCard
                key={index}
                name={item.name}
                image={item.image}
                current={item.current}
                discount={item.discount}
                star={item.star}
                color={item.colors}
              />
            ) : null
          )}
        </div>
        <div className="product-list-page">
          <PageComponent />
        </div>
      </div>
    </>
  );
};

export default ProductColumn;
