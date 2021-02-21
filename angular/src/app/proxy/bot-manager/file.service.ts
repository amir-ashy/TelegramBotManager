import type { FileDto, FileResultRequestDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FileService {
  apiName = 'Default';

  create = (input: FileDto) =>
    this.restService.request<any, FileDto>({
      method: 'POST',
      url: `/api/app/file`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/file/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, FileDto>({
      method: 'GET',
      url: `/api/app/file/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: FileResultRequestDto) =>
    this.restService.request<any, PagedResultDto<FileDto>>({
      method: 'GET',
      url: `/api/app/file`,
      params: { botId: input.botId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: FileDto) =>
    this.restService.request<any, FileDto>({
      method: 'PUT',
      url: `/api/app/file/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
