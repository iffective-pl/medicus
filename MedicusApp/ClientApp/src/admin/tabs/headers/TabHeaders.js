import {Card, CardBody, Col, Row, TabPane} from "reactstrap";
import {DragDropContext, Draggable, Droppable} from "react-beautiful-dnd";
import {useEffect, useState} from "react";
import TabHeader from "./TabHeader";

import '../specs/Tabs.css';
import TabHeaderUnassigned from "./TabHeaderUnassigned";
import AddHeaderButton from "../../operations/AddHeaderButton";
import EditHeadersButton from "../../operations/EditHeadersButton";

export default function TabHeaders(props) {
  let [headers, setHeaders] = useState([]);
  let [dropdowns, setDropdowns] = useState([]);
  let [update, setUpdate] = useState(false);

  let loadHeaders = () => {
    setHeaders([])
    fetch("api/UI/GetHeadersOrder", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setHeaders(j))
  }

  let loadDropDowns = () => {
    fetch("api/UI/GetHeaderIds", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setDropdowns(j))
  }

  useEffect(() => {
    loadHeaders();
  }, [props.keycloak.token])

  useEffect(() => {
    loadDropDowns();
  }, [props.keycloak.token, headers])

  let move = (linkId, destination) => {
    fetch("api/UI/MoveLink?linkId=" + linkId, {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(destination)
    })
      .then(r => r.text())
      .then(t => {
        if(t === "true") {
          setUpdate(!update);
        }
      })
  }

  let order = (linkId, destination) => {
    fetch("api/UI/OrderLink?linkId=" + linkId, {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(destination)
    })
      .then(r => r.text())
      .then(t => {
        if(t === "true") {
          setUpdate(!update);
        }
      })
  }

  let onDragEnd = (e) => {
    let destId = e.destination.droppableId.replace('headerId', '')
    let dest = {droppableId: destId, index: e.destination.index};
    if(e.source.droppableId !== e.destination.droppableId) {
      move(e.draggableId, dest)
    } else {
      order(e.draggableId, dest);
    }
  }

  let onDragEndHeader = (e) => {
    fetch("api/UI/OrderHeader?headerId=" + e.draggableId,{
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.keycloak.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(
        {
          droppableId: 0,
          index: e.destination.index
        })
    })
      .then(r => r.text())
      .then(t => {
        if(t === "true") {
          loadHeaders();
        }
      })
  }

  return (
    <TabPane tabId={props.index.toString()} className="mt-3 mb-3">
      <Row>
        <Col>
          <EditHeadersButton token={props.keycloak.token} load={loadHeaders} forceUpdate={() => setUpdate(!update)} headers={headers.filter(f => !f.isPredefined)}/>
          <AddHeaderButton token={props.keycloak.token} load={loadHeaders}/>
        </Col>
      </Row>
      <Row className="pt-3">
        <Col>
          <h4 className="title">Kolejność nagłówków</h4>
        </Col>
      </Row>
      <Row className="pt-3">
        <Col>
          <DragDropContext onDragEnd={onDragEndHeader}>
            <Droppable droppableId={"droppable"} direction="horizontal">
              {(provided) => (
                <div {...provided.droppableProps} ref={provided.innerRef}>
                  <Card>
                    <CardBody>
                      {headers.map((item, key) => (
                        <Draggable key={key} draggableId={item.id.toString()} index={key}>
                          {(provided) => (
                            <div ref={provided.innerRef}
                                 style={provided.draggableProps.style}
                                 {...provided.draggableProps}
                                 {...provided.dragHandleProps}
                                 className="d-inline-block float-start me-3">
                              <Card>
                                <CardBody>
                                  {item.name}
                                </CardBody>
                              </Card>
                            </div>
                          )}
                        </Draggable>
                      ))}
                      {provided.placeholder}
                    </CardBody>
                  </Card>
                </div>
              )}
            </Droppable>
          </DragDropContext>
        </Col>
      </Row>
      <Row className="pt-3">
        <Col>
          <h4 className="title">Przypisanie linków</h4>
        </Col>
      </Row>
      <Row className="pt-3">
        <Col>
          <DragDropContext onDragEnd={onDragEnd}>
            <div className="tab-cont">
              <div>
                <TabHeaderUnassigned token={props.keycloak.token} update={update}/>
              </div>
              <div className="tab-headers-cont">
                <div className="tab-headers">
                  {dropdowns.map((item, key) => (
                    <TabHeader id={item} key={key} update={update}/>
                  ))}
                </div>
              </div>
            </div>
          </DragDropContext>
        </Col>
      </Row>
    </TabPane>
  )
}