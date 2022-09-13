import {Card, CardBody, CardImg, CardImgOverlay, CardSubtitle, CardTitle, Container} from "reactstrap";

import Services from '../../data/services.json';
import './HomeServices.css';
import Line from "../Line";

export default function HomeServices() {
  let services = Services.services;
  return (
    <Container fluid className="p-4">
      <span className="h2 text-center d-block title">Nasze usługi</span>
      <Line center />
      <div className="text-center pb-4">
        {services.map((item, index) => (
          <Card key={index} className="services shadow m-2 d-inline-block">
            <CardImg
              alt={item.name}
              src={item.image}
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
        ))}
      </div>
    </Container>
  )
}