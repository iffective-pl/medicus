import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";

import {useEffect, useState} from "react";

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
                  <NavLink className="footer position-relative" href="#">
                    <Row>
                      <Col xs="1">
                        <i className="bi bi-geo-alt"/>
                      </Col>
                      <Col>
                        <div>Plac Wolności 15</div>
                        <div>87-800 Włocławek</div>
                      </Col>
                    </Row>
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <Row>
                      <Col xs="1">
                        <i className="bi bi-envelope" />
                      </Col>
                      <Col>
                        info@example.com
                      </Col>
                    </Row>
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <Row>
                      <Col xs="1">
                        <i className="bi bi-telephone" />
                      </Col>
                      <Col>
                        54 2313141
                      </Col>
                    </Row>
                  </NavLink>
                  <NavLink className="footer" href="#">
                    <Row>
                      <Col xs="1">
                      </Col>
                      <Col>
                        54 2313741
                      </Col>
                    </Row>
                  </NavLink>
                  <NavLink className="footer" href="#">
                    <Row>
                      <Col xs="1">
                        <i className="bi bi-phone" />
                      </Col>
                      <Col>
                        692 184 214
                      </Col>
                    </Row>
                  </NavLink>
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