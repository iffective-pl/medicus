import {useEffect, useState} from "react";
import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button, Card, CardBody, CardHeader,
  Col,
  Form,
  FormGroup,
  Input,
  Label, Modal, ModalBody, ModalFooter, ModalHeader,
  Row, UncontrolledAccordion
} from "reactstrap";
import Notification from "../../../components/Notification";
import TabSpecPrices from "./TabSpecPrices";
import TabSpecDescs from "./TabSpecDescs";
import list from "../../../data/icons.json";
import {DragDropContext, Draggable, Droppable} from "react-beautiful-dnd";

let sp = {
  id: undefined,
  name: "",
  style: {
    className: "",
    color: ""
  },
  doctorsOrder: [],
  descriptions: []
}

export default function TabSpec(props) {
  let [spec, setSpec] = useState(sp)
  let [icon, setIcon] = useState()
  let [color, setColor] = useState()
  let [order, setOrder] = useState([])

  let [open, setOpen] = useState(false);
  let toggle = () => setOpen(!open)

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    setOrder([])
    fetch("api/Spec/GetSpec?specId=" + props.id, {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => {
        setSpec(j)
        setIcon(j.style.className)
        setColor(j.style.color)
        setOrder(j.doctorsOrder)
      })
  }

  useEffect(() => load(), [props.token])

  let onChange = (e) => {
    const s = spec;
    s[e.target.name] = e.target.value;
    setSpec(s);
  }

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Aktualizacja nazwy specjalizacji...")
    e.preventDefault()

    fetch("api/Spec/UpdateSpec", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        id: spec.id,
        name: spec.name,
        style: {
          className: icon,
          color: color
        }
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nazwa specjalizacji zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować nazwy specjalizacji")
        }
        load()
      })
  }

  let onDelete = (e) => {
    setLoading(true)
    setMessage("Usuwanie specjalizacji...")
    e.preventDefault()

    fetch("api/Spec/DeleteSpec?specId=" + spec.id, {
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
          setMessage("Specjalizacja została usunięta")
        } else {
          setMessage("Nie udało się usunąć specjalizacji")
        }
        props.load()
      })
  }

  let onDragEnd = (e) => {
    let destination = e.destination;
    destination.droppableId = destination.droppableId.replace("specId", "");
    fetch("api/Spec/OrderDoctor?doctorId=" + e.draggableId, {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(destination)
    })
      .then(r => r.text())
      .then(t => t === "true" ? load() : null)
  }

  return (
    <UncontrolledAccordion className="mb-3" open="0" openDefault="0">
      <AccordionItem>
        <AccordionHeader targetId={props.index.toString()}>
          {spec.name}
        </AccordionHeader>
        <AccordionBody accordionId={props.index.toString()}>
          <Form onSubmit={onSubmit}>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="name"
                    name="name"
                    type="text"
                    defaultValue={spec.name}
                    onChange={onChange}
                  />
                  <Label for="name">
                    Nazwa specjalizacji
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col xs="5">
                <FormGroup floating>
                  <Input
                    id="className"
                    name="className"
                    type="select"
                    value={icon}
                    onChange={(e) => setIcon(e.target.value)}
                  >
                    <option></option>
                    {list.map((item, key) => (
                      <option value={item} key={key}>
                        {item}
                      </option>
                    ))}
                  </Input>
                  <Label for="className">
                    Wybierz obrazek specjalizacji
                  </Label>
                </FormGroup>
              </Col>
              <Col xs="1">
                <i className={icon ? "icon " + icon : ""} style={{"background-color": color}}/>
              </Col>
              <Col>
                <FormGroup floating>
                  <Input
                    id="color"
                    name="color"
                    type="color"
                    value={color}
                    onChange={(e) => setColor(e.target.value)}
                  />
                  <Label for="color">
                    Kolor obrazka specjalizacji
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <Button className="float-end" color="info" type="submit" disabled={loading}>Zapisz</Button>
              </Col>
            </Row>
          </Form>
          <Notification loading={loading} success={success} message={message}/>
          <Row className="mt-3">
            <Col>
              <DragDropContext onDragEnd={onDragEnd}>
                <Droppable droppableId={"specId" + spec.id} direction="horizontal">
                  {(provided) => (
                    <div {...provided.droppableProps} ref={provided.innerRef}>
                      <Card>
                        <CardHeader>Kolejność lekarzy</CardHeader>
                        <CardBody>
                          {order.map((item, key) => (
                            <Draggable key={key} draggableId={item.toString()} index={key}>
                              {(provided) => {
                                let doc = spec.doctors.find(d => d.id === item);
                                return (
                                  <div ref={provided.innerRef}
                                       style={provided.draggableProps.style}
                                       {...provided.draggableProps}
                                       {...provided.dragHandleProps}
                                       className="d-inline-block float-start me-3">
                                    <Card>
                                      <CardBody>
                                        {doc.title} {doc.firstName} {doc.lastName}
                                      </CardBody>
                                    </Card>
                                  </div>
                                )
                              }}
                            </Draggable>
                          ))}
                          {provided.placeholder}
                        </CardBody>
                      </Card>
                    </div>
                  )}
                </Droppable>
              </DragDropContext>
            </Col>
          </Row>
          <TabSpecDescs token={props.token} spec={spec} load={load}/>
          <TabSpecPrices token={props.token} id={spec.id}/>
          <Row className="mt-3">
            <Col>
              <Button color="danger" onClick={toggle}>Usuń specjalizację</Button>
              <Modal isOpen={open} toggle={toggle}>
                <Form onSubmit={onDelete}>
                  <ModalHeader toggle={toggle}>Specjalizacja</ModalHeader>
                  <ModalBody>
                    Czy na pewno chcesz usunąć specjalizację: {spec.name}?
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
            </Col>
          </Row>
        </AccordionBody>
      </AccordionItem>
    </UncontrolledAccordion>
  )
}