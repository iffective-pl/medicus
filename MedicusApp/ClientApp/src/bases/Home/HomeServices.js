import {Button, Card, CardBody, CardSubtitle, CardText, CardTitle, Container} from "reactstrap";

import Services from '../../mocks/services.json';

export default function HomeServices() {
  let services = Services.services;
  return (
    <Container>
      {services.map((item, index) => (
        <Card
        >
          <img
            alt={item.name}
            src={item.image}
          />
          <CardBody>
            <CardTitle tag="h5">
              Card title
            </CardTitle>
            <CardSubtitle
              className="mb-2 text-muted"
              tag="h6"
            >
              Card subtitle
            </CardSubtitle>
            <CardText>
              Some quick example text to build on the card title and make up the bulk of the card‘s content.
            </CardText>
            <Button>
              Button
            </Button>
          </CardBody>
        </Card>
      ))}
    </Container>
  )
}