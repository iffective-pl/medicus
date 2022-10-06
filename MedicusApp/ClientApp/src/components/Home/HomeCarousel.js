import {useState} from "react";
import {Button, Carousel, CarouselControl, CarouselIndicators, CarouselItem} from "reactstrap";

import './HomeCarousel.css';
import Config from '../../config/Config';

export default function HomeCarousel(props) {
  let [activeIndex, setActiveIndex] = useState(0);
  let [animating, setAnimating] = useState(false);

  const next = () => {
    if (animating) return;
    const nextIndex = activeIndex === props.carousels.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(nextIndex);
  };

  const previous = () => {
    if (animating) return;
    const nextIndex = activeIndex === 0 ? props.carousels.length - 1 : activeIndex - 1;
    setActiveIndex(nextIndex);
  };

  const goToIndex = (newIndex) => {
    if (animating) return;
    setActiveIndex(newIndex);
  };

  return (
    <Carousel
      interval={10000}
      next={next}
      previous={previous}
      activeIndex={activeIndex}
      className="description-img"
    >
      <CarouselIndicators
        items={props.carousels}
        activeIndex={activeIndex}
        onClickHandler={goToIndex}
      />
      {props.carousels.map((item, key) => (
        <CarouselItem
          onExiting={() => setAnimating(true)}
          onExited={() => setAnimating(false)}
          key={key}
          className="description-back"
        >
          <img src={Config.minio + item.source} alt={key} className="description-img" />
          <span className="description">
            <span className="description-text">
              <h1 className="title">{item.mainTitle}</h1>
              <h1 className="title">{item.subTitle}</h1>
              <h3 className="sub-title fw-bold">{item.text}</h3>
              <Button
                tag="a" size="lg"
                className="title-button mt-2"
                hidden={!item.buttonHref} href={item.buttonHref}
              >{item.buttonText}</Button>
            </span>
          </span>
        </CarouselItem>
      ))}
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