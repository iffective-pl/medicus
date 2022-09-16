import {
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

let comp = {
  id: undefined,
  name: "",
  address: "",
  code: "",
  city: "",
  emails: [],
  phones: [],
  mobilePhones: []
}

export default function TabCompany(props) {
  let [company, setCompany] = useState(comp);

  useEffect(() => {
    fetch("api/Company", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setCompany(j))
  }
  , [props.keycloak.token]);

  return (
    <TabPane tabId="1" className="p-5">
      <Form>
        <Row>
          <Col>
            <FormGroup floating>
              <Input
                bsSize="lg"
                id="name"
                name="Name"
                type="text"
                value={company.name}
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
                value={company.address}
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
                value={company.code}
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
                value={company.city}
              />
              <Label for="name">
                Miasto
              </Label>
            </FormGroup>
          </Col>
        </Row>
        <Row>
          <Col>
            <AddDeleteList elements={company.phones} type="phone"/>
          </Col>
          <Col>
            <AddDeleteList elements={company.mobilePhones} type="mobile"/>
          </Col>
          <Col>
            <AddDeleteList elements={company.emails} type="email"/>
          </Col>
        </Row>
      </Form>
    </TabPane>
  )
}