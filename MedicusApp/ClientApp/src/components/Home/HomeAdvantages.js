import {Container} from "reactstrap";

import './HomeAdvantages.css';
import {isMobile} from "react-device-detect";

export default function HomeAdvantages() {
  return (
    <Container className="p-0" fluid>
      <div className={"advantages-container " + (isMobile ? "advantages-rows" : "advantages-cols")}>
        <div className="text-center overflow-hidden advantages-image-container">
          <span className="h1 very-center">Co nas wyróżnia?</span>
          <img src="images/used/advantages.jpg" alt="main-2" className="advantages-image" />
        </div>
        <div className="text-center title">
          <div className="advantages">
            <div className="advantage-hover">
              <a href="docs" className="advantage">
                <div className="advantage">
                  <div className="advantage-cell">
                    <i className="heart icon advantage" />
                    <div className="h4 p-1">Wysokiej klasy specjaliści</div>
                  </div>
                </div>
              </a>
            </div>
            <div className="advantage-hover">
              <a href="about" className="advantage">
                <div className="advantage">
                  <div className="advantage-cell">
                    <i className="ventilator icon advantage" />
                    <div className="h4 p-1">Nowoczesny sprzęt do ultrasonografii i echokardiografii</div>
                  </div>
                </div>
              </a>
            </div>
            <div className="advantage-hover">
              <a href="contact" className="advantage">
                <div className="advantage">
                  <div className="advantage-cell">
                    <i className="wheelchair icon advantage" />
                    <div className="h4 p-1">Łatwy dostęp</div>
                  </div>
                </div>
              </a>
            </div>
            <div className="advantage-hover">
              <a href="contact" className="advantage">
                <div className="advantage">
                  <div className="advantage-cell">
                    <i className="city icon advantage" />
                    <div className="h4 p-1">Komfortowe nowe wnętrza w idealnej lokalizacji</div>
                  </div>
                </div>
              </a>
            </div>
          </div>
        </div>
      </div>
    </Container>
  )
}