import HomeCarousel from "../bases/Home/HomeCarousel";
import HomeServices from "../bases/Home/HomeServices";
import HomeAdvantages from "../bases/Home/HomeAdvantages";
import Reminder from "../bases/Reminder";

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