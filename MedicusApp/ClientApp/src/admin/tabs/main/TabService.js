import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardImg,
  CardImgOverlay,
  CardSubtitle,
  CardTitle,
  Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader,
  Row
} from "reactstrap";
import ImageSelector from "../../../components/ImageSelector";
import {useEffect, useState} from "react";
import Notification from "../../../components/Notification";
import Config from "../../../config/Config";

export default function TabService(props) {
  let [image, setImage] = useState(props.service.source)
  let [href, setHref] = useState(props.service.href)
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
    arr = arr.concat(l.map((item) => ({name: item.spec.name, href: "docs/" + item.spec.id})));
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
    setMessage("Aktualizacja serwisu...")
    e.preventDefault()
    fetch("api/MP/UpdateService", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        id: props.service.id,
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
          setMessage("Zaktualizowano serwis")
        } else {
          setMessage("Nie udało się zaktualizować serwisu")
        }
        props.update()
      })
  }

  let onDel = (e) => {
    setOpenEdit(false)
    setLoading(true)
    setMessage("Usuwanie serwisu...")
    e.preventDefault()
    fetch("api/MP/DeleteService?serviceId=" + props.service.id, {
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
          setMessage("Usunięto serwis")
        } else {
          setMessage("Nie udało się usunąć serwisu")
        }
        props.update()
      })
  }

  return (
    <>
      <Card className="d-inline-block me-3 mb-3">
        <CardBody className="p-0">
          <Card className="services shadow">
            <CardImg
              alt={props.service.name}
              src={Config.minio + props.service.source}
            />
            <CardImgOverlay className="p-0">
              <CardBody className="services p-5">
                <CardTitle tag="h5">
                  {props.service.name}
                </CardTitle>
                <CardSubtitle
                  className="mb-2 text-muted"
                  tag="h6"
                >
                  {props.service.description}
                </CardSubtitle>
              </CardBody>
            </CardImgOverlay>
          </Card>
        </CardBody>
        <CardFooter>
          <Row>
            <Col>
              <Button className="float-start" color="danger" onClick={toggleDel}>Usuń serwis</Button>
              <Modal isOpen={openDel} toggle={toggleDel}>
                <Form onSubmit={onDel}>
                  <ModalHeader toggle={toggleEdit}>Serwis</ModalHeader>
                  <ModalBody>
                    Czy na pewno chcesz usunąć ten serwis?
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
              <Button className="float-end" color="info" onClick={toggleEdit}>Edytuj serwis</Button>
              <Modal isOpen={openEdit} toggle={toggleEdit} size="xl">
                <ModalHeader toggle={toggleEdit}>Serwis</ModalHeader>
                <Form onSubmit={onEdit}>
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
                            defaultValue={props.service.name}
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
                            defaultValue={props.service.description}
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