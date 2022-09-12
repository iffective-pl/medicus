import {useEffect, useState} from "react";
import {Container} from "reactstrap";
import Line from "../components/Line";
import DocsDoctors from "../components/Docs/DocsDoctors";
import Loading from "../components/Loading";
import DocsPricing from "../components/Docs/DocsPricing";
import DocsDescription from "../components/Docs/DocsDescription";

export default function Spec(props) {
  let [data, setData] = useState();

  useEffect(() => {
    fetch("api/Specs/" + props.type)
      .then(r => r.json())
      .then(j => setData(j));
  });

  if(data) {
    return (
      <Container>
        <h2 className="text-center">{data.name}</h2>
        <Line center/>
        <DocsDoctors doctors={data.doctors}/>
        <DocsDescription descriptions={data.descriptions}/>
        <DocsPricing prices={data.prices}/>
      </Container>
    )
  } else {
    return (
      <Loading/>
    )
  }
}