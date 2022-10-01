import {Button, Col, Form, FormGroup, Input, InputGroup, Row} from "reactstrap";
import {useEffect, useState} from "react";
import DelPriceButton from "../../operations/DelPriceButton";
import Notification from "../../../components/Notification";

let p = {
  id: 0,
  title: "",
  value: "",
  specId: 0
}

export default function TabSpecPrice(props) {
  let [price, setPrice] = useState(p);
  let [modified, setModified] = useState(false);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

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

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Aktualizacja usługi...")
    e.preventDefault();

    let data = {
      id: props.id,
      title: e.target.title.value,
      value: e.target.value.value
    }

    fetch("api/Spec/UpdatePrice", {
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
          setMessage("Usługa została zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować usługi")
        }
        props.load()
      })
  }

  return (
    <>
      <Row className="mb-3">
        <Col>
          <Form onSubmit={onSubmit}>
            <InputGroup>
              <DelPriceButton token={props.token} id={props.id} name={price.title} load={props.load} />
              <Input
                name="title"
                type="text"
                onChange={onChange}
                defaultValue={price.title}
              />
              <Input
                name="value"
                type="text"
                onChange={onChange}
                defaultValue={price.value}
              />
              <Button color="info" disabled={!modified} type="submit">Zapisz</Button>
            </InputGroup>
          </Form>
        </Col>
      </Row>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}