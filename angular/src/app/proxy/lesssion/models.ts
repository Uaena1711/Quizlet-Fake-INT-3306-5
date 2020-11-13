import type { AuditedEntityDto } from '@abp/ng.core';

export interface LessionCreateorUpdateDto {
  name: string;
  courseId: string;
}

export interface LessionDto extends AuditedEntityDto<string> {
  name: string;
  courseId: string;
}
