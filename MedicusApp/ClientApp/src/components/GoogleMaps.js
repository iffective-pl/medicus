import {GoogleMap, useJsApiLoader} from "@react-google-maps/api";
import {useCallback, useState} from "react";

const center = {
  lat: 52.654110,
  lng: 19.067100
}

const style = {
  width: "100%",
  height: "45vh"
}

export default function GoogleMaps() {
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyDN8u8t4uc6OR_6I3jUhU7uZc0fcrY_kIo"
  })

  // eslint-disable-next-line no-unused-vars
  const [map, setMap] = useState(null)

  const onLoad = useCallback(function callback(map) {
    const bounds = new window.google.maps.LatLngBounds(center);
    map.fitBounds(bounds);
    setMap(map)
  }, [])

  const onUnmount = useCallback(function callback() {
    setMap(null)
  }, [])

  return isLoaded ? (
    <div className="mt-4">
      <GoogleMap
        zoom={15}
        onLoad={onLoad}
        center={center}
        mapContainerStyle={style}
        onUnmount={onUnmount}
      >
        { /* Child components, such as markers, info windows, etc. */ }
        <></>
      </GoogleMap>
    </div>
  ) : <></>
}