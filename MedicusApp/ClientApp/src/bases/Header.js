import {useState} from "react";
import {
  Collapse, DropdownItem, DropdownMenu,
  DropdownToggle,
  Nav,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem, NavLink,
  UncontrolledDropdown
} from "reactstrap";

import "./Header.css";
import AppRoutes from "../AppRoutes";
import logo from '../images/logo-oryg-medicus-cropped.png';

export default function Header() {
  let [collapse, setCollapse] = useState(false);

  let headers = (item) => {
    if(item.options) {
      return (
        <UncontrolledDropdown nav inNavbar>
          <DropdownToggle nav caret>
            {item.name}
          </DropdownToggle>
          <DropdownMenu>
            {item.options.map((option, index) => (
              <DropdownItem key={index} tag="a" href={item.href + option.href}>{option.name}</DropdownItem>
            ))}
          </DropdownMenu>
        </UncontrolledDropdown>
      )
    } else {
      return (
        <NavLink active={document.location.href.endsWith(item.href)} href={item.href}>
          {item.name}
        </NavLink>
      )
    }
  }

  return (
    <Navbar light container expand="lg">
      <NavbarBrand href="/">
        <img src={logo} alt="logo" className="logo" />
      </NavbarBrand>
      <NavbarToggler onClick={() => setCollapse(!collapse)} />
      <Collapse isOpen={collapse} navbar>
        <Nav className="me-auto" navbar>
          {AppRoutes.filter(q => !q.index).map((item, index) => (
            <NavItem key={index}>
              {headers(item)}
            </NavItem>
          ))}
        </Nav>
      </Collapse>
    </Navbar>
  );
}