import type { FileBase } from '../models';

export interface EncryptedCredentials {
  data?: string;
  hash?: string;
  secret?: string;
}

export interface EncryptedPassportElement {
  type?: string;
  hash?: string;
  data?: string;
  phoneNumber?: string;
  email?: string;
  files: PassportFile[];
  frontSide: PassportFile;
  reverseSide: PassportFile;
  selfie: PassportFile;
  translation: PassportFile[];
}

export interface PassportData {
  data: EncryptedPassportElement[];
  credentials: EncryptedCredentials;
}

export interface PassportFile extends FileBase {
  fileDate?: string;
}
