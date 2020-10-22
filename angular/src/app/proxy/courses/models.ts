import type { AuditedEntityDto } from '@abp/ng.core';

export interface CourseCreateUpdateDto {
  name: string;
  password: string;
  publishDate: string;
  userId: string;
  price: number;
}

export interface CourseDto extends AuditedEntityDto<string> {
  name: string;
  password: string;
  userId: string;
  publishDate: string;
  price: number;
}
