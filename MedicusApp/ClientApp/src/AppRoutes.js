import Home from "./pages/Home";
import About from "./pages/About";
import Docs from "./pages/Docs";
import Contact from "./pages/Contact";
import Register from "./pages/Register";

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
    path: "contact",
    element: <Contact />
  }
];

export default AppRoutes;
