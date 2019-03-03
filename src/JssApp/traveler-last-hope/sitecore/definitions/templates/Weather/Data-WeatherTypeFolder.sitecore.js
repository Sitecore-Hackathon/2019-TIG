// eslint-disable-next-line no-unused-vars
import {Manifest, SitecoreIcon} from '@sitecore-jss/sitecore-jss-manifest';
import {sitecoreTemplates} from '../../const.settings';

/**
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function(manifest) {
  manifest.addTemplate({
    id: 'data-weather-type-folder',
    name: 'Data-WeatherTypeFolder',
    displayName: 'Data - Weather Type Folder',
    icon: SitecoreIcon.SunDimmed,
    insertOptions: ['data-weather-type'],
    inherits: [sitecoreTemplates.Folder,],
  });
}
