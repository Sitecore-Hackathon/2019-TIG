// eslint-disable-next-line no-unused-vars
import {Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {sitecoreTemplates} from '../../const.settings';

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function(manifest) {
  manifest.addTemplate({
    id: 'data-pmd-folder',
    name: 'Data-PMDFolder',
    displayName: 'Data - PMD Folder',
    icon: SitecoreIcon.MagazineFolder,
    insertOptions: ['data-product-folder',],
    inherits: [sitecoreTemplates.Folder,],
  });
}
