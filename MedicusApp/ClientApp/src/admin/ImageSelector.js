import {FormGroup, Input, Label} from "reactstrap";
import Config from "../config/Config";
import {useEffect, useState} from "react";
import Notification from "../components/Notification";

export default function ImageSelector(props) {
  let [images, setImages] = useState([]);

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  let loadImages = (token) => {
    fetch("api/Minio", {
      headers: {
        "Authorization": "Bearer " + token
      }
    })
      .then(r => r.json())
      .then(j => setImages(j))
  }

  useEffect(() => {
    loadImages(props.token)
  }, [props.token])

  let onChange = (e) => {
    setLoading(true)
    setMessage("Wysyłanie nowego obrazka...")

    let data = new FormData();
    data.append("file", e.target.files[0])

    fetch("api/Minio", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token
      },
      body: data
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t.startsWith("medicus/"));
        if(t.startsWith("medicus/")) {
          setMessage("Obrazek został wysłany")
          props.setImage(t)
        } else {
          setMessage("Nie udało się wysłać obrazka")
        }
        loadImages(props.token)
      })
  }

  return (
    <>
      <div className="images-cont">
        <div className="d-inline-block float-start m-2 rounded shadow">
          <label htmlFor="file" className="image-cont text-center d-table">
            <div className="d-table-cell vertical-center">
              <i className="icon folder"/>
              <h5 className="text-center">Prześlij zdjęcie</h5>
            </div>
          </label>
          <Input
            id="file"
            name="file"
            type="file"
            accept=".jpg,.jpeg,.png"
            className="d-none"
            onChange={onChange}
          />
        </div>
        {images.map((item, index) => (
          <div className="d-inline-block position-relative float-start m-2 rounded shadow" key={index} onClick={() => props.setImage(item)}>
            <div className="image-checkbox">
              <Input type="checkbox" checked={props.image === item} readOnly />
            </div>
            <img className="image-cont" src={Config.minio + item} alt={item}/>
          </div>
        ))}
      </div>
      <div className="mt-3">
        <FormGroup floating>
          <Input
            id="image"
            name="image"
            value={props.image}
            type="text"
            disabled
          />
          <Label for="image">
            Obrazek
          </Label>
        </FormGroup>
      </div>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}