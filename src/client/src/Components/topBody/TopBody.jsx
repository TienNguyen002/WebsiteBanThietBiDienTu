import React from "react";
import { ChevronRight, Smartphone } from "lucide-react";
import category from "../../Shared/data/category.json";
import banner from "../../Shared/data/banner.json";
import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay, Pagination } from "swiper/modules";
import "./topBody.scss";
import "swiper/css";
import "swiper/css/pagination";

const TopBody = () => {
  return (
    <>
      <div className="home-top-body">
        <div className="home-top-body-category">
          {category.result.map((item, index) => (
            <div key={index} className="home-top-body-category-item">
              <div home-top-body-category-item-detail>
                <Smartphone className="category-icon" />
                <span className="category-name">{item.name}</span>
              </div>
              <ChevronRight className="category-more" />
            </div>
          ))}
        </div>
        <Swiper
          loop={true}
          autoplay={{
            delay: 3000,
            disableOnInteraction: false,
            pauseOnMouseEnter: true,
          }}
          pagination={{
            dynamicBullets: true,
          }}
          modules={[Autoplay, Pagination]}
          className="mySwiper"
        >
          {banner.result.map((item, index) => (
            <SwiperSlide key={index}>
              <img src={item.image} alt={item.name}></img>
            </SwiperSlide>
          ))}
        </Swiper>
        <div className="more-img">Sample</div>
      </div>
    </>
  );
};

export default TopBody;
