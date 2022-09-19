import {Button, Col, Form, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import {useState} from "react";
import Notification from "../components/Notification";

export default function DelDescButton(props) {
  let [open, setOpen] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let onSubmit = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Usuwanie sekcji opisu specjalizacji...")
    e.preventDefault();
    fetch("api/Spec/DeleteDesc?descId=" + props.desc, {
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
          setMessage("Usuwanie sekcji opisu powiodło się")
        } else {
          setMessage("Usuwanie sekcji opisu nie powiodło się")
        }
        props.load()
      })
  }

  return (
    <>
      <Button color="danger" onClick={toggle}>Usuń</Button>
      <Modal isOpen={open} toggle={toggle}>
        <Form onSubmit={onSubmit}>
          <ModalHeader toggle={toggle}>Sekcja opisu</ModalHeader>
          <ModalBody>
            Czy na pewno chcesz usunąć tą sekcję opisu?
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