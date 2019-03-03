
// External modules
import React from 'react';
import { NavLink } from 'react-router-dom';

// Shared components
import PlaceholderComponent from '../../shared/Component/ComponentPlaceholder';

// Partials of component
import './styles.scss';

const TXT_NO_LOCATION = "No location. Based on your location, we will choose the most interesting products for all weathers! Please, share it with us!";
const TXT_WITH_LOCATION = "Your location is:"

const LocalizationBar = (props) => {
  const {fields} = props;
  const {city, country} = fields;
  const noLocation = !!(country === null && city === null);

  return (
    <PlaceholderComponent classesWrapper={`sticky-top`} {...props}>
      <div className="c-LocalizationBar border-bottom">
        {
          noLocation ? (
            <p>
              <span>{TXT_NO_LOCATION}</span>
              <NavLink to="/get-weather" className="btn btn-primary btn-block mt-3">Add my location by form</NavLink>
            </p>
          ) : (
            <p>{TXT_WITH_LOCATION} <strong>{country}, {city}</strong></p>
          )
        }
      </div>
    </PlaceholderComponent>
  )
};

export default LocalizationBar;
