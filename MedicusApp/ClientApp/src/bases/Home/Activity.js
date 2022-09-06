import {useState} from "react";
import {Button, Offcanvas, OffcanvasBody, OffcanvasHeader} from "reactstrap";

import './Activity.css';

export default function Activity() {
  let [open, setOpen] = useState(false);

  let toggle = () => setOpen(!open);

  return (
    <>
      <Button
        color="info"
        onClick={toggle}
        className="activity"
      >
        Aktualności
      </Button>
      <Offcanvas direction="end" isOpen={open} toggle={toggle}>
        <OffcanvasHeader toggle={toggle}>
          Aktualności
        </OffcanvasHeader>
        <OffcanvasBody>
          <strong>
            To jest miejsce na potencjalne aktualności
          </strong>
        </OffcanvasBody>
      </Offcanvas></>
  )
}