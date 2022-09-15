import {Container} from "reactstrap";
import Line from "../components/Line";

import './About.css';
import {isMobile} from "react-device-detect";
import GoogleMaps from "../components/GoogleMaps";

export default function About() {
  return (
    <>
      <Container>
        <h3 className="text-center">O nas</h3>
        <Line center/>
        <div className={"mt-3 mb-5 about-cont " + (isMobile ? "small" : "normal")}>
          <div className="fs-5 about-table">
            <div className="about-cell">
              <b>1 czerwca 1990</b> roku powstała Przychodni Specjalistycznej MEDICUS we Włocławku przy Placu Wolności 15 – pierwsza niepubliczna przychodnia specjalistyczna w mieście i w regionie i jedna z pierwszych tego typu w kraju.<br/>
              W jej składzie znalazły się poradnie i gabinety specjalistyczne deficytowych specjalności w mieście i regionie kierowane przez wysoko kwalifikowanych specjalistów i pracowników nauki z klinik i oddziałów z Warszawy, Łodzi, Bydgoszczy i Włocławka oraz szerokoprofilowe laboratorium analityczno-bakteriologiczne.<br/>
              Specjalnościami wiodącymi tej przychodni jest <b>kardiologia dorosłych, kardiologia dziecięca oraz ginekologia i położnictwo</b> – co umożliwia wyposażenie  tych poradni w specjalistyczny sprzęt echokardiograficzny i ultrasonograficzny.
            </div>
          </div>
          <div className="about-table">
            <div className="about-cell">
              <img src="images/used/about-1.jpg" alt="przychodnia" className="about shadow-lg" />
            </div>
          </div>
          <div className="about-table">
            <div className="about-cell">
              <img src="images/used/about-2.jpg" alt="przychodnia" className="about shadow-lg" />
            </div>
          </div>
          <div className="fs-5 about-table">
            <div className="about-cell">
              Założycielem i Kierownikiem Przychodni jest <b>dr n. med. Wiesław Nowakowski</b> - absolwent Wydziału Lekarskiego Akademii Medycznej w Poznaniu (1963 – 1969).<br/>
              Po odbyciu stażu podyplomowego był asystentem I Oddziału Chorób Wewnętrznych w Szpitalu Wojewódzkim we Włocławku.<br/>
              W 1974 r. uzyskuje I st. z chorób wewnętrznych, w 1977 r. - II st. z chorób wewnętrznych z wynikiem celującym, w 1980 r. – specjalizację z kardiologii (pierwszy włocławianin z tą specjalizacją), w 1988 r. doktorat / dysertacja z kardiologii - pierwsza w mieście i regionie.<br/>
              W latach 1973 - 1997 pełnił funkcje Ordynatora Kardiologicznego Szpitala Uzdr., Naczelnego Lekarza oraz z-cy Dyrektora d/s lecznictwa PPUW w Wieńcu Zdroju.<br/>
              W 1995 r. organizuje oddział włocławski Polskiego Towarzystwa Kardiologicznego, a od 2011 r. jest honorowym przewodniczącym tego Oddziału.<br/>
              Jest autorem siedmiu opracowań książkowych o tematyce biograficzno-historycznej wydanych na specjalne rocznicowe okazje oraz ponad 100. publikacji i prezentacji z zakresu kardiologii, genetyki, profilaktyki i promocji zdrowia, medycyny społecznej.<br/>
              Był organizatorem siedemnastu konferencji naukowych w zakresie kardiologii o zasięgu regionalnym i ogólnopolskim.
            </div>
          </div>
        </div>
      </Container>
      <GoogleMaps/>
    </>
  );
}