import {Container, Nav, NavItem, NavLink, TabContent} from "reactstrap";
import Line from "../components/Line";
import {useState} from "react";
import TabCompany from "./tabs/TabCompany";
import TabHeaders from "./tabs/headers/TabHeaders";
import TabSpecs from "./tabs/specs/TabSpecs";
import AdminContext from "./AdminContext";
import TabDoctors from "./tabs/doctors/TabDoctors";
import TabStatics from "./tabs/statics/TabStatics";
import TabMain from "./tabs/TabMain";

export default function AdminContent() {
  let [tab, setTab] = useState(0);

  let tabs = [
    {element: TabSpecs, name: "Specjalizacje"},
    {element: TabDoctors, name: "Lekarze"},
    {element: TabHeaders, name: "Nagłówki"},
    {disabled: true},
    {element: TabCompany, name: "Dane Przychodni"},
    {element: TabStatics, name: "Statyczne Strony"},
    {disabled: true},
    {element: TabMain, name: "Strona główna"}
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