import { BotService } from './../proxy/bot-manager/bot.service';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { BotDto } from './../proxy/bot-manager/models';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bot',
  templateUrl: './bot.component.html',
  styleUrls: ['./bot.component.scss'],
  providers: [ListService],
})
export class BotComponent implements OnInit {

  botList = { items: [], totalCount: 0 } as PagedResultDto<BotDto>;

  form: FormGroup;
  selectedBot = {} as BotDto;

  isModalOpen = false;

  constructor(public readonly listService: ListService, private botService: BotService, private fb: FormBuilder,
    private confirmation: ConfirmationService, private router: Router) { }

  ngOnInit(): void {
    const botStreamCreator = (query) => this.botService.getList(query);
    this.listService.hookToQuery(botStreamCreator).subscribe(response => {
      this.botList = response;
    });

  }

  createBot() {
    this.selectedBot = {} as BotDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  refresh() {
    this.botList = { items: [], totalCount: 0 } as PagedResultDto<BotDto>;
    this.listService.get();
  }


  editBook(id: string) {
    this.botService.get(id).subscribe((book) => {
      this.selectedBot = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedBot.name || '', Validators.required],
      token: [this.selectedBot.token || '', Validators.required],
      isActive: [this.selectedBot.isActive || false, Validators.required],
      checkMembership: [this.selectedBot.checkMembership || false, Validators.required],
      membershipTargetId: [this.selectedBot.membershipTargetId || ''],
      tenantId: [this.selectedBot.tenantId || null],
      serverPathId: [this.selectedBot.serverPathId || null],
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.botService.delete(id).subscribe(() => this.listService.get());
      }
    });
  }
  navigateToFile(id: string) {
    this.router.navigate(['files', { botId: id }]);
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedBot.id
      ? this.botService.update(this.selectedBot.id, this.form.value)
      : this.botService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.listService.get();
    });
  }

}
