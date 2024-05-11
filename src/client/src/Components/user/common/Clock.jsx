//Import Component Library
import React from "react";
//CSS
import "../styles/homePage.scss";

const Clock = ({ days, hours, minutes, seconds }) => {
  return (
    <div className="home-clock">
      <div className="home-clock-data">
        <div className="home-clock-data-detail">
          <h1 className="home-clock-data-detail-number">{days}</h1>
          <h3 className="home-clock-data-detail-name">Ngày</h3>
        </div>
        <span className="home-clock-data-dot">:</span>
      </div>

      <div className="home-clock-data">
        <div className="home-clock-data-detail">
          <h1 className="home-clock-data-detail-number">{hours}</h1>
          <h3 className="home-clock-data-detail-name">Tiếng</h3>
        </div>
        <span className="home-clock-data-dot">:</span>
      </div>

      <div className="home-clock-data">
        <div className="home-clock-data-detail">
          <h1 className="home-clock-data-detail-number">{minutes}</h1>
          <h3 className="home-clock-data-detail-name">Phút</h3>
        </div>
        <span className="home-clock-data-dot">:</span>
      </div>

      <div className="home-clock-data">
        <div className="home-clock-data-detail">
          <h1 className="home-clock-data-detail-number">{seconds}</h1>
          <h3 className="home-clock-data-detail-name">Giây</h3>
        </div>
      </div>
    </div>
  );
};

export default Clock;
