import AppRoutes from "../AppRoutes";
import "./Header.css";
import {useEffect, useState} from "react";
import {
  MDBBtn, MDBBtnGroup,
  MDBCollapse,
  MDBContainer, MDBIcon,
  MDBNavbar,
  MDBNavbarBrand, MDBNavbarItem, MDBNavbarLink,
  MDBNavbarNav,
  MDBNavbarToggler, MDBPopover, MDBPopoverBody
} from "mdb-react-ui-kit";
import logo from '../images/logo-oryg-medicus-cropped.png';

const isMobile = (width) => width <= 991;

export default function Header() {
  let [collapse, setCollapse] = useState(false);

  function handleWindowSizeChange() {
      setCollapse(!isMobile(window.innerWidth));
  }

  useEffect(() => {
    handleWindowSizeChange();
    window.addEventListener('resize', handleWindowSizeChange);
    return () => {
      window.removeEventListener('resize', handleWindowSizeChange);
    }
  }, []);

  //let dropDown = ()

  let headers = (item) => {
    if(item.options) {
      return (
        <MDBPopover noRipple dismiss placement='bottom' btnChildren={item.name} btnClassName={document.location.href.indexOf(item.href) > -1 ? "btn-dismissed active" : "btn-dismissed"}
                    poperStyle={{background: "transparent", boxShadow: "none"}} >
          <MDBPopoverBody>
            <MDBBtnGroup vertical aria-label='Pionowa grupa przycisków'>
              {item.options.map((option, key) => (
                <MDBBtn noRipple className="btn-dismissed btn-list" key={key} tag="a" href={item.href + option.href}>{option.name}</MDBBtn>
              ))}
            </MDBBtnGroup>
          </MDBPopoverBody>
        </MDBPopover>
      )
    } else {
      return (
        <MDBNavbarLink active={document.location.href.endsWith(item.href)} href={item.href}>
          {item.name}
        </MDBNavbarLink>
      )
    }
  }

  return (
    <MDBNavbar expand='lg' light bgColor='light'>
      <MDBContainer>
        <MDBNavbarBrand href='/'>
          <img src={logo} alt="medicus" className="logo"/>
        </MDBNavbarBrand>
        <MDBNavbarToggler
          type='button'
          aria-expanded='false'
          aria-label='Pokaż nawigację'
          onClick={() => setCollapse(!collapse)}
        >
          <MDBIcon icon='bars' fas />
        </MDBNavbarToggler>
        <MDBCollapse show={collapse}>
          <MDBNavbarNav left>
            {AppRoutes.filter(q => !q.index).map((item, index) => (
              <MDBNavbarItem key={index} aria-current={item.href}>
                {headers(item)}
              </MDBNavbarItem>
            ))}
          </MDBNavbarNav>
        </MDBCollapse>
      </MDBContainer>
    </MDBNavbar>
  );
}