import {Table} from "reactstrap";
import Line from "../Line";

export default function DocsPricing(props) {
  return (
    <div className="p-3">
      <h3>Cennik</h3>
      <Line left className="mid"/>
      <Table>
        <thead>
          <tr>
            <th>
              Usługa
            </th>
            <th>
              Cena
            </th>
          </tr>
        </thead>
        <tbody>
          {props.prices.map((item, index) =>
            <tr key={index}>
              <td>{item.title}</td>
              <td>{item.value + " zł"}</td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  )
}