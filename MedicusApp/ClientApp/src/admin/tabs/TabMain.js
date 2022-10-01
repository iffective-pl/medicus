import {Card, CardBody, CardHeader, Col, Row, TabPane} from "reactstrap";

export default function TabMain(props) {
  return (
    <TabPane tabId={props.index.toString()} className="pt-3 pb-3">
      <Row className="mb-3">
        <Col>
          <Card>
            <CardHeader>Karuzela</CardHeader>
          </Card>
        </Col>
      </Row>
      <Row className="mb-3">
        <Col>
          <CardHeader>Usługi</CardHeader>
        </Col>
      </Row>
      <Row className="mb-3">
        <Col>
          <CardHeader>Co nas wyróżnia?</CardHeader>
          <CardBody>

          </CardBody>
        </Col>
      </Row>
    </TabPane>
  )
}