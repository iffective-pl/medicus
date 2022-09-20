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
  Label,
  Row
} from "reactstrap";
import Notification from "../../components/Notification";
import TabSpecDesc from "./TabSpecDesc";
import AddDescButton from "../AddDescButton";
import TabSpecPrices from "./TabSpecPrices";

let sp = {
  id: undefined,
  name: "",
  descriptions: []
}

export default function TabSpec(props) {
  let [spec, setSpec] = useState(sp)
  let [open, setOpen] = useState(false);

  let toggle = () => setOpen(!open)

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    fetch("api/Spec/GetSpec?specId=" + props.id, {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setSpec(j))
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
        name: spec.name
      })
    })
      .then(r => r.json())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Nazwa specjalizacji zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować nazwy specjalizacji")
        }
      })
  }

  return (
    <Row className="mb-3">
      <Col>
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
                    <Label for="title">
                      Nazwa
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
                <Card>
                  <CardHeader>
                    <Row>
                      <Col className="d-table">
                        <div className="vertical-center d-table-cell">
                          Sekcje opisów
                        </div>
                      </Col>
                      <Col>
                        <AddDescButton id={spec.id} token={props.token} load={load}/>
                      </Col>
                    </Row>
                  </CardHeader>
                  <CardBody className="p-3">
                    {spec.descriptions.map((item, key) => (
                      <TabSpecDesc desc={item} key={key} token={props.token} update={load}/>
                    ))}
                  </CardBody>
                </Card>
              </Col>
            </Row>
            <TabSpecPrices token={props.token} id={spec.id}/>
          </AccordionBody>
        </AccordionItem>
      </Col>
    </Row>
  )
}