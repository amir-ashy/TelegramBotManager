import { ReportDto } from './../proxy/bot-manager/models';
import { ReportService } from './../proxy/bot-manager/report.service';
import { AuthService, ListService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { BotStatusReportDto } from '@proxy/bot-manager';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }

  usersReport: ReportDto[];
  filesReport: ReportDto[];
  botStatusReport: BotStatusReportDto[];

  constructor(private oAuthService: OAuthService, private authService: AuthService, private reportService: ReportService) {

  }
  ngOnInit(): void {

    var getUsersData = this.reportService.getMostActiveUserList();
    getUsersData.subscribe(response => this.usersReport = response);

    var getFilesData = this.reportService.getMostUsadedFileList();
    getFilesData.subscribe(response => this.filesReport = response);

    var getBotsData = this.reportService.getBotStatusReportList();
    getBotsData.subscribe(response => this.botStatusReport = response);
  }

  login() {
    this.authService.initLogin();
  }
  onSelect(event) {
    console.log(event);
  }

}

class Data {
  constructor(public name: string, public value: number) {

  }
}
