import {
  Button,
  Col,
  Form,
  FormGroup,
  FormText,
  Input, Label,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";
import {useEffect, useState} from "react";
import Notification from "../components/Notification";
import Config from "./config/Config";

export default function AddDescButton(props) {
  let [images, setImages] = useState([]);
  let [image, setImage] = useState("");

  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let loadImages = (token) => {
    fetch("api/Minio", {
      headers: {
        "Authorization": "Bearer " + token
      }
    })
      .then(r => r.json())
      .then(j => setImages(j))
  }

  useEffect(() => {
    loadImages(props.token)
  }, [props.token])

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

  let onChange = (e) => {
    setLoading(true)
    setMessage("Wysyłanie nowego obrazka...")

    let data = new FormData();
    data.append("file", e.target.files[0])

    fetch("api/Minio", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token
      },
      body: data
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t.startsWith("medicus/"));
        if(t.startsWith("medicus/")) {
          setMessage("Obrazek został wysłany")
          setImage(t)
        } else {
          setMessage("Nie udało się wysłać obrazka")
        }
      })
  }

  return (
    <>
      <Button className="float-end" color="success" onClick={toggle} disabled={loading}>Dodaj</Button>
      <Modal isOpen={open} toggle={toggle}>
        <ModalHeader toggle={toggle}>Sekcja opisu</ModalHeader>
        <ModalBody>
          <div className="images-cont">
            <div className="d-inline-block float-start m-2 rounded shadow">
              <label htmlFor="file" className="image-cont text-center d-table">
                <div className="d-table-cell vertical-center">
                  <i className="icon folder"/>
                  <h5 className="text-center">Prześlij zdjęcie</h5>
                </div>
              </label>
              <Input
                id="file"
                name="file"
                type="file"
                accept=".jpg,.jpeg,.png"
                className="d-none"
                onChange={onChange}
              />
            </div>
            {images.map((item, index) => (
              <div className="d-inline-block position-relative float-start m-2 rounded shadow" key={index} onClick={() => setImage(item)}>
                <div className="image-checkbox">
                  <Input type="checkbox" checked={image === item} />
                </div>
                <img className="image-cont" src={Config.minio + item} alt={item}/>
              </div>
            ))}
          </div>
          <div className="mt-3">
            <FormGroup floating>
              <Input
                id="image"
                name="image"
                defaultValue={image}
                type="text"
                disabled
              />
              <Label for="image">
                Obrazek
              </Label>
            </FormGroup>
          </div>
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