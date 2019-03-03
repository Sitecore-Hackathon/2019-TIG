import {CommonFieldTypes, Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {mediaLibraryFolder} from '../../../../src/helpers';

const section = "Product Category";

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function (manifest) {
  manifest.addTemplate({
    id: 'data-weather-type',
    name: 'Data-WeatherType',
    displayName: 'Data - Weather Type',
    icon: SitecoreIcon.Sun,
    fields: [
      {
        section: section,
        name: 'typeName',
        displayName: 'Name',
        type: CommonFieldTypes.SingleLineText,
      },
      {
        section: section,
        name: 'image',
        displayName: 'Image',
        type: CommonFieldTypes.Image,
        source: mediaLibraryFolder('Weather/Types'),
      },
    ],
  });
}
