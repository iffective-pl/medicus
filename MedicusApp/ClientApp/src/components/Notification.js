import {Spinner, Toast, ToastBody, ToastHeader} from "reactstrap";

import './Notification.css';
import {useEffect, useState} from "react";

export default function Notification(props) {
  let [hidden, setHidden] = useState(true);

  useEffect(() => {
    if(props.success || props.message || props.loading) {
      setHidden(false);
      setTimeout(() => setHidden(true), 5000);
    }
  }, [props.loading, props.success])

  let icon = () => {
    if(props.loading) {
      return (<Spinner size="sm">Ładowanie...</Spinner>)
    } else {
      if(props.success) {
        return "success"
      } else {
        return "danger"
      }
    }
  }

  return (
    <div hidden={hidden} className="notification onTop">
      <Toast>
        <ToastHeader icon={icon()}>
          Operacja
        </ToastHeader>
        <ToastBody>
          {props.message}
        </ToastBody>
      </Toast>
    </div>
  )
}