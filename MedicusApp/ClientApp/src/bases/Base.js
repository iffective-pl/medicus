import './Base.css'

import Header from "./Header";
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