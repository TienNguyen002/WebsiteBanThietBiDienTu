import React from "react";
import { Zap, ChevronRight } from "lucide-react";
import ProductCard from "../productCard/ProductCard";
import Clock from "../clock/Clock";
import { Swiper, SwiperSlide } from "swiper/react";
import { EffectCoverflow, Autoplay, Navigation } from "swiper/modules";
import product from "../../Shared/data/product.json";
import { Link } from "react-router-dom";
import "./flashSale.scss";
import "swiper/css";
import "swiper/css/effect-coverflow";
import "swiper/css/navigation";
import "swiper/css/autoplay";
import "swiper/css/pagination";

const FlashSale = () => {
  const handleLink = () => {
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="home-flash-sale">
        <div className="home-flash-sale-top">
          <div className="home-flash-sale-top-title">
            <h1 className="home-flash-sale-title">Flash Sale</h1>
            <Zap className="home-flash-sale-icon" />
          </div>
          <div className="home-flash-sale-top-clock">
            <Clock />
          </div>
          <Link
            to={"/sale"}
            onClick={handleLink}
            className="home-flash-sale-top-more"
          >
            Xem tất cả <ChevronRight />
          </Link>
        </div>
        <Swiper
          loop={true}
          loopFillGroupWithBlank={true}
          autoplay={{
            delay: 3000,
            disableOnInteraction: false,
            pauseOnMouseEnter: true,
          }}
          navigation={true}
          modules={[EffectCoverflow, Autoplay, Navigation]}
          className="home-flash-sale-swiper"
          effect={"coverflow"}
          coverflowEffect={{
            rotate: 10,
            stretch: 50,
            depth: 200,
            modifier: 1,
            slideShadows: true,
          }}
          breakpoints={{
            640: {
              slidesPerView: 1,
              spaceBetween: 20,
            },
            768: {
              slidesPerView: 2,
              spaceBetween: 30,
            },
            1024: {
              slidesPerView: 3,
              spaceBetween: 150,
            },
          }}
        >
          {product.result.map((item, index) => (
            <SwiperSlide className="home-flash-sale-swiper-slide" key={index}>
              <div
                className="home-flash-sale-swiper-slide-container"
                key={index}
              >
                <ProductCard
                  name={item.name}
                  image={item.image}
                  current={item.current}
                  discount={item.discount}
                  star={item.star}
                  color={item.colors}
                />
              </div>
            </SwiperSlide>
          ))}
        </Swiper>
      </div>
    </>
  );
};

export default FlashSale;
