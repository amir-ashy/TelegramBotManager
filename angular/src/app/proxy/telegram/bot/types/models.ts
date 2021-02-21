import type { ChatType } from './enums/chat-type.enum';
import type { MaskPositionPoint } from './enums/mask-position-point.enum';
import type { Invoice, PreCheckoutQuery, ShippingQuery, SuccessfulPayment } from './payments/models';
import type { PassportData } from './passport/models';
import type { InlineKeyboardMarkup } from './reply-markups/models';
import type { MessageType } from './enums/message-type.enum';
import type { MessageEntityType } from './enums/message-entity-type.enum';
import type { UpdateType } from './enums/update-type.enum';

export interface Animation {
  fileId?: string;
  fileUniqueId?: string;
  width: number;
  height: number;
  duration: number;
  thumb: PhotoSize;
  fileName?: string;
  mimeType?: string;
  fileSize: number;
}

export interface Audio extends FileBase {
  duration: number;
  performer?: string;
  title?: string;
  mimeType?: string;
  thumb: PhotoSize;
}

export interface CallbackQuery {
  id?: string;
  from: User;
  message: Message;
  inlineMessageId?: string;
  chatInstance?: string;
  data?: string;
  gameShortName?: string;
  isGameQuery: boolean;
}

export interface Chat {
  id: number;
  type: ChatType;
  title?: string;
  username?: string;
  firstName?: string;
  lastName?: string;
  allMembersAreAdministrators: boolean;
  photo: ChatPhoto;
  description?: string;
  inviteLink?: string;
  pinnedMessage: Message;
  permissions: ChatPermissions;
  slowModeDelay?: number;
  stickerSetName?: string;
  canSetStickerSet?: boolean;
}

export interface ChatPermissions {
  canSendMessages?: boolean;
  canSendMediaMessages?: boolean;
  canSendPolls?: boolean;
  canSendOtherMessages?: boolean;
  canAddWebPagePreviews?: boolean;
  canChangeInfo?: boolean;
  canInviteUsers?: boolean;
  canPinMessages?: boolean;
}

export interface ChatPhoto {
  bigFileId?: string;
  bigFileUniqueId?: string;
  smallFileId?: string;
  smallFileUniqueId?: string;
}

export interface ChosenInlineResult {
  resultId?: string;
  from: User;
  location: Location;
  inlineMessageId?: string;
  query?: string;
}

export interface Contact {
  phoneNumber?: string;
  firstName?: string;
  lastName?: string;
  userId: number;
  vcard?: string;
}

export interface Dice {
  emoji?: string;
  value: number;
}

export interface Document extends FileBase {
  thumb: PhotoSize;
  fileName?: string;
  mimeType?: string;
}

export interface FileBase {
  fileId?: string;
  fileUniqueId?: string;
  fileSize: number;
}

export interface Game {
  title?: string;
  description?: string;
  photo: PhotoSize[];
  text?: string;
  textEntities: MessageEntity[];
  animation: Animation;
}

export interface InlineQuery {
  id?: string;
  from: User;
  query?: string;
  location: Location;
  offset?: string;
}

export interface Location {
  longitude: number;
  latitude: number;
}

export interface MaskPosition {
  point: MaskPositionPoint;
  xShift: number;
  yShift: number;
  scale: number;
}

export interface Message {
  messageId: number;
  from: User;
  unixDateTime?: number;
  date?: string;
  chat: Chat;
  isForwarded: boolean;
  forwardFrom: User;
  forwardFromChat: Chat;
  forwardFromMessageId: number;
  forwardSignature?: string;
  forwardSenderName?: string;
  forwardDate?: string;
  replyToMessage: Message;
  viaBot: User;
  editDate?: string;
  mediaGroupId?: string;
  authorSignature?: string;
  text?: string;
  entities: MessageEntity[];
  entityValues: string[];
  captionEntities: MessageEntity[];
  captionEntityValues: string[];
  audio: Audio;
  document: Document;
  animation: Animation;
  game: Game;
  photo: PhotoSize[];
  sticker: Sticker;
  video: Video;
  voice: Voice;
  videoNote: VideoNote;
  caption?: string;
  contact: Contact;
  location: Location;
  venue: Venue;
  poll: Poll;
  dice: Dice;
  newChatMembers: User[];
  leftChatMember: User;
  newChatTitle?: string;
  newChatPhoto: PhotoSize[];
  deleteChatPhoto: boolean;
  groupChatCreated: boolean;
  supergroupChatCreated: boolean;
  channelChatCreated: boolean;
  migrateToChatId: number;
  migrateFromChatId: number;
  pinnedMessage: Message;
  invoice: Invoice;
  successfulPayment: SuccessfulPayment;
  connectedWebsite?: string;
  passportData: PassportData;
  replyMarkup: InlineKeyboardMarkup;
  type: MessageType;
}

export interface MessageEntity {
  type: MessageEntityType;
  offset: number;
  length: number;
  url?: string;
  user: User;
  language?: string;
}

export interface PhotoSize extends FileBase {
  width: number;
  height: number;
}

export interface Poll {
  id?: string;
  question?: string;
  options: PollOption[];
  totalVoterCount: number;
  isClosed: boolean;
  isAnonymous: boolean;
  type?: string;
  allowsMultipleAnswers: boolean;
  correctOptionId?: number;
  explanation?: string;
  explanationEntities: MessageEntity[];
  openPeriod?: number;
  closeDate?: string;
}

export interface PollAnswer {
  pollId?: string;
  user: User;
  optionIds: number[];
}

export interface PollOption {
  text?: string;
  voterCount: number;
}

export interface Sticker extends FileBase {
  width: number;
  height: number;
  isAnimated: boolean;
  thumb: PhotoSize;
  emoji?: string;
  setName?: string;
  maskPosition: MaskPosition;
}

export interface Update {
  id: number;
  message: Message;
  editedMessage: Message;
  inlineQuery: InlineQuery;
  chosenInlineResult: ChosenInlineResult;
  callbackQuery: CallbackQuery;
  channelPost: Message;
  editedChannelPost: Message;
  shippingQuery: ShippingQuery;
  preCheckoutQuery: PreCheckoutQuery;
  poll: Poll;
  pollAnswer: PollAnswer;
  type: UpdateType;
}

export interface User {
  id: number;
  isBot: boolean;
  firstName?: string;
  lastName?: string;
  username?: string;
  languageCode?: string;
  canJoinGroups?: boolean;
  canReadAllGroupMessages?: boolean;
  supportsInlineQueries?: boolean;
}

export interface Venue {
  location: Location;
  title?: string;
  address?: string;
  foursquareId?: string;
  foursquareType?: string;
}

export interface Video extends FileBase {
  width: number;
  height: number;
  duration: number;
  thumb: PhotoSize;
  mimeType?: string;
}

export interface VideoNote extends FileBase {
  length: number;
  duration: number;
  thumb: PhotoSize;
}

export interface Voice extends FileBase {
  duration: number;
  mimeType?: string;
}
