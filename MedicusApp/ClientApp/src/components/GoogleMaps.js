import {GoogleMap, InfoWindow, Marker, useJsApiLoader} from "@react-google-maps/api";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  CardText,
  CardTitle,
  Popover,
  PopoverBody,
  PopoverHeader
} from "reactstrap";

const center = {
  lat: 52.654110,
  lng: 19.067100
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
        </InfoWindow>
      </GoogleMap>
    </div>
  ) : <></>
}