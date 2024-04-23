import React, { useState } from "react";
import "./productFilter.scss";
import { Slider } from "antd";
import { formatVND } from "../../../../Common/function";
import branch from "../../../../Shared/data/branch.json";
import { Radio } from "antd";
import ColorSquare from "../colorSquare/ColorSquare";
import color from "../../../../Shared/data/color.json";
import StarRating from "../starRating/StarRating";

const ProductFilter = ({ hasBranch }) => {
  const [branchValue, setBranchValue] = useState("all");
  const [starValue, setStarValue] = useState("all");
  const [minValue, setMinValue] = useState(50000);
  const [maxValue, setMaxValue] = useState(10000000);

  const onBranchChange = (e) => {
    setBranchValue(e.target.value);
  };

  const onStarChange = (e) => {
    setStarValue(e.target.value);
  };

  const onChangeComplete = (value) => {
    setMinValue(value[0]);
    setMaxValue(value[1]);
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
            max={10000000}
            step={50000}
            onChangeComplete={onChangeComplete}
          />
          <div className="product-filter-price-current">
            <p className="product-filter-price-current-title">Giá đang lọc:</p>
            <p className="product-filter-price-current-fprice">
              {formatVND(minValue)} - {formatVND(maxValue)}
            </p>
          </div>
          <p className="product-filter-price-button">Lọc</p>
        </div>
        {hasBranch ? (
          <div className="product-filter-branch">
            <p className="product-filter-line"></p>
            <p className="product-filter-branch-title">Thương hiệu</p>
            <Radio.Group onChange={onBranchChange} value={branchValue}>
              <Radio value="all">Tất cả</Radio>
              {branch.result.map((item, index) => (
                <div className="product-filter-branch-list" key={index}>
                  <Radio
                    value={item.name}
                    className="product-filter-branch-list-name"
                  >
                    {item.name}
                  </Radio>
                </div>
              ))}
            </Radio.Group>
          </div>
        ) : null}
        <div className="product-filter-rating">
          <p className="product-filter-line"></p>
          <p className="product-filter-rating-title">Đánh giá</p>
          <Radio.Group onChange={onStarChange} value={starValue}>
            <Radio value="all">Tất cả</Radio>
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
            <p className="product-filter-color-top-remove">Xóa lọc</p>
          </div>
          {color.result.map((item, index) => (
            <ColorSquare key={index} color={item.color} />
          ))}
        </div>
      </div>
    </>
  );
};

export default ProductFilter;
