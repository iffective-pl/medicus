import {Button, Col, Container, Row} from "reactstrap";

export default function Reminder() {
  return (
    <Container fluid className="reminder">
      <Row className="p-5 text-center">
        <Col>
          <span className="h3 text-white">Zarejestruj się na wizytę już teraz!</span>
        </Col>
        <Col>
          <Button size="lg" color="info" tag="a" href="register">Skontaktuj się z nami</Button>
        </Col>
      </Row>
    </Container>
  )
}