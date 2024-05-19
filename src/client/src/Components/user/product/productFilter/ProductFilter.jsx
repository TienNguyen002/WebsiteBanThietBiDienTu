import React, { useState } from "react";
import "../../styles/homePage.scss";
import { Slider } from "antd";
import { formatVND } from "../../../../Common/function";
import { Radio } from "antd";
import ColorSquare from "../../common/ColorSquare";
import StarRating from "../starRating/StarRating";

const ProductFilter = ({
  hasBranch,
  branches,
  colors,
  onMinMaxFilterChange,
  onBranchFilterChange,
  onRatingFilterChange,
  onColorFilterChange,
}) => {
  const [branchValue, setBranchValue] = useState("");
  const [starValue, setStarValue] = useState(0);
  const [minValue, setMinValue] = useState(50000);
  const [maxValue, setMaxValue] = useState(50000000);
  const [colorSelect, setColorSelect] = useState({});

  const onBranchChange = (e) => {
    setBranchValue(e.target.value);
    onBranchFilterChange(e.target.value);
  };

  const onStarChange = (e) => {
    setStarValue(e.target.value);
    onRatingFilterChange(e.target.value);
  };

  const onChangeComplete = (value) => {
    setMinValue(value[0]);
    setMaxValue(value[1]);
  };

  const handleColorClick = (slug, name) => {
    onColorFilterChange(slug);
    setColorSelect(name);
  };

  const resetColor = () => {
    onColorFilterChange("");
  };

  const filterPrice = () => {
    onMinMaxFilterChange(minValue, maxValue);
  };

  return (
    <>
      <div className="product-filter">
        <div className="product-filter-title">
          <h3>Bộ lọc sản phẩm</h3>
        </div>
        <div className="product-filter-price">
          <p className="product-filter-line"></p>
          <div className="product-filter-price-title">Giá tiền</div>
          <Slider
            range={{
              draggableTrack: true,
            }}
            defaultValue={[minValue, maxValue]}
            min={50000}
            max={50000000}
            step={50000}
            onChangeComplete={onChangeComplete}
          />
          <div className="product-filter-price-current">
            <p className="product-filter-price-current-title">Giá đang lọc:</p>
            <p className="product-filter-price-current-fprice">
              {formatVND(minValue)} - {formatVND(maxValue)}
            </p>
          </div>
          <button className="product-filter-price-button" onClick={filterPrice}>
            Lọc
          </button>
        </div>
        {hasBranch ? (
          <div className="product-filter-branch">
            <p className="product-filter-line"></p>
            <p className="product-filter-branch-title">Thương hiệu</p>
            <Radio.Group onChange={onBranchChange} value={branchValue}>
              <Radio value="">Tất cả</Radio>
              {branches && branches.length > 0
                ? branches.map((item, index) => (
                    <div className="product-filter-branch-list" key={index}>
                      <Radio
                        value={item.name}
                        className="product-filter-branch-list-name"
                      >
                        {item.name}
                      </Radio>
                    </div>
                  ))
                : null}
            </Radio.Group>
          </div>
        ) : null}
        <div className="product-filter-rating">
          <p className="product-filter-line"></p>
          <p className="product-filter-rating-title">Đánh giá</p>
          <Radio.Group onChange={onStarChange} value={starValue}>
            <Radio value={0}>Tất cả</Radio>
            <div className="product-filter-rating-list">
              <Radio value={5} className="product-filter-rating-list-5">
                <StarRating rating={5} />
              </Radio>
              <Radio value={4} className="product-filter-rating-list-4">
                <StarRating rating={4} />
              </Radio>
              <Radio value={3} className="product-filter-rating-list-3">
                <StarRating rating={3} />
              </Radio>
              <Radio value={2} className="product-filter-rating-list-2">
                <StarRating rating={2} />
              </Radio>
              <Radio value={1} className="product-filter-rating-list-1">
                <StarRating rating={1} />
              </Radio>
            </div>
          </Radio.Group>
        </div>
        <div className="product-filter-color">
          <p className="product-filter-line"></p>
          <div className="product-filter-color-top">
            <p className="product-filter-color-top-title">Màu</p>
            <button
              className="product-filter-color-top-remove"
              onClick={resetColor}
            >
              Xóa lọc
            </button>
          </div>
          {colors && colors.length > 0
            ? colors.map((item, index) => (
                <>
                  <ColorSquare
                    key={index}
                    color={item.name}
                    slug={item.urlSlug}
                    select={colorSelect}
                    onClick={() => handleColorClick(item.urlSlug, item.name)}
                  />
                </>
              ))
            : null}
        </div>
      </div>
    </>
  );
};

export default ProductFilter;
