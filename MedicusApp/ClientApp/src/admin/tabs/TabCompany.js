import {
  Button,
  Col,
  Form,
  FormGroup,
  Input,
  Label,
  Row,
  TabPane
} from "reactstrap";
import {useEffect, useState} from "react";
import AddDeleteList from "../AddDeleteList";
import Notification from "../../components/Notification";

let comp = {
  id: undefined,
  name: "",
  address: "",
  code: "",
  city: ""
}

export default function TabCompany(props) {
  let [company, setCompany] = useState(comp);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let load = () => {
    fetch("api/Company/GetCompany", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
        .then(r => r.json())
        .then(j => setCompany(j))
  }

  useEffect(() => {
    load()
  }, [props.keycloak.token]);

  let onChange = (e) => {
    const c = company;
    c[e.target.name] = e.target.value;
    setCompany(c);
  }

  let onSubmit = (e) => {
    setLoading(true);
    setMessage("Aktualizacja danych placówki...");
    e.preventDefault();
    let data = { id: company.id };
    Object.entries(e.target).filter(q => q.nodeName !== "BUTTON").forEach(([key, value]) => {
      data[value.name] = value.value;
    });

    fetch("api/Company/UpdateCompany", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(data)
    })
        .then(r => r.text())
        .then(t => {
          load()
          setLoading(false);
          setSuccess(t === "true")
          if(t === "true") {
            setMessage("Aktualizacja powiodła się")
          } else {
            setMessage("Aktualizacja nie powiodła się")
          }
        })
  }

  return (
    <TabPane tabId="1" className="pt-3 pb-3">
      <Form onSubmit={onSubmit}>
        <Row>
          <Col>
            <FormGroup floating>
              <Input
                bsSize="lg"
                id="name"
                name="Name"
                type="text"
                defaultValue={company.name}
                onChange={onChange}
              />
              <Label for="name">
                Nazwa Przychodni
              </Label>
            </FormGroup>
          </Col>
        </Row>
        <Row>
          <Col>
            <FormGroup floating>
              <Input
                bsSize="lg"
                id="address"
                name="address"
                type="text"
                defaultValue={company.address}
                onChange={onChange}
              />
              <Label for="name">
                Adres
              </Label>
            </FormGroup>
          </Col>
        </Row>
        <Row>
          <Col>
            <FormGroup floating>
              <Input
                bsSize="lg"
                id="code"
                name="code"
                type="text"
                defaultValue={company.code}
                onChange={onChange}
              />
              <Label for="name">
                Kod pocztowy
              </Label>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup floating>
              <Input
                bsSize="lg"
                id="city"
                name="city"
                type="text"
                defaultValue={company.city}
                onChange={onChange}
              />
              <Label for="name">
                Miasto
              </Label>
            </FormGroup>
          </Col>
        </Row>
        <Row>
          <Col>
            <Button className="float-end" color="info" type="submit" disabled={loading}>Zaktualizuj</Button>
          </Col>
        </Row>
      </Form>
      <Row className="mt-3">
        <Col>
          <AddDeleteList type="phone" token={props.keycloak.token}/>
        </Col>
        <Col>
          <AddDeleteList type="mobile" token={props.keycloak.token}/>
        </Col>
        <Col>
          <AddDeleteList type="email" token={props.keycloak.token}/>
        </Col>
      </Row>
      <Notification loading={loading} success={success} message={message}/>
    </TabPane>
  )
}