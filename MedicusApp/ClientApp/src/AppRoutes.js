import Home from "./pages/Home";
import About from "./pages/About";
import Docs from "./pages/Docs";
import Contact from "./pages/Contact";

const AppRoutes = [
  {
    index: true,
    path: "/",
    name: 'Start',
    element: <Home />
  },
  {
    path: "about",
    name: "O nas",
    element: <About />
  },
  {
    path: "docs",
    name: "Lekarze",
    element: <Docs />
  },
  {
    path: "contact",
    name: "Kontakt",
    element: <Contact />
  }
];

export default AppRoutes;
