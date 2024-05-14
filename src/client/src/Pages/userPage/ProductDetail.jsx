import React, { useEffect, useState } from "react";
import NavigationBar from "../../Components/user/common/NavigationBar";
import ImageGallery from "../../Components/user/product/imageGallery/ImageGallery";
import StarRating from "./../../Components/user/product/starRating/StarRating";
import { formatVND } from "../../Common/function";
import ColorSquare from "./../../Components/user/common/ColorSquare";
import { useNavigate, useParams } from "react-router-dom";
import ProductTag from "../../Components/user/product/productTag/ProductTag";
import { ShoppingCart, Heart } from "lucide-react";
import { Tabs } from "antd";
import TabPane from "antd/es/tabs/TabPane";
import "../../styles/productDetail.scss";
import Quantity from "../../Components/user/common/Quantity";
import { getProductDetail } from "../../Api/Controller";
import Loading from "./../../Components/shared/Loading";

const ProductDetail = () => {
  const navigate = useNavigate();
  const [quantity, setQuantity] = useState(1);
  const [product, setProduct] = useState([]);
  const [category, setCategory] = useState({});
  const [branch, setBranch] = useState({});
  const [serie, setSerie] = useState({});
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  const params = useParams();
  const { slug } = params;

  useEffect(() => {
    getProductDetail(slug).then((data) => {
      if (data) {
        setProduct(data);
        setCategory(data.serie.category);
        setBranch(data.serie.branch);
        setSerie(data.serie);
      } else {
        setProduct([]);
      }
      setIsVisibleLoading(false);
    });
  }, []);

  const handleBranchLink = (urlSlug) => {
    navigate(`/${category.urlSlug}/${urlSlug}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleCategoryLink = (urlSlug) => {
    navigate(`/${urlSlug}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleTagClick = (newSlug) => {
    navigate(`/detail/${newSlug}`);
    window.location.reload();
  };

  const clickImage = () => {
    console.log("hello");
  };
  // const parts = window.location.pathname.split("/");
  return (
    <>
      <NavigationBar
        category={category.name}
        categorySlug={category.urlSlug}
        branch={branch.name}
        branchSlug={branch.urlSlug}
        serie={serie.name}
        serieSlug={serie.urlSlug}
        name={product.name}
      />
      {isVisibleLoading ? (
        <>
          <Loading />
        </>
      ) : (
        <div className="product-information">
          <div className="product-information-item">
            {serie.images && serie.images.length > 0 ? (
              <ImageGallery images={serie.images} />
            ) : (
              <img
                src={product.imageUrl}
                alt={product.name}
                className="product-information-item-image"
              />
            )}
            <div className="product-information-item-box">
              <p
                className="product-information-item-box-category"
                onClick={() => handleCategoryLink(category.urlSlug)}
              >
                {category.name}
              </p>
              <h2 className="product-information-item-box-name">
                {product.name}
              </h2>
              {product.rating ? (
                <StarRating
                  rating={product.rating}
                  className="product-information-item-box-rating"
                />
              ) : null}
              <div className="product-information-item-box-tag">
                <ProductTag
                  products={serie.products}
                  tag={product.shortName}
                  onClick={handleTagClick}
                />
              </div>
              <div className="product-information-item-box-color">
                {product.colors ? (
                  <>
                    {product.colors.map((item, index) => (
                      <ColorSquare
                        color={item.name}
                        key={index}
                        onClick={clickImage}
                      />
                    ))}
                  </>
                ) : null}
              </div>
              <div className="product-information-item-box-price">
                <div className="product-information-item-box-price-discount">
                  <p>{formatVND(product.price)}</p>
                </div>
                <div className="product-information-item-box-price-current">
                  <s>{formatVND(product.orPrice)}</s>
                </div>
              </div>
              <div className="product-information-item-box-status">
                <p className="product-information-item-box-status-title">
                  Tình trạng:
                </p>
                {product.amount > 0 ? (
                  <p className="product-information-item-box-status-available">
                    Còn hàng
                  </p>
                ) : (
                  <p className="product-information-item-box-status-out">
                    Hết hàng
                  </p>
                )}
              </div>
              <div className="product-information-item-box-branch">
                <p className="product-information-item-box-branch-title">
                  Thương hiệu:
                </p>
                <img
                  src={branch.imageUrl}
                  alt={branch.name}
                  className="product-information-item-box-branch-logo"
                  onClick={() => handleBranchLink(branch.urlSlug)}
                />
              </div>
              <div className="product-information-item-box-special">
                <p className="product-information-item-box-special-title">
                  Đặc điểm nổi bật
                </p>
                {product.shortDescription}
              </div>
              <div className="product-information-item-box-action">
                <div className="product-information-item-box-action-cart">
                  <div className="product-information-item-box-action-cart-quantity">
                    <Quantity quantity={quantity} setQuantity={setQuantity} />
                  </div>
                  <p className="product-information-item-box-action-cart-add">
                    Thêm vào giỏ hàng <ShoppingCart />
                  </p>
                </div>
                <div className="product-information-item-box-action-heart">
                  <Heart />
                </div>
              </div>
            </div>
          </div>
          <div className="product-infomation-body">
            <div className="product-information-body-tab">
              <Tabs defaultActiveKey="1" centered>
                <TabPane
                  tab={
                    <span className="product-information-body-tab-title">
                      Mô tả sản phẩm
                    </span>
                  }
                  key="1"
                  className="product-information-body-tab-content product-information-body-tab-content-desc"
                >
                  {serie.description}
                </TabPane>
                <TabPane
                  tab={
                    <span className="product-information-body-tab-title">
                      Thông số kỹ thuật
                    </span>
                  }
                  key="2"
                  className="product-information-body-tab-content product-information-body-tab-content-speci"
                >
                  {product.specification}
                </TabPane>
                <TabPane
                  tab={
                    <span className="product-information-body-tab-title">
                      Bình luận
                    </span>
                  }
                  key="3"
                  className="product-information-body-tab-content product-information-body-tab-content-comment"
                >
                  Bình luận
                </TabPane>
              </Tabs>
            </div>
          </div>
          {/* <ShopPrivacy /> */}
          {/*
        <p>Phụ kiện</p>
        <p>Sản phẩm tương tự</p> */}
        </div>
      )}
    </>
  );
};

export default ProductDetail;
