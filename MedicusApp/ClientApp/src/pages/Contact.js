import {Button, Col, Container, Form, FormGroup, Input, Label, NavLink, Row} from "reactstrap";
import GoogleMaps from "../components/GoogleMaps";
import Line from "../components/Line";
import {isMobile} from "react-device-detect";

import './Contact.css';
import {useEffect, useState} from "react";

let company = {
  emails: [],
  allPhones: []
}

export default function Contact() {
  let [comp, setComp] = useState(company);

  useEffect(() => {
    fetch("api/Company")
      .then(r => r.json())
      .then(j => setComp(j))
  }, [])

  return (
    <>
      <Container className="title">
        <h2 className="text-center">Kontakt</h2>
        <Line center />
        <div className={"main-container " + (isMobile ? "small" : "normal")}>
          <div>
            <div className={"text-center side-container " + (isMobile ? "small" : "normal")}>
              <div className="pb-4">
                <div>
                  <i className="phone icon"/>
                </div>
                <div>
                  {comp.allPhones.map((item, index) => <div key={index}><NavLink href={"tel:" + item}>{item}</NavLink></div>)}
                </div>
              </div>
              <div className="pb-4">
                <div>
                  <i className="message icon"/>
                </div>
                <div>
                  {comp.emails.map((item, index) => <div key={index}><NavLink href={"mailto:" + item}>{item}</NavLink></div>)}
                </div>
              </div>
              <div className="pb-4">
                <div>
                  <i className="location icon"/>
                </div>
                <div>
                  <div>{comp.address}</div>
                  <div>{comp.code} {comp.city}</div>
                </div>
              </div>
            </div>
          </div>
          <div>
            <Form>
              <Row>
                <Col>
                  <FormGroup floating>
                    <Input
                      bsSize="lg"
                      id="firstName"
                      name="firstName"
                      placeholder="Imię"
                    />
                    <Label for="firstName">
                      Imię
                    </Label>
                  </FormGroup>
                </Col>
                <Col>
                  <FormGroup floating>
                    <Input
                      bsSize="lg"
                      id="lastName"
                      name="lastName"
                      placeholder="Nazwisko"
                    />
                    <Label for="lastName">
                      Nazwisko
                    </Label>
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col>
                  <FormGroup floating>
                    <Input
                      bsSize="lg"
                      id="phoneNumber"
                      name="phoneNumber"
                      placeholder="Numer telefonu"
                      type="text"
                    />
                    <Label for="phoneNumber">
                      Numer telefonu
                    </Label>
                  </FormGroup>
                </Col>
                <Col>
                  <FormGroup floating>
                    <Input
                      bsSize="lg"
                      id="email"
                      name="email"
                      placeholder="Email"
                      type="email"
                    />
                    <Label for="email">
                      Email
                    </Label>
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col>
                  <FormGroup floating>
                    <Input
                      bsSize="lg"
                      id="message"
                      name="message"
                      placeholder="Wiadomość"
                      type="textarea"
                      className="text-area-size"
                    />
                    <Label for="message">
                      Wiadomość
                    </Label>
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
          </div>
        </div>
      </Container>
      <GoogleMaps/>
    </>
  )
}