import {Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalHeader, Row} from "reactstrap";
import Notification from "../../components/Notification";
import {useEffect, useState} from "react";

export default function EditHeadersButton(props) {
  let [header, setHeader] = useState();
  let [statics, setStatics] = useState([]);
  let [open, setOpen] = useState(false);
  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let toggle = () => setOpen(!open);

  useEffect(() => {
    if(props.headers && props.headers.length > 0) {
      setHeader(props.headers[0])
    }
    loadStatics()
  }, [props.headers])

  let loadStatics = () => {
    fetch("api/Static/GetStaticDropdown", {
        headers: {
          "Authorization": "Bearer " + props.token,
        }
      })
      .then(r => r.json())
      .then(j => setStatics(j))
  }

  let onSubmit = () => {
    setOpen(false)
    setLoading(true)
    setMessage("Aktualizacja nagłówka...")
    fetch("api/UI/UpdateHeader", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(header)
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
        props.load()
      })
  }

  let onDelete = () => {
    setOpen(false)
    setLoading(true)
    setMessage("Usuwanie nagłówka...")
    fetch("api/UI/DeleteHeader?headerId=" + header.id, {
      method: "DELETE",
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Usunięto nagłówek")
        } else {
          setMessage("Nie udało się usunąć nagłówka")
        }
        props.load()
        props.forceUpdate()
      })
  }

  let onChangeHeader = (e) => {
    setHeader(props.headers.find(q => q.id === parseInt(e.target.value)))
  }

  let onChangeText = (e) => {
    let change = {};
    change[e.target.name] = e.target.value;
    setHeader(h => ({
      ...h,
      ...change
    }));
  }

  let onChangeCheckbox = (e) => {
    let change = {};
    change[e.target.name] = e.target.checked;
    setHeader(h => ({
      ...h,
      ...change
    }));
  }

  return (
    <>
      <Button className="float-end me-3" color="info" onClick={toggle} disabled={loading}>Edytuj nagłówki</Button>
      <Modal isOpen={open} toggle={toggle}>
        <ModalHeader toggle={toggle}>Nagłówek</ModalHeader>
        <Form>
          <ModalBody>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="header">
                    Nagłówek
                  </Label>
                  <Input
                    id="header"
                    name="header"
                    type="select"
                    onChange={onChangeHeader}
                    disabled={props.headers.length < 1}
                  >
                    {props.headers.map((item, key) => (
                      <option value={item.id} key={key}>
                        {item.name}
                      </option>
                    ))}
                  </Input>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup floating>
                  <Input
                    bsSize="lg"
                    id="name"
                    name="name"
                    type="text"
                    onChange={onChangeText}
                    defaultValue={header?.name}
                  />
                  <Label for="name">
                    Nazwa nagłówka
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="href">
                    Przekierowanie na statyczną stronę
                  </Label>
                  <Input
                    id="href"
                    name="href"
                    type="select"
                    defaultValue={header?.href}
                    onChange={onChangeText}
                    disabled={header?.isDropdown || statics.length < 1}
                  >
                    {statics.map((item, key) => (
                      <option value={"static/" + item.id} key={key}>
                        {item.name}
                      </option>
                    ))}
                  </Input>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col>
                <FormGroup check>
                  <Input
                    className="me-2"
                    name="isDropdown"
                    type="checkbox"
                    onChange={onChangeCheckbox}
                    checked={header?.isDropdown}
                  />
                  <Label check>
                    Czy może się rozwijać?
                  </Label>
                </FormGroup>
              </Col>
              <Col>
                <FormGroup check>
                  <Input
                    className="me-2"
                    name="isHidden"
                    type="checkbox"
                    onChange={onChangeCheckbox}
                    checked={!header?.isHidden}
                  />
                  <Label check>
                    Czy może wyświetlać się w nagłówku?
                  </Label>
                </FormGroup>
              </Col>
            </Row>
            <Row className="mt-3">
              <Col>
                <Button color="danger" className="float-start" onClick={onDelete} disabled={loading}>
                  Usuń
                </Button>
              </Col>
              <Col>
                <Button color="info" className="float-end" onClick={onSubmit} disabled={loading}>
                  Zapisz
                </Button>
              </Col>
            </Row>
          </ModalBody>
        </Form>
      </Modal>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}