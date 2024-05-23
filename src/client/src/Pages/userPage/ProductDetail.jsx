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
import { countAllComment, getProductDetail } from "../../Api/Controller";
import { useDispatch, useSelector } from "react-redux";
import toast, { Toaster } from "react-hot-toast";
import { addItem } from "../../Redux/Cart";
import CommentOverview from "../../Components/user/common/comment/CommentOverview";
import CommentBox from "../../Components/user/common/comment/CommentBox";
import CommentList from "../../Components/user/common/comment/CommentList";
import DOMPurify from "dompurify";

const ProductDetail = () => {
  const navigate = useNavigate();
  const [quantity, setQuantity] = useState(1);
  const [product, setProduct] = useState([]);
  const [category, setCategory] = useState({});
  const [branch, setBranch] = useState({});
  const [serie, setSerie] = useState({});
  const [reload, setReload] = useState(false);
  const [colorSelect, setColorSelect] = useState("");
  const [total, setTotal] = useState();
  const params = useParams();
  const { slug } = params;
  const dispatch = useDispatch();
  let user = useSelector((state) => state.auth.login.currentUser);

  useEffect(() => {
    document.title = "Trang chi tiết";
    setReload(false);
    getProductDetail(slug).then((data) => {
      if (data) {
        setProduct(data);
        setCategory(data.serie.category);
        setBranch(data.serie.branch);
        setSerie(data.serie);
      } else {
        setProduct([]);
      }
    });

    countAllComment(slug).then((data) => {
      if (data) {
        setTotal(data);
      } else setTotal();
    });
  }, [reload]);

  const handleBranchLink = (urlSlug) => {
    navigate(`/list/${category.urlSlug}/${urlSlug}`);
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
    setColorSelect("");
    navigate(`/detail/${newSlug}`);
    setReload(true);
  };

  const handleAddCart = () => {
    if (user === null) {
      toast.error("Vui lòng đăng nhập");
    } else {
      if (product.colors.length > 0 && colorSelect === "") {
        toast.error("Vui lòng chọn màu của sản phẩm");
      } else {
        if (product.amount === 0) {
          toast.error("Hiện tại sản phẩm đã hết hàng");
        } else {
          dispatch(
            addItem({
              id: product.id,
              productName: product.name,
              price:
                product.price === 0
                  ? product.orPrice * quantity
                  : product.price * quantity,
              realPrice: product.price === 0 ? product.orPrice : product.price,
              imageUrl: product.imageUrl,
              color: colorSelect,
              quantity: quantity,
            })
          );
          toast.success("Đã thêm sản phẩm vào giỏ hàng");
        }
      }
    }
  };

  const clickImage = (colorName) => {
    setColorSelect(colorName);
  };
  // const parts = window.location.pathname.split("/");

  return (
    <>
      <Toaster />
      <NavigationBar
        category={category.name}
        categorySlug={category.urlSlug}
        branch={branch.name}
        branchSlug={branch.urlSlug}
        serie={serie.name}
        serieSlug={serie.urlSlug}
        name={product.name}
      />

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
            {serie.rating ? (
              <StarRating
                rating={serie.rating}
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
                      select={colorSelect}
                      key={index}
                      onClick={() => clickImage(item.name)}
                    />
                  ))}
                </>
              ) : null}
            </div>
            <div className="product-information-item-box-price">
              {product.price === 0 ? (
                <div className="top-card-product-detail-item-price-original">
                  <p>{formatVND(product.orPrice)}</p>
                </div>
              ) : (
                <>
                  <div className="top-card-product-detail-item-price-current">
                    <p>{formatVND(product.price)}</p>
                  </div>
                  <div className="top-card-product-detail-item-price-original">
                    <s>{formatVND(product.orPrice)}</s>
                  </div>
                </>
              )}
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
              <p
                dangerouslySetInnerHTML={{
                  __html: DOMPurify.sanitize(product.shortDescription),
                }}
              ></p>
            </div>
            <div className="product-information-item-box-action">
              <div className="product-information-item-box-action-cart">
                <div className="product-information-item-box-action-cart-quantity">
                  <Quantity quantity={quantity} setQuantity={setQuantity} />
                </div>
                <p
                  className="product-information-item-box-action-cart-add"
                  onClick={handleAddCart}
                >
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
                <p
                  dangerouslySetInnerHTML={{
                    __html: DOMPurify.sanitize(serie.description),
                  }}
                ></p>
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
                <p
                  dangerouslySetInnerHTML={{
                    __html: DOMPurify.sanitize(product.specification),
                  }}
                ></p>
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
                <CommentOverview rating={serie.rating} total={total} />
                <CommentBox slug={slug} setReload={setReload} reload={reload} />
                <CommentList className="comment-list" reload={reload} />
              </TabPane>
            </Tabs>
          </div>
        </div>
        {/* <ShopPrivacy /> */}
        {/*
        <p>Phụ kiện</p>
        <p>Sản phẩm tương tự</p> */}
      </div>
    </>
  );
};

export default ProductDetail;
