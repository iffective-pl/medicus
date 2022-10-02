import {useEffect, useState} from "react";
import TabSpecPrice from "./TabSpecPrice";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col, Form, FormGroup, Input, Label, Modal,
  ModalBody, ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";
import Notification from "../../../components/Notification";

export default function TabSpecPrices(props) {
  let [prices, setPrices] = useState([]);

  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);
  let toggle = () => setOpen(!open);

  let load = () => {
    if(props.id) {
      fetch("api/Spec/GetPrices?specId=" + props.id, {
        headers: {
          "Authorization": "Bearer " + props.token
        }
      })
        .then(r => r.json())
        .then(j => setPrices(j))
    }
  }

  useEffect(() => load(), [props.id, props.token])

  let onSubmit = (e) => {
    setOpen(false);
    setLoading(true)
    setMessage("Tworzenie nowej usługi...")
    e.preventDefault();
    let data = {
      specId: props.id
    }

    Object.entries(e.target).filter(q => q.nodeName !== "BUTTON").forEach(([key, value]) => {
      data[value.name] = value.value;
    });

    fetch("api/Spec/AddPrice", {
      method: "PUT",
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
          setMessage("Usługa została dodana")
        } else {
          setMessage("Nie udało się dodać nowej usługi")
        }
        load(props.id, props.token)
      })
  }

  return (
    <>
      <Notification loading={loading} success={success} message={message}/>
      <Row className="mt-3">
        <Col>
          <Card>
            <CardHeader>
              <Row>
                <Col className="d-table">
                  <div className="vertical-center d-table-cell">
                    Cennik
                  </div>
                </Col>
                <Col>
                  <Button className="float-end" color="success" onClick={toggle}>Dodaj</Button>
                  <Modal isOpen={open} toggle={toggle}>
                    <ModalHeader toggle={toggle}>Cena usługi</ModalHeader>
                    <Form onSubmit={onSubmit}>
                      <ModalBody>
                        <FormGroup floating>
                          <Input
                            id="title"
                            name="title"
                            type="text"
                          />
                          <Label htmlFor="title">
                            Usługa
                          </Label>
                        </FormGroup>
                        <FormGroup floating>
                          <Input
                            id="value"
                            name="value"
                            type="text"
                          />
                          <Label htmlFor="value">
                            Cena (liczba)
                          </Label>
                        </FormGroup>
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
            </CardHeader>
            <CardBody>
              {prices.map((item, index) => (
                <TabSpecPrice id={item} specId={props.id} token={props.token} key={index} load={load}/>
              ))}
            </CardBody>
          </Card>
        </Col>
      </Row>
    </>
  )
}