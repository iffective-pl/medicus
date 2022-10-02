import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import ImageSelector from "../../components/ImageSelector";
import {useEffect, useState} from "react";
import Notification from "../../components/Notification";

export default function AddServiceButton(props) {
  let [image, setImage] = useState()
  let [statics, setStatics] = useState([])
  let [links, setLinks] = useState([])
  let [headers, setHeaders] = useState([])

  let [open, setOpen] = useState(false);
  let toggle = () => setOpen(!open);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let loadStatics = () => {
    fetch("api/Static/GetStaticDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setStatics(j))
  }

  let loadLinks = () => {
    fetch("api/UI/GetLinkDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setLinks(j))
  }

  let loadHeaders = () => {
    fetch("api/UI/GetHeaderDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setHeaders(j))
  }

  useEffect(() => {
    loadStatics()
    loadLinks()
    loadHeaders()
  }, [props.token])

  let onAddCarousel = (e) => {
    setOpen(false)
    setLoading(true)
    setMessage("Dodawanie serwisu...")
    e.preventDefault()
    fetch("api/MP/AddService", {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        source: image,
        name: e.target.name.value,
        description: e.target.description.value,
        href: e.target.href.value
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Dodano serwis")
        } else {
          setMessage("Nie udało się dodać serwisu")
        }
        props.load()
      })
  }

  let onImageChange = (e) => {
    setImage(e)
  }

  let joinCollections = (s, h, l) => {
    let arr = [{name: "", href: ""}];
    arr = arr.concat(s.map((item) => ({name: item.name, href: "static/" + item.id})));
    arr.push({name: "──────────", disabled: true})
    arr = arr.concat(h);
    arr.push({name: "──────────", disabled: true})
    arr = arr.concat(l.map((item) => ({name: item.spec.name, href: "docs/" + item.href})));
    return arr.map((item, key) => (
      <option value={item.href} key={key} disabled={item.disabled}>
        {item.name}
      </option>
    ));
  }

  return (
    <>
      <Button className="float-end" color="success" onClick={toggle}>Dodaj serwis</Button>
      <Modal isOpen={open} toggle={toggle} size="xl">
        <ModalHeader toggle={toggle}>Karuzela</ModalHeader>
        <Form onSubmit={onAddCarousel}>
          <ModalBody>
            <ImageSelector token={props.token} image={image} setImage={onImageChange}/>
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
                    Nazwa
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
                    type="text"
                  />
                  <Label for="description">
                    Opis
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="href">
                    Przekierowanie
                  </Label>
                  <Input
                    id="href"
                    name="href"
                    type="select"
                    disabled={statics.length < 1}
                  >
                    {joinCollections(statics, headers, links)}
                  </Input>
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