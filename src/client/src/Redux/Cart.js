import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  items: [],
  totalAmount: 0,
  totalPrice: 0,
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    addItem: (state, action) => {
      const existingItem = state.items.find(
        (item) =>
          item.id === action.payload.id && item.color === action.payload.color
      );

      if (existingItem) {
        existingItem.quantity += action.payload.quantity;
      } else {
        state.items.push(action.payload);
        state.totalAmount++;
      }
      state.totalPrice = state.items.reduce((acc, item) => acc + item.price, 0);
    },
    removeItem: (state, action) => {
      const { id, color } = action.payload;
      state.items = state.items.filter(
        (item) => item.id !== id || item.color !== color
      );
      state.totalAmount--;
      state.totalPrice = state.items.reduce((acc, item) => acc + item.price, 0);
    },
    updateQuantity: (state, action) => {
      const item = state.items.find((item) => item.id === action.payload.id);
      if (item) {
        item.quantity = action.payload.quantity;
        item.price = item.realPrice * item.quantity;
      }
      state.totalPrice = state.items.reduce((acc, item) => acc + item.price, 0);
    },
    applyDiscount: (state, action) => {
      const discountPercentage = 1 - action.payload.percent;
      state.totalPrice *= discountPercentage;
    },
    resetCart: (state) => {
      return initialState;
    },
  },
});

export const { addItem, removeItem, updateQuantity, applyDiscount, resetCart } =
  cartSlice.actions;

export const cartReducer = cartSlice.reducer;
