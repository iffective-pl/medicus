import {Container} from "reactstrap";

import './HomeAdvantages.css';
import Config from '../../config/Config';
import {isMobile} from "react-device-detect";

export default function HomeAdvantages(props) {
  return (
    <Container className="p-0 mt-5" fluid>
      <div className={"advantages-container " + (isMobile ? "advantages-rows" : "advantages-cols")}>
        <div className="text-center overflow-hidden advantages-image-container">
          <span className="h1 very-center">Co nas wyróżnia?</span>
          <img src={Config.minio + "medicus-static/advantages.jpg"} alt="advantages" className="advantages-image" />
        </div>
        <div className="text-center title">
          <div className="advantages">
            {props.advantages.sort((a, b) => a.id > b.id ? 1 : -1).map((item, index) => (
              <div className="advantage-hover" key={index}>
                <a href={item.href} className="advantage">
                  <div className="advantage">
                    <div className="advantage-cell">
                      <i className={"icon advantage " + item.icon} />
                      <div className="h4 p-1">{item.name}</div>
                    </div>
                  </div>
                </a>
              </div>
            ))}
          </div>
        </div>
      </div>
    </Container>
  )
}