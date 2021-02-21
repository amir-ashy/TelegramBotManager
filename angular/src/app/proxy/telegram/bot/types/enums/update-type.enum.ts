import { mapEnumToOptions } from '@abp/ng.core';

export enum UpdateType {
  Unknown = unknown,
  Message = message,
  InlineQuery = inline_query,
  ChosenInlineResult = chosen_inline_result,
  CallbackQuery = callback_query,
  EditedMessage = edited_message,
  ChannelPost = channel_post,
  EditedChannelPost = edited_channel_post,
  ShippingQuery = shipping_query,
  PreCheckoutQuery = pre_checkout_query,
  Poll = poll,
  PollAnswer = poll_answer,
}

export const updateTypeOptions = mapEnumToOptions(UpdateType);
