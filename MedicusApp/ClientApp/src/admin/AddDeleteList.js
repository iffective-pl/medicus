import {useEffect, useState} from "react";
import {
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button,
  Col,
  Input,
  InputGroup, Row,
  UncontrolledAccordion
} from "reactstrap";

import './AddDeleteList.css';

export default function AddDeleteList(props) {
  let [elements, setElements] = useState([]);

  useEffect(() => {
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

  return (
    <UncontrolledAccordion className="mb-3">
      <AccordionItem>
        <AccordionHeader targetId="1">
          {title()}
        </AccordionHeader>
        <AccordionBody accordionId="1">
          {elements.map((item, index) => (
            <Row key={index}>
              <Col>
                <InputGroup key={index} className="p-2">
                  <Input defaultValue={props.type === "email" ? item.address : item.number}/>
                  <Button color="danger">
                    Usuń
                  </Button>
                </InputGroup>
              </Col>
            </Row>
          ))}
          <Row>
            <Col>
              <Button className="m-2" color="success">Dodaj</Button>
            </Col>
          </Row>
        </AccordionBody>
      </AccordionItem>
    </UncontrolledAccordion>
  )
}