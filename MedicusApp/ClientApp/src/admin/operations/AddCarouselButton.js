import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader, Row} from "reactstrap";
import ImageSelector from "../../components/ImageSelector";
import {useEffect, useState} from "react";
import Notification from "../../components/Notification";

export default function AddCarouselButton(props) {
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
    setMessage("Dodawanie elementu karuzeli...")
    e.preventDefault()
    fetch("api/MP/AddCarousel", {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        source: image,
        mainTitle: e.target.mainTitle.value,
        subTitle: e.target.subTitle.value,
        text: e.target.text.value,
        buttonHref: e.target.href.value,
        buttonText: e.target.buttonText.value
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Dodano element karuzeli")
        } else {
          setMessage("Nie udało się dodać elementu karuzeli")
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
    arr = arr.concat(l.map((item) => ({name: item.spec.name, href: "docs/" + item.spec.id})));
    return arr.map((item, key) => (
      <option value={item.href} key={key} disabled={item.disabled}>
        {item.name}
      </option>
    ));
  }

  return (
    <>
      <Button className="float-end" color="success" onClick={toggle}>Dodaj element</Button>
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
                    id="mainTitle"
                    name="mainTitle"
                    type="text"
                  />
                  <Label for="mainTitle">
                    Główny tytuł
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="subTitle"
                    name="subTitle"
                    type="text"
                  />
                  <Label for="subTitle">
                    Podtytuł
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="text"
                    name="text"
                    type="text"
                  />
                  <Label for="text">
                    Tekst
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="buttonText"
                    name="buttonText"
                    type="text"
                  />
                  <Label for="buttonText">
                    Tekst przycisku
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="href">
                    Przekierowanie przycisku
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