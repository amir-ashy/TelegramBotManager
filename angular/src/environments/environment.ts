import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'TelegramBotManager',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44334',
    redirectUri: baseUrl,
    clientId: 'TelegramBotManager_App',
    responseType: 'code',
    scope: 'offline_access TelegramBotManager',
  },
  apis: {
    default: {
      url: 'https://localhost:44334',
      rootNamespace: 'Nikia.TelegramBotManager',
    },
  },
} as Environment;
