import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Table, Space, Button, Input, Radio, Modal } from "antd";
import CartProcessing from "../../Components/user/cart/CartProcessing";
import { formatVND } from "../../Common/function";
import {
  applyDiscount,
  removeItem,
  resetCart,
  updateQuantity,
} from "../../Redux/Cart";
import toast, { Toaster } from "react-hot-toast";
import "../../styles/homeLayout.scss";
import { Trash } from "lucide-react";
import { resetStep, setNextStep, setPrevStep } from "../../Redux/Step";
import CartOverview from "../../Components/user/cart/CartOverview";
import { useNavigate } from "react-router-dom";
import CartProduct from "../../Components/user/cart/CartProduct";
import {
  createOrder,
  getDiscountByCodeName,
  getUserById,
} from "../../Api/Controller";

const CartPage = () => {
  const initialState = {
    id: "",
    username: "",
    address: "",
    phone: "",
    paymentMethod: 0,
    discountId: 1,
  };
  let cart = useSelector((state) => state.cart);
  let step = useSelector((state) => state.step);
  let user = useSelector((state) => state.auth.login.currentUser);
  const [userInfo, setUserInfo] = useState(initialState);
  const [discount, setDiscount] = useState({
    name: "",
    percent: 1,
  });
  const [paymentMethod, setPaymentMethod] = useState(0);
  const [open, setOpen] = useState(false);
  const [status, setStatus] = useState("");
  const [apply, setApply] = useState(false);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if (user !== null) {
      getUserById(user.id).then((data) => {
        setUserInfo({
          id: user.id,
          username: user.username,
          address: data?.address,
          phone: data?.phoneNumber,
          paymentMethod: 0,
          discountId: 1,
        });
      });
    }
  }, []);

  const orderModel = {
    address: userInfo.address,
    phone: userInfo.phone,
    quantity: cart.totalAmount,
    totalPrice: cart.totalPrice,
    statusId: status,
    userId: user.id,
    paymentMethodId: userInfo.paymentMethod,
    discountId: userInfo.discountId,
    orderItems: cart.items.map((item) => ({
      productId: item.id,
      color: item.color,
      quantity: item.quantity,
      price: item.price,
    })),
  };

  const handleOrder = () => {
    createOrder(orderModel);
  };

  const removeProduct = (id, color) => {
    dispatch(removeItem({ id, color }));
    toast.success("Đã xóa sản phẩm");
  };

  const moveToNextStep = () => {
    dispatch(setNextStep());
  };

  const moveToPrevStep = () => {
    dispatch(setPrevStep());
  };

  const onPaymentChange = (e) => {
    setPaymentMethod(e.target.value);
    setStatus(e.target.value);
    setUserInfo({ ...userInfo, paymentMethod: e.target.value });
  };

  const handleShippingStep = () => {
    if (cart.items.length === 0) {
      toast.error("Bạn chưa có sản phẩm nào trong giỏ hàng!");
    } else {
      moveToNextStep();
    }
  };

  const handleUserInfo = () => {
    if (userInfo.address === null || userInfo.phone === null) {
      toast.error("Vui lòng điền đầy đủ thông tin!");
    }
    if (
      cart.items.length > 0 &&
      userInfo.address !== null &&
      userInfo.phone !== null
    ) {
      moveToNextStep();
      setApply(true);
    }
  };

  const handleApplyDiscount = () => {
    getDiscountByCodeName(discount.name).then((data) => {
      if (data) {
        setUserInfo({
          username: userInfo.username,
          address: userInfo.address,
          phone: userInfo.phone,
          paymentMethod: userInfo.paymentMethod,
          discountId: data.id,
        });
        setDiscount({ percent: data.discountPrice });
        dispatch(applyDiscount({ percent: data.discountPrice }));
        setApply(false);
        toast.success("Áp dụng mã thành công");
      } else {
        toast.error("Lỗi");
        // setUserInfo(initialState);
        setDiscount({ percent: 1 });
      }
    });
  };

  const handlePayment = () => {
    if (userInfo.paymentMethod === 0) {
      toast.error("Vui lòng chọn phương thức thanh toán!");
    }
    if (
      cart.items.length > 0 &&
      userInfo.address !== null &&
      userInfo.phone !== null &&
      userInfo.paymentMethod > 0
    ) {
      moveToNextStep();
      handleOrder();
      toast.success("Đặt hàng thành công");
    }
  };

  const handleFinal = () => {
    dispatch(resetCart());
    dispatch(resetStep());
    navigate("/");
  };

  const handleOk = () => {
    setOpen(true);
  };

  const handleCancel = () => {
    setOpen(false);
  };

  const columns = [
    {
      title: "Hình",
      dataIndex: "imageUrl",
      key: "imageUrl",
      render: (imageUrl) => (
        <img src={imageUrl} className="item-image" alt={imageUrl} />
      ),
      width: 100,
    },
    {
      title: "Sản phẩm",
      dataIndex: "productName",
      key: "productName",
      width: 500,
    },
    {
      title: "Số lượng đặt",
      dataIndex: "quantity",
      key: "quantity",
      width: 200,
      render: (quantity, record) => (
        <Space size="middle">
          <button
            disabled={quantity === 1}
            onClick={() =>
              dispatch(
                updateQuantity({ id: record.id, quantity: quantity - 1 })
              )
            }
          >
            -
          </button>
          <span>{quantity}</span>
          <button
            onClick={() =>
              dispatch(
                updateQuantity({ id: record.id, quantity: quantity + 1 })
              )
            }
          >
            +
          </button>
        </Space>
      ),
    },
    {
      title: "Màu sản phẩm",
      dataIndex: "color",
      key: "color",
      width: 200,
    },
    {
      title: "Tổng tiền",
      dataIndex: "price",
      key: "price",
      width: 200,
      render: (price) => <span>{formatVND(price)}</span>,
    },
    {
      title: "Xóa sản phẩm",
      key: "operation",
      fixed: "right",
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Trash
              onClick={() => removeProduct(record.id, record.color)}
              className="action-remove"
            />
          </div>
        </Space>
      ),
    },
  ];

  return (
    <>
      <Toaster />
      <div className="cart-page">
        <CartProcessing
          currentStep={step.currentStep}
          className="cart-page-processing"
        />
        {step.currentStep === 0 ? (
          <div>
            <h1 className="cart-page-title">Giỏ hàng của bạn</h1>
            <div className="cart-page-user">
              <div className="cart-page-user-detail">
                <Table
                  columns={columns}
                  dataSource={cart.items}
                  pagination={false}
                />
              </div>
              <div className="cart-page-user-overview">
                <CartOverview />
                <Button
                  color="primary"
                  className="cart-page-user-overview-button"
                  onClick={handleShippingStep}
                >
                  Xác nhận thông tin
                </Button>
              </div>
            </div>
          </div>
        ) : step.currentStep === 1 ? (
          <div className="cart-page-form">
            <div className="cart-page-form-input">
              <h1 className="cart-page-title">Điền thông tin nhận hàng</h1>
              <label className="cart-page-form-input-title">Họ và tên</label>
              <Input
                value={userInfo.username}
                placeholder={"Nhập họ và tên"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, username: e.target.value })
                }
              ></Input>
              <label className="cart-page-form-input-title">
                Địa chỉ nhận hàng
              </label>
              <Input
                value={userInfo.address}
                placeholder={"Nhập địa chỉ"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, address: e.target.value })
                }
              ></Input>
              <label className="cart-page-form-input-title">
                Số điện thoại
              </label>
              <Input
                value={userInfo.phone}
                placeholder={"Nhập số điện thoại"}
                onChange={(e) =>
                  setUserInfo({ ...userInfo, phone: e.target.value })
                }
              ></Input>
            </div>
            <div className="cart-page-user-overview">
              <CartOverview />
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={handleOk}
              >
                Xem giỏ hàng
              </Button>
              <Modal
                centered
                open={open}
                footer={null}
                onCancel={handleCancel}
                width={1000}
              >
                <CartProduct />
              </Modal>
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={moveToPrevStep}
              >
                Quay lại bước trước
              </Button>
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={handleUserInfo}
              >
                Tiến hành thanh toán
              </Button>
            </div>
          </div>
        ) : step.currentStep === 2 ? (
          <div className="cart-page-form">
            <div className="cart-page-form-input">
              <h1 className="cart-page-title">Thông tin nhận hàng của bạn</h1>
              <label className="cart-page-form-input-title">Họ và tên</label>
              <Input
                disabled
                value={userInfo.username}
                placeholder={"Nhập họ và tên"}
              ></Input>
              <label className="cart-page-form-input-title">
                Địa chỉ nhận hàng
              </label>
              <Input
                disabled
                value={userInfo.address}
                placeholder={"Nhập địa chỉ"}
              ></Input>
              <label className="cart-page-form-input-title">
                Số điện thoại
              </label>
              <Input
                disabled
                value={userInfo.phone}
                placeholder={"Nhập số điện thoại"}
              ></Input>
              <div className="cart-page-select">
                <div className="cart-page-select-payment">
                  <h3 className="cart-page-title">
                    Lựa chọn phương thức thanh toán
                  </h3>
                  <Radio.Group onChange={onPaymentChange} value={paymentMethod}>
                    <Radio value="1">QR Pay</Radio>
                    <Radio value="2">Thanh toán trực tiếp</Radio>
                  </Radio.Group>
                </div>
                <div className="cart-page-select-discount">
                  <h3 className="cart-page-title">Mã giảm giá</h3>
                  <Input
                    placeholder={"Nhập mã giảm giá"}
                    onChange={(e) =>
                      setDiscount({ ...discount, name: e.target.value })
                    }
                  ></Input>
                  {apply ? (
                    <Button onClick={handleApplyDiscount}>Áp dụng</Button>
                  ) : (
                    <Button disabled onClick={handleApplyDiscount}>
                      Áp dụng
                    </Button>
                  )}
                </div>
              </div>
            </div>
            <div className="cart-page-user-overview">
              <CartOverview />
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={handleOk}
              >
                Xem giỏ hàng
              </Button>
              <Modal
                centered
                open={open}
                footer={null}
                onCancel={handleCancel}
                width={1000}
              >
                <CartProduct />
              </Modal>
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={moveToPrevStep}
              >
                Quay lại bước trước
              </Button>
              <Button
                color="primary"
                className="cart-page-user-overview-button"
                onClick={handlePayment}
              >
                Tiến hành thanh toán
              </Button>
            </div>
          </div>
        ) : (
          <div className="cart-page-final">
            <img
              src="https://i.ebayimg.com/images/g/Z1oAAOSwhWdj57Zp/s-l1200.jpg"
              alt="No Access"
              className="common-page-image"
            />
            <Button
              color="primary"
              className="cart-page-user-overview-button"
              onClick={handleFinal}
            >
              Xác nhận
            </Button>
          </div>
        )}
      </div>
    </>
  );
};

export default CartPage;
