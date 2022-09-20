import {Spinner} from "reactstrap";

export default function Loading() {
  return (
    <div className="flex-fill d-table">
      <div className="d-table-cell vertical-center text-center">
        <Spinner color="info"/>
      </div>
    </div>
  )
}