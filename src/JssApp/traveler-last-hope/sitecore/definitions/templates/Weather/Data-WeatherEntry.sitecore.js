// eslint-disable-next-line no-unused-vars
import {CommonFieldTypes, Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {dataSourceContentData, mediaLibraryFolder} from '../../../../src/helpers';

const section = "Weather Entry";

/**
 * This is the data template for an individual _item_ in the Styleguide's Content List field demo.
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function (manifest) {
  manifest.addTemplate({
    id: 'data-weather-entry',
    name: 'Data-Weather-Entry',
    displayName: 'Data - Weather Entry',
    icon: SitecoreIcon.CloudSun,
    fields: [
      {
        section: section,
        name: 'date',
        displayName: 'Date',
        type: CommonFieldTypes.Date
      },
      {
        section: section,
        name: 'weatherType',
        displayName: 'Weather Type',
        type: CommonFieldTypes.ItemLink,
        source: dataSourceContentData('Weather/Type'),
      },
      {
        section: section,
        name: 'temp',
        displayName: 'Temperature',
        type: CommonFieldTypes.Number
      },
      {
        section: section,
        name: 'pressure',
        displayName: 'Pressure',
        type: CommonFieldTypes.Number
      },
      {
        section: section,
        name: 'description',
        displayName: 'Description',
        type: CommonFieldTypes.MultiLineText,
      },
      {
        section: section,
        name: 'wind',
        displayName: 'Wind',
        type: CommonFieldTypes.Number
      },
      {
        section: section,
        name: 'clouds',
        displayName: 'Clouds',
        type: CommonFieldTypes.Number
      },
    ],
  });
}
