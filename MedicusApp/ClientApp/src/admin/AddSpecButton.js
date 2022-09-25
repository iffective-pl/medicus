import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import {useEffect, useState} from "react";
import Notification from "../components/Notification";

export default function AddSpecButton(props) {
  let [open, setOpen] = useState(false);
  let [specs, setSpecs] = useState([]);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  useEffect(() => {
    if(props.doc) {
      fetch("api/Doctor/GetAvailableSpecs?doctorId=" + props.doc, {
        headers: {
          "Authorization": "Bearer " + props.token
        }
      })
        .then(r => r.json())
        .then(j => setSpecs(j))
    }
  }, [props.doc, props.specs])

  let onSubmit = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Aktualizacja specjalizacji lekarza...")
    e.preventDefault();
    fetch("api/Doctor/AddSpec?doctorId=" + props.doc + "&specId=" + parseInt(e.target.specSelect.value), {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Aktualizacja powiodła się")
        } else {
          setMessage("Aktualizacja nie powiodła się")
        }
        props.load()
      })
  }

  return (
    <>
      <Button className="float-end" color="success" onClick={toggle} disabled={loading}>Dodaj</Button>
      <Modal isOpen={open} toggle={toggle}>
        <Form onSubmit={onSubmit}>
          <ModalHeader toggle={toggle}>Specjalizacja</ModalHeader>
          <ModalBody>
            <FormGroup>
              <Label for="specSelect">
                Wybierz specjalizację, która ma zostać dodana lekarzowi
              </Label>
              <Input
                id="specSelect"
                name="specSelect"
                type="select"
              >
                {specs.map((item, key) => (
                  <option value={item.id} key={key}>
                    {item.name}
                  </option>
                ))}
              </Input>
            </FormGroup>
          </ModalBody>
          <ModalFooter>
            <Row>
              <Col>
                <Button color="primary" type="submit" disabled={loading}>
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
    </>
  )
}