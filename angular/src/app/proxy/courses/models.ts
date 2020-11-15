import type { AuditedAggregateRoot } from '../volo/abp/domain/entities/auditing/models';
import type { AuditedEntityDto } from '@abp/ng.core';

export interface Course extends AuditedAggregateRoot<string> {
  name: string;
  password: string;
  userId: string;
  publishDate: string;
  price: number;
  wordnumber: number;
}

export interface CourseCreateUpdateDto {
  name: string;
  password: string;
  publishDate: string;
  userId: string;
  price: number;
}

export interface CourseDto extends AuditedEntityDto<string> {
  name: string;
  userId: string;
  publishDate: string;
  price: number;
  wordnumber: number;
}
