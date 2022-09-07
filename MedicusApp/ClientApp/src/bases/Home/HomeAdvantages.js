import {Col, Container, Row} from "reactstrap";

import './HomeAdvantages.css';

export default function HomeAdvantages() {
  return (
    <Container fluid>
      <Row className="main p-0 mt-4">
        <Col className="advantages left text-center">
          <span className="h1 very-center">Co nas wyróżnia?</span>
        </Col>
        <Col className="advantages text-center">
          <Row className="advantages">
            <Col className="advantages right hover">
              <img src="icons/outpatient.svg" alt="doctor" className="icon" />
              <div className="h6 p-1">Wysokiej klasy specjaliści</div>
            </Col>
            <Col className="advantages right hover">
              <img src="icons/heart.svg" alt="cardiology" className="icon" />
              <div className="h6 p-1">Nowoczesny sprzęt do ultrasonografii i echokardiografii</div>
            </Col>
          </Row>
          <Row className="advantages">
            <Col className="advantages right hover">
              <img src="icons/calm.svg" alt="comfort" className="icon" />
              <div className="h6 p-1">Wysoka jakość obsługi</div>
            </Col>
            <Col className="advantages right hover">
              <img src="icons/rural_post_alt.svg" alt="comfort" className="icon" />
              <div className="h6 p-1">Komfortowe nowe wnętrza</div>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  )
}