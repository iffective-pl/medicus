import {Container, Nav, NavItem, NavLink, TabContent} from "reactstrap";
import Line from "../components/Line";
import {useState} from "react";
import TabCompany from "./tabs/TabCompany";
import TabHeaders from "./tabs/headers/TabHeaders";
import TabSpecs from "./tabs/specs/TabSpecs";
import AdminContext from "./AdminContext";
import TabDoctors from "./tabs/doctors/TabDoctors";
import TabStatics from "./tabs/statics/TabStatics";
import TabMain from "./tabs/main/TabMain";

export default function AdminContent() {
  let [tab, setTab] = useState(0);

  let tabs = [
    {element: TabCompany, name: "Dane Przychodni"},
    {disabled: true},
    {element: TabMain, name: "Strona główna"},
    {element: TabStatics, name: "Statyczne Strony"},
    {disabled: true},
    {element: TabSpecs, name: "Specjalizacje"},
    {element: TabDoctors, name: "Lekarze"},
    {element: TabHeaders, name: "Nagłówki"}
  ]

  let isActive = (i) => tab === i ? "active" : "";

  return (
    <Container>
      <h3 className="text-center title">Portal Administracyjny</h3>
      <Line center/>
      <Nav tabs>
        {tabs.map((item, index) => (
          <NavItem key={index}>
            <NavLink className={isActive(index)} onClick={() => setTab(index)} disabled={item.disabled}>
              {item.name}
            </NavLink>
          </NavItem>
        ))}
      </Nav>
      <TabContent activeTab={tab.toString()} className="p-3">
        <AdminContext.Consumer>
          {keycloak => {
            return tabs.map((item, index) => item.disabled ? null : (
              <item.element key={index} index={index} keycloak={keycloak}/>
            ))
          }}
        </AdminContext.Consumer>
      </TabContent>
    </Container>
  )
}