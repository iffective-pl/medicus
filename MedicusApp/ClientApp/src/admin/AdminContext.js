import React from "react";
import Keycloak from "keycloak-js";

const AdminContext = React.createContext(new Keycloak());

export default AdminContext;