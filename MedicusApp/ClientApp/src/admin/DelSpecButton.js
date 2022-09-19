import {Button, Col, Form, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import {useState} from "react";
import Notification from "../components/Notification";

export default function DelSpecButton(props) {
  let [open, setOpen] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let onSubmit = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Aktualizacja specjalizacji lekarza...")
    e.preventDefault();
    fetch("api/Doctor/DeleteSpec?doctorId=" + props.doc + "&specId=" + props.id, {
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
          setMessage("Aktualizacja powiodła się")
        } else {
          setMessage("Aktualizacja nie powiodła się")
        }
        props.load()
      })
  }

  return (
    <>
      <Modal isOpen={open} toggle={toggle} active={!loading}>
        <Form onSubmit={onSubmit}>
          <ModalHeader toggle={toggle}>Specjalizacja</ModalHeader>
          <ModalBody>
            Czy na pewno chcesz usunąć specjalizację: {props.name}
          </ModalBody>
          <ModalFooter>
            <Row>
              <Col>
                <Button color="primary" type="submit" active={!loading}>
                  Zatwierdź
                </Button>
              </Col>
              <Col>
                <Button color="secondary" onClick={toggle} active={!loading}>
                  Anuluj
                </Button>
              </Col>
            </Row>
          </ModalFooter>
        </Form>
      </Modal>
      <Notification loading={loading} success={success} message={message}/>
      <Button color="danger" onClick={toggle}>Usuń</Button>
    </>
  )
}