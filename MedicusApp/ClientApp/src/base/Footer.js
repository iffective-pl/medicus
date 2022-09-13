import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";

import {useEffect, useState} from "react";

import './Footer.css';

export default function Footer() {
  let [links, setLinks] = useState([]);
  let [specs, setSpecs] = useState([]);
  useEffect(() => {
    fetch("/api/Links")
      .then(r => r.json())
      .then(j => setLinks(j))
    fetch("/api/Specs")
      .then(r => r.json())
      .then(j => setSpecs(j))
  }, []);

  return (
    <span className="footer">
      <section className='footer p-5'>
        <Container className='text-center text-md-start'>
          <Row>
            <Col md="3" lg="4" xl="3" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>
                Poradnia Specjalistyczna MEDICUS
              </h6>
              <p>
                Opis
              </p>
            </Col>

            <Col md="2" lg="2" xl="2" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Mapa strony</h6>
              <Nav vertical>
                {links.map((item, index) => (
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
                {specs.map((item, index) => (
                  <NavItem key={index}>
                    <NavLink className="footer" href={"docs/" + item.href}>
                      {item.name}
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
                        <div>Plac Wolności 15</div>
                        <div>87-800 Włocławek</div>
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
                    <div><NavLink className="footer" href="#">biuro@medicus.włocławek.pl</NavLink></div>
                    <div><NavLink className="footer" href="#">rejestracja@medicus.włocławek.pl</NavLink></div>
                  </div>
                </NavItem>
                <NavItem>
                  <div className="footer-container">
                    <div className="footer-icon-container">
                      <div className="footer-icon">
                        <i className="bi bi-telephone" />
                      </div>
                    </div>
                    <div><NavLink className="footer" href="#">54 2313741</NavLink></div>
                    <div><NavLink className="footer" href="#">54 2313141</NavLink></div>
                    <div className="footer-icon-single">
                      <div className="footer-icon">
                        <i className="bi bi-phone" />
                      </div>
                    </div>
                    <div>
                      <NavLink className="footer" href="#">692 184 214</NavLink>
                    </div>
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
            <NavLink className="footer-secondary" href="/">
              Copyright © 2022 - MEDICUS
            </NavLink>
          </NavItem>
        </Nav>
      </section>
    </span>
  );
}