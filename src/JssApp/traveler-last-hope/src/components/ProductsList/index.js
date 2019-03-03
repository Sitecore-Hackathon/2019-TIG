
// External modules
import React from 'react';
import { RichText } from '@sitecore-jss/sitecore-jss-react';

// Shared components
import PlaceholderComponent from '../../shared/Component/ComponentPlaceholder';

// Partials of component
import './styles.scss';


const ProductsList = (props) => {
  const data = [];

  if (props.fields) {
    Object.keys(props.fields).forEach((key) => {
      data.push(props.fields[key]);
    })
  }

  return (
    <PlaceholderComponent {...props}>
      <div className="c-ProductsList">
        { props.fields && props.fields.heading &&
          <RichText field={props.fields.heading} tag="h2" className="c-ProductsList__heading display-4" />
        }
        <br />
        { props.fields && data.length > 0 &&
          data.map((item, index) => {
            return (
              <article className="c-ProductsList__item" key={`Product-${index}`}>
                <header className="c-ProductsList__item__head">
                  <h2>{item.name}</h2>
                  <span>{item.category}</span>
                </header>
                <div className="c-ProductsList__item__img">
                  <img src={item.image} alt={item.name} />
                </div>
                <p className="c-ProductsList__item__desc">{item.description}</p>
                <footer className="c-ProductsList__item__footer">
                  <span>Price:</span><span>{item.price}$</span>
                </footer>
              </article>
            )
          })
        }
      </div>
    </PlaceholderComponent>
  )
};

export default ProductsList;
