import React from 'react';

import './styles.scss';

const PlaceholderComponent = ({children, rendering, classesWrapper = ''}) => {
  const componentId = `i${rendering.uid.replace(/[{}]/g, '')}`;
  const _componentWrapperClasses = `component ${classesWrapper}`;

  return (
    <React.Fragment>
      <section className={_componentWrapperClasses} id={componentId}>
        {children}
      </section>
    </React.Fragment>
  );
};

export default PlaceholderComponent;