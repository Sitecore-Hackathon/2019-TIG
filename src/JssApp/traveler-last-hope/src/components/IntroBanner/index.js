
// External modules
import React from 'react';
import { RichText, Image, getFieldValue } from '@sitecore-jss/sitecore-jss-react';

// Shared components
import PlaceholderComponent from '../../shared/Component/ComponentPlaceholder';

// Partials of component
import './styles.scss';


const IntroBanner = (props) => (
  <PlaceholderComponent {...props}>
    <div className="c-IntroBanner">
      { props.fields && props.fields.heading &&
        <RichText field={props.fields.heading} tag='h2' className="c-IntroBanner__heading display-4" />
      }
      { getFieldValue(props.fields, 'bgimgurl') &&
        <Image field={props.fields.bgimgurl} className="c-IntroBanner__img" />
      }
    </div>
  </PlaceholderComponent>
);

export default IntroBanner;
