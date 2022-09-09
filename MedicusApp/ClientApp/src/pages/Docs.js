import DocsSpecs from "../components/Docs/DocsSpecs";
import {useParams} from "react-router-dom";
import Reminder from "../components/Reminder";

export default function Docs() {
  let params = useParams();

  let type = () => {
    if(params.type) {
      return <></>
    } else {
      return <DocsSpecs />
    }
  }

  return (
    <>
      {type()}
      <Reminder />
    </>
  )

}