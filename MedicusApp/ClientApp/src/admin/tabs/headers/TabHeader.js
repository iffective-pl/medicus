import {useEffect, useState} from "react";
import {Droppable} from "react-beautiful-dnd";
import {Card, CardBody, CardHeader} from "reactstrap";
import TabHeaderLink from "./TabHeaderLink";

const h = {
  id: 0,
  name: "",
  href: "",
  isIndex: false,
  isHidden: false,
  links: []
}

export default function TabHeader(props) {
  let [header, setHeader] = useState(h);

  useEffect(() => {
    let head = {
      id: header.id,
      name: header.name,
      href: header.href,
      isIndex: header.isIndex,
      isHidden: header.isHidden,
      links: []
    };
    setHeader(head);
    fetch("api/UI/GetHeader?headerId=" + props.id,
      {
        headers: {
          "Authorization": "Bearer " + props.token
        }
      })
      .then(r => r.json())
      .then(j => setHeader(j))
  }, [props.token, props.id, props.update])

  if (header.id === 0) {
    return <></>
  }

  return (
    <Card className="tab-header me-2 ms-2">
      <CardHeader>
        {header.name}
      </CardHeader>
      <CardBody>
        <Droppable droppableId={"headerId" + header.id.toString()}>
          {(provided) => (
            <div {...provided.droppableProps} ref={provided.innerRef} className="tab-body">
              {header.links.map((item, key) => (
                <TabHeaderLink link={item} key={key} index={item.order}/>
              ))}
              {provided.placeholder}
            </div>
          )}
        </Droppable>
      </CardBody>
    </Card>
  )
}