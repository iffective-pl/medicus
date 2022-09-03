import './Header.css'
import {Card, Container, Spacer} from "@nextui-org/react";

import Header from "./Header";
import "./Base.css";

export default function Base(props) {

  return (
    <>
      <Header/>
      <Spacer y={1} />
      <Container>
        <Card>
          {props.children}
        </Card>
      </Container>
    </>
  );
}