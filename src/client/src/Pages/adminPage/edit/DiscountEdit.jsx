import React, { useEffect, useState } from "react";
import "../../../styles/adminLayout.scss";
import { createDiscount } from "../../../Api/Controller";
import { DatePicker, Input, Button } from "antd";
import toast from "react-hot-toast";
import { generateRandomCode } from "../../../Common/function";

const DiscountEdit = ({ id, onOk, setReloadData }) => {
  const initialState = {
    codeName: "",
    discountPrice: "",
    endDate: "",
  };
  const [discount, setDiscount] = useState(initialState);

  useEffect(() => {
    resetState();
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    formData.set("Rating", discount.endDate);
    createDiscount(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
        setReloadData(true);
        toast.success("Thêm thành công");
      } else {
        toast.success("Thêm thất bại");
      }
    });
  };

  const resetState = () => {
    setDiscount(initialState);
  };

  return (
    <>
      <div className="edit">
        <h1 className="edit-title">Thêm mã giảm giá</h1>
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="edit-form"
        >
          <div className="edit-form-title">
            <div className="edit-form-title-top">
              <p className="edit-form-title-name">Tên mã giảm giá</p>
              <Button
                onClick={() =>
                  setDiscount({ ...discount, codeName: generateRandomCode() })
                }
              >
                Tạo mã ngẫu nhiên
              </Button>
            </div>
            <Input
              name="codeName"
              value={discount.codeName}
              placeholder={"Nhập tên mã giảm giá"}
              className="edit-form-title-input"
              onChange={(e) =>
                setDiscount({ ...discount, codeName: e.target.value })
              }
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Phần trăm giảm</p>
            <Input
              name="discountPrice"
              value={discount.discountPrice}
              placeholder={"Nhập tên mã giảm giá"}
              className="edit-form-title-input"
              onChange={(e) =>
                setDiscount({ ...discount, discountPrice: e.target.value })
              }
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Ngày kết thúc</p>
            <DatePicker
              showTime
              name="endDate"
              placeholder="Thời gian kết thúc ưu đãi"
              onChange={(value) => {
                setDiscount({ ...discount, endDate: value });
              }}
              className="management-date-picker"
              width="100px"
              //   onOk={onOk}
            />
          </div>
          <div className="edit-form-button">
            <button type="submit" className="edit-form-button-submit">
              Thêm
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default DiscountEdit;
