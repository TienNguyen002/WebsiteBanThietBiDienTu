import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { getPagedProduct, searchProduct } from "../../Api/Controller";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import PageComponent from "../../Components/user/common/PageComponent";

const SearchPage = () => {
  const initialState = {
    keyword: "",
    sortOrder: "",
    pageSize: 16,
    pageNumber: 1,
  };
  const location = useLocation();
  const query = location.state?.query;
  const [products, setProducts] = useState([]);
  const [metadata, setMetadata] = useState();
  const [queryChanged, setQueryChanged] = useState(false);
  const [payload, setPayload] = useState(initialState);

  useEffect(() => {
    document.title = "Tìm kiếm sản phẩm ...";
    if (query) {
      setPayload((prevPayload) => ({
        ...prevPayload,
        keyword: query,
        pageNumber: 1,
      }));
      setQueryChanged(true);
    }
  }, [query]);

  useEffect(() => {
    if (queryChanged || payload.pageNumber || payload.sortOrder) {
      getPagedProduct(payload).then((data) => {
        if (data) {
          setProducts(data.items);
          setMetadata(data.metadata);
        } else {
          setProducts([]);
          setMetadata(null);
        }
      });
    }
    setQueryChanged(false);
  }, [payload]);

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

  const handleSortChange = (sortOrder) => {
    setPayload((prevPayload) => ({
      ...prevPayload,
      sortOrder,
    }));
  };

  return (
    <>
      <div className="search-page">
        <h1>
          Kết quả của tìm kiếm của <span>"{query}"</span>
        </h1>
        {products && products.length > 0 ? (
          <div>
            <ProductColumn
              products={products}
              onPageSizeChange={handlePageSize}
              onSortOrderChange={handleSortChange}
            />
            {metadata && (
              <PageComponent metadata={metadata} onChange={handlePageChange} />
            )}
          </div>
        ) : (
          <p>Không có sản phẩm nào có {query}</p>
        )}
      </div>
    </>
  );
};

export default SearchPage;
