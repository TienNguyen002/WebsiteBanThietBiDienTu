import React, { useState, useEffect, useRef } from "react";
import { Input, Select, Upload, Image, Button } from "antd";
import { PlusOutlined } from "@ant-design/icons";
import toast from "react-hot-toast";
import JoditReact from "jodit-react";
import {
  editSerie,
  getAllFilters,
  getSerieById,
  uploadImageEditor,
} from "../../../Api/Controller";

const SerieEdit = ({ id, onOk, setReloadData }) => {
  const initialState = {
    id: 0,
    name: "",
    description: "",
    categoryId: "",
    branchId: "",
    images: [],
  };
  const [serie, setSerie] = useState(initialState);
  const [categories, setCategories] = useState([]);
  const [branches, setBranches] = useState([]);
  const editor = useRef("");

  const filterOption = (input, option) =>
    (option?.label ?? "").toLowerCase().includes(input.toLowerCase());

  const categoryOptions = categories.map((category) => ({
    value: category.id,
    label: category.name,
  }));

  const branchOptions = branches.map((branch) => ({
    value: branch.id,
    label: branch.name,
  }));

  useEffect(() => {
    if (id === 0) {
      resetState();
    }
    if (id > 0) {
      getSerieById(id).then((data) => {
        if (data) {
          setSerie({
            id: data.id,
            name: data.name,
            description: data.description,
            categoryId: data.category.id,
            branchId: data.branch.id,
            images: data.images,
          });
        } else setSerie(initialState);
      });
    }
    getAllFilters().then((data) => {
      if (data) {
        setCategories(data.categories);
        setBranches(data.branches);
      } else {
        setCategories([]);
        setBranches([]);
      }
    });
  }, [id]);

  const handleImageUpload = async ({ file, onSuccess, onError }) => {
    try {
      const imageInfo = await uploadImageEditor(file);
      if (imageInfo && imageInfo.secure_url) {
        setSerie((prevState) => ({
          ...prevState,
          images: [...prevState.images, { imageUrl: imageInfo.secure_url }],
        }));
        {
          console.log(imageInfo.secure_url);
        }
        onSuccess("OK");
      } else {
        onError("Error: Invalid image URL");
      }
    } catch (error) {
      onError("Error uploading image");
    }
  };

  const handleImageRemove = (file) => {
    setSerie((prevState) => ({
      ...prevState,
      images: prevState.images.filter((image) => image.imageUrl !== file.url),
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    formData.set("Description", editor.current.value || serie.description);
    formData.set("CategoryId", serie.categoryId);
    formData.set("BranchId", serie.branchId);
    console.log(serie.images);
    serie.images.forEach((image, index) => {
      formData.append(`Images[${index}]`, image.imageUrl);
    });
    editSerie(formData).then((data) => {
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

  const resetState = () => {
    setSerie(initialState);
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

  return (
    <>
      <div className="edit">
        {id === 0 ? (
          <h1 className="edit-title">Thêm dòng sản phẩm</h1>
        ) : (
          <h1 className="edit-title">Chỉnh sửa dòng sản phẩm</h1>
        )}

        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleSubmit}
          className="edit-form"
        >
          <input
            hidden
            name="Id"
            title="Id"
            value={id}
            onChange={(e) => setSerie({ ...serie, id: e.target.value })}
          ></input>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Tên dòng sản phẩm</p>
            <Input
              name="name"
              value={serie.name}
              placeholder={"Nhập tên dòng sản phẩm"}
              className="edit-form-title-input"
              onChange={(e) => setSerie({ ...serie, name: e.target.value })}
            ></Input>
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Mô tả</p>
            <JoditReact
              ref={editor}
              name="Description"
              type="text"
              value={serie.description}
              config={editorConfig}
            />
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Chọn danh mục</p>
            <Select
              showSearch
              allowClear
              placeholder="Lựa chọn danh mục"
              optionFilterProp="children"
              onChange={(value) => setSerie({ ...serie, categoryId: value })}
              value={serie.categoryId}
              filterOption={filterOption}
              options={categoryOptions}
              className="edit-form-select"
            />
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Chọn thương hiệu</p>
            <Select
              showSearch
              allowClear
              placeholder="Lựa chọn thương hiệu"
              optionFilterProp="children"
              onChange={(value) => setSerie({ ...serie, branchId: value })}
              value={serie.branchId}
              filterOption={filterOption}
              options={branchOptions}
              className="edit-form-select"
            />
          </div>
          <div className="edit-form-title">
            <p className="edit-form-title-name">Quản lý hình ảnh</p>
            <Upload
              customRequest={handleImageUpload}
              listType="picture-card"
              fileList={serie.images.map((image, index) => ({
                uid: index,
                name: `image-${index}`,
                status: "done",
                url: image.imageUrl,
              }))}
              onRemove={handleImageRemove}
              accept=".jpg,.jpeg,.png"
            >
              {serie.images.length >= 8 ? null : (
                <div>
                  <PlusOutlined />
                  <div style={{ marginTop: 8 }}>Tải lên</div>
                </div>
              )}
            </Upload>
          </div>
          <div className="edit-form-button">
            <Button type="primary" htmlType="submit">
              {id === 0 ? "Thêm" : "Chỉnh sửa"}
            </Button>
          </div>
        </form>
      </div>
    </>
  );
};

export default SerieEdit;
