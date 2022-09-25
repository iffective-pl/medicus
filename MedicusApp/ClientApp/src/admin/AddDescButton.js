import {
  Button,
  Col,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";
import {useState} from "react";
import Notification from "../components/Notification";
import ImageSelector from "./ImageSelector";

export default function AddDescButton(props) {

  let [image, setImage] = useState("");

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
    fetch("api/Spec/AddDesc", {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        image: image,
        specId: props.id
      })
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
        <ModalHeader toggle={toggle}>Sekcja opisu</ModalHeader>
        <ModalBody>
          <ImageSelector token={props.token} image={image} setImage={setImage}/>
        </ModalBody>
        <ModalFooter>
          <Row>
            <Col>
              <Button color="primary" onClick={onSubmit} disabled={loading}>
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
      </Modal>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}