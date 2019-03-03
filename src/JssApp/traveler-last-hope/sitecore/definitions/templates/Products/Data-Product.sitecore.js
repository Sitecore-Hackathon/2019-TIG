import {CommonFieldTypes, Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {dataSourceContentData, mediaLibraryFolder} from '../../../../src/helpers';

const section = "Product";

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function (manifest) {
  manifest.addTemplate({
    id: 'data-product',
    name: 'Data-Product',
    displayName: 'Data - Product',
    icon: SitecoreIcon.Barcode,
    fields: [
      {
        section: section,
        name: 'productName',
        displayName: 'Name',
        type: CommonFieldTypes.SingleLineText,
      },
      {
        section: section,
        name: 'weatherType',
        displayName: 'Weather Type',
        type: CommonFieldTypes.ContentList,
        source: dataSourceContentData('Weather/Types'),
      },
      {
        section: section,
        name: 'image',
        displayName: 'Image',
        type: CommonFieldTypes.Image,
        source: mediaLibraryFolder('PMD/Products'),
      },
      {
        section: section,
        name: 'description',
        displayName: 'Description',
        type: CommonFieldTypes.MultiLineText,
      },
      {
        section: section,
        name: 'price',
        displayName: 'Price',
        type: CommonFieldTypes.Number
      },
    ],
  });
}
