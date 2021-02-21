import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { Update } from '../telegram/bot/types/models';

@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  apiName = 'Default';

  getInitTelegramService = () =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: `/api/app/telegram/init-telegram-service`,
    },
    { apiName: this.apiName });

  service1ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service1`,
      body: update,
    },
    { apiName: this.apiName });

  service2ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service2`,
      body: update,
    },
    { apiName: this.apiName });

  service3ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service3`,
      body: update,
    },
    { apiName: this.apiName });

  service4ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service4`,
      body: update,
    },
    { apiName: this.apiName });

  service5ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service5`,
      body: update,
    },
    { apiName: this.apiName });

  service6ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service6`,
      body: update,
    },
    { apiName: this.apiName });

  service7ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service7`,
      body: update,
    },
    { apiName: this.apiName });

  service8ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service8`,
      body: update,
    },
    { apiName: this.apiName });

  service9ByUpdate = (update: Update) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/telegram/service9`,
      body: update,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
