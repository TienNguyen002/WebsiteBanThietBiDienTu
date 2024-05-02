import React, { useEffect, useState } from "react";
import Category from "../../Components/user/common/category/Category";
// import Branch from "../../Components/branch/Branch";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/salePage.scss";
import NavigationBar from "../../Components/user/common/navigationBar/NavigationBar";
import { getProductFilter, getPagedProduct } from "../../Api/Controller";
import PageComponent from "../../Components/user/common/pagination/PageComponent";

const SalePage = () => {
  const [branches, setBranches] = useState();
  const [categories, setCategories] = useState();
  const [colors, setColors] = useState();
  const [products, setProducts] = useState([]);
  const [metadata, setMetadata] = useState();

  const filterPayload = {
    isSale: true,
  };

  const [payload, setPayload] = useState({
    isSale: true,
    pageSize: 20,
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
  }, [payload]);

  const handlePageChange = (pageNumber) => {
    setPayload((prevPayload) => ({ ...prevPayload, pageNumber }));
  };

  return (
    <>
      <NavigationBar sale="Sale" />
      <div className="sale-page">
        <div className="sale-page-category">
          <Category title={false} sale={true} category={categories} />
          {/* <Branch /> */}
        </div>
        <div className="sale-page-product">
          <div className="sale-page-product-filter">
            <ProductFilter
              hasBranch={true}
              branches={branches}
              colors={colors}
            />
          </div>
          <div className="sale-page-product-list">
            <ProductColumn products={products} metadata={metadata} />
            {metadata && (
              <PageComponent metadata={metadata} onChange={handlePageChange} />
            )}
          </div>
        </div>
      </div>
    </>
  );
};

export default SalePage;
