import { mapEnumToOptions } from '@abp/ng.core';

export enum BaseResult {
  NeedPermission = 0,
  NoPermission = 1,
  Ok = 2,
}

export const baseResultOptions = mapEnumToOptions(BaseResult);
