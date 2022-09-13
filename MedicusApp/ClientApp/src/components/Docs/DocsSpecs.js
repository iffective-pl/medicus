import {Container} from "reactstrap";
import {useEffect, useState} from "react";

import './DocsSpecs.css';
import Line from "../Line";

export default function DocsSpecs() {
  let [specs, setSpecs] = useState([]);

  useEffect(() => {
    fetch("/api/Specs")
      .then(r => r.json())
      .then(j => setSpecs(j));
  });

  return(
    <Container fluid="sm" className="text-center pt-5 pb-5">
      <h2 className="title m-3">Nasi lekarze specjalizują się w</h2>
      <Line center />
      {specs.map((item, index) => (
        <a href={"docs/" + item.href} key={index}>
          <div className="d-inline-block spec m-2 p-3 shadow">
            <div className="spec-icon-container">
              <i className={item.className + " spec-icon"}/>
            </div>
            <div className="mt-3">
              <div className="h4 flex-row title">{item.name}</div>
            </div>
          </div>
        </a>
      ))}
    </Container>
  )
}