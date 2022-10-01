import {
  Card,
  CardBody,
  CardFooter,
  Col,
  Row
} from "reactstrap";
import {useEffect, useState} from "react";
import DelDescButton from "../../operations/DelDescButton";
import EditDescButton from "../../operations/EditDescButton";
import Description from "../../../components/Description";

let des = {
  id: undefined,
  image: "",
  descriptionTexts: []
}

export default function TabSpecDesc(props) {
  let [desc, setDesc] = useState(des);

  useEffect(() => {
    setDesc(props.desc);
  }, [props.desc])

  return (
    <Card className="mb-3">
      <CardBody className="p-0">
        <Description description={desc} isEven={props.isEven}/>
      </CardBody>
      <CardFooter>
        <Row>
          <Col>
            <DelDescButton token={props.token} load={props.update} desc={desc.id}/>
          </Col>
          <Col>
            <EditDescButton desc={desc} token={props.token} update={props.update}/>
          </Col>
        </Row>
      </CardFooter>
    </Card>
  )
}