import {Link, Navbar} from "@nextui-org/react";
import cross from "../images/cross.png";
import medicus from "../images/medicus.png";
import AppRoutes from "../AppRoutes";
import "./Header.css";

export default function Header() {
  return (
    <Navbar>
      <Navbar.Brand hideIn="xs">
        <img
          src={cross}
          alt='cross'
          loading='lazy'
          className='cross'
        />
        <img
          src={medicus}
          alt='medicus'
          loading='lazy'
          className='medicus'
        />
      </Navbar.Brand>
      <Navbar.Brand href='/' showIn="xs">
        <Navbar.Toggle aria-label="toggle navigation" />
        <img
          src={cross}
          alt='cross'
          loading='lazy'
          className='cross'
        />
      </Navbar.Brand>
      <Navbar.Content enableContentHighlight hideIn="xs" variant="underline">
        {AppRoutes.map((item, index) => (
          <Navbar.Link isActive={document.location.href.endsWith(item.path)} key={index} href={item.path}>
            {item.name}
          </Navbar.Link>
        ))}
      </Navbar.Content>
      <Navbar.Collapse showIn="xs">
        {AppRoutes.map((item, index) => (
          <Navbar.CollapseItem key={index}>
            <Link
              color="inherit"
              css={{
                minWidth: "100%",
              }}
              href={item.path}
            >
              {item.name}
            </Link>
          </Navbar.CollapseItem>
        ))}
      </Navbar.Collapse>
      <Navbar.Content enableContentHighlight>
        <Navbar.Item>
          <Navbar.Link href="register">
            Rejestracja
          </Navbar.Link>
        </Navbar.Item>
      </Navbar.Content>
    </Navbar>
  );
}