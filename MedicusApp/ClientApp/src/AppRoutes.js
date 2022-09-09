import Home from "./pages/Home";
import About from "./pages/About";
import Docs from "./pages/Docs";
import Contact from "./pages/Contact";
import Register from "./pages/Register";
import USG from "./pages/USG";
import Holter from "./pages/Holter";
import ECHO from "./pages/ECHO";

const AppRoutes = [
  {
    index: true,
    path: "/",
    element: <Home />
  },
  {
    path: "about",
    element: <About />
  },
  {
    path: "register",
    element: <Register />
  },
  {
    path: "docs",
    optional: [
      {
        path: ":type",
        element: <Docs />
      },
      {
        path: "",
        element: <Docs />
      }
    ],
    element: <Docs />
  },
  {
    path: "usg",
    optional: [
      {
        path: ":type",
        element: <Docs />
      }
    ],
    element: <USG />
  },
  {
    path: "echo",
    optional: [
      {
        path: ":type",
        element: <Docs />
      }
    ],
    element: <ECHO />
  },
  {
    path: "holter",
    element: <Holter />
  },
  {
    path: "contact",
    element: <Contact />
  }
];

export default AppRoutes;
