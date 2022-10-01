import HomeCarousel from "../components/Home/HomeCarousel";
import HomeServices from "../components/Home/HomeServices";
import HomeAdvantages from "../components/Home/HomeAdvantages";
import Reminder from "../components/Reminder";
import {useEffect, useState} from "react";

let defaultM = {
  id: 0,
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
      <HomeCarousel />
      <HomeServices />
      <HomeAdvantages advantages={mp.advantages} />
      <Reminder />
    </>
  );
}