import React, { useState, useEffect, useRef } from "react";
import "../../../styles/adminLayout.scss";
import {
  editBranch,
  editProduct,
  getAllFilters,
  getProductById,
  uploadImageEditor,
} from "../../../Api/Controller";
import { Input, Select } from "antd";
import toast from "react-hot-toast";
import JoditReact from "jodit-react";

const ProductEdit = ({ id, serieId, onOk, setReloadData }) => {
  const initialState = {
    id: 0,
    name: "",
    shortName: "",
    imageUrl: "",
    shortDescription: "",
    specification: "",
    price: "",
    orPrice: "",
    serieId: "",
    colors: [],
  };

  const shortDesEditor = useRef("");
  const speciEditor = useRef("");

  const [product, setProduct] = useState(initialState);
  const [colors, setColors] = useState([]);
  const [selectedColors, setSelectedColors] = useState(
    product.colors.map((color) => color.id)
  );
  const editImageFrame =
    "https://t4.ftcdn.net/jpg/04/81/13/43/360_F_481134373_0W4kg2yKeBRHNEklk4F9UXtGHdub3tYk.jpg";

  useEffect(() => {
    if (id === 0) {
      resetState();
    }
    if (id > 0) {
      getProductById(id).then((data) => {
        if (data) {
          setProduct(data);
        } else setProduct(initialState);
      });
    }
    getAllFilters().then((data) => {
      if (data) {
        setColors(data.colors);
      } else {
        setColors([]);
      }
    });
  }, [id]);

  const colorOptions = colors.map((color) => ({
    value: color.id,
    label: color.name,
  }));

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onloadend = async () => {
      if (reader.result) {
        setProduct({ ...product, imageUrl: reader.result });
      }
    };
    reader.readAsDataURL(file);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    product.colors.forEach((selectedColors) => {
      formData.set("Colors", selectedColors.name);
    });
    editProduct(formData).then((data) => {
      if (data) {
        onOk();
        resetState();
        setReloadData(true);
        if (id === 0) {
          toast.success("Thêm thành công");
        } else toast.success("Chỉnh sửa thành công");
      } else {
        if (id === 0) {
          toast.error("Thêm thất bại");
        } else toast.error("Chỉnh sửa thất bại");
      }
    });
  };

  const handleChange = (selectedColors) => {
    setSelectedColors(selectedColors);
  };

  const resetState = () => {
    setProduct(initialState);
  };

  const editorConfig = {
    readonly: false,
    toolbar: true,
    spellcheck: false,
    language: "en",
    autofocus: false,
    toolbarButtonSize: "small",
    toolbarAdaptive: false,
    showCharsCounter: false,
    showWordsCounter: false,
    showXPathInStatusbar: false,
    askBeforePasteHTML: true,
    askBeforePasteFromWord: true,
    width: 1000,
    height: 500,
    defaultActionOnPaste: "insert_clear_html",
    placeholder: "Viết mô tả về sản phẩm",
    beautyHTML: true,
    controls: {
      image: {
        exec: async (editor) => {
          await imageUpload(editor);
        },
      },
    },
  };

  const handleRemove = (removedTag) => {
    const newSelectedColors = selectedColors.filter(
      (colorId) => colorId !== removedTag
    );
    setSelectedColors(newSelectedColors);
    setProduct({
      ...product,
      colors: product.colors.filter((color) => color.id !== removedTag),
    });
  };

  console.log(product.colors);
  const imageUpload = async (editor) => {
    const input = document.createElement("input");
    input.setAttribute("type", "file");
    input.setAttribute("accept", "image/*");
    input.click();
    input.onchange = async function () {
      const imageFile = input.files[0];
      if (!imageFile) {
        return;
      }
      if (!imageFile.name.match(/\.(jpg|jpeg|png)$/)) {
        return;
      }
      const imageInfo = await uploadImageEditor(imageFile);
      insertImage(editor, imageInfo);
    };
  };

  const insertImage = (editor, image) => {
    const imgNode = editor.create.fromHTML(
      `<img src="${image.secure_url}" alt="${image.original_filename}" />`
    );
    editor.selection.insertNode(imgNode);
  };

  const handleInputKeyDown = (e) => {
    if (e.key === "Enter") {
      e.preventDefault();
      const newColor = { id: Date.now(), name: e.target.value };
      setColors([...colors, newColor]);
      setProduct({ ...product, colors: [...product.colors, newColor] });
      e.target.value = "";
    }
  };

  return (
    <>
      <div className="edit">
        {id === 0 ? (
          <h1 className="edit-title">Thêm sản phẩm</h1>
        ) : (
          <h1 className="edit-title">Chỉnh sửa sản phẩm</h1>
        )}

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
            <input
              hidden
              name="SerieId"
              title="SerieId"
              value={serieId}
              onChange={(e) =>
                setProduct({ ...product, serieId: e.target.value })
              }
            ></input>
            <label htmlFor="uploadGallery">
              {product.imageUrl === "" || product.imageUrl === null ? (
                <img
                  src={editImageFrame}
                  className="edit-form-gallery-image"
                  alt={product.name}
                />
              ) : (
                <img
                  src={product.imageUrl}
                  className="edit-form-gallery-image"
                  alt={product.name}
                />
              )}
              <input
                id="uploadGallery"
                type="file"
                name="ImageFile"
                title="ImageFile"
                onChange={handleImageChange}
                accept=".png, .jpg, .jpeg"
                className="setGallery"
                hidden
              />
            </label>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên sản phẩm</p>
            <Input
              name="name"
              value={product.name}
              placeholder={"Nhập tên sản phẩm"}
              className="edit-form-title-input"
              onChange={(e) => setProduct({ ...product, name: e.target.value })}
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên ngắn gọn của sản phẩm</p>
            <Input
              name="shortName"
              value={product.shortName}
              placeholder={"Nhập tên ngắn gọn sản phẩm"}
              className="edit-form-title-input"
              onChange={(e) =>
                setProduct({ ...product, shortName: e.target.value })
              }
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Mô tả ngắn</p>
            <JoditReact
              ref={shortDesEditor}
              name="ShortDescription"
              type="text"
              value={product.shortDescription}
              config={editorConfig}
            />
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Thông số kỹ thuật</p>
            <JoditReact
              ref={speciEditor}
              name="Specification"
              type="text"
              value={product.specification}
              config={editorConfig}
            />
          </div>
          {id > 0 ? (
            <div className="edit-form-title">
              <p className="edit-form-title-name">Giá hiện tại</p>
              <Input
                name="price"
                value={product.price}
                placeholder={"Nhập vào giá hiện tại"}
                className="edit-form-title-input"
                onChange={(e) =>
                  setProduct({ ...product, price: e.target.value })
                }
              ></Input>
            </div>
          ) : null}
          <div className="edit-form-title">
            <p className="edit-form-title-name">Giá gốc</p>
            <Input
              name="orPrice"
              value={product.orPrice}
              placeholder={"Nhập vào giá gốc"}
              className="edit-form-title-input"
              onChange={(e) =>
                setProduct({ ...product, orPrice: e.target.value })
              }
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Màu sản phẩm</p>
            <Select
              mode="tags"
              style={{ width: "100%" }}
              placeholder="Chọn màu cho sản phẩm"
              value={product.colors.map((color) => color.id)}
              onChange={handleChange}
              options={colorOptions}
              onInputKeyDown={handleInputKeyDown}
              filterOption={(input, option) =>
                option.label.toLowerCase().indexOf(input.toLowerCase()) >= 0
              }
              onDeselect={handleRemove}
            />
          </div>
          <div className="edit-form-button">
            <button type="submit" className="edit-form-button-submit">
              {id === 0 ? "Thêm" : "Chỉnh sửa"}
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default ProductEdit;
