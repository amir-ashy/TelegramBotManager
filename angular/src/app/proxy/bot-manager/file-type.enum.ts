import { mapEnumToOptions } from '@abp/ng.core';

export enum FileType {
  Audio = 0,
  Video = 1,
  Document = 2,
  Image = 3,
}

export const fileTypeOptions = mapEnumToOptions(FileType);
