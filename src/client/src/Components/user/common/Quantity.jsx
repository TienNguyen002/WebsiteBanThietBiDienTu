import React from "react";
import "../styles/homePage.scss";

const Quantity = ({ quantity, setQuantity }) => {
  const increaseQuantity = () => {
    setQuantity(quantity + 1);
  };

  const decreaseQuantity = () => {
    setQuantity(quantity - 1);
  };

  return (
    <>
      <div className="quantity">
        <button
          className="quantity-decrement"
          onClick={decreaseQuantity}
          disabled={quantity === 0}
        >
          -
        </button>
        <input
          type="number"
          min={0}
          max={10}
          step={1}
          className="quantity-input"
          readOnly
          value={quantity}
        />
        <button
          className="quantity-increase"
          onClick={increaseQuantity}
          disabled={quantity === 100}
        >
          +
        </button>
      </div>
    </>
  );
};

export default Quantity;
