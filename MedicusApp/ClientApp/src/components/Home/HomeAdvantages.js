import {Col, Container, Row} from "reactstrap";

import './HomeAdvantages.css';

export default function HomeAdvantages() {
  return (
    <Container fluid>
      <Row className="main p-0">
        <Col className="advantages left text-center overflow-hidden">
          <img src="images/used/advantages.jpg" alt="main-2" className="main" />
          <span className="h1 very-center">Co nas wyróżnia?</span>
        </Col>
        <Col className="advantages text-center title">
          <Row className="advantages">
            <Col className="advantages right hover fit">
              <a href="docs" className="advantages">
                <div>
                  <div className="heart icon" />
                  <div className="h5 p-1">Wysokiej klasy specjaliści</div>
                </div>
              </a>
            </Col>
            <Col className="advantages right hover fit">
              <a href="about" className="advantages">
                <div>
                  <div className="ventilator icon" />
                  <div className="h5 p-1">Nowoczesny sprzęt do ultrasonografii i echokardiografii</div>
                </div>
              </a>
            </Col>
          </Row>
          <Row className="advantages">
            <Col className="advantages right hover fit">
              <a href="contact" className="advantages">
                <div>
                  <div className="wheelchair icon" />
                  <div className="h5 p-1">Łatwy dostęp</div>
                </div>
              </a>
            </Col>
            <Col className="advantages right hover fit">
              <a href="contact" className="advantages">
                <div>
                  <div className="city icon" />
                  <div className="h5 p-1">Komfortowe nowe wnętrza w idealnej lokalizacji</div>
                </div>
              </a>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  )
}