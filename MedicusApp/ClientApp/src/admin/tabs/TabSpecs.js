import {
  TabPane, UncontrolledAccordion
} from "reactstrap";
import {useEffect, useState} from "react";
import TabSpec from "./TabSpec";

export default function TabSpecs(props) {
  let [specs, setSpecs] = useState([]);

  useEffect(() => {
    setSpecs([]);
    fetch("api/Spec/GetSpecIds", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setSpecs(j))
  }, [props.keycloak.token])

  return (
    <TabPane tabId="4" className="pt-3 pb-3">
      <UncontrolledAccordion className="mb-3">
        {specs.map((item, key) => <TabSpec id={item} token={props.keycloak.token} index={key} key={key}/>)}
      </UncontrolledAccordion>
    </TabPane>
  )
}