import React, { useState, useEffect } from "react";
import "../../../styles/adminLayout.scss";
import { addProductSale } from "../../../Api/Controller";
import { Input } from "antd";
import toast from "react-hot-toast";

const ProductSaleEdit = ({ id, onOk, setReloadData }) => {
  const initialState = {
    id: 0,
    salePrice: "",
  };

  const [product, setProduct] = useState(initialState);

  useEffect(() => {
    resetState();
    setProduct({ id: id });
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    addProductSale(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
        setReloadData(true);
        toast.success("Thêm thành công");
      } else {
        toast.error("Thêm thất bại");
      }
    });
  };

  const resetState = () => {
    setProduct(initialState);
  };

  return (
    <>
      <div className="edit">
        <h1 className="edit-title">
          Nhập giá trước khi thêm vào danh sách ưu đãi
        </h1>
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
            <p className="edit-form-title-name">Giá ưu đãi</p>
            <Input
              name="SalePrice"
              value={product.salePrice}
              placeholder={"Nhập giá ưu đãi"}
              className="edit-form-title-input"
              onChange={(e) =>
                setProduct({ ...product, salePrice: e.target.value })
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

export default ProductSaleEdit;
