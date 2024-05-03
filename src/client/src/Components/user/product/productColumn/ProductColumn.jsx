import React, { useState } from "react";
import "./productColumn.scss";
import { Grip, List } from "lucide-react";
import ProductFlexCard from "../productFlexCard/ProductFlexCard";
import DropDown from "./dropDown/DropDown";
import ProductItem from "./../productCard/ProductItem";

const ProductColumn = ({ products, onPageSizeChange }) => {
  const [grid, setGrid] = useState(true);
  const [selected, setSelected] = useState("");

  const onClickGrid = () => {
    setGrid(true);
    onPageSizeChange(16);
  };

  const onClickFlex = () => {
    setGrid(false);
    onPageSizeChange(8);
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
          {products && products.length > 0
            ? products.map((item, index) =>
                grid ? (
                  <ProductItem
                    key={index}
                    name={item.name}
                    slug={item.urlSlug}
                    image={item.imageUrl}
                    current={item.price}
                    orPrice={item.orPrice}
                    star={item.rating}
                    color={item.colors}
                  />
                ) : grid === false ? (
                  <ProductFlexCard
                    key={index}
                    name={item.name}
                    slug={item.urlSlug}
                    image={item.imageUrl}
                    current={item.price}
                    orPrice={item.orPrice}
                    star={item.rating}
                    color={item.colors}
                    shortDes={item.shortDescription}
                  />
                ) : null
              )
            : null}
        </div>
      </div>
    </>
  );
};

export default ProductColumn;
