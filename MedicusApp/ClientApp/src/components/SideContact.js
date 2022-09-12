import Line from "./Line";
import {Col, Container, Row} from "reactstrap";

export default function SideContact(props) {
  return (
    <Container className="title">
      <h2 className="text-center">{props.title}</h2>
      <Line center />
      <Row>
        <Col xs="4" className="text-center">
          <div className="p-3">
            <div>
              <i className="location icon"/>
            </div>
            <div>
              <div>Plac Wolności 15</div>
              <div>87-800 Włocławek</div>
            </div>
          </div>
          <div className="p-3">
            <div>
              <i className="message icon"/>
            </div>
            <div>
              <div>biuro@medicus.wloclawek.pl</div>
              <div>rejestracja@medicus.wloclawek.pl</div>
            </div>
          </div>
          <div className="p-3">
            <div>
              <i className="phone icon"/>
            </div>
            <div>
              <div>54 2313141</div>
              <div>54 2313741</div>
            </div>
          </div>
          <div className="p-3">
            <div>
              <i className="mobile icon"/>
            </div>
            <div>
              <div>692 184 214</div>
            </div>
          </div>
        </Col>
        <Col xs="8">
          {props.children}
        </Col>
      </Row>
    </Container>
  )
}