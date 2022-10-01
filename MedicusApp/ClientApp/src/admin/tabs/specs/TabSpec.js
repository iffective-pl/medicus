import {useEffect, useState} from "react";
import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button,
  Col,
  Form,
  FormGroup,
  Input,
  Label, Modal, ModalBody, ModalFooter, ModalHeader,
  Row
} from "reactstrap";
import Notification from "../../../components/Notification";
import TabSpecPrices from "./TabSpecPrices";
import TabSpecDescs from "./TabSpecDescs";

let sp = {
  id: undefined,
  name: "",
  descriptions: []
}

export default function TabSpec(props) {
  let [spec, setSpec] = useState(sp)
  let [open, setOpen] = useState(false);

  let toggle = () => setOpen(!open)

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    fetch("api/Spec/GetSpec?specId=" + props.id, {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setSpec(j))
  }

  useEffect(() => load(), [props.token])

  let onChange = (e) => {
    const s = spec;
    s[e.target.name] = e.target.value;
    setSpec(s);
  }

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Aktualizacja nazwy specjalizacji...")
    e.preventDefault()

    fetch("api/Spec/UpdateSpec", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        id: spec.id,
        name: spec.name
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nazwa specjalizacji zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować nazwy specjalizacji")
        }
        load()
      })
  }

  let onDelete = (e) => {
    setLoading(true)
    setMessage("Usuwanie specjalizacji...")
    e.preventDefault()

    fetch("api/Spec/DeleteSpec?specId=" + spec.id, {
      method: "DELETE",
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Specjalizacja została usunięta")
        } else {
          setMessage("Nie udało się usunąć specjalizacji")
        }
        props.load()
      })
  }

  return (
    <AccordionItem>
      <AccordionHeader targetId={props.index.toString()}>
        {spec.name}
      </AccordionHeader>
      <AccordionBody accordionId={props.index.toString()}>
        <Form onSubmit={onSubmit}>
          <Row>
            <Col>
              <FormGroup floating>
                <Input
                  bsSize="lg"
                  id="name"
                  name="name"
                  type="text"
                  defaultValue={spec.name}
                  onChange={onChange}
                />
                <Label for="name">
                  Nazwa specjalizacji
                </Label>
              </FormGroup>
            </Col>
          </Row>
          <Row>
            <Col>
              <Button className="float-end" color="info" type="submit" disabled={loading}>Zapisz</Button>
            </Col>
          </Row>
        </Form>
        <Notification loading={loading} success={success} message={message}/>
        <TabSpecDescs token={props.token} spec={spec} load={load}/>
        <TabSpecPrices token={props.token} id={spec.id}/>
        <Row className="mt-3">
          <Col>
            <Button color="danger" onClick={toggle}>Usuń specjalizację</Button>
            <Modal isOpen={open} toggle={toggle}>
              <Form onSubmit={onDelete}>
                <ModalHeader toggle={toggle}>Specjalizacja</ModalHeader>
                <ModalBody>
                  Czy na pewno chcesz usunąć specjalizację: {spec.name}?
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
          </Col>
        </Row>
      </AccordionBody>
    </AccordionItem>
  )
}