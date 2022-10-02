import {
  Button,
  Card,
  CardBody, CardFooter,
  CardHeader, Col,
  FormGroup,
  Input, Label,
  Modal,
  ModalBody, ModalFooter,
  ModalHeader, Row
} from "reactstrap";
import {useEffect, useState} from "react";
import Notification from "../../components/Notification";
import ImageSelector from "../../components/ImageSelector";
import 'react-draft-wysiwyg/dist/react-draft-wysiwyg.css';
import TextEditor from "../../components/TextEditor";

let descDef = {
  id: undefined,
  image: "",
  descriptionTexts: []
}

export default function EditDescButton(props) {
  let [desc, setDesc] = useState(descDef);
  let [open, setOpen] = useState(false);

  let toggleEdit = () => setOpen(!open);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let [update, setUpdate] = useState(undefined);

  useEffect(() => setDesc(props.desc), [props.desc])

  let onSubmit = (e) => {
    setUpdate(!update);
    setOpen(false);
    setLoading(true);
    setMessage("Aktualizacja sekcji opisu...");
    e.preventDefault();

    fetch("api/Desc", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(desc)
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true")
        if(t === "true") {
          setMessage("Aktualizacja powiodła się")
        } else {
          setMessage("Aktualizacja nie powiodła się")
        }
        props.update()
      })
  }

  let onImageChange = (v) => {
    setDesc({
      id: desc.id,
      image: v,
      descriptionTexts: desc.descriptionTexts
    });
  }

  let onAdd = () => {
    let l = desc.descriptionTexts;
    l.push({
      title: "",
      text: ""
    });
    setDesc({
      id: desc.id,
      image: desc.image,
      descriptionTexts: l
    });
  }

  let onChange = (e, i) => {
    let l = desc.descriptionTexts;
    l[i][e.target.name] = e.target.value;
    setDesc({
      id: desc.id,
      image: desc.image,
      descriptionTexts: l
    });
  }

  let onDelete = (i) => {
    let l = desc.descriptionTexts;
    l.splice(i);
    setDesc({
      id: desc.id,
      image: desc.image,
      descriptionTexts: l
    });
  }

  return (
    <>
      <Button className="float-end" color="info" onClick={toggleEdit}>Edytuj</Button>
      <Modal isOpen={open} toggle={toggleEdit} size="xl">
        <ModalHeader toggle={toggleEdit}>Sekcja Opisu</ModalHeader>
        <ModalBody>
          <ImageSelector token={props.token} image={desc.image} setImage={onImageChange}/>
          <Card className="mt-3">
            <CardHeader>
              <Row>
                <Col className="d-table">
                  <div className="d-table-cell vertical-center">
                    Podsekcje opisu
                  </div>
                </Col>
                <Col>
                  <Button className="float-end" color="success" onClick={onAdd}>Dodaj</Button>
                </Col>
              </Row>
            </CardHeader>
            <CardBody className="pb-0">
              {desc.descriptionTexts.map((item, index) =>
                <Card key={index} className="mb-3">
                  <CardHeader className="pb-0">
                    <FormGroup floating>
                      <Input
                        bsSize="lg"
                        id="title"
                        name="title"
                        type="text"
                        defaultValue={item.title}
                        onChange={(e) => onChange(e, index)}
                      />
                      <Label for="title">
                        Tytuł
                      </Label>
                    </FormGroup>
                  </CardHeader>
                  <CardBody className="pb-0">
                    <TextEditor dt={item} onChange={(e) => onChange(e, index)} update={update}/>
                  </CardBody>
                  <CardFooter>
                    <Row>
                      <Col>
                        <Button color="danger" onClick={() => onDelete(index)}>
                          Usuń
                        </Button>
                      </Col>
                    </Row>
                  </CardFooter>
                </Card>
              )}
            </CardBody>
          </Card>
        </ModalBody>
        <ModalFooter>
          <Row>
            <Col>
              <Button color="primary" onClick={onSubmit} disabled={loading}>
                Zapisz
              </Button>
            </Col>
            <Col>
              <Button color="secondary" onClick={toggleEdit} disabled={loading}>
                Anuluj
              </Button>
            </Col>
          </Row>
        </ModalFooter>
      </Modal>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}