import { mapEnumToOptions } from '@abp/ng.core';

export enum MaskPositionPoint {
  Forehead = forehead,
  Eyes = eyes,
  Mouth = mouth,
  Chin = chin,
}

export const maskPositionPointOptions = mapEnumToOptions(MaskPositionPoint);
