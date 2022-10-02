import {Button, Form, Input, InputGroup} from "reactstrap";
import {useEffect, useState} from "react";
import Notification from "../../../components/Notification";

let defaultAdv = {
  id: 0,
  name: "",
  icon: "",
  href: ""
}

export default function TabAdvantage(props) {
  let [adv, setAdv] = useState(defaultAdv)
  let [statics, setStatics] = useState([])
  let [links, setLinks] = useState([])
  let [headers, setHeaders] = useState([])

  let [loading, setLoading] = useState(undefined);
  let [message, setMessage] = useState(undefined);
  let [success, setSuccess] = useState(undefined);

  useEffect(() => {
    loadStatics()
    loadLinks()
    loadHeaders()
    setAdv(props.adv)
  }, [props.token])

  let loadStatics = () => {
    fetch("api/Static/GetStaticDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setStatics(j))
  }

  let loadLinks = () => {
    fetch("api/UI/GetLinkDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setLinks(j))
  }

  let loadHeaders = () => {
    fetch("api/UI/GetHeaderDropdown", {
      headers: {
        "Authorization": "Bearer " + props.token
      }
    })
      .then(r => r.json())
      .then(j => setHeaders(j))
  }

  let onSubmit = (e) => {
    setLoading(true)
    setMessage("Aktualizacja zalety...")
    e.preventDefault()
    fetch("api/MP/UpdateAdvantage", {
      method: "POST",
      headers: {
        "Authorization": "Bearer " + props.token,
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        id: adv.id,
        name: e.target.name.value,
        href: e.target.href.value
      })
    })
      .then(r => r.text())
      .then(t => {
        setLoading(false);
        setSuccess(t === "true");
        if(t === "true") {
          setMessage("Zaleta została zaktualizowana")
        } else {
          setMessage("Nie udało się zaktualizować zalety")
        }
      })
  }

  let joinCollections = (s, h, l) => {
    let arr = [{name: "", href: ""}];
    arr = arr.concat(s.map((item) => ({name: item.name, href: "static/" + item.id})));
    arr.push({name: "──────────", disabled: true})
    arr = arr.concat(h);
    arr.push({name: "──────────", disabled: true})
    arr = arr.concat(l.map((item) => ({name: item.spec.name, href: "docs/" + item.spec.id})));
    return arr.map((item, key) => (
      <option value={item.href} key={key} disabled={item.disabled}>
        {item.name}
      </option>
    ));
  }

  let onChange = (e) => {
    let change = {};
    change[e.target.name] = e.target.value;
    setAdv(a => ({
      ...a,
      ...change
    }));
  }

  return (
    <>
      <Form onSubmit={onSubmit} className="mb-2">
        <InputGroup>
          <Input
            name="name"
            type="text"
            defaultValue={adv.name}
          />
          <Input
            id="href"
            name="href"
            type="select"
            value={adv.href}
            onChange={onChange}
            disabled={statics.length < 1}
          >
            {joinCollections(statics, headers, links)}
          </Input>
          <Button color="info" type="submit">Zapisz</Button>
        </InputGroup>
      </Form>
      <Notification loading={loading} success={success} message={message}/>
    </>
  )
}