import {Table} from "reactstrap";
import Line from "../Line";

export default function DocsDoctors(props) {
  let isNull = (day) => {
    if(day)
      return day;
    else
      return "-";
  }

  return (
    <div className="p-3">
      <h3>Nasi lekarze</h3>
      <Line left className="mid"/>
      {props.doctors.map((item, index) =>
        <div key={index} className="d-inline-block flex-row me-5">
          <h4>{item.title}</h4>
          <h3>{item.firstName} {item.lastName}</h3>
          <div>{item.city}</div>
          <Table>
            <thead>
              <tr>
                <th>
                  Dzień tygodnia
                </th>
                <th>
                  Godziny przyjęć
                </th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Poniedziałek</td>
                <td>{isNull(item.workingHours.monday)}</td>
              </tr>
              <tr>
                <td>Wtorek</td>
                <td>{isNull(item.workingHours.tuesday)}</td>
              </tr>
              <tr>
                <td>Środa</td>
                <td>{isNull(item.workingHours.wednesday)}</td>
              </tr>
              <tr>
                <td>Czwartek</td>
                <td>{isNull(item.workingHours.thursday)}</td>
              </tr>
              <tr>
                <td>Piątek</td>
                <td>{isNull(item.workingHours.friday)}</td>
              </tr>
              <tr>
                <td>Sobota</td>
                <td>{isNull(item.workingHours.saturday)}</td>
              </tr>
              <tr>
                <td>Niedziela</td>
                <td>{isNull(item.workingHours.sunday)}</td>
              </tr>
            </tbody>
          </Table>
        </div>
      )}
    </div>
  )
}