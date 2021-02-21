import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/telegram-manager',
        name: '::Menu:TelegramManager',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/bots',
        name: '::Menu:Bot',
        parentName: '::Menu:TelegramManager',
        layout: eLayoutType.application,
        requiredPolicy: 'TelegramBotManager.Bots',
      },
      {
        path: '/files',
        name: '::Menu:File',
        parentName: '::Menu:TelegramManager',
        layout: eLayoutType.application,
        requiredPolicy: 'TelegramBotManager.Files',
      },
    ]);
  };
}
