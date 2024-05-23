import React from "react";
import { Steps } from "antd";

const CartProcessing = ({ currentStep }) => {
  //   const { currentStep } = useSelector((state) => state.cart);
  //   const handleCheckout = () => {
  //     dispatch(setCurrentStep(1));
  //   };
  return (
    <div>
      <Steps current={currentStep}>
        <Steps.Step title="Giỏ hàng" description="Xem giỏ hàng của bạn" />
        <Steps.Step
          title="Shipping"
          description="Điền thông tin vận chuyển của bạn"
        />
        <Steps.Step
          title="Thanh toán"
          description="Chọn phương thức thanh toán"
        />
        <Steps.Step
          title="Xác nhận"
          description="Xác nhận lại thông tin của bạn"
        />
      </Steps>
    </div>
  );
};

export default CartProcessing;
