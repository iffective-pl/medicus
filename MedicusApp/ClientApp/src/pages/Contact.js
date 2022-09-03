import {Card, Grid, Text} from "@nextui-org/react";
import logo from "../images/logo-oryg-medicus-cropped.png";
import "./Contact.css";
import {FaPhone} from "react-icons/fa";

export default function Contact() {
  return (
    <>
      <Card.Header className="card-h">
        <Text h2>Kontakt</Text>
      </Card.Header>
      <Card.Body className="card-b">
        <Grid.Container gap={2}>
          <Grid xs={5}>
            <Text>
              <Text h2>Przychodnia Specjalistyczna MEDICUS</Text>
              <Text h3>Rok założenia 1990</Text>
            </Text>
          </Grid>
          <Grid xs={7}/>
          <Grid>
            <img
              src={logo}
              alt="logo"
              className="logo"
            />
          </Grid>
          <Grid>
            <Text h4 className="address">Plac Wolności 15</Text>
            <Text h4 className="address">87-800 Włocławek</Text>
            <Text h4>
              <FaPhone className="phone" />
              <a className="phone-content" href="tel:+48542313141">54 2313141</a>
            </Text>
          </Grid>
        </Grid.Container>
      </Card.Body>
    </>
  )
}