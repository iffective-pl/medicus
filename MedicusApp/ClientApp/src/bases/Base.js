import './Header.css'

import Header from "./Header";
import "./Base.css";
import Footer from "./Footer";

export default function Base(props) {

  return (
    <>
      <Header/>
      <div className="body">
        {props.children}
      </div>
      <Footer/>
    </>
  );
}