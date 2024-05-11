import React, { useEffect, useState } from "react";
import Branch from "../../Components/user/common/Branch";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/homeLayout.scss";
import { useParams } from "react-router-dom";
import { getProductFilter, getPagedProduct } from "../../Api/Controller";
import NavigationBar from "../../Components/user/common/NavigationBar";
import PageComponent from "../../Components/user/common/PageComponent";

const MorePage = ({ isSale, isHighRating, isNew, isTop }) => {
  const param = useParams();
  let { category } = param;
  const [branches, setBranches] = useState();
  const [colors, setColors] = useState();
  const [products, setProducts] = useState([]);
  const [metadata, setMetadata] = useState();
  const [naviBar, setNaviBar] = useState("");

  const filterPayload = {
    isSale: isSale,
    isHighRating: isHighRating,
    isNew: isNew,
    isTop: isTop,
    category: category,
  };

  const [payload, setPayload] = useState({
    isSale: isSale,
    isHighRating: isHighRating,
    isNew: isNew,
    isTop: isTop,
    sortOrder: "",
    category: category,
    branch: "",
    minPrice: 50000,
    maxPrice: 50000000,
    rating: 0,
    color: "",
    pageSize: 16,
    pageNumber: 1,
  });

  useEffect(() => {
    if (isSale) {
      setNaviBar("Ưu đãi");
    }
    if (isHighRating) {
      setNaviBar("Sản phẩm đánh giá cao");
    }
    if (isNew) {
      setNaviBar("Sản phẩm mới");
    }
    if (isTop) {
      setNaviBar("Sản phẩm bán chạy");
    }
    getProductFilter(filterPayload).then((data) => {
      if (data) {
        setBranches(data.branches);
        setColors(data.colors);
      } else {
        setBranches();
        setColors();
      }
    });

    getPagedProduct(payload).then((data) => {
      if (data) {
        setProducts(data.items);
        setMetadata(data.metadata);
      } else {
        setProducts([]);
        setMetadata(null);
      }
    });
  }, [payload]);

  const handlePageChange = (pageNumber) => {
    setPayload((prevPayload) => ({ ...prevPayload, pageNumber }));
  };

  const handleMinMaxChange = (minPrice, maxPrice) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      minPrice,
      maxPrice,
    }));
  };

  const handleBranchChange = (branch) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      branch,
    }));
  };

  const handleRatingChange = (rating) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      rating,
    }));
  };

  const handlePageSize = (pageSize) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      pageSize,
      pageNumber: 1,
    }));
  };

  const handleSortChange = (sortOrder) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      sortOrder,
    }));
  };

  const handleColorChange = (color) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      color,
    }));
  };

  return (
    <>
      <NavigationBar title={naviBar} category={category} />
      <div className="list-page">
        <div className="list-page-branch">
          <Branch sale={true} branch={branches} />
        </div>
        <div className="list-page-product">
          <div className="list-page-product-filter">
            <ProductFilter
              hasBranch={false}
              branches={branches}
              colors={colors}
              onMinMaxFilterChange={handleMinMaxChange}
              onBranchFilterChange={handleBranchChange}
              onRatingFilterChange={handleRatingChange}
              onColorFilterChange={handleColorChange}
            />
          </div>
          <div className="list-page-product-list">
            <ProductColumn
              products={products}
              onPageSizeChange={handlePageSize}
              onSortOrderChange={handleSortChange}
            />
            {metadata && (
              <PageComponent metadata={metadata} onChange={handlePageChange} />
            )}
          </div>
        </div>
      </div>
    </>
  );
};

export default MorePage;
