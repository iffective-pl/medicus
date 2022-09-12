import SideContact from "../components/SideContact";
import {Button, Col, Form, FormGroup, Input, Label, Row} from "reactstrap";
import GoogleMaps from "../components/GoogleMaps";

export default function Contact() {
  return (
    <>
      <SideContact title="Kontakt">
        <Form>
          <Row>
            <Col>
              <FormGroup>
                <Label for="firstName">
                  Imię
                </Label>
                <Input
                  bsSize="lg"
                  id="firstName"
                  name="firstName"
                  placeholder="Imię"
                />
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="lastName">
                  Nazwisko
                </Label>
                <Input
                  bsSize="lg"
                  id="lastName"
                  name="lastName"
                  placeholder="Nazwisko"
                />
              </FormGroup>
            </Col>
          </Row>
          <Row>
            <Col>
              <FormGroup>
                <Label for="phoneNumber">
                  Numer telefonu
                </Label>
                <Input
                  bsSize="lg"
                  id="phoneNumber"
                  name="phoneNumber"
                  placeholder="Numer telefonu"
                  type="text"
                />
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="email">
                  Email
                </Label>
                <Input
                  bsSize="lg"
                  id="email"
                  name="email"
                  placeholder="Email"
                  type="email"
                />
              </FormGroup>
            </Col>
          </Row>
          <Row>
            <Col>
              <FormGroup>
                <Label for="message">
                  Wiadomość
                </Label>
                <Input
                  bsSize="lg"
                  id="message"
                  name="message"
                  placeholder="Wiadomość"
                  type="textarea"
                />
              </FormGroup>
            </Col>
          </Row>
          <Row>
            <Col>
              <div>
                <Button color="info" size="lg" className="float-end">
                  Wyślij
                </Button>
              </div>
            </Col>
          </Row>
        </Form>
      </SideContact>
      <GoogleMaps/>
    </>
  )
}