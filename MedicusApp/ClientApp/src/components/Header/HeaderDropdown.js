import {Collapse, Dropdown, DropdownItem, DropdownMenu, NavLink} from "reactstrap";
import {useEffect, useState} from "react";

export default function HeaderDropdown(props) {
  let [isCollapseOpen, setCollapseOpen] = useState(false);
  let [disabled, setDisable] = useState(false);

  let toggle = () => {
    if (!disabled) {
      setCollapseOpen(!isCollapseOpen);
    }
  }

  useEffect(() => {
    if(props.toggled !== undefined) {
      setDisable(true);
      if(props.toggled) {
        setTimeout(() => {
          setCollapseOpen(props.toggled);
        }, 250);
      } else {
        setCollapseOpen(props.toggled);
      }
    }
  }, [props.toggled]);

  return (
    <div onMouseEnter={toggle} onMouseLeave={toggle}>
      <Dropdown isOpen={true} toggle={toggle} nav inNavbar>
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