import React, { useState } from "react";
import "./productColumn.scss";
import { Grip, List } from "lucide-react";
import ProductFlexCard from "../productFlexCard/ProductFlexCard";
import DropDown from "./dropDown/DropDown";
import ProductItem from "./../productCard/ProductItem";
import { useDispatch, useSelector } from "react-redux";
import { reset, updateGrid } from "../../../../Redux/Grid";

const ProductColumn = ({ products, onPageSizeChange }) => {
  const [selected, setSelected] = useState("");
  const gridChange = useSelector((state) => state.gridChange);
  const dispatch = useDispatch();

  const handleReset = (e) => {
    dispatch(reset());
    onPageSizeChange(16);
  };

  const onBranchChange = () => {
    dispatch(updateGrid());
    onPageSizeChange(8);
  };

  // const onClickGrid = () => {
  //   setGrid(true);
  //   onPageSizeChange(16);
  // };

  // const onClickFlex = () => {
  //   setGrid(false);
  //   onPageSizeChange(8);
  // };

  return (
    <>
      <div className="product-list">
        <div className="product-list-top">
          <div className="product-list-top-view">
            <button
              className={
                gridChange.grid
                  ? `product-list-top-view-grid-show`
                  : `product-list-top-view-grid`
              }
              onClick={handleReset}
            >
              <Grip />
            </button>
            <button
              className={
                gridChange.grid
                  ? `product-list-top-view-flex`
                  : `product-list-top-view-flex-show`
              }
              onClick={onBranchChange}
            >
              <List />
            </button>
          </div>
          <DropDown selected={selected} setSelected={setSelected} />
        </div>
        <div className={gridChange.grid ? "product-list-grid" : ""}>
          {products && products.length > 0
            ? products.map((item, index) =>
                gridChange.grid ? (
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
                ) : gridChange.grid === false ? (
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
