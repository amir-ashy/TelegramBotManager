import { BotService } from './../proxy/bot-manager/bot.service';
import { FileService } from './../proxy/bot-manager/file.service';
import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { FileDto, BotDto, FileResultRequestDto } from './../proxy/bot-manager/models';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { FileType, fileTypeOptions } from '@proxy/bot-manager';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.scss'],
  providers: [ListService],
})
export class FileComponent implements OnInit {

  fileList = { items: [], totalCount: 0 } as PagedResultDto<FileDto>;

  form: FormGroup;

  requestBotId: string;
  botList: Observable<BotDto[]>;

  selectedFile = {} as FileDto;

  selectedBot = null as BotDto

  fileTypeList = fileTypeOptions;

  isModalOpen = false;

  constructor(public readonly listService: ListService, private fileService: FileService, private botService: BotService,
    private fb: FormBuilder, private confirmation: ConfirmationService, private route: ActivatedRoute) {
    this.requestBotId = this.route.snapshot.paramMap.get('botId');

    if (this.requestBotId != null) {
      this.botList = botService.get(this.requestBotId).pipe(map((r) => [r]));
      botService.get(this.requestBotId).subscribe(response => this.selectedBot = response);

    }
    else {
      this.botList = botService.getList({} as PagedAndSortedResultRequestDto).pipe(map((r) => r.items));
    }
  }

  ngOnInit(): void {
    const fileStreamCreator = (query) => {
      (query as FileResultRequestDto).botId = this.selectedBot?.id;
      return this.fileService.getList(query);
    };
    this.listService.hookToQuery(fileStreamCreator).subscribe(response => {
      this.fileList = response;
    });

  }
  onBotSelected() {
    this.refresh();
  }

  createFile() {
    this.selectedFile = {} as FileDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  refresh() {

    this.fileList = { items: [], totalCount: 0 } as PagedResultDto<FileDto>;
    this.listService.get();
  }


  editBook(id: string) {
    this.fileService.get(id).subscribe((book) => {
      this.selectedFile = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      botId: [this.selectedFile.botId || (this.selectedBot == null ? null : this.selectedBot.id), Validators.required],
      name: [this.selectedFile.name || '', Validators.required],
      code: [this.selectedFile.code || null, Validators.required],
      fileUrl: [this.selectedFile.fileUrl || '', Validators.required],
      shareUrl: [this.selectedFile.shareUrl || ''],
      fileType: [this.selectedFile.fileType || null, Validators.required],
      tenantId: [this.selectedFile.tenantId || null]
    });
    console.log(this.form);
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.fileService.delete(id).subscribe(() => this.listService.get());
      }
    });
  }

  copyShareurl(id: string) {
    var file = this.fileList.items.find(item => item.id == id);
    this.copyMessage(file.shareUrl);
  }

  copyMessage(val: string) {
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = val;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedFile.id
      ? this.fileService.update(this.selectedFile.id, this.form.value)
      : this.fileService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.listService.get();
    });
  }


}
