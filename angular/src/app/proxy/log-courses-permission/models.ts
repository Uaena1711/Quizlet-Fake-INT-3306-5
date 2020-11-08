import type { AuditedEntityDto } from '@abp/ng.core';
import type { BaseResult } from './base-result.enum';

export interface CoursesPermissionCreateUpdateDto {
  courseId: string;
  userId: string;
}

export interface CoursesPermissionDto extends AuditedEntityDto<string> {
  courseId: string;
  userId: string;
}

export interface StatusResult {
  result: BaseResult;
}
