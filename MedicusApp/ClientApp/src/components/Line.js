import './Line.css';

export default function Line(props) {
  let position = () => {
    if(props.left)
      return "float-start";
    else if(props.right)
      return "float-end";
  }

  if(props.center) {
    return (
      <div className="flex-row line-container pb-4 mt-4 text-center">
        <hr/>
      </div>
    )
  } else {
    return (
      <div className={"flex-row line-container pb-4 mt-4 " + position()}>
        <div className={"line " + props.className}>
          <hr/>
        </div>
      </div>
    )
  }
}