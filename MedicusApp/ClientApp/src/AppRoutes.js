import Home from "./pages/Home";
import About from "./pages/About";
import Docs from "./pages/Docs";
import Contact from "./pages/Contact";
import Register from "./pages/Register";
import USG from "./pages/USG";

const AppRoutes = [
  {
    index: true,
    path: "/",
    href: "/",
    name: 'Strona główna',
    element: <Home />
  },
  {
    path: "about",
    href: "about",
    name: "O nas",
    element: <About />
  },
  {
    path: "register",
    href: "register",
    name: "Rejestracja",
    element: <Register />
  },
  {
    path: "docs",
    href: "docs",
    name: "Lekarze specjaliści",
    element: <Docs />
  },
  {
    path: "usg/?sex/?type",
    href: "usg",
    name: "USG",
    options: [
      {href: "/kids", name: "USG Dzieci"},
      {href: "/pregnancy", name: "USG Ciąży"},
      {href: "/adults", name: "USG Dorosłych"}
    ],
    element: <USG />
  },
  {
    path: "echo/?type",
    href: "echo",
    name: "ECHO Serca",
    options: [
      {href: "/kids", name: "Dzieci"},
      {href: "/adults", name: "Dorosłych"}
    ]
  },
  {
    path: "holter",
    href: "holter",
    name: "Holter"
  },
  {
    path: "contact",
    href: "contact",
    name: "Kontakt",
    element: <Contact />
  }
];

export default AppRoutes;
