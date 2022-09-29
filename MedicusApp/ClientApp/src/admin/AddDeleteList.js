import {useEffect, useState} from "react";
import {
  Button, Card, CardBody, CardHeader,
  Col, Form, FormGroup,
  Input,
  InputGroup, Label, Modal, ModalBody, ModalFooter, ModalHeader, Row
} from "reactstrap";

import './AddDeleteList.css';
import Notification from "../components/Notification";

export default function AddDeleteList(props) {
  let [elements, setElements] = useState([]);

  let [openAdd, setOpenAdd] = useState(false);
  let [openDel, setOpenDel] = useState(false);

  let toggleAdd = () => setOpenAdd(!openAdd);
  let toggleDel = () => setOpenDel(!openDel);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    switch(props.type) {
      default:
      case "phone": {
        fetch("api/Company/GetPhones", {
          headers: {
            "Authorization": "Bearer " + props.token
          }
        })
          .then(r => r.json())
          .then(j => setElements(j))
        break
      }
      case "mobile": {
        fetch("api/Company/GetMobilePhones", {
          headers: {
            "Authorization": "Bearer " + props.token
          }
        })
          .then(r => r.json())
          .then(j => setElements(j))
        break
      }
      case "email": {
        fetch("api/Company/GetEmails", {
          headers: {
            "Authorization": "Bearer " + props.token
          }
        })
          .then(r => r.json())
          .then(j => setElements(j))
      }
    }
  }

  useEffect(() => {
    load();
  }, [props.type, props.token]);

  let title = () => {
    switch (props.type) {
      default:
      case "phone":
        return "Numery telefonów mobilnych"
      case "mobile":
        return "Numery telefonów stacjonarnych"
      case "email":
        return "Adresy mailowe"
    }
  }

  let field = () => {
    switch (props.type) {
      default:
      case "phone":
        return "Numer telefonu mobilnego"
      case "mobile":
        return "Numer telefonu stacjonarnego"
      case "email":
        return "Adres mailowy"
    }
  }

  let onAdd = (e) => {
    setOpenAdd(false)
    setLoading(true)
    setMessage("Operacja w toku...")
    e.preventDefault()
    let data = e.target.value.value;
    sendRequestAdd(data)
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Operacja ukończona z powodzeniem")
        } else {
          setMessage("Nie udało się ukończyć operacji")
        }
        load()
      })
  }

  let onUpdate = (e) => {
    setOpenDel(false)
    setLoading(true)
    setMessage("Operacja w toku...")
    e.preventDefault()
    let data = e.target.value.value;
    sendRequestUpdate(data)
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Operacja ukończona z powodzeniem")
        } else {
          setMessage("Nie udało się ukończyć operacji")
        }
        load()
      })
  }

  let onDel = (e, id) => {
    setOpenDel(false)
    setLoading(true)
    setMessage("Operacja w toku...")
    e.preventDefault()
    sendRequestDel(id)
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Operacja ukończona z powodzeniem")
        } else {
          setMessage("Nie udało się ukończyć operacji")
        }
        load()
      })
  }

  let sendRequestAdd = (data) => {
    switch(props.type) {
      default:
      case "phone": {
        return fetch("api/Company/AddNumber", {
          method: "PUT",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            number: data,
            isMobile: false
          })
        })
      }
      case "mobile": {
        return fetch("api/Company/AddNumber", {
          method: "PUT",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            number: data,
            isMobile: true
          })
        })
      }
      case "email": {
        return fetch("api/Company/AddEmail", {
          method: "PUT",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            address: data
          })
        })
      }
    }
  }

  let sendRequestUpdate = (data) => {
    switch(props.type) {
      default:
      case "phone": {
        return fetch("api/Company/UpdateNumber", {
          method: "POST",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            number: data,
            isMobile: false
          })
        })
      }
      case "mobile": {
        return fetch("api/Company/UpdateNumber", {
          method: "POST",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            number: data,
            isMobile: true
          })
        })
      }
      case "email": {
        return fetch("api/Company/UpdateEmail", {
          method: "POST",
          headers: {
            "Authorization": "Bearer " + props.token,
            "Content-Type": "application/json"
          },
          body: JSON.stringify({
            address: data
          })
        })
      }
    }
  }

  let sendRequestDel = (id) => {
    switch(props.type) {
      default:
      case "phone": {
        return fetch("api/Company/DeleteNumber?id=" + id, {
          method: "DELETE",
          headers: {
            "Authorization": "Bearer " + props.token
          }
        })
      }
      case "email": {
        return fetch("api/Company/DeleteEmail?id=" + id, {
          method: "DELETE",
          headers: {
            "Authorization": "Bearer " + props.token
          }
        })
      }
    }
  }

  return (
    <>
      <Card className="mb-3">
        <CardHeader targetId="1">
          <Row>
            <Col>
              <div className="d-table height-top">
                <div className="d-table-cell vertical-center">
                  {title()}
                </div>
              </div>
            </Col>
            <Col sm={2}>
              <Button className="float-end" color="success" onClick={toggleAdd}>Dodaj</Button>
              <Modal isOpen={openAdd} toggle={toggleAdd}>
                <ModalHeader toggle={toggleAdd}>{title()}</ModalHeader>
                <Form onSubmit={onAdd}>
                  <ModalBody>
                    <Row>
                      <Col>
                        <FormGroup floating>
                          <Input
                            bsSize="lg"
                            id="value"
                            name="value"
                            type="text"
                          />
                          <Label for="value">
                            {field()}
                          </Label>
                        </FormGroup>
                      </Col>
                    </Row>
                  </ModalBody>
                  <ModalFooter>
                    <Row>
                      <Col>
                        <Button color="primary" type="submit" disabled={loading}>
                          Stwórz
                        </Button>
                      </Col>
                      <Col>
                        <Button color="secondary" onClick={toggleAdd} disabled={loading}>
                          Anuluj
                        </Button>
                      </Col>
                    </Row>
                  </ModalFooter>
                </Form>
              </Modal>
            </Col>
          </Row>
        </CardHeader>
        <CardBody accordionId="1">
          {elements.map((item, index) => (
            <Row key={index}>
              <Col>
                <Modal isOpen={openDel} toggle={toggleDel}>
                  <Form onSubmit={(e) => onDel(e, item.id)}>
                    <ModalHeader toggle={toggleDel}>Usługa</ModalHeader>
                    <ModalBody>
                      Czy na pewno chcesz usunąć ten element?
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
                <Form onSubmit={onUpdate}>
                  <InputGroup key={index} className="m-2">
                    <Button color="danger" onClick={toggleDel}>
                      Usuń
                    </Button>
                    <Input name="value" defaultValue={props.type === "email" ? item.address : item.number}/>
                    <Button color="info" type="submit">
                      Zapisz
                    </Button>
                  </InputGroup>
                </Form>
              </Col>
            </Row>
          ))}
        </CardBody>
      </Card>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}