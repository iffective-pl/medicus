import {Button, Col, Input, InputGroup, Row} from "reactstrap";
import {useEffect, useState} from "react";

let p = {
  id: 0,
  title: "",
  value: "",
  specId: 0
}

export default function TabSpecPrice(props) {
  let [price, setPrice] = useState(p);
  let [modified, setModified] = useState(false);

  let load = (id, token) => {
    if(id !== 0) {
      fetch("api/Spec/GetPrice?priceId=" + id, {
        headers: {
          "Authorization": "Bearer " + token
        }
      })
        .then(r => r.json())
        .then(j => setPrice(j))
    }
  }

  useEffect(() => load(props.id, props.token), [props.id, props.token])

  let onChange = (e) => {
    setModified(true);
    let pr = price;
    pr[e.target.name] = e.target.value;
    setPrice(pr);
  }

  return (
    <Row className="mb-3">
      <Col>
        <InputGroup>
          <Button color="danger">Usuń</Button>
          <Input
            name="title"
            type="text"
            onChange={onChange}
            defaultValue={price?.title}
          />
          <Input
            name="value"
            type="text"
            onChange={onChange}
            defaultValue={price?.value}
          />
          <Button color="info" disabled={!modified}>Zapisz</Button>
        </InputGroup>
      </Col>
    </Row>
  )
}