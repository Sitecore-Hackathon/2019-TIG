import {CommonFieldTypes, Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {mediaLibraryFolder} from '../../../../src/helpers';

const section = "Location";

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function (manifest) {
  manifest.addTemplate({
    id: 'data-location',
    name: 'Data-Location',
    displayName: 'Data - Location',
    icon: SitecoreIcon.WaterFish,
    fields: [
      {
        section: section,
        name: 'country',
        displayName: 'Country',
        type: CommonFieldTypes.SingleLineText,
      },
      {
        section: section,
        name: 'city',
        displayName: 'City',
        type: CommonFieldTypes.SingleLineText,
      },
    ],
  });
}
