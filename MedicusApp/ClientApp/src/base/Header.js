import {useEffect, useState} from "react";
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

export default function Header() {
  let [collapse, setCollapse] = useState(false);
  let [links, setLinks] = useState([]);

  useEffect(() => {
    fetch("/api/Links")
      .then(r => r.json())
      .then(j => setLinks(j))
  }, []);

  let headers = (item, index) => {
    if(item.options.length > 0) {
      return (
        <UncontrolledDropdown nav inNavbar key={index}>
          <DropdownToggle className="header" nav caret>
            {item.name}
          </DropdownToggle>
          <DropdownMenu>
            {item.options.map((option, index) => (
              <DropdownItem className="header" key={index} tag="a" href={item.href + option.href}>{option.name}</DropdownItem>
            ))}
          </DropdownMenu>
        </UncontrolledDropdown>
      )
    } else {
      return (
        <NavItem key={index}>
          <NavLink className="header" active={document.location.href.endsWith(item.href)} href={item.href}>
            {item.name}
          </NavLink>
        </NavItem>
      )
    }
  }

  return (
    <Navbar light container expand="lg">
      <NavbarBrand href="/">
        <img src="images/logo-oryg-medicus-cropped.png" alt="logo" className="logo" />
      </NavbarBrand>
      <NavbarToggler onClick={() => setCollapse(!collapse)} />
      <Collapse isOpen={collapse} navbar>
        <Nav className="me-auto" navbar>
          {links.filter(q => !q.isIndex).map(headers)}
        </Nav>
      </Collapse>
    </Navbar>
  );
}