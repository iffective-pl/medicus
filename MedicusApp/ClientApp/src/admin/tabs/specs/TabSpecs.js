import {
  Button,
  Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader,
  Row,
  TabPane, UncontrolledAccordion
} from "reactstrap";
import {useEffect, useState} from "react";
import TabSpec from "./TabSpec";
import Notification from "../../../components/Notification";

import list from '../../../data/icons.json';

export default function TabSpecs(props) {
  let [specs, setSpecs] = useState([]);
  let [icon, setIcon] = useState("")
  let [color, setColor] = useState("");

  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let load = () => {
    setSpecs([]);
    fetch("api/Spec/GetSpecIds", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setSpecs(j))
  }

  useEffect(() => load(), [props.keycloak.token])

  let onSubmit = (e) => {
    setOpen(false);
    setLoading(true)
    setMessage("Tworzenie nowej specjalizacji...")
    e.preventDefault();

    let data = {
      name: e.target.name.value,
      style: {
        className: e.target.className.value,
        color: e.target.color.value
      }
    }

    fetch("api/Spec/AddSpec", {
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
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nowa specjalizacja została stworzona")
        } else {
          setMessage("Nie udało się stworzyć nowej specjalizacji")
        }
        load()
      })
  }

  return (
    <TabPane tabId={props.index.toString()} className="pt-3 pb-3">
      <Row className="mb-3">
        <Col>
          <Button className="float-end" color="success" onClick={toggle}>Dodaj specjalizację</Button>
          <Modal isOpen={open} toggle={toggle} size="xl">
            <ModalHeader toggle={toggle}>Specjalizacja</ModalHeader>
            <Form onSubmit={onSubmit}>
              <ModalBody>
                <Row>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="name"
                        name="name"
                        type="text"
                      />
                      <Label for="name">
                        Nazwa specjalizacji
                      </Label>
                    </FormGroup>
                  </Col>
                </Row>
                <Row>
                  <Col xs="5">
                    <FormGroup floating>
                      <Input
                        id="className"
                        name="className"
                        type="select"
                        defaultValue={icon}
                        onChange={(e) => setIcon(e.target.value)}
                      >
                        <option></option>
                        {list.map((item, key) => (
                          <option value={item} key={key}>
                            {item}
                          </option>
                        ))}
                      </Input>
                      <Label for="className">
                        Wybierz obrazek specjalizacji
                      </Label>
                    </FormGroup>
                  </Col>
                  <Col xs="1">
                    <i className={icon ? "icon " + icon : ""} style={{"background-color": color}}/>
                  </Col>
                  <Col>
                    <FormGroup floating>
                      <Input
                        id="color"
                        name="color"
                        type="color"
                        value={color}
                        onChange={(e) => setColor(e.target.value)}
                      />
                      <Label for="color">
                        Kolor obrazka
                      </Label>
                    </FormGroup>
                  </Col>
                </Row>
              </ModalBody>
              <ModalFooter>
                <Row>
                  <Col>
                    <Button color="primary" disabled={loading} type="submit">
                      Zatwierdź
                    </Button>
                  </Col>
                  <Col>
                    <Button color="secondary" onClick={toggle} disabled={loading}>
                      Anuluj
                    </Button>
                  </Col>
                </Row>
              </ModalFooter>
            </Form>
          </Modal>
          <Notification loading={loading} success={success} message={message}/>
        </Col>
      </Row>
      <Row>
        <Col>
          <UncontrolledAccordion className="mb-3" open="0" openDefault="0">
            {specs.map((item, key) => <TabSpec id={item} token={props.keycloak.token} index={key} key={key} load={load}/>)}
          </UncontrolledAccordion>
        </Col>
      </Row>
    </TabPane>
  )
}