import {useEffect, useState} from "react";
import {Droppable} from "react-beautiful-dnd";
import {Card, CardBody, CardHeader} from "reactstrap";
import TabHeaderLink from "./TabHeaderLink";

export default function TabHeaderUnassigned(props) {
  let [links, setLinks] = useState([])

  useEffect(() => {
    setLinks([]);
    fetch("api/UI/GetUnassignedLinks",
      {
        headers: {
          "Authorization": "Bearer " + props.token
        }
      })
      .then(r => r.json())
      .then(j => setLinks(j))
  }, [props.token, props.update])

  return (
    <Card className="tab-header me-2 ms-2">
      <CardHeader>
        Nieprzypisane linki
      </CardHeader>
      <CardBody>
        <Droppable droppableId="headerId0" className="droppable-size">
          {(provided) => (
            <div {...provided.droppableProps} ref={provided.innerRef} className="tab-body">
              {links.map((item, key) => (
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