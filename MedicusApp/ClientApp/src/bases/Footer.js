import {Col, Container, Nav, NavItem, NavLink, Row} from "reactstrap";
import {BsEnvelope, BsPinMap, BsPrinter, BsTelephone} from "react-icons/bs";

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
                Company name
              </h6>
              <p>
                Here you can use rows and columns to organize your footer content. Lorem ipsum dolor sit amet,
                consectetur adipisicing elit.
              </p>
            </Col>

            <Col md="2" lg="2" xl="2" className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-3'>Products</h6>
              <Nav vertical>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Angular
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    React
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Vue
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    Laravel
                  </NavLink>
                </NavItem>
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
              <h6 className='text-uppercase fw-bold mb-3'>Contact</h6>
              <Nav vertical>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <BsPinMap className="me-2"/>
                    New York, NY 10012, US
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
                    <BsTelephone className="me-3" /> + 01 234 567 88
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="footer" href="#">
                    <BsPrinter className="me-3" /> + 01 234 567 89
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