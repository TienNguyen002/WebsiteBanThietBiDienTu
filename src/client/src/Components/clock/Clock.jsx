import React, { useEffect, useState } from "react";

import "./clock.scss";

const Clock = () => {
  const [days, setDays] = useState();
  const [hours, setHours] = useState();
  const [minutes, setMinutes] = useState();
  const [seconds, setSeconds] = useState();

  let interval;

  const countDown = () => {
    const destination = new Date("Apr 23, 2024").getTime();

    interval = setInterval(() => {
      const now = new Date().getTime();
      const different = destination - now;
      const days = Math.floor(different / (1000 * 60 * 60 * 24));

      const hours = Math.floor(
        (different % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
      );

      const minutes = Math.floor((different % (1000 * 60 * 60)) / (1000 * 60));

      const seconds = Math.floor((different % (1000 * 60)) / 1000);

      if (destination < 0) clearInterval(interval.current);
      else {
        setDays(days);
        setHours(hours);
        setMinutes(minutes);
        setSeconds(seconds);
      }
    });
  };

  useEffect(() => {
    countDown();
  });

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
