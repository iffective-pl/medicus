import {Container, Nav, NavItem, NavLink, TabContent} from "reactstrap";
import Line from "../components/Line";
import {useState} from "react";
import TabCompany from "./tabs/TabCompany";
import TabHeaders from "./tabs/TabHeaders";
import TabSpecs from "./tabs/TabSpecs";
import AdminContext from "./AdminContext";
import TabDoctors from "./tabs/TabDoctors";

export default function AdminContent() {
  let [tab, setTab] = useState(1);

  let isActive = (i) => tab === i ? "active" : "";

  return (
    <Container>
      <h3 className="text-center title">Portal Administracyjny</h3>
      <Line center/>
      <Nav tabs>
        <NavItem>
          <NavLink className={isActive(1)} onClick={() => setTab(1)}>
            Dane Przychodni
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink className={isActive(2)} onClick={() => setTab(2)}>
            Nagłówki
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink className={isActive(3)} onClick={() => setTab(3)}>
            Lekarze
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink className={isActive(4)} onClick={() => setTab(4)}>
            Specjalizacje
          </NavLink>
        </NavItem>
      </Nav>
      <TabContent activeTab={tab.toString()} className="p-3">
        <AdminContext.Consumer>
          {keycloak => (
              <>
                <TabCompany keycloak={keycloak}/>
                <TabHeaders keycloak={keycloak}/>
                <TabDoctors keycloak={keycloak}/>
                <TabSpecs keycloak={keycloak}/>
              </>
          )}
        </AdminContext.Consumer>
      </TabContent>
    </Container>
  )
}