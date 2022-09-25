import {useEffect, useState} from "react";
import TabDoctor from "./TabDoctor";
import {
  Button,
  Col, Form,
  FormGroup, Input, Label,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row,
  TabPane,
  UncontrolledAccordion
} from "reactstrap";
import Notification from "../../components/Notification";

export default function TabDoctors(props) {
  let [doctors, setDoctors] = useState([]);
  let [open, setOpen] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let load = () => {
    setDoctors([]);
    fetch("api/Doctor/GetDoctors", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setDoctors(j))
  }

  useEffect(() => {
    load()
  }, [props.keycloak.token])

  let create = (e) => {
    setOpen(false);
    setLoading(true);
    setMessage("Tworzenie nowego profilu lekarza...");
    e.preventDefault();

    let data = {};
    Object.entries(e.target).filter(q => q.nodeName !== "BUTTON").forEach(([key, value]) => {
      data[value.name] = value.value;
    });

    fetch("api/Doctor/AddDoctor", {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Aktualizacja powiodła się")
        } else {
          setMessage("Aktualizacja nie powiodła się")
        }
        load()
      })
  }

  return (
    <TabPane tabId="3" className="pt-3 pb-3">
      <Row className="mb-3">
        <Col>
          <Button className="float-end" color="success" onClick={toggle}>Dodaj lekarza</Button>
          <Modal isOpen={open} toggle={toggle} size="xl">
            <Form onSubmit={create}>
              <ModalHeader toggle={toggle}>Nowy profil lekarza</ModalHeader>
              <ModalBody>
                <Row>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="title"
                        name="title"
                        type="text"
                      />
                      <Label for="title">
                        Tytuł
                      </Label>
                    </FormGroup>
                  </Col>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="firstName"
                        name="firstName"
                        type="text"
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
                        type="text"
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
                        id="specTitle"
                        name="specTitle"
                        type="text"
                      />
                      <Label for="specTitle">
                        Tytuł specjalistyczny
                      </Label>
                    </FormGroup>
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="description"
                        name="description"
                        type="textarea"
                        className="text-area-size"
                      />
                      <Label for="description">
                        Opis
                      </Label>
                    </FormGroup>
                  </Col>
                </Row>
              </ModalBody>
              <ModalFooter>
                <Row>
                  <Col>
                    <Button color="primary" type="submit" disabled={loading}>Stwórz</Button>
                  </Col>
                  <Col>
                    <Button color="secondary" onClick={toggle} disabled={loading}>Anuluj</Button>
                  </Col>
                </Row>
              </ModalFooter>
            </Form>
          </Modal>
        </Col>
      </Row>
      <Notification loading={loading} success={success} message={message}/>
      <UncontrolledAccordion className="mb-3">
        {doctors.map((item, key) => <TabDoctor id={item} token={props.keycloak.token} index={key} key={key} update={load}/>)}
      </UncontrolledAccordion>
    </TabPane>
  )
}