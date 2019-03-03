// eslint-disable-next-line no-unused-vars
import {Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {sitecoreTemplates} from '../../const.settings';

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function(manifest) {
  manifest.addTemplate({
    id: 'data-product-folder',
    name: 'Data-ProductFolder',
    displayName: 'Data - Product Folder',
    icon: SitecoreIcon.FolderDocument2,
    insertOptions: ['data-product'],
    inherits: [sitecoreTemplates.Folder,],
  });
}
