import {Table} from "reactstrap";
import Line from "../Line";
import {isMobile} from "react-device-detect";

import './DocsDoctors.css';

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
      <div className={"doctors-container " + (isMobile ? "doctors-rows" : "doctors-cols")}>
        {props.doctors.map((item, index) =>
          <div key={index}>
            <h4>{item.title}</h4>
            <h3>{item.firstName} {item.lastName}</h3>
            <div>{item.specTitle}</div>
            <div>{item.description}</div>
            <Table className="mt-3">
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
                <td>{isNull(item.workingHours[0].monday)}</td>
              </tr>
              <tr>
                <td>Wtorek</td>
                <td>{isNull(item.workingHours[0].tuesday)}</td>
              </tr>
              <tr>
                <td>Środa</td>
                <td>{isNull(item.workingHours[0].wednesday)}</td>
              </tr>
              <tr>
                <td>Czwartek</td>
                <td>{isNull(item.workingHours[0].thursday)}</td>
              </tr>
              <tr>
                <td>Piątek</td>
                <td>{isNull(item.workingHours[0].friday)}</td>
              </tr>
              <tr>
                <td>Sobota</td>
                <td>{isNull(item.workingHours[0].saturday)}</td>
              </tr>
              </tbody>
            </Table>
          </div>
        )}
      </div>
    </div>
  )
}