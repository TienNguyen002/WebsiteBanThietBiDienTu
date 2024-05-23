import React, { useState } from "react";
import "../../styles/homePage.scss";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Thumbs, Autoplay } from "swiper/modules";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/thumbs";
import "swiper/css/autoplay";

const ImageGallery = ({ images }) => {
  const [imgThumbs, setImgThumbs] = useState(null);

  return (
    <>
      <div className="image-gallery">
        <Swiper
          loop={true}
          autoplay={{
            delay: 3000,
            disableOnInteraction: false,
            pauseOnMouseEnter: true,
          }}
          zoom={true}
          spaceBetween={10}
          navigation={true}
          modules={[Navigation, Thumbs, Autoplay]}
          grabCursor={true}
          thumbs={{
            swiper: imgThumbs && !imgThumbs.destroyed ? imgThumbs : null,
          }}
          className="image-gallery-current"
        >
          {images
            ? images.map((item, index) => (
                <SwiperSlide key={index}>
                  <img src={item.imageUrl} alt={item.id} />
                </SwiperSlide>
              ))
            : null}
          {/* <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-z-lip5_3_.png"
              alt="1"
            />
          </SwiperSlide>
          <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_256gb_-_9.png"
              alt="1"
            />
          </SwiperSlide>
          <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_6_1__1.png"
              alt="1"
            />
          </SwiperSlide>
          <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_2_1.png"
              alt="1"
            />
          </SwiperSlide>
          <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_4_1.png"
              alt="1"
            />
          </SwiperSlide>
          <SwiperSlide>
            <img
              src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_3_1.png"
              alt="1"
            />
          </SwiperSlide> */}
        </Swiper>
        <Swiper
          onSwiper={setImgThumbs}
          loop={true}
          spaceBetween={10}
          slidesPerView={4}
          modules={[Navigation, Thumbs]}
          className="image-gallery-thumbs"
        >
          {images
            ? images.map((item, index) => (
                <SwiperSlide key={index}>
                  <div className="image-gallery-thumbs-wrapper">
                    <img src={item.imageUrl} alt={item.id} />
                  </div>
                </SwiperSlide>
              ))
            : null}
          {/* <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-z-lip5_3_.png"
                alt="1"
              />
            </div>
          </SwiperSlide>
          <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_256gb_-_9.png"
                alt="1"
              />
            </div>
          </SwiperSlide>
          <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_6_1__1.png"
                alt="1"
              />
            </div>
          </SwiperSlide>
          <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_2_1.png"
                alt="1"
              />
            </div>
          </SwiperSlide>
          <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_4_1.png"
                alt="1"
              />
            </div>
          </SwiperSlide>
          <SwiperSlide>
            <div className="image-gallery-thumbs-wrapper">
              <img
                src="https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/g/a/galaxy_z_flip5_-_3_1.png"
                alt="1"
              />
            </div>
          </SwiperSlide> */}
        </Swiper>
      </div>
    </>
  );
};

export default ImageGallery;
