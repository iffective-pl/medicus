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
          <div className="square pt-5">
            <div className="square-small mr-1">
                <img src="icons/outpatient.svg" alt="doctor" className="icon" />
                <div className="h5 p-1">Wysokiej klasy specjaliści</div>
            </div>
            <div className="square-small mr-1">
              <img src="icons/heart.svg" alt="cardiology" className="icon" />
              <div className="h5 p-1">Nowoczesny sprzęt do ultrasonografii i echokardiografii</div>
            </div>
            <div className="square-small mr-1">
              <img src="icons/calm.svg" alt="comfort" className="icon" />
              <div className="h5 p-1">Wysoka jakość obsługi</div>
            </div>
            <div className="square-small mr-1">
              <img src="icons/rural_post_alt.svg" alt="comfort" className="icon" />
              <div className="h5 p-1">Komfortowe nowe wnętrza</div>
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  )
}