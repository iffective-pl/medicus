import {Collapse, Dropdown, DropdownItem, DropdownMenu, NavLink} from "reactstrap";
import {useState} from "react";
import {isMobile} from "react-device-detect";

export default function HeaderDropdown(props) {
  let [isCollapseOpen, setCollapseOpen] = useState(isMobile);

  let toggle = () => {
    if(!isMobile)
      setCollapseOpen(!isCollapseOpen);
  }

  return (
    <div onMouseEnter={toggle} onMouseLeave={toggle}>
      <Dropdown isOpen={isCollapseOpen} toggle={toggle} nav inNavbar className="me-2">
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