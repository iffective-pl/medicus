import './Description.css';
import {isMobile} from "react-device-detect";
import Config from "../config/Config";
import {Editor, convertFromRaw, EditorState} from 'draft-js'

export default function Description(props) {
  let desc = props.description;

  let content = (t) => {
    if(t === "") {
      return EditorState.createEmpty();
    } else {
      return EditorState.createWithContent(convertFromRaw(JSON.parse(t)))
    }
  }

  if(props.isEven) {
    return (
      <div className={"desc-row mb-5 " + (isMobile ? "rows" : "columns")}>
        <div className="desc-image shadow-lg">
          <img src={Config.minio + desc.image} className="d-image" alt="desc"/>
        </div>
        <div>
          {desc.descriptionTexts.map((item, index) =>
            <div key={index} className="ps-4 pe-4">
              <h4>{item.title}</h4>
              <Editor editorState={content(item.text)} readOnly={true} />
            </div>
          )}
        </div>
      </div>
    )
  } else {
    return (
      <div className={"desc-row mb-5 " + (isMobile ? "rows" : "columns")}>
        <div>
          {desc.descriptionTexts.map((item, index) =>
            <div key={index} className="ps-4 pe-4">
              <h4>{item.title}</h4>
              <Editor editorState={content(item.text)} readOnly={true} />
            </div>
          )}
        </div>
        <div className="desc-image shadow-lg">
          <img src={Config.minio + desc.image} className="d-image" alt="desc"/>
        </div>
      </div>
    )
  }
}