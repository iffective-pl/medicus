import {isMobile} from "react-device-detect";
import {
  Card,
  CardBody,
  CardFooter,
  Col,
  Row
} from "reactstrap";
import {useEffect, useState} from "react";
import DelDescButton from "../DelDescButton";
import EditDescButton from "../EditDescButton";

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
        <div className={"no-gap desc-row " + (isMobile ? "rows" : "columns")}>
          <div className="desc-image shadow-lg">
            <img src={desc.image} className="desc-image" alt="desc"/>
          </div>
          <div className="ps-3">
            {desc.descriptionTexts.map((item, index) =>
              <div key={index} className="pt-2">
                <h4>{item.title}</h4>
                <span>{item.text}</span>
              </div>
            )}
          </div>
        </div>
      </CardBody>
      <CardFooter>
        <Row>
          <Col>
            <DelDescButton token={props.token} load={props.update}/>
          </Col>
          <Col>
            <EditDescButton desc={desc} token={props.token} update={props.update}/>
          </Col>
        </Row>
      </CardFooter>
    </Card>

  )
}