import React, { useEffect, useState } from "react";
import TopCard from "./topCard/TopCard";
import "./topSuggest.scss";
import { getTop, getNew, getSold } from "../../../../Api/Controller";

const TopSuggest = () => {
  const [top, setTop] = useState();
  const [news, setNew] = useState();
  const [sold, setSold] = useState();

  useEffect(() => {
    getTop(4).then((data) => {
      if (data) {
        setTop(data);
      } else setTop([]);
    });

    getNew(4).then((data) => {
      if (data) {
        setNew(data);
      } else setNew([]);
    });

    getSold(4).then((data) => {
      if (data) {
        setSold(data);
      } else setSold([]);
    });
  }, []);

  return (
    <>
      <div className="top-suggest">
        <TopCard title={"Sản phẩm được đánh giá cao"} products={top} />
        <TopCard title={"Sản phẩm mới"} isNew={true} products={news} />
        <TopCard title={"Sản phẩm bán chạy"} products={sold} />
      </div>
    </>
  );
};

export default TopSuggest;
