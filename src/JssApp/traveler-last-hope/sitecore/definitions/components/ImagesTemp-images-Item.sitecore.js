// eslint-disable-next-line no-unused-vars
import {CommonFieldTypes, SitecoreIcon, Manifest} from '@sitecore-jss/sitecore-jss-manifest';
import {mediaLibraryFolder} from '../../../src/helpers';

// workaround for images from Content/Data items to copy them to media library

export default function(manifest) {
  manifest.addComponent({
    name: 'ImagesTemp-images-Item',
    icon: SitecoreIcon.DocumentTag,
    fields: [
      {
        name: 'image',
        displayName: 'Gallery Image',
        type: CommonFieldTypes.Image,
        source: mediaLibraryFolder(''),
      },
    ],
  });
}


