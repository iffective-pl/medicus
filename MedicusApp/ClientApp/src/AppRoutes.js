import Home from "./pages/Home";
import Docs from "./pages/Docs";
import Contact from "./pages/Contact";
import Register from "./pages/Register";
import Admin from "./pages/Admin";
import Static from "./pages/Static";

const AppRoutes = [
  {
    index: true,
    path: "/",
    element: <Home />
  },
  {
    path: "register",
    element: <Register />
  },
  {
    path: "contact",
    element: <Contact />
  },
  {
    path: "admin",
    element: <Admin />
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
    path: "static/:type",
    element: <Static />
  }
];

export default AppRoutes;
