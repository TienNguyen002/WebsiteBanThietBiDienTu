import React, { useEffect, useState } from "react";
import NavigationBar from "../../Components/user/common/navigationBar/NavigationBar";
import ImageGallery from "../../Components/user/product/imageGallery/ImageGallery";
import StarRating from "./../../Components/user/product/starRating/StarRating";
import { formatVND } from "../../Common/function";
import ColorSquare from "./../../Components/user/product/colorSquare/ColorSquare";
import { useNavigate, useParams } from "react-router-dom";
import ProductTag from "../../Components/user/product/productTag/ProductTag";
import { ShoppingCart, Heart } from "lucide-react";
import { Tabs } from "antd";
import TabPane from "antd/es/tabs/TabPane";
import "../../styles/productDetail.scss";
import Quantity from "../../Components/user/common/quantity/Quantity";
import { getProductDetail } from "../../Api/Controller";

const ProductDetail = () => {
  const navigate = useNavigate();
  const [quantity, setQuantity] = useState(1);
  const [available, setAvailable] = useState(true);
  const [product, setProduct] = useState({});
  const params = useParams();
  const { slug } = params;

  useEffect(() => {
    getProductDetail(slug).then((data) => {
      if (data) {
        setProduct(data);
        console.log(data);
      } else setProduct([]);
    });
  }, []);

  const handleBranchLink = () => {
    navigate("/branch");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleCategoryLink = () => {
    navigate("/more");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  // const parts = window.location.pathname.split("/");
  return (
    <>
      <NavigationBar />
      <div className="product-information">
        <div className="product-information-item">
          <ImageGallery />
          <div className="product-information-item-box">
            <p
              className="product-information-item-box-category"
              onClick={handleCategoryLink}
            >
              Điện thoại
            </p>
            <h2 className="product-information-item-box-name">
              {product.name}
            </h2>
            <StarRating
              rating={5}
              className="product-information-item-box-rating"
            />
            <div className="product-information-item-box-tag">
              <ProductTag />
            </div>
            <div className="product-information-item-box-color">
              <ColorSquare />
            </div>
            <div className="product-information-item-box-price">
              <div className="product-information-item-box-price-discount">
                <p>{formatVND(16990000)}</p>
              </div>
              <div className="product-information-item-box-price-current">
                <s>{formatVND(25990000)}</s>
              </div>
            </div>
            <div className="product-information-item-box-status">
              <p className="product-information-item-box-status-title">
                Tình trạng:
              </p>
              {available ? (
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
                src="https://w7.pngwing.com/pngs/176/171/png-transparent-samsung-galaxy-gurugram-faridabad-logo-samsung-blue-text-logo.png"
                alt="Samsung"
                className="product-information-item-box-branch-logo"
                onClick={handleBranchLink}
              />
            </div>
            <div className="product-information-item-box-special">
              <p className="product-information-item-box-special-title">
                Đặc điểm nổi bật
              </p>
              <li>
                Galaxy AI tiện ích - Khoanh vùng search đa năng, là trợ lý chỉnh
                ảnh, trợ lý chat thông minh, phiên dịch trực tiếp
              </li>
              <li>
                Thần thái nổi bật, cân mọi phong cách- Lấy cảm hứng từ thiên
                nhiên với màu sắc thời thượng, xu hướng
              </li>
              <li>
                Thiết kế thu hút ánh nhìn - Gập không kẽ hỡ, dẫn đầu công nghệ
                bản lề Flex
              </li>
              <li>
                Tuyệt tác selfie thoả sức sáng tạo - Camera sau hỗ trợ AI xử lí
                cực sắc nét ngay cả trên màn hình ngoài
              </li>
              <li>
                Bền bỉ bất chấp mọi tình huống - Đạt chuẩn kháng bụi và nước
                IPX8 cùng chất liệu nhôm Armor Aluminum giúp hạn chế cong và
                xước
              </li>
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
                Mô tả sản phẩm
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
                Thông số kỹ thuật
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

        {/*
        <p>Phụ kiện</p>
        <p>Sản phẩm tương tự</p> */}
      </div>
    </>
  );
};

export default ProductDetail;
