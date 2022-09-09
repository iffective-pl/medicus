import {Dropdown, DropdownItem, DropdownMenu, NavLink} from "reactstrap";
import {useState} from "react";

export default function HeaderDropdown(props) {
  let [collapse, setCollapse] = useState(true);

  let toggle = () => setCollapse(!collapse)

  return (
    <div onMouseEnter={toggle} onMouseLeave={toggle}>
      <Dropdown isOpen={!collapse} toggle={toggle} nav inNavbar>

        <NavLink className="header" active={document.location.href.endsWith(props.item.href)} href={props.item.href} mouseEnter={() => console.log("active")}>
          {props.item.name}
        </NavLink>

        <DropdownMenu>
          {props.item.options.map((option, index) => (
            <DropdownItem className="header" key={index} tag="a" href={props.item.href + option.href}>{option.name}</DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>
    </div>
  )
}