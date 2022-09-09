import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";

import AppRoutes from "../AppRoutes";

export default function Footer() {
  return (
    <span className="footer">
      <section className='footer pt-5'>
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
                {AppRoutes.map((item, index) => (
                  <NavItem key={index}>
                    <NavLink className="footer" href={item.href}>
                      {item.name}
                    </NavLink>
                  </NavItem>
                ))}
              </Nav>
            </Col>

            <Col md="3" lg="2" xl="2" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Useful links</h6>
              <Nav vertical>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Pricing
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Settings
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Orders
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Help
                  </NavLink>
                </NavItem>
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