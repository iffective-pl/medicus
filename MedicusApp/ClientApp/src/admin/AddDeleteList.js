import {useState} from "react";
import {Button, Card, CardBody, CardHeader, Collapse, Input, InputGroup} from "reactstrap";

import './AddDeleteList.css';

export default function AddDeleteList(props) {
  let [open, setOpen] = useState(false);

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
    <Card className="mb-3">
      <CardHeader onClick={() => setOpen(!open)}>
        <div className="d-inline-block">
            {title()}
        </div>
        <div className="d-inline-block add-delete-list">
          <i className="icon menu add-delete-list"/>
        </div>
      </CardHeader>
      <Collapse isOpen={open}>
        <CardBody>
          {props.elements.map((item, index) => (
            <InputGroup key={index} className="p-2">
              <Input value={item}/>
              <Button color="danger">
                Usuń
              </Button>
            </InputGroup>
          ))}
          <Button className="m-2" color="success">Dodaj</Button>
        </CardBody>
      </Collapse>
    </Card>
  )
}