import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  currentStep: 0,
  cartItems: [],
};

export const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    setCurrentStep: (state, action) => {
      state.currentStep = action.payload;
    },
    addToCart: (state, action) => {
      state.cartItems.push(action.payload);
    },
    removeFromCart: (state, action) => {
      state.cartItems = state.cartItems.filter(
        (item) => item.id !== action.payload
      );
    },
  },
});

export const { setCurrentStep, addToCart, removeFromCart } = cartSlice.actions;

export default cartSlice.reducer;
