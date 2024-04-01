import "./header.scss";

const Header = () => {
  return (
    <>
      <div className="header-top">
        <div className="swiper wrapper">
          This is one to swipe and have banner
        </div>
      </div>
      <div className="header">
        <div className="header-logo">
          {/* <img src="https://www.titancorpvn.com/assets/images/logo-white.png" alt="" /> */}
          <span>Hello</span>
        </div>
        <div className="category">
          <i class="fa-solid fa-book"></i>
          <span> Danh mục</span>
        </div>
        <div className="searching">
          <i className="icon-search" class="fa-solid fa-magnifying-glass"></i>
          <input className="input-search" type="text" />
        </div>
        <div className="header-end">
          <i class="fa-solid fa-cart-shopping"></i>
          <i class="fa-solid fa-user"></i>
        </div>
      </div>
    </>
  );
};

export default Header;
