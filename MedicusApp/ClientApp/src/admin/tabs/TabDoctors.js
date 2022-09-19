import {useEffect, useState} from "react";
import TabDoctor from "./TabDoctor";
import {TabPane, UncontrolledAccordion} from "reactstrap";

export default function TabDoctors(props) {
  let [doctors, setDoctors] = useState([]);

  useEffect(() => {
    fetch("api/Doctor/GetDoctors", {
      headers: {
        "Authorization": "Bearer " + props.keycloak.token
      }
    })
      .then(r => r.json())
      .then(j => setDoctors(j))
  }, [props.keycloak.token])

  return (
    <TabPane tabId="3" className="pt-5 pb-5">
      <UncontrolledAccordion className="mb-3">
        {doctors.map((item, key) => <TabDoctor id={item} token={props.keycloak.token} index={key} key={key}/>)}
      </UncontrolledAccordion>
    </TabPane>
  )
}