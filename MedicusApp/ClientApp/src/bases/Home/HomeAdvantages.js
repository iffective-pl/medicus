import {Col, Container, Row} from "reactstrap";

import './HomeAdvantages.css';

export default function HomeAdvantages() {
  return (
    <Container fluid>
      <Row>
        <Col className="advantages left text-center">
          <div className="square">
            <span className="h1 very-center">Co nas wyróżnia?</span>
          </div>
        </Col>
        <Col className="advantages right text-center">
          <div className="square">
            <Row>
              <Col className="square-small p-3">
                <img src="icons/outpatient.svg" alt="doctor" className="icon mt-5" />
                <div className="h3 p-3">Wysokiej klasy specjaliści</div>
              </Col>
              <Col className="square-small p-3 align-middle">
                <img src="icons/heart.svg" alt="cardiology" className="icon mt-5" />
                <div className="h3 p-2">Nowoczesny sprzęt do ultrasonografii i echokardiografii</div>
              </Col>
            </Row>
            <Row>
              <Col className="square-small p-3">
                <img src="icons/calm.svg" alt="comfort" className="icon" />
                <div className="h3 p-2">Komfortowe wnętrzna i wysoka jakość obsługi</div>
              </Col>
            </Row>
          </div>
        </Col>
      </Row>
    </Container>
  )
}