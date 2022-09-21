import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";

import {useEffect, useState} from "react";

import './Footer.css';

let company = {
  emails: [],
  phones: [],
  mobilePhones: []
}

export default function Footer() {
  let [links, setLinks] = useState([]);
  let [headers, setHeaders] = useState([]);
  let [comp, setComp] = useState(company);
  useEffect(() => {
    fetch("/api/UI/GetLinks")
      .then(r => r.json())
      .then(j => setLinks(j))
    fetch("/api/UI/GetHeaders")
      .then(r => r.json())
      .then(j => setHeaders(j))
    fetch("/api/Company/GetFullCompany")
      .then(r => r.json())
      .then(j => setComp(j))
  }, []);

  return (
    <span className="footer">
      <section className='footer p-5'>
        <Container className='text-center text-md-start'>
          <Row>
            <Col md="3" lg="4" xl="3" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>
                {comp.name}
              </h6>
            </Col>

            <Col md="2" lg="2" xl="2" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Mapa strony</h6>
              <Nav vertical>
                {headers.map((item, index) => (
                  <NavItem key={index}>
                    <NavLink className="footer" href={item.href}>
                      {item.name}
                    </NavLink>
                  </NavItem>
                ))}
              </Nav>
            </Col>

            <Col md="3" lg="2" xl="2" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Lekarze specjaliści</h6>
              <Nav vertical>
                {links.map((item, index) => (
                  <NavItem key={index}>
                    <NavLink className="footer" href={"docs/" + item.href}>
                      {item.spec.name}
                    </NavLink>
                  </NavItem>
                ))}
              </Nav>
            </Col>

            <Col md="4" lg="3" xl="3" className='mx-auto mb-md-0 mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Kontakt</h6>
              <Nav vertical>
                <NavItem>
                    <div className="footer-container">
                    <div className="footer-icon-single">
                      <div className="footer-icon">
                        <i className="bi bi-geo-alt"/>
                      </div>
                    </div>
                    <div>
                      <NavLink className="footer" href="#">
                        <div>{comp.address}</div>
                        <div>{comp.code} {comp.city}</div>
                      </NavLink>
                    </div>
                  </div>
                </NavItem>
                <NavItem>
                  <div className="footer-container">
                    <div className="footer-icon-container">
                      <div className="footer-icon">
                        <i className="bi bi-envelope" />
                      </div>
                    </div>
                    {comp.emails.map((item, index) =>
                      <div key={index}><NavLink className="footer" href="#">{item.address}</NavLink></div>
                    )}
                  </div>
                </NavItem>
                <NavItem>
                  <div className="footer-container">
                    <div className="footer-icon-container">
                      <div className="footer-icon">
                        <i className="bi bi-telephone" />
                      </div>
                    </div>
                    {comp.phones.map((item, index) =>
                      <div key={index}><NavLink className="footer" href="#">{item.number}</NavLink></div>
                    )}
                    <div className="footer-icon-single">
                      <div className="footer-icon">
                        <i className="bi bi-phone" />
                      </div>
                    </div>
                    {comp.mobilePhones.map((item, index) =>
                      <div key={index}><NavLink className="footer" href="#">{item.number}</NavLink></div>
                    )}
                  </div>
                </NavItem>
              </Nav>
            </Col>
          </Row>
        </Container>
      </section>

      <section className='text-center p-3 border-top border-2 footer-secondary'>
        <Nav justified>
          <NavItem>
            <NavLink className="footer-secondary" href="admin">
              Copyright © 2022 - MEDICUS
            </NavLink>
          </NavItem>
        </Nav>
      </section>
    </span>
  );
}