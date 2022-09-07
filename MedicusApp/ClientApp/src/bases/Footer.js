import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";
import {BsEnvelope, BsPinMap, BsTelephone} from "react-icons/bs";

import AppRoutes from "../AppRoutes";

export default function Footer() {
  return (
    <>
      <section className='d-flex p-4 footer border-bottom'>
      </section>

      <section className='footer pt-4'>
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
                    <div className="d-inline-block">
                      <BsPinMap className="me-3"/>
                    </div>
                    <div className="d-inline-block">
                      <div>Plac Wolności 15</div>
                      <div>87-800 Włocławek</div>
                    </div>
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <BsEnvelope className="me-3" />
                    info@example.com
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <div className="me-3 d-inline-block">
                      <BsTelephone />
                    </div>
                    <div className="d-inline-block">
                      54 2313141<br/>
                      54 2313741<br/>
                      692 184 214
                    </div>
                  </NavLink>
                </NavItem>
              </Nav>
            </Col>
          </Row>
        </Container>
      </section>

      <div className='text-center footer-secondary p-3'>
        <Nav justified>
          <NavItem>
            <NavLink className="footer-secondary" href="/">
              Copyright © 2022 - MEDICUS
            </NavLink>
          </NavItem>
        </Nav>
      </div>
    </>
  );
}