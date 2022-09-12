import Line from "../Line";
import Description from "../Description";

export default function DocsDescription(props) {
  return (
    <div className="p-3">
      <h3>Opis specjalizacji</h3>
      <Line left className="mid"/>
      {props.descriptions.map((item, index) =>
        <Description key={index} description={item} isEven={index%2===0}/>
      )}
    </div>
  )
}