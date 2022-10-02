import {
  Button,
  Col,
  Form,
  FormGroup,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row,
  TabPane, UncontrolledAccordion
} from "reactstrap";
import Notification from "../../../components/Notification";
import {useEffect, useState} from "react";
import TabStatic from "./TabStatic";

export default function TabStatics(props) {
  let [statics, setStatics] = useState([])

  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  let load = () => {
    fetch('api/Static/GetStaticIds', {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setStatics(j))
  }

  useEffect(() => {
    load()
  }, [props.keycloak.token])

  let onSubmit = (e) => {
    setOpen(false);
    setLoading(true)
    setMessage("Tworzenie nowej specjalizacji...")
    e.preventDefault();
    fetch('api/Static/AddStatic', {
      method: "PUT",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({name: e.target.name.value, hasMap: e.target.hasMap.checked})
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nowa specjalizacja została stworzona")
        } else {
          setMessage("Nie udało się stworzyć nowej specjalizacji")
        }
        load()
      })
  }

  return (
    <TabPane tabId={props.index.toString()} className="pt-3 pb-3">
      <Row className="mb-3">
        <Col>
          <Button className="float-end" color="success" onClick={toggle}>Dodaj statyczną stronę</Button>
          <Modal isOpen={open} toggle={toggle} size="xl">
            <ModalHeader toggle={toggle}>Statyczna strona</ModalHeader>
            <Form onSubmit={onSubmit}>
              <ModalBody>
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
                    <Button color="secondary" onClick={toggle} disabled={loading}>
                      Anuluj
                    </Button>
                  </Col>
                </Row>
              </ModalFooter>
            </Form>
          </Modal>
          <Notification loading={loading} success={success} message={message}/>
        </Col>
      </Row>
      <Row>
        <Col>
          <UncontrolledAccordion className="mb-3">
            {statics.map((item, key) => <TabStatic id={item} token={props.keycloak.token} index={key} key={key} load={load}/>)}
          </UncontrolledAccordion>
        </Col>
      </Row>
    </TabPane>
  )
}