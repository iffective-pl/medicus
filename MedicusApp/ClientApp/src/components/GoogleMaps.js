import {GoogleMap, InfoWindow, useJsApiLoader} from "@react-google-maps/api";
import {
  Card,
  CardBody,
  CardText,
  CardTitle
} from "reactstrap";

const center = {
  lat: 52.654073468178176,
  lng: 19.0671225821407
}

const style = {
  width: "100%",
  height: "45vh"
}

const options = {
  streetViewControl: false
}

export default function GoogleMaps() {
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyDN8u8t4uc6OR_6I3jUhU7uZc0fcrY_kIo"
  })

  return isLoaded ? (
    <div className="mt-4">
      <GoogleMap
        zoom={17}
        center={center}
        options={options}
        mapContainerStyle={style}
      >

        <InfoWindow
          position={center}

        >
          <a href="https://goo.gl/maps/Bo7DdG3jAkWrWC6p8" target="_blank" className="advantage" rel="noreferrer">
            <Card className="border-0">
              <CardBody className="p-2">
                <CardTitle tag="h5">
                  Poradnia Specjalistyczna<br/>MEDICUS
                </CardTitle>
                <CardText>
                  <div>Plac Wolności 15</div>
                  <div>87-800 Włocławek</div>
                </CardText>
              </CardBody>
            </Card>
          </a>
        </InfoWindow>
      </GoogleMap>
    </div>
  ) : <></>
}