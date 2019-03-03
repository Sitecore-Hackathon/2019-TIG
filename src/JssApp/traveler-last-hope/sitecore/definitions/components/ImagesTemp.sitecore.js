// eslint-disable-next-line no-unused-vars
import {CommonFieldTypes, SitecoreIcon, Manifest} from '@sitecore-jss/sitecore-jss-manifest';
import {mediaLibraryFolder} from '../../../src/helpers';

/**
 * Workaround for images from Content/Data items to copy them to media library
 * @param manifest
 */
export default function(manifest) {
  manifest.addComponent({
    name: 'ImagesTemp',
    icon: SitecoreIcon.DocumentTag,
    fields: [
      {
        name: 'images',
        displayName: 'Images Gallery',
        type: CommonFieldTypes.ContentList,
        source: mediaLibraryFolder(''),
      },
    ],
  });
}
