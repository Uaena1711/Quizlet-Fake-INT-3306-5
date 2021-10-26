import { Config } from '@abp/ng.core';

const baseUrl = 'http://localhost';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Quizlet_Fake',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44340',
    redirectUri: baseUrl,
    clientId: 'Quizlet_Fake_App',
    responseType: 'code',
    scope: 'offline_access Quizlet_Fake',
  },
  apis: {
    default: {
      url: 'https://localhost:44340',
      rootNamespace: 'Quizlet_Fake',
    },
  },
} as Config.Environment;
