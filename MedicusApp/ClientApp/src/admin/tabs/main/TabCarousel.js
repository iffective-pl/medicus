import Notification from "../../../components/Notification";
import {useEffect, useState} from "react";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Col, Form,
  FormGroup,
  Input, Label, Modal,
  ModalBody, ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";
import Config from "../../../config/Config";
import ImageSelector from "../../../components/ImageSelector";

export default function TabCarousel(props) {
  let [image, setImage] = useState(props.carousel.source)
  let [href, setHref] = useState(props.carousel.buttonHref)
  let [statics, setStatics] = useState([])
  let [links, setLinks] = useState([])
  let [headers, setHeaders] = useState([])

  let [openEdit, setOpenEdit] = useState(false);
  let [openDel, setOpenDel] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggleEdit = () => setOpenEdit(!openEdit);
  let toggleDel = () => setOpenDel(!openDel);

  useEffect(() => {
    loadStatics()
    loadLinks()
    loadHeaders()
  }, [props.token])

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

  let onImageChange = (e) => {
    setImage(e)
  }

  let onEdit = (e) => {
    setOpenEdit(false)
    setLoading(true)
    setMessage("Aktualizacja elementu karuzeli...")
    e.preventDefault()
    fetch("api/MP/UpdateCarousel", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        id: props.carousel.id,
        source: image,
        mainTitle: e.target.mainTitle.value,
        subTitle: e.target.subTitle.value,
        text: e.target.text.value,
        buttonHref: href,
        buttonText: e.target.buttonText.value
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Zaktualizowano element karuzeli")
        } else {
          setMessage("Nie udało się zaktualizować elementu karuzeli")
        }
        props.update()
      })
  }

  let onDel = (e) => {
    setOpenEdit(false)
    setLoading(true)
    setMessage("Usuwanie elementu karuzeli...")
    e.preventDefault()
    fetch("api/MP/DeleteCarousel?carouselId=" + props.carousel.id, {
      method: "DELETE",
      headers: {
        "Authorization": "Bearer " + props.token
      },
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Usunięto element karuzeli")
        } else {
          setMessage("Nie udało się usunąć elementu karuzeli")
        }
        props.update()
      })
  }

  return (
    <>
      <Card className="mb-3">
        <CardBody className="p-0 overflow-hidden">
          <img alt={props.index} src={Config.minio + props.carousel.source} className="description-img admin" />
          <span className="description">
            <span className="description-text">
              <h1 className="title">{props.carousel.mainTitle}</h1>
              <h1 className="title">{props.carousel.subTitle}</h1>
              <h3 className="sub-title fw-bold">{props.carousel.text}</h3>
              <Button
                tag="a" size="lg"
                className="title-button mt-2"
                hidden={!props.carousel.buttonHref} href={props.carousel.buttonHref}
              >{props.carousel.buttonText}</Button>
            </span>
          </span>
        </CardBody>
        <CardFooter>
          <Row>
            <Col>
              <Button color="danger" onClick={toggleDel}>Usuń element</Button>
              <Modal isOpen={openDel} toggle={toggleDel}>
                <Form onSubmit={onDel}>
                  <ModalHeader toggle={toggleEdit}>Element karuzeli</ModalHeader>
                  <ModalBody>
                    Czy na pewno chcesz usunąć ten element karuzeli?
                  </ModalBody>
                  <ModalFooter>
                    <Row>
                      <Col>
                        <Button color="primary" type="submit" disabled={loading}>
                          Zatwierdź
                        </Button>
                      </Col>
                      <Col>
                        <Button color="secondary" onClick={toggleDel} disabled={loading}>
                          Anuluj
                        </Button>
                      </Col>
                    </Row>
                  </ModalFooter>
                </Form>
              </Modal>
            </Col>
            <Col>
              <Button className="float-end" color="info" onClick={toggleEdit}>Edytuj element</Button>
              <Modal isOpen={openEdit} toggle={toggleEdit} size="xl">
                <ModalHeader toggle={toggleEdit}>Karuzela</ModalHeader>
                <Form onSubmit={onEdit}>
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
                            defaultValue={props.carousel.mainTitle}
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
                            defaultValue={props.carousel.subTitle}
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
                            defaultValue={props.carousel.text}
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
                            defaultValue={props.carousel.buttonText}
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
                            value={href}
                            onChange={(e) => setHref(e.target.value)}
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
                          Zapisz
                        </Button>
                      </Col>
                      <Col>
                        <Button color="secondary" onClick={toggleEdit} disabled={loading}>
                          Anuluj
                        </Button>
                      </Col>
                    </Row>
                  </ModalFooter>
                </Form>
              </Modal>
            </Col>
          </Row>
        </CardFooter>
      </Card>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}