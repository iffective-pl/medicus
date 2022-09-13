import DocsSpecs from "../components/Docs/DocsSpecs";
import {useParams} from "react-router-dom";
import Reminder from "../components/Reminder";
import Spec from "./Spec";

export default function Docs() {
  let params = useParams();

  let type = () => {
    if (params.type) {
      return <Spec type={params.type} />
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