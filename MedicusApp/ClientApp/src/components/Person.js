import {Button, Card, Col, Grid, Popover, Table, Text} from "@nextui-org/react";
import {FaRegClock} from "react-icons/fa";
import "./Person.css";

export default function Person(props) {
  let showHours = (person) => {
    if(person.hours) {
        return (
            <Grid xs={4} justify="flex-end">
                <Popover placement="top">
                    <Popover.Trigger>
                        <Button auto flat icon={<FaRegClock/>}></Button>
                    </Popover.Trigger>
                    <Popover.Content>
                        <Table>
                        <Table.Header>
                            <Table.Column>Dzień</Table.Column>
                            <Table.Column>Godziny</Table.Column>
                        </Table.Header>
                        <Table.Body>
                            {person.hours.map((item, index) => (
                            <Table.Row key={index}>
                                <Table.Cell>{keyToString(item.day)}</Table.Cell>
                                <Table.Cell>{item.hours}</Table.Cell>
                            </Table.Row>
                            ))}
                        </Table.Body>
                        </Table>
                    </Popover.Content>
                </Popover>
            </Grid>
        );
   } else {
     return <></>;
   }
  }

  let keyToString = (key) => {
    switch(key) {
      case "monday":
        return "Poniedziałek";
      case "tuesday":
        return "Wtorek";
      case "wednesday":
        return "Środa";
      case "thursday":
        return "Czwartek";
      case "friday":
        return "Piątek";
      case "saturday":
        return "Sobota";
      case "sunday":
        return "Niedziela";
      default:
    }
  }

  return (
    <Card css={{ "max-width": "33rem", "text-align": "left" }} className="no-padding">
      <Card.Header css={{ position: "absolute", zIndex: 1, top: 5 }}>
        <Col>
          <Text size={15} weight="bold" transform="uppercase" color="#f2f2f2">
            {props.person.unit.name}
          </Text>
          <Text size={17} b color="white">
            {props.person.unit.title}
          </Text>
        </Col>
      </Card.Header>
          <Card.Body css={{ p: 0 }} className="no-padding">
        <Card.Image
          src={props.person.img}
          objectFit="cover"
          width="100%"
          height="100%"
          alt="Person"
        />
      </Card.Body>
      <Card.Footer
        isBlurred
        css={{
          position: "absolute",
          bgBlur: "#0f111466",
          borderTop: "$borderWeights$light solid $gray800",
          bottom: 0,
          zIndex: 1,
        }}
      >
        <Grid.Container>
          <Grid xs={8}>
            <Text size={20} b color="white">{props.person.title} {props.person.name}</Text>
          </Grid>
          {showHours(props.person)}
        </Grid.Container>
      </Card.Footer>
    </Card>
  );
}