import {Collapse, Dropdown, DropdownItem, DropdownMenu, NavLink} from "reactstrap";
import {useState} from "react";
import {isMobile} from "react-device-detect";

export default function HeaderDropdown(props) {
  let [isCollapseOpen, setCollapseOpen] = useState(isMobile);

  let toggle = () => {
    if(!isMobile)
      setCollapseOpen(!isCollapseOpen);
  }

  let isActive = (href) => {
    if(href.length > 0) {
      if(document.location.href.endsWith(href)) {
        return true;
      }
    }
    return false;
  }

  return (
    <div onMouseEnter={toggle} onMouseLeave={toggle}>
      <Dropdown isOpen={isCollapseOpen} toggle={toggle} nav inNavbar className="me-2">
        <NavLink className="header" active={isActive(props.item.href)} href={props.item.href ? props.item.href : "#"}>
          {props.item.name}
        </NavLink>
        <Collapse isOpen={isCollapseOpen}>
          <DropdownMenu>
            {props.item.links.map((option, index) => (
              <DropdownItem className="header" key={index} tag="a" href={props.item.href + option.href}>{option.spec.name}</DropdownItem>
            ))}
          </DropdownMenu>
        </Collapse>
      </Dropdown>
    </div>
  )
}