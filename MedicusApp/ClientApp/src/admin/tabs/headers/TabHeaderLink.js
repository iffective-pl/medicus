import {Draggable} from "react-beautiful-dnd";
import {Card, CardBody} from "reactstrap";

export default function TabHeaderLink(props) {
  return (
    <Draggable draggableId={props.link.id.toString()} index={props.index}>
      {(provided) => (
        <div ref={provided.innerRef}
             {...provided.draggableProps}
             {...provided.dragHandleProps}
             className="m-2">
          <Card>
            <CardBody>
              {props.link.spec.name}
            </CardBody>
          </Card>
        </div>
      )}
    </Draggable>
  )
}