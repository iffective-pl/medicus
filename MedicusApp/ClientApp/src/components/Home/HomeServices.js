import {Card, CardBody, CardImg, CardImgOverlay, CardSubtitle, CardTitle, Container} from "reactstrap";

import './HomeServices.css';
import Line from "../Line";
import Config from "../../config/Config";

export default function HomeServices(props) {
  return (
    <Container fluid className="p-5 mt-3">
      <span className="h2 text-center d-block title">Nasze usługi</span>
      <Line center />
      <div className="text-center pm-4 cont-services">
        {props.services.map((item, index) => (
          <a href={item.href} className="text-reset">
            <Card key={index} className="services shadow m-2 d-inline-block">
              <CardImg
                alt={item.name}
                src={Config.minio + item.source}
              />
              <CardImgOverlay className="p-0">
                <CardBody className="services p-5">
                  <CardTitle tag="h5">
                    {item.name}
                  </CardTitle>
                  <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                  >
                    {item.description}
                  </CardSubtitle>
                </CardBody>
              </CardImgOverlay>
            </Card>
          </a>
        ))}
      </div>
    </Container>
  )
}