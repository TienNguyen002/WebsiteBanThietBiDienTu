//Import Component Library
import React, { useState, useEffect } from "react";
import { useNavigate, Link } from "react-router-dom";
import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay, Pagination } from "swiper/modules";
import { ChevronRight } from "lucide-react";
//Import API
import { getAllCategory } from "../../../../Api/Controller";
//Import Component
import CategoryIcon from "../../common/categoryIcon/CategoryIcon";
//Import data
import banner from "../../../../Shared/data/banner.json";
import ad1 from "../../../../Shared/images/ad-1.png";
import ad2 from "../../../../Shared/images/ad-2.png";
import ad3 from "../../../../Shared/images/ad-3.png";
//CSS
import "./topHome.scss";
import "swiper/css";
import "swiper/css/pagination";

const TopHome = () => {
  const navigate = useNavigate();
  const [categories, setCategories] = useState([]);

  const handleLink = () => {
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  useEffect(() => {
    getAllCategory().then((data) => {
      if (data) {
        setCategories(data);
      } else setCategories([]);
    });
  }, []);

  return (
    <>
      <div className="home-top-body">
        <div className="home-top-body-category">
          {categories.map((item, index) => (
            <Link
              to={item.urlSlug}
              key={index}
              className="home-top-body-category-item"
              onClick={handleLink}
            >
              <div className="home-top-body-category-item-detail">
                <CategoryIcon item={item} />
                <span className="category-name">{item.name}</span>
              </div>
              <ChevronRight className="category-more" />
            </Link>
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
        <div className="home-top-body-more">
          <img src={ad1} alt="ad1" className="home-top-body-more-ad" />
          <img src={ad2} alt="ad1" className="home-top-body-more-ad" />
          <img src={ad3} alt="ad1" className="home-top-body-more-ad" />
        </div>
      </div>
    </>
  );
};

export default TopHome;
