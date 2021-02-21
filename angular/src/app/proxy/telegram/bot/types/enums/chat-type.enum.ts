import { mapEnumToOptions } from '@abp/ng.core';

export enum ChatType {
  Private = private,
  Group = group,
  Channel = channel,
  Supergroup = supergroup,
}

export const chatTypeOptions = mapEnumToOptions(ChatType);
