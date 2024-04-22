import React from "react";
import NavigationBar from "../../Components/navigationBar/NavigationBar";
import ImageGallery from "../../Components/imageGallery/ImageGallery";
import StarRating from "./../../Components/starRating/StarRating";
import { formatVND } from "../../Common/function";
import ColorSquare from "./../../Components/colorSquare/ColorSquare";
import "../../styles/productDetail.scss";
import { useNavigate } from "react-router-dom";

const ProductDetail = () => {
  const navigate = useNavigate();

  const handleBranchLink = () => {
    navigate("/branch");
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
            <p className="product-information-item-box-category">Điện thoại</p>
            <h2>Samsung Galaxy Z Flip5 256GB</h2>
            <StarRating rating={5} />
            <div>Tag</div>
            <div>
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
              <p className="product-information-item-box-status-info">
                Còn hàng
              </p>
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
            <p>Thêm vào giỏ hàng</p>
          </div>
        </div>
        <p>Thông tin sản phẩm</p>
        <p>Phụ kiện</p>
        <p>Sản phẩm tương tự</p>
        <p>Mô tả chi tiết - Đặc điểm nổi bật</p>
        <p>Thông số kỹ thuật</p>
        <div>
          Đánh giá - Tổng đánh giá
          <div>
            <p>Ô bình luận kèm đánh giá</p>
            <p>Gửi</p>
            <p>Danh sách bình luận của khách hàng</p>
          </div>
        </div>
      </div>
    </>
  );
};

export default ProductDetail;
