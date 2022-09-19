import {
  Button,
  Col,
  Form,
  FormGroup,
  FormText,
  Input,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";
import {useState} from "react";
import Notification from "../components/Notification";

export default function AddDescButton(props) {
  let [open, setOpen] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let onSubmit = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Dodawanie nowej sekcji opisu...")
    e.preventDefault();

    let data = {};

    fetch("api/Spec/AddDesc?specId=" + props.id, {
      method: "PUT",
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
          setMessage("Sekcja opis został dodany")
        } else {
          setMessage("Nie udało się dodać nowej sekcji opisu")
        }
        props.load()
      })
  }

  return (
    <>
      <Button className="float-end" color="success" onClick={toggle} disabled={loading}>Dodaj</Button>
      <Modal isOpen={open} toggle={toggle}>
        <Form onSubmit={onSubmit}>
          <ModalHeader toggle={toggle}>Sekcja opisu</ModalHeader>
          <ModalBody>
            <Row>
              <Col>
                <FormGroup>
                  <Input
                    name="file"
                    type="file"
                    accept=".jpg,.jpeg,.png"
                  />
                  <FormText>
                    Wybierz zdjęcie dla sekcji opisu
                  </FormText>
                </FormGroup>
              </Col>
            </Row>
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