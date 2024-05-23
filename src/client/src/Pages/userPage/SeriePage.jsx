import React, { useEffect, useState } from "react";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/homeLayout.scss";
import { useParams } from "react-router-dom";
import { getProductFilter, getPagedProduct } from "../../Api/Controller";
import NavigationBar from "../../Components/user/common/NavigationBar";
import PageComponent from "../../Components/user/common/PageComponent";

const SeriePage = ({ isSale, isHighRating, isNew, isTop }) => {
  const param = useParams();
  let { category, branch, serie } = param;
  const [colors, setColors] = useState();
  const [products, setProducts] = useState([]);
  const [metadata, setMetadata] = useState();
  const [naviBar, setNaviBar] = useState("");

  const categoryName = products[0]?.category.name;
  const categorySlug = products[0]?.category.urlSlug;
  const branchName = products[0]?.branch.name;
  const branchSlug = products[0]?.branch.urlSlug;
  const serieName = products[0]?.serie.name;
  const serieSlug = products[0]?.serie.urlSlug;

  const filterPayload = {
    isSale: isSale,
    isHighRating: isHighRating,
    isNew: isNew,
    isTop: isTop,
    category: category,
    branch: branch,
  };

  const [payload, setPayload] = useState({
    isSale: isSale,
    isHighRating: isHighRating,
    isNew: isNew,
    isTop: isTop,
    sortOrder: "",
    category: category,
    branch: branch,
    serie: serie,
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
      document.title = "Trang ưu đãi";
    }
    if (isHighRating) {
      setNaviBar("Sản phẩm đánh giá cao");
      document.title = "Trang sản phẩm đánh giá cao";
    }
    if (isNew) {
      setNaviBar("Sản phẩm mới");
      document.title = "Trang sản phẩm mới";
    }
    if (isTop) {
      setNaviBar("Sản phẩm bán chạy");
      document.title = "Trang sản phẩm bán chạy";
    }
    if (
      isSale === false &&
      isHighRating === false &&
      isNew === false &&
      isTop === false
    ) {
      document.title = "Danh sách sản phẩm";
    }
    getProductFilter(filterPayload).then((data) => {
      if (data) {
        setColors(data.colors);
      } else {
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
      <NavigationBar
        title={naviBar}
        category={categoryName}
        categorySlug={categorySlug}
        branch={branchName}
        branchSlug={branchSlug}
        serie={serieName}
        serieSlug={serieSlug}
      />
      <div className="list-page">
        <div className="list-page-product">
          <div className="list-page-product-filter">
            <ProductFilter
              hasBranch={false}
              colors={colors}
              onMinMaxFilterChange={handleMinMaxChange}
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

export default SeriePage;
