import {useState} from "react";
import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import Notification from "../components/Notification";

export default function AddHeaderButton(props) {
  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let onSubmit = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Tworzenia nagłówka...")
    e.preventDefault()

    let data = {
      name: e.target.name.value,
      isDropdown: e.target.dropdown.checked,
      isHidden: e.target.hidden.checked
    }

    fetch("api/UI/AddHeader", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nagłówek został utworzony")
        } else {
          setMessage("Nie udało się utworzyć nagłówka")
        }
        props.load()
      })
  }

  return (
    <>
      <Button className="float-end me-3" color="success" onClick={toggle} disabled={loading}>Dodaj nagłówek</Button>
      <Modal isOpen={open} toggle={toggle}>
        <ModalHeader toggle={toggle}>Nagłówek</ModalHeader>
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
                    Nazwa nagłówka
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="href"
                    name="href"
                    type="text"
                  />
                  <Label for="href">
                    Przekierowanie
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup check>
                  <Input
                    className="me-2"
                    name="dropdown"
                    type="checkbox"
                  />
                  <Label check>
                    Czy może mieć opcje?
                  </Label>
                </FormGroup>
              </Col>
              <Col>
                <FormGroup check>
                  <Input
                    className="me-2"
                    name="hidden"
                    type="checkbox"
                  />
                  <Label check>
                    Czy jest ukryty na górze?
                  </Label>
                </FormGroup>
              </Col>
            </Row>
          </ModalBody>
          <ModalFooter>
            <Row>
              <Col>
                <Button color="primary" type="submit" disabled={loading}>
                  Stwórz
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
    </>
  )
}