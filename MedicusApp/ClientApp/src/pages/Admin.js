import {useEffect, useState} from "react";
import Keycloak from "keycloak-js";
import {Spinner} from "reactstrap";
import AdminContext from "../admin/AdminContext";
import Config from '../admin/config/Config';
import AdminContent from "../admin/AdminContent";

import './Admin.css';

export default function Admin() {
  const [keycloak, setKeycloak] = useState(undefined);
  const [authenticated, setAuthenticated] = useState();

  useEffect(() => {
    const service = new Keycloak(Config);
    service.init({ onLoad: "login-required" }).then(authenticated => {
      setKeycloak(service)
      setAuthenticated(authenticated)
    })
  }, []);

  if(authenticated) {
    return (
      <AdminContext.Provider value={keycloak}>
        <AdminContent/>
      </AdminContext.Provider>
    )
  } else if(authenticated === undefined) {
    return (
      <div className="flex-fill d-table">
        <div className="d-table-cell flex-fill text-center vertical-center">
          <Spinner/>
        </div>
      </div>
    )
  } else {
    return (
      <div className="text-center h1">Brak dostępu</div>
    )
  }
}