import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button,
  Card,
  CardBody, CardFooter,
  CardHeader,
  Col, Form, FormGroup, Input, Label,
  Modal, ModalBody, ModalFooter, ModalHeader,
  Row
} from "reactstrap";
import {useEffect, useState} from "react";
import ImageSelector from "../../../components/ImageSelector";
import Notification from "../../../components/Notification";
import DelDescButton from "../../operations/DelDescButton";
import EditDescButton from "../../operations/EditDescButton";
import Description from "../../../components/Description";

const defaultS = {
  id: 0,
  name: "",
  descriptions: []
}

export default function TabStatic(props) {
  let [s, setS] = useState(defaultS);
  let [image, setImage] = useState("");

  let [openAdd, setOpenAdd] = useState(false);
  let [openDel, setOpenDel] = useState(false);
  let [openEdit, setOpenEdit] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggleAdd = () => setOpenAdd(!openAdd);
  let toggleDel = () => setOpenDel(!openDel);
  let toggleEdit = () => setOpenEdit(!openEdit);

  let load = () => {
    fetch("api/Static/GetStatic?staticId=" + props.id)
      .then(r => r.json())
      .then(j => setS(j))
  }

  useEffect(() => {
    load()
  }, [props.token])

  let onChangeText = (e) => {
    let change = {};
    change[e.target.name] = e.target.value;
    setS(s => ({
      ...s,
      ...change
    }));
  }

  let onChangeCheckbox = (e) => {
    let change = {};
    change[e.target.name] = e.target.checked;
    setS(s => ({
      ...s,
      ...change
    }));
  }

  let onSubmitAdd = (e) => {
    setOpenAdd(false)
    setLoading(true)
    setMessage("Dodawanie nowej sekcji opisu...")
    e.preventDefault();
    fetch("api/Desc", {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        image: image,
        staticId: props.id
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
        load()
      })
  }

  let onSubmitDel = (e) => {
    setOpenDel(false)
    setLoading(true)
    setMessage("Usuwanie statycznej strony...")
    e.preventDefault();
    fetch("api/Static/DeleteStatic?staticId=" + props.id, {
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
          setMessage("Statyczna strona została usunięta")
        } else {
          setMessage("Nie udało się usunąć statycznej strony")
        }
        props.load()
      })
  }

  let onSubmitUpdate = (e) => {
    setOpenAdd(false)
    setLoading(true)
    setMessage("Aktualizacja statycznej strony...")
    e.preventDefault();
    fetch("api/Static/UpdateStatic", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(s)
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Statyczna strona została zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować statycznej strony")
        }
        load()
      })
  }

  return (
    <>
      <AccordionItem>
        <AccordionHeader targetId={props.index.toString()}>
          {s.name}
        </AccordionHeader>
        <AccordionBody accordionId={props.index.toString()}>
          <Card>
            <CardHeader>
              <Row>
                <Col>
                  <Button className="float-end" color="success" onClick={toggleAdd} disabled={loading}>Dodaj sekcję opisu</Button>
                  <Modal isOpen={openAdd} toggle={toggleAdd}>
                    <ModalHeader toggle={toggleAdd}>Sekcja opisu</ModalHeader>
                    <ModalBody>
                      <ImageSelector token={props.token} image={image} setImage={setImage}/>
                    </ModalBody>
                    <ModalFooter>
                      <Row>
                        <Col>
                          <Button color="primary" onClick={onSubmitAdd} disabled={loading}>
                            Zatwierdź
                          </Button>
                        </Col>
                        <Col>
                          <Button color="secondary" onClick={toggleAdd} disabled={loading}>
                            Anuluj
                          </Button>
                        </Col>
                      </Row>
                    </ModalFooter>
                  </Modal>
                </Col>
              </Row>
            </CardHeader>
            <CardBody className="p-3">
              {s.descriptions.map((item, index) => (
                <Card className="mb-3">
                  <CardBody className="p-0">
                    <Description description={item} isEven={index%2===0}/>
                  </CardBody>
                  <CardFooter>
                    <Row>
                      <Col>
                        <DelDescButton token={props.token} load={props.load} desc={item.id}/>
                      </Col>
                      <Col>
                        <EditDescButton desc={item} token={props.token} update={props.load}/>
                      </Col>
                    </Row>
                  </CardFooter>
                </Card>
              ))}
            </CardBody>
            <CardFooter>
              <Row>
                <Col>
                  <Button color="danger" onClick={toggleDel}>Usuń statyczną stronę</Button>
                  <Modal isOpen={openDel} toggle={toggleDel}>
                    <Form onSubmit={onSubmitDel}>
                      <ModalHeader toggle={toggleDel}>Statyczna strona</ModalHeader>
                      <ModalBody>
                        Czy na pewno chcesz usunąć tą statyczną stronę?
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
                  <Button className="float-end" color="info" onClick={toggleEdit}>Edytuj statyczną stronę</Button>
                  <Modal isOpen={openEdit} toggle={toggleEdit} size="xl">
                    <ModalHeader toggle={toggleEdit}>Statyczna strona</ModalHeader>
                    <Form onSubmit={onSubmitUpdate}>
                      <ModalBody>
                        <Row>
                          <Col>
                            <FormGroup floating>
                              <Input
                                bsSize="lg"
                                id="name"
                                name="name"
                                type="text"
                                onChange={onChangeText}
                                value={s.name}
                              />
                              <Label for="name">
                                Nazwa statycznej strony
                              </Label>
                            </FormGroup>
                          </Col>
                        </Row>
                        <Row>
                          <Col>
                            <FormGroup check>
                              <Input
                                name="hasMap"
                                type="checkbox"
                                onChange={onChangeCheckbox}
                                checked={s.hasMap}
                              />
                              <Label check>
                                Czy ma być wyświetlana mapa na dole strony?
                              </Label>
                            </FormGroup>
                          </Col>
                        </Row>
                      </ModalBody>
                      <ModalFooter>
                        <Row>
                          <Col>
                            <Button color="primary" disabled={loading} type="submit">
                              Zatwierdź
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
        </AccordionBody>
      </AccordionItem>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}