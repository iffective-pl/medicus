import {useEffect, useState} from "react";
import {convertFromRaw, convertToRaw, EditorState} from "draft-js";
import {Editor} from "react-draft-wysiwyg";

export default function TextEditor(props) {
  let [editorState, setEditorState] = useState(EditorState.createEmpty())

  useEffect(() => {
    if(props.dt.text === "") {
      setEditorState(EditorState.createEmpty());
    } else {
      let raw = convertFromRaw(JSON.parse(props.dt.text));
      setEditorState(EditorState.createWithContent(raw));
    }
  }, [])

  let onChange = (e) => {
    setEditorState(e);
    props.onChange({
      target: {
        name: "text",
        value: JSON.stringify(convertToRaw(e.getCurrentContent()))
      }
    })
  }

  return (
    <Editor
      editorState={editorState}
      onEditorStateChange={onChange}
    />
  )
}