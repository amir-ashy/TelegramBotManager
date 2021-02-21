import type { BotStatusReportDto, ReportDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ReportService {
  apiName = 'Default';

  getBotStatusReportList = () =>
    this.restService.request<any, BotStatusReportDto[]>({
      method: 'GET',
      url: `/api/app/report/bot-status-report-list`,
    },
    { apiName: this.apiName });

  getMostActiveUserList = () =>
    this.restService.request<any, ReportDto[]>({
      method: 'GET',
      url: `/api/app/report/most-active-user-list`,
    },
    { apiName: this.apiName });

  getMostUsadedFileList = () =>
    this.restService.request<any, ReportDto[]>({
      method: 'GET',
      url: `/api/app/report/most-usaded-file-list`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
