import {useEffect, useState} from "react";
import Keycloak from "keycloak-js";
import {Spinner} from "reactstrap";

export default function Admin() {
  const [keycloak, setKeycloak] = useState(null);
  const [authenticated, setAuthenticated] = useState();

  useEffect(()=>{
    const service = new Keycloak({
      "realm": "medicus",
      "clientId": "medicus-web",
      "url": "http://localhost:8080/"
    });
    service.init({ onLoad: "login-required" }).then(authenticated => {
      setKeycloak(keycloak)
      setAuthenticated(authenticated)
    })
  }, []);

  if(authenticated) {
    return (
      <div>Authenticated</div>
    )
  } else if(authenticated === undefined) {
    return (
      <Spinner/>
    )
  } else {
    return (
      <div>Unauthenticated</div>
    )
  }
}