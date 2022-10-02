import {Button, Col, Container, Form, FormGroup, Input, Label, NavLink, Row} from "reactstrap";
import GoogleMaps from "../components/GoogleMaps";
import Line from "../components/Line";
import {isMobile} from "react-device-detect";

import './Contact.css';
import {useEffect, useState} from "react";
import Notification from "../components/Notification";

let company = {
  emails: [],
  allPhones: []
}

export default function Contact() {
  let [comp, setComp] = useState(company);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  useEffect(() => {
    fetch("api/Company/GetFullCompany")
      .then(r => r.json())
      .then(j => setComp(j))
  }, [])

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Wysyłanie wiadomości...")
    e.preventDefault();
    let data = {
      firstName: e.target.firstName.value,
      lastName: e.target.lastName.value,
      email: e.target.email.value,
      number: e.target.number.value,
      message: e.target.message.value
    }

    fetch("api/Email/Send", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Wiadomość została wysłana")
        } else {
          setMessage("Wiadomość nie została wysłana")
        }
      })
  }

  return (
    <>
      <Container className="title mb-5">
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
                  {comp.allPhones.map((item, index) => <div key={index}><NavLink href={"tel:" + item.number}>{item.number}</NavLink></div>)}
                </div>
              </div>
              <div className="pb-4">
                <div>
                  <i className="message icon"/>
                </div>
                <div>
                  {comp.emails.map((item, index) => <div key={index}><NavLink href={"mailto:" + item.address}>{item.address}</NavLink></div>)}
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
            <Form onSubmit={onSubmit}>
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
                      id="number"
                      name="number"
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
                  <FormGroup check>
                    <Input type="checkbox" />
                    <Label check>
                      Zgadzam się na na przetwarzanie moich danych osobowych przez Trimedic w celu prowadzenia marketingu bezpośredniego za pośrednictwem poczty elektronicznej zgodnie z ustawą z dnia 18 lipca 2002 r. o świadczeniu usług drogą elektroniczną (t.j. Dz.U. z 2017 r. poz. 1219). Dane osobowe przekazuję dobrowolnie i oświadczam, że są zgodne z prawdą. Zapoznałem(-am) się z treścią klauzuli informacyjnej, w tym z informacją o celu i sposobach przetwarzania danych osobowych oraz prawie dostępu do treści swoich danych i prawie ich poprawiania.
                    </Label>
                  </FormGroup>
                </Col>
              </Row>
              <Row>
                <Col>
                  <FormGroup check>
                    <Input type="checkbox" />
                    <Label check>
                      Zgadzam się na na przetwarzanie moich danych osobowych przez Trimedic w celu prowadzenia marketingu bezpośredniego za pośrednictwem połączeń telefonicznych zgodnie z ustawą z dnia 16 lipca 2004 r. – Prawo telekomunikacyjne (t.j. Dz.U. z 2017 r. poz. 1907 ze zm.). Dane osobowe przekazuję dobrowolnie i oświadczam, że są zgodne z prawdą. Zapoznałem(-am) się z treścią klauzuli informacyjnej, w tym z informacją o celu i sposobach przetwarzania danych osobowych oraz prawie dostępu do treści swoich danych i prawie ich poprawiania.
                    </Label>
                  </FormGroup>
                </Col>
              </Row>
              <Row className="mt-3">
                <Col>
                  <div>
                    <Button color="info" size="lg" className="float-end" type="submit" disabled={loading}>
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
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}