import HomeCarousel from "../components/Home/HomeCarousel";
import HomeServices from "../components/Home/HomeServices";
import HomeAdvantages from "../components/Home/HomeAdvantages";
import Reminder from "../components/Reminder";
import {useEffect, useState} from "react";

let defaultM = {
  id: 0,
  carousels: [],
  services: [],
  advantages: []
}

export default function Home() {
  let [mp, setMp] = useState(defaultM)

  useEffect(() => {
    fetch("api/MP/GetMainPage")
      .then(r => r.json())
      .then(j => setMp(j))
  }, [])

  return (
    <>
      <HomeCarousel carousels={mp.carousels} />
      <HomeServices services={mp.services} />
      <HomeAdvantages advantages={mp.advantages} />
      <Reminder />
    </>
  );
}