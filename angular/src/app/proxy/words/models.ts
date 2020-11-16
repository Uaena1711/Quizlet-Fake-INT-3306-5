import type { AuditedAggregateRoot } from '../volo/abp/domain/entities/auditing/models';
import type { AuditedEntityDto } from '@abp/ng.core';

export interface Word extends AuditedAggregateRoot<string> {
  name: string;
  vn: string;
  en: string;
  lessonId: string;
}

export interface WordCreateOrUpdateDto {
  name: string;
  vn: string;
  en: string;
  lessonId: string;
}

export interface WordDto extends AuditedEntityDto<string> {
  name: string;
  vn: string;
  en: string;
  lessonId: string;
}
