import {useState} from "react";
import {Button, Carousel, CarouselControl, CarouselIndicators, CarouselItem} from "reactstrap";

import './HomeCarousel.css';
import Config from '../../config/Config';
import Items from '../../data/carousel.json';

export default function HomeCarousel() {
  let [activeIndex, setActiveIndex] = useState(0);
  let [animating, setAnimating] = useState(false);
  let items = Items.items;

  const next = () => {
    if (animating) return;
    const nextIndex = activeIndex === items.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(nextIndex);
  };

  const previous = () => {
    if (animating) return;
    const nextIndex = activeIndex === 0 ? items.length - 1 : activeIndex - 1;
    setActiveIndex(nextIndex);
  };

  const goToIndex = (newIndex) => {
    if (animating) return;
    setActiveIndex(newIndex);
  };

  const slides = items.map((item, index) => {
    if(item.brand) {
      return (
        <CarouselItem
          onExiting={() => setAnimating(true)}
          onExited={() => setAnimating(false)}
          key={index}
          className="description-back"
        >
          <img src={Config.minio + item.src} alt={item.altText} className="description-img" />
          <span className="description">
            <span className="description-text">
              <h1 className="title">{item.captionHeader}</h1>
              <h1 className="title">{item.brand}</h1>
              <h3 className="sub-title fw-bold">{item.captionText}</h3>
              <Button
                size="lg"
                className="title-button mt-2"
                tag="a" href="docs"
              >Nasi specjaliści</Button>
            </span>
          </span>
        </CarouselItem>
      );
    } else {
      return (
        <CarouselItem
          onExiting={() => setAnimating(true)}
          onExited={() => setAnimating(false)}
          key={index}
          className="description-back"
        >
          <img src={Config.minio + item.src} alt={item.altText} className="description-img" />
          <span className="description">
            <span className="description-text">
              <p className="fs-1 mb-2 title">Tytuł główny</p>
              <p className="fs-3 fw-bold mb-2 sub-title">Tytuł podrzędny</p>
            </span>
          </span>
        </CarouselItem>
      );
    }

  });

  return (
    <Carousel
      interval={10000}
      next={next}
      previous={previous}
      activeIndex={activeIndex}
    >
      <CarouselIndicators
        items={items}
        activeIndex={activeIndex}
        onClickHandler={goToIndex}
      />
      {slides}
      <CarouselControl
        direction="prev"
        directionText="Previous"
        onClickHandler={previous}
      />
      <CarouselControl
        direction="next"
        directionText="Next"
        onClickHandler={next}
      />
    </Carousel>
  );
}