import './Description.css';
import {isMobile} from "react-device-detect";
import Config from "../admin/config/Config";
import {Editor, convertFromRaw, EditorState} from 'draft-js'

export default function Description(props) {
  let desc = props.description;

  if(props.isEven) {
    return (
      <div className={"desc-row " + (isMobile ? "rows" : "columns")}>
        <div className="desc-image shadow-lg">
          <img src={Config.minio + desc.image} className="desc-image" alt="desc"/>
        </div>
        <div>
          {desc.descriptionTexts.map((item, index) =>
            <div key={index} className="pt-2">
              <h4>{item.title}</h4>
              <Editor editorState={EditorState.createWithContent(convertFromRaw(JSON.parse(item.text)))} readOnly={true} />
            </div>
          )}
        </div>
      </div>
    )
  }
}