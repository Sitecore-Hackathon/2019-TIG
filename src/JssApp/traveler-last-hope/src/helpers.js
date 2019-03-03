import config from "./temp/config";
import {getFieldValue} from '@sitecore-jss/sitecore-jss-react';

export const jssAppName = config.jssAppName.replace("-stage", "")
  .replace("-production", "");

export const sitecorePages = {
  homepageId: `/sitecore/content/${jssAppName}/home`.replace('-stage', ''),
};

function contentFolder(subFolder) {
  return `/sitecore/content/${jssAppName}/${subFolder}`;
}

export function contentConfigurationPath(subFolder) {
  return contentFolder(`Content/Configuration/${subFolder}`);
}

export function contentDataPath(subFolder) {
  return contentFolder(`Content/Data/${subFolder}`);
}

export function dataSourceContentConfiguration(subFolderInContentConfiguration) {
  return 'dataSource=' + contentConfigurationPath(subFolderInContentConfiguration);
}

export function dataSourceContentData(subFolderInContentData) {
  return 'dataSource=' + contentDataPath(subFolderInContentData);
}

export function dataSourceConfiguration(subFolderInRouteAndQuery) {
  return 'dataSource=' + contentFolder(subFolderInRouteAndQuery);
}

export function mediaLibraryFolder(subFolder) {
  return `/sitecore/media library/${jssAppName}/data/media/${subFolder}`;
}

export function isDisconectedMode(sitecoreContext) {
  return sitecoreContext && sitecoreContext.site && sitecoreContext.site.name === "JssDisconnectedLayoutService";
}

export default {sitecorePages};
