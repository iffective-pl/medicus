import './Description.css';
import {isMobile} from "react-device-detect";

export default function Description(props) {
  let desc = props.description;

  if(props.isEven) {
    return (
      <div className={"desc-row " + (isMobile ? "rows" : "columns")}>
        <div className="desc-image shadow-lg">
          <img src={desc.image} className="desc-image" alt="desc"/>
        </div>
        <div>
          <h4>{desc.title}</h4>
          <span>{desc.text}</span>
        </div>
      </div>
    )
  }
}