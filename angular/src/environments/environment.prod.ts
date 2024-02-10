import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'AsapTask',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44360/',
    redirectUri: baseUrl,
    clientId: 'AsapTask_App',
    responseType: 'code',
    scope: 'offline_access AsapTask',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'AsapTask',
    },
  },
} as Environment;
