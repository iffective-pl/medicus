import {Card, Collapse, Grid, Spacer, Text} from "@nextui-org/react";

import "./Docs.css"
import Person from "../components/Person";
import docs from '../mocks/docs.json';

export default function Docs() {
  return (
    <>
      <Card.Header className="card-h">
        <Text h2>Nasi Lekarze</Text>
      </Card.Header>
      <Card.Body className="card-b">
        <Grid.Container>
            <Grid justify="center" xs={12}>
                <Person person={docs.director} />
            </Grid>
        </Grid.Container>
        <Spacer y={1} />
        <Collapse.Group splitted className="no-padding">
        {docs.units.map((item, index) => (
            <Collapse title={item.index + " " + item.name} key={index} className="no-padding">
            <Grid.Container gap={2}>
                {item.doctors.map((item, key) => (
                <Grid key={key}>
                    <Person person={item}/>
                </Grid>
                ))}
            </Grid.Container>
            </Collapse>
        ))}
        </Collapse.Group>
      </Card.Body>
    </>
  );
}