import { mapEnumToOptions } from '@abp/ng.core';

export enum MessageEntityType {
  Mention = mention,
  Hashtag = hashtag,
  BotCommand = bot_command,
  Url = url,
  Email = email,
  Bold = bold,
  Italic = italic,
  Code = code,
  Pre = pre,
  TextLink = text_link,
  TextMention = text_mention,
  PhoneNumber = phone_number,
  Cashtag = cashtag,
  Unknown = unknown,
  Underline = underline,
  Strikethrough = strikethrough,
}

export const messageEntityTypeOptions = mapEnumToOptions(MessageEntityType);
