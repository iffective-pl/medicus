import Line from "../components/Line";
import {Container} from "reactstrap";
import {useEffect, useState} from "react";
import {isMobile} from "react-device-detect";
import Description from "../components/Description";
import {useParams} from "react-router-dom";
import GoogleMaps from "../components/GoogleMaps";

let defaultS = {
  name: "",
  hasMap: false,
  descriptions: []
}

export default function Static() {
  let params = useParams();
  let [s, setS] = useState(defaultS);

  useEffect(() => {
    fetch("api/Static/GetStatic?staticId=" + params.type)
      .then(r => r.json())
      .then(j => setS(j))
  })

  let hasMap = () => {
    if (s.hasMap) {
      return <GoogleMaps/>
    }
  }

  return (
    <>
      <Container>
        <h3 className="text-center">{s.name}</h3>
        <Line center/>
        <div className={"mt-3 mb-5 " + (isMobile ? "small" : "normal")}>
          {s.descriptions.map((item, key) => (
            <Description description={item} isEven={key%2===0}/>
          ))}
        </div>
      </Container>
      {hasMap()}
    </>
  )
}