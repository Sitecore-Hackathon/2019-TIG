
// External modules
import React from 'react';
import { NavLink } from 'react-router-dom';
import moment from 'moment';

// Shared components
import PlaceholderComponent from '../../shared/Component/ComponentPlaceholder';

// Partials of component
import './styles.scss';

const WeatherBox = (props) => {
  const data = [];

  if (props.fields) {
    Object.keys(props.fields).forEach((key) => {
      data.push(props.fields[key]);
    })
  }

  return (
  <PlaceholderComponent {...props}>
    <div className="c-WeatherBox">
      {
        props.fields && data.length > 0 &&
          <React.Fragment>
            <div className="c-WeatherBox__list">
              {
                data.map((item, index) => {
                  return (
                    <div className="c-WeatherBox__item" key={`WeatherBox-${index}`}>
                      <div className="c-WeatherBox__item__img">
                        <img src={item.imageUrl} alt={item.description} />
                      </div>
                      <div className="c-WeatherBox__item__info">
                        <h3>Weather for day: {moment(item.date).format('DD-MM-YYYY')}</h3>
                        <ul>
                          <li>Pressure: <strong>{item.pressure} kPa</strong></li>
                          <li>Temperature: <strong>{item.temp} °C</strong></li>
                          <li>Wind speed: <strong>{item.wind} km/s</strong></li>
                        </ul>
                        <p>That day will be: <i>{item.description}</i></p>
                      </div>
                    </div>
                  )
                })
              }
            </div>
            <div className="c-WeatherBox__cta">
              <NavLink to="/products-list" className="btn btn-block btn-lg btn-success">Go to product list</NavLink>
            </div>
            <small>Icons downloaded from: https://www.amcharts.com/free-animated-svg-weather-icons/</small>
          </React.Fragment>
        // ) : (
        //   <p className="bg-warning text-center text-white c-WeatherBox__message">We can't show weather for You, becasue we don't know Your location.</p>
        // )
      }

    </div>
  </PlaceholderComponent>
  )
};

export default WeatherBox;
