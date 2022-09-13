import Line from "./Line";
import {Container} from "reactstrap";

import './SideContact.css';
import {isMobile} from "react-device-detect";

export default function SideContact(props) {
  return (
    <Container className="title">
      <h2 className="text-center">{props.title}</h2>
      <Line center />
      <div className={"main-container " + (isMobile ? "small" : "normal")}>
        <div>
          <div className={"text-center side-container " + (isMobile ? "small" : "normal")}>
            <div className="pb-4">
              <div>
                <i className="location icon"/>
              </div>
              <div>
                <div>Plac Wolności 15</div>
                <div>87-800 Włocławek</div>
              </div>
            </div>
            <div className="pb-4">
              <div>
                <i className="message icon"/>
              </div>
              <div>
                <div>biuro@medicus.wloclawek.pl</div>
                <div>rejestracja@medicus.wloclawek.pl</div>
              </div>
            </div>
            <div className="pb-4">
              <div>
                <i className="phone icon"/>
              </div>
              <div>
                <div>54 2313141</div>
                <div>54 2313741</div>
              </div>
            </div>
            <div className="pb-4">
              <div>
                <i className="mobile icon"/>
              </div>
              <div>
                <div>692 184 214</div>
              </div>
            </div>
          </div>
        </div>
        <div>
          {props.children}
        </div>
      </div>
    </Container>
  )
}