import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Row,
  TabPane
} from "reactstrap";
import {useEffect, useState} from "react";
import TabAdvantage from "./TabAdvantage";
import TabCarousel from "./TabCarousel";
import AddCarouselButton from "../../operations/AddCarouselButton";
import TabService from "./TabService";
import AddServiceButton from "../../operations/AddServiceButton";

let defaultM = {
  id: 0,
  carousels: [],
  services: [],
  advantages: []
}

export default function TabMain(props) {
  let [main, setMain] = useState(defaultM)

  let load = () => {
    fetch("api/MP/GetMainPage")
      .then(r => r.json())
      .then(j => setMain(j))
  }

  useEffect(() => {
    load()
  }, [props.keycloak.token])

  return (
    <TabPane tabId={props.index.toString()} className="pt-3 pb-3">
      <Row className="mb-3">
        <Col>
          <Card>
            <CardHeader>
              <Row>
                <Col>
                  <div className="d-table height-top">
                    <div className="d-table-cell vertical-center">
                      Karuzela
                    </div>
                  </div>
                </Col>
                <Col>
                  <AddCarouselButton token={props.keycloak.token} load={load}/>
                </Col>
              </Row>
            </CardHeader>
            <CardBody>
              {main.carousels.map((item, key) => (
                <TabCarousel carousel={item} key={key} index={key} token={props.keycloak.token} update={load}/>
              ))}
            </CardBody>
          </Card>
        </Col>
      </Row>
      <Row className="mb-3">
        <Col>
          <Card>
            <CardHeader>
              <Row>
                <Col>
                  <div className="d-table height-top">
                    <div className="d-table-cell vertical-center">
                      Usługi
                    </div>
                  </div>
                </Col>
                <Col>
                  <AddServiceButton token={props.keycloak.token} load={load}/>
                </Col>
              </Row>
            </CardHeader>
            <CardBody className="text-center">
              {main.services.map((item, key) => (
                <TabService service={item} key={key} token={props.keycloak.token} update={load}/>
              ))}
            </CardBody>
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