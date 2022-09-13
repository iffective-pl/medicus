import {useEffect, useState} from "react";
import {
  Collapse,
  Nav,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem, NavLink
} from "reactstrap";

import "./Header.css";
import HeaderDropdown from "../components/Header/HeaderDropdown";

export default function Header() {
  let [isOpen, setIsOpen] = useState(undefined);
  let [links, setLinks] = useState([]);

  useEffect(() => {
    fetch("/api/Links")
      .then(r => r.json())
      .then(j => setLinks(j))
  }, []);

  let toggleButton = () => {
    if(isOpen)
      setIsOpen(!isOpen);
    else
      setIsOpen(true);
  }

  let headers = (item, index) => {
    if(item.options.length > 0) {
      return (
        <HeaderDropdown item={item} key={index} />
      )
    } else {
      return (
        <NavItem key={index} className="me-2">
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
        <NavbarToggler onClick={toggleButton}/>
      <Collapse isOpen={isOpen} navbar>
        <Nav className="me-auto" navbar>
          {links.filter(q => !q.isIndex).map(headers)}
        </Nav>
      </Collapse>
    </Navbar>
  );
}