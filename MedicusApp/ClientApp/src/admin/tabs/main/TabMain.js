import {Card, CardBody, CardHeader, Col, Row, TabPane} from "reactstrap";
import {useEffect, useState} from "react";
import TabAdvantage from "./TabAdvantage";

let defaultM = {
  id: 0,
  advantages: []
}

export default function TabMain(props) {
  let [main, setMain] = useState(defaultM)

  useEffect(() => {
    fetch("api/MP/GetMainPage")
      .then(r => r.json())
      .then(j => setMain(j))
  }, [props.keycloak.token])

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
          <Card>
            <CardHeader>Usługi</CardHeader>
          </Card>
        </Col>
      </Row>
      <Row className="mb-3">
        <Col>
          <Card>
            <CardHeader>Co nas wyróżnia?</CardHeader>
            <CardBody>
              {main.advantages.sort((a, b) => a.id > b.id ? 1 : -1).map((item, index) => (
                <TabAdvantage adv={item} token={props.keycloak.token} key={index}/>
              ))}
            </CardBody>
          </Card>
        </Col>
      </Row>
    </TabPane>
  )
}