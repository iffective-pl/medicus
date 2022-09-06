import {Card, CardBody, CardSubtitle, CardTitle, Container} from "reactstrap";

import Services from '../../mocks/services.json';
import './HomeServices.css';

export default function HomeServices() {
  let services = Services.services;
  return (
    <Container>
      {services.map((item, index) => (
        <Card key={index} className="services shadow">
          <img
            alt={item.name}
            src={item.image}
          />
          <CardBody className="services">
            <CardTitle tag="h5">
              {item.name}
            </CardTitle>
            <CardSubtitle
              className="mb-2 text-muted"
              tag="h6"
            >
              {item.name}
            </CardSubtitle>
          </CardBody>
        </Card>
      ))}
    </Container>
  )
}