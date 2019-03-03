// eslint-disable-next-line no-unused-vars
import {Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {sitecoreTemplates} from '../../const.settings';

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function(manifest) {
  manifest.addTemplate({
    id: 'data-weather-folder',
    name: 'Data-WeatherFolder',
    displayName: 'Data - Weather Folder',
    icon: SitecoreIcon.CloudSun,
    insertOptions: ['data-weather-type'],
    inherits: [sitecoreTemplates.Folder,],
  });
}
