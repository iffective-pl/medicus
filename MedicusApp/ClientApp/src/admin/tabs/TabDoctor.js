import {useEffect, useState} from "react";
import {
  AccordionBody,
  AccordionHeader, AccordionItem,
  Button, Card,
  CardBody,
  CardHeader,
  Col,
  Form,
  FormGroup,
  Input,
  InputGroup,
  Label, Modal, ModalBody, ModalFooter, ModalHeader,
  Row,
} from "reactstrap";
import Notification from "../../components/Notification";
import AddSpecButton from "../AddSpecButton";
import DelSpecButton from "../DelSpecButton";

let doc = {
  id: undefined,
  title: "",
  firstName: "",
  lastName: "",
  specTitle: "",
  description: "",
  image: "",
  workingHours: [],
  specializations: []
}

let hours = {
  monday: "",
  tuesday: "",
  wednesday: "",
  thursday: "",
  friday: "",
  saturday: ""
}

export default function TabDoctor(props) {
  let [doctor, setDoctor] = useState(doc);
  let [spec, setSpec] = useState(1)
  let [workingHours, setWorkingHours] = useState(hours);

  let [open, setOpen] = useState(false);

  let toggle = () => setOpen(!open)

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    fetch("api/Doctor/GetDoctor?doctorId=" + props.id, {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => {
        setDoctor(j);
        if(j.specializations.length > 0) {
          setSpec(j.specializations[0].id);
        }
      })
  }

  useEffect(() => load(), [props.token])

  let onChange = (e) => {
    const d = doctor;
    d[e.target.name] = e.target.value;
    setDoctor(d);
  }

  let onChangeSpec = (e) => {
    setSpec(parseInt(e.target.value));
  }

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Aktualizacja danych lekarza...")
    e.preventDefault();
    let data = { id: doctor.id };
    Object.entries(e.target).filter(q => q.nodeName !== "BUTTON").forEach(([key, value]) => {
      data[value.name] = value.value;
    });

    fetch("api/Doctor/UpdateDoctor", {
      method: "POST",
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
          setMessage("Aktualizacja powiodła się")
        } else {
          setMessage("Aktualizacja nie powiodła się")
        }
        load()
      })
  }

  let onSubmitWorkingHours = (e) => {
    setLoading(true);
    setMessage("Aktualizacja godzin pracy...");
    e.preventDefault();
    let data = { specId: spec, doctorId: doctor.id };
    Object.entries(e.target).filter(q => q.nodeName !== "BUTTON").forEach(([key, value]) => {
      data[value.name] = value.value;
    });

    fetch("api/Doctor/UpdateWorkingHours", {
      method: "POST",
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
        if (t === "true") {
          setMessage("Aktualizacja powiodła się");
        } else {
          setMessage("Aktualizacja nie powiodła się");
        }
        load()
      })
  }

  let deleteDoctor = (e) => {
    setOpen(false);
    setLoading(true);
    setMessage("Usuwanie lekarza...");
    e.preventDefault();
    fetch("api/Doctor/DeleteDoctor?doctorId=" + doctor.id, {
      method: "DELETE",
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if (t === "true") {
          setMessage("Lekarz został usunięty");
        } else {
          setMessage("Usuwanie nie powiodło się");
        }
        props.update()
      })
  }

  useEffect(() => {
    if(doctor.id) {
      setWorkingHours(doctor.workingHours.find(q => q.specId === spec))
    }
  }, [spec, doctor])

  return (
    <>
      <Row className="mb-3">
        <Col>
          <AccordionItem>
            <AccordionHeader targetId={props.index.toString()}>
              {doctor.title} {doctor.firstName} {doctor.lastName}
            </AccordionHeader>
            <AccordionBody accordionId={props.index.toString()}>
              <Form onSubmit={onSubmit}>
                <Row>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="title"
                        name="title"
                        type="text"
                        defaultValue={doctor.title}
                        onChange={onChange}
                      />
                      <Label for="title">
                        Tytuł
                      </Label>
                    </FormGroup>
                  </Col>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="firstName"
                        name="firstName"
                        type="text"
                        defaultValue={doctor.firstName}
                        onChange={onChange}
                      />
                      <Label for="firstName">
                        Imię
                      </Label>
                    </FormGroup>
                  </Col>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="lastName"
                        name="lastName"
                        type="text"
                        defaultValue={doctor.lastName}
                        onChange={onChange}
                      />
                      <Label for="lastName">
                        Nazwisko
                      </Label>
                    </FormGroup>
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="specTitle"
                        name="specTitle"
                        type="text"
                        defaultValue={doctor.specTitle}
                        onChange={onChange}
                      />
                      <Label for="specTitle">
                        Tytuł specjalistyczny
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
                        type="textarea"
                        className="text-area-size"
                        defaultValue={doctor.description}
                        onChange={onChange}
                      />
                      <Label for="description">
                        Opis
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
              <Row className="mt-3">
                <Col>
                  <Card>
                    <CardHeader targetId="=1">Specjalizacje</CardHeader>
                    <CardBody accordion="-1">
                      {doctor.specializations.map((item, key) => (
                        <Row key={key}>
                          <Col>
                            <InputGroup key={key} className="mb-3">
                              <DelSpecButton id={item.id} name={item.name} doc={doctor.id} token={props.token} load={load}/>
                              <Input type="text" defaultValue={item.name} disabled/>
                            </InputGroup>
                          </Col>
                        </Row>
                      ))}
                      <Row>
                        <Col>
                          <AddSpecButton doc={doctor.id} token={props.token} load={load} specs={doctor.specializations}/>
                        </Col>
                      </Row>
                    </CardBody>
                  </Card>
                </Col>
                <Col>
                  <Card>
                    <CardHeader targetId="=1">Godziny pracy</CardHeader>
                    <CardBody accordion="-1">
                      <Row>
                        <Col>
                          <FormGroup>
                            <Label for="spec">
                              Specjalizacja
                            </Label>
                            <Input
                              id="spec"
                              name="spec"
                              type="select"
                              onChange={onChangeSpec}
                              disabled={doctor.specializations.length < 1}
                            >
                              {doctor.specializations.map((item, key) => (
                                <option value={item.id} key={key}>
                                  {item.name}
                                </option>
                              ))}
                            </Input>
                          </FormGroup>
                        </Col>
                      </Row>
                      <Form onSubmit={onSubmitWorkingHours} className="text-center">
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Poniedziałek
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="monday"
                              name="monday"
                              type="text"
                              defaultValue={workingHours?.monday}
                            />
                          </Col>
                        </Row>
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Wtorek
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="tuesday"
                              name="tuesday"
                              type="text"
                              defaultValue={workingHours?.tuesday}
                            />
                          </Col>
                        </Row>
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Środa
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="wednesday"
                              name="wednesday"
                              type="text"
                              defaultValue={workingHours?.wednesday}
                            />
                          </Col>
                        </Row>
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Czwartek
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="thursday"
                              name="thursday"
                              type="text"
                              defaultValue={workingHours?.thursday}
                            />
                          </Col>
                        </Row>
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Piątek
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="friday"
                              name="friday"
                              type="text"
                              defaultValue={workingHours?.friday}
                            />
                          </Col>
                        </Row>
                        <Row className="mb-3">
                          <Col className="d-table">
                            <div className="d-table-cell vertical-center">
                              Sobota
                            </div>
                          </Col>
                          <Col>
                            <Input
                              id="saturday"
                              name="saturday"
                              type="text"
                              defaultValue={workingHours?.saturday}
                            />
                          </Col>
                        </Row>
                        <Row>
                          <Col>
                            <Button className="float-end" color="info" type="submit" disabled={loading || doctor.specializations.length < 1}>Zapisz</Button>
                          </Col>
                        </Row>
                      </Form>
                    </CardBody>
                  </Card>
                </Col>
              </Row>
              <Row className="mt-3">
                <Col>
                  <Button color="danger" onClick={toggle} disabled={loading}>Usuń</Button>
                  <Modal isOpen={open} toggle={toggle}>
                    <Form onSubmit={deleteDoctor}>
                      <ModalHeader toggle={toggle}>Lekarz</ModalHeader>
                      <ModalBody>
                        Czy na pewno chcesz usunąć lekarza: {doctor.title} {doctor.firstName} {doctor.lastName}?
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
        </Col>
      </Row>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}