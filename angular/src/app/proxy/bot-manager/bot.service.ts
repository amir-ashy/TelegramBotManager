import type { BotDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BotService {
  apiName = 'Default';

  assignServicePathByInput = (input: BotDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/bot/assign-service-path`,
      body: input,
    },
    { apiName: this.apiName });

  create = (input: BotDto) =>
    this.restService.request<any, BotDto>({
      method: 'POST',
      url: `/api/app/bot`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/bot/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, BotDto>({
      method: 'GET',
      url: `/api/app/bot/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<BotDto>>({
      method: 'GET',
      url: `/api/app/bot`,
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: BotDto) =>
    this.restService.request<any, BotDto>({
      method: 'PUT',
      url: `/api/app/bot/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
