import Line from "../components/Line";
import {isMobile} from "react-device-detect";
import {Container, NavLink} from "reactstrap";

import './Register.css';
import {useEffect, useState} from "react";

let company = {
  emails: [],
  phones: [],
  mobilePhones: []
}

export default function Register() {
  let [comp, setComp] = useState(company);

  useEffect(() => {
    fetch("api/Company/GetFullCompany")
      .then(r => r.json())
      .then(j => setComp(j))
  }, [])

  return (
    <Container className="title text-center">
      <h2>Rejestracja</h2>
      <Line center />
      <div className={"main-container-reg " + (isMobile ? "small" : "normal")}>
        <div className="pb-4">
          <div>
            <i className="phone icon"/>
          </div>
          <div>
            {comp.phones.map((item, index) => <div key={index}><NavLink href={"tel:" + item.number}>{item.number}</NavLink></div>)}
          </div>
        </div>
        <div className="table-cont">
          <div className="table-text h5 text-start">
            Rejestracja w Przychodni Medicus otwarta jest od poniedziałku do piątku w godzinach od 13:00 do 17:00
          </div>
        </div>
        <div className="pb-4">
          <div>
            <i className="mobile icon"/>
          </div>
          <div>
            {comp.mobilePhones.map((item, index) => <div key={index}><NavLink href={"tel:" + item.number}>{item.number}</NavLink></div>)}
          </div>
        </div>
        <div className="table-cont">
          <div className="table-text h5 text-start">
            Rejestracja telefoniczna codziennie od 8:00 do 19:00
          </div>
        </div>
        <div className="pb-4">
          <div>
            <i className="message icon"/>
          </div>
          <div>
            {comp.emails.map((item, index) => <div key={index}><NavLink href={"mailto:" + item}>{item.address}</NavLink></div>)}
          </div>
        </div>
        <div/>
        <div className="pb-4">
          <div>
            <i className="location icon"/>
          </div>
          <div>
            <div>{comp.address}</div>
            <div>{comp.code} {comp.city}</div>
          </div>
        </div>
      </div>
    </Container>
  );
}