import React, { useEffect, useState } from "react";
import Category from "../../Components/user/common/category/Category";
// import Branch from "../../Components/branch/Branch";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/listPage.scss";
import NavigationBar from "../../Components/user/common/navigationBar/NavigationBar";
import { getProductFilter, getPagedProduct } from "../../Api/Controller";
import PageComponent from "../../Components/user/common/pagination/PageComponent";
import { useSelector } from "react-redux";

const ListPage = () => {
  const [branches, setBranches] = useState();
  const [categories, setCategories] = useState();
  const [colors, setColors] = useState();
  const [products, setProducts] = useState([]);
  const [metadata, setMetadata] = useState();
  const payloadFilter = useSelector((state) => state.payloadFilter);

  const filterPayload = {
    isSale: true,
  };

  const [payload, setPayload] = useState({
    isSale: true,
    sortOrder: payloadFilter.sortOrder,
    category: payloadFilter.category,
    branch: payloadFilter.branch,
    minPrice: payloadFilter.minPrice,
    maxPrice: payloadFilter.maxPrice,
    rating: payloadFilter.rating,
    color: payloadFilter.color,
    pageSize: 16,
    pageNumber: 1,
  });

  useEffect(() => {
    getProductFilter(filterPayload).then((data) => {
      if (data) {
        setBranches(data.branches);
        setCategories(data.categories);
        setColors(data.colors);
      } else {
        setBranches();
        setCategories();
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
  }, [payload, payloadFilter]);

  const handlePageChange = (pageNumber) => {
    setPayload((prevPayload) => ({ ...prevPayload, pageNumber }));
  };

  const handlePageSize = (pageSize) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      pageSize,
      pageNumber: 1,
    }));
  };

  return (
    <>
      <NavigationBar sale="Sale" />
      <div className="list-page">
        <div className="list-page-category">
          <Category title={false} sale={true} category={categories} />
          {/* <Branch /> */}
        </div>
        <div className="list-page-product">
          <div className="list-page-product-filter">
            <ProductFilter
              hasBranch={true}
              branches={branches}
              colors={colors}
            />
          </div>
          <div className="list-page-product-list">
            <ProductColumn
              products={products}
              onPageSizeChange={handlePageSize}
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

export default ListPage;
