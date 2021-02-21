import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { FileType } from './file-type.enum';

export interface BotDto extends FullAuditedEntityDto<string> {
  name?: string;
  isActive: boolean;
  token?: string;
  checkMembership: boolean;
  membershipTargetId?: string;
  serverPathId?: string;
  tenantId?: string;
}

export interface BotStatusReportDto extends EntityDto<string> {
  botName?: string;
  botIsActive: boolean;
  totalFileCount: number;
  totalBotUserCount: number;
  tenantId?: string;
}

export interface FileDto extends FullAuditedEntityDto<string> {
  botId?: string;
  botName?: string;
  code: number;
  name?: string;
  fileUrl?: string;
  shareUrl?: string;
  fileType: FileType;
  tenantId?: string;
}

export interface FileResultRequestDto extends PagedAndSortedResultRequestDto {
  botId?: string;
}

export interface ReportDto extends EntityDto {
  name?: string;
  value: number;


}
