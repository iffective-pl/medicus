import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Row
} from "reactstrap";
import AddDescButton from "../../operations/AddDescButton";
import TabSpecDesc from "./TabSpecDesc";

export default function TabSpecDescs(props) {
  return (
    <Row className="mt-3">
      <Col>
        <Card>
          <CardHeader>
            <Row>
              <Col className="d-table">
                <div className="vertical-center d-table-cell">
                  Sekcje opisów
                </div>
              </Col>
              <Col>
                <AddDescButton id={props.spec.id} token={props.token} load={props.load}/>
              </Col>
            </Row>
          </CardHeader>
          <CardBody className="p-3">
            {props.spec.descriptions.map((item, key) => (
              <TabSpecDesc desc={item} key={key} token={props.token} update={props.load} isEven={key%2===0}/>
            ))}
          </CardBody>
        </Card>
      </Col>
    </Row>
  )
}