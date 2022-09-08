import HomeCarousel from "../components/Home/HomeCarousel";
import HomeServices from "../components/Home/HomeServices";
import HomeAdvantages from "../components/Home/HomeAdvantages";
import Reminder from "../components/Reminder";

export default function Home() {
  return (
    <>
      <HomeCarousel />
      <HomeServices />
      <HomeAdvantages />
      <Reminder />
    </>
  );
}