import './Description.css';

export default function Description(props) {
  let desc = props.description;

  if(props.isEven) {
    return (
      <div className="desc-container d-inline-block mb-3">
        <div className="d-inline-block desc-image-container shadow-lg">
          <img src={desc.image} className="desc-image" alt="desc"/>
        </div>
        <div className="d-inline-block desc-text ps-5">
          <h4>{desc.title}</h4>
          <span>{desc.text}</span>
        </div>
      </div>
    )
  } else {
    return (
      <div>
        <div className="d-inline-block">
          <h4>{desc.title}</h4>
          <span>{desc.description}</span>
        </div>
        <div className="d-inline-block">
          <img src={desc.image} className="img-fluid" alt="desc"/>
        </div>
      </div>
    )
  }
}