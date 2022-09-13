import {Collapse, Dropdown, DropdownItem, DropdownMenu, NavLink} from "reactstrap";
import {useEffect, useState} from "react";

export default function HeaderDropdown(props) {
  let [isOpen, setIsOpen] = useState(false);
  let [isCollapseOpen, setCollapseOpen] = useState(false);
  let toggle = () => {
    setIsOpen(!isOpen);
    setCollapseOpen(!isCollapseOpen);
  }

  useEffect(() => {
    setCollapseOpen(!props.isOpen);
    setTimeout(() => {
      setCollapseOpen(props.isOpen);
      setIsOpen(props.isOpen)
    }, 250);
  }, [props.isOpen]);

  return (
    <div onMouseEnter={toggle} onMouseLeave={toggle}>
      <Dropdown isOpen={isOpen} toggle={toggle} nav inNavbar>
        <NavLink className="header" active={document.location.href.endsWith(props.item.href)} href={props.item.href} mouseEnter={() => console.log("active")}>
          {props.item.name}
        </NavLink>
        <Collapse isOpen={isCollapseOpen}>
          <DropdownMenu>
            {props.item.options.map((option, index) => (
              <DropdownItem className="header" key={index} tag="a" href={props.item.href + option.href}>{option.name}</DropdownItem>
            ))}
          </DropdownMenu>
        </Collapse>
      </Dropdown>
    </div>
  )
}