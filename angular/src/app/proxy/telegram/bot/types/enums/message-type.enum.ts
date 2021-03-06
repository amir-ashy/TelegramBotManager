import { mapEnumToOptions } from '@abp/ng.core';

export enum MessageType {
  Unknown = unknown,
  Text = text,
  Photo = photo,
  Audio = audio,
  Video = video,
  Voice = voice,
  Document = document,
  Sticker = sticker,
  Location = location,
  Contact = contact,
  Venue = venue,
  Game = game,
  VideoNote = video_note,
  Invoice = invoice,
  SuccessfulPayment = successful_payment,
  WebsiteConnected = website_connected,
  ChatMembersAdded = chat_members_added,
  ChatMemberLeft = chat_member_left,
  ChatTitleChanged = chat_title_changed,
  ChatPhotoChanged = chat_photo_changed,
  MessagePinned = message_pinned,
  ChatPhotoDeleted = chat_photo_deleted,
  GroupCreated = group_created,
  SupergroupCreated = supergroup_created,
  ChannelCreated = channel_created,
  MigratedToSupergroup = migrated_to_supergroup,
  MigratedFromGroup = migrated_from_group,
  Animation = animation,
  Poll = poll,
  Dice = dice,
}

export const messageTypeOptions = mapEnumToOptions(MessageType);
