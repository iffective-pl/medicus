import {Card, CardBody, CardImg, CardImgOverlay, CardSubtitle, CardTitle, Container} from "reactstrap";

import Services from '../../data/services.json';
import './HomeServices.css';

export default function HomeServices() {
  let services = Services.services;
  return (
    <Container className="p-4">
      <span className="h2 text-center d-block pb-4">Nasze usługi</span>
      <div className="text-center">
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