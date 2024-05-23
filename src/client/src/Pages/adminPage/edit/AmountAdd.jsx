import React, { useState, useEffect } from "react";
import "../../../styles/adminLayout.scss";
import { addAmount } from "../../../Api/Controller";
import { Input } from "antd";
import toast from "react-hot-toast";

const AmountAdd = ({ id, onOk, setReloadData }) => {
  const initialState = {
    id: 0,
    amount: "",
  };

  const [product, setProduct] = useState(initialState);

  useEffect(() => {
    resetState();
    setProduct({ id: id });
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    addAmount(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
        setReloadData(true);
        toast.success("Đã nhập hàng");
      } else {
        toast.error("Nhập hàng gặp lỗi");
      }
    });
  };

  const resetState = () => {
    setProduct(initialState);
  };

  return (
    <>
      <div className="edit">
        <h1 className="edit-title">Nhập hàng</h1>
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="edit-form"
        >
          <div className="edit-form-gallery">
            <input
              hidden
              name="Id"
              title="Id"
              value={id}
              onChange={(e) => setProduct({ ...product, id: e.target.value })}
            ></input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Số lượng nhập</p>
            <Input
              name="Amount"
              value={product.amount}
              placeholder={"Nhập số lượng nhập hàng"}
              className="edit-form-title-input"
              onChange={(e) =>
                setProduct({ ...product, amount: e.target.value })
              }
            ></Input>
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

export default AmountAdd;
