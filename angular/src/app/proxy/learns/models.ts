import type { AuditedEntityDto } from '@abp/ng.core';

export interface LearnCreateUpdateDto {
  userId: string;
  wordId: string;
  lessonId: string;
  dateReview: string;
  dateofLearn: string;
  level: number;
  note: string;
}

export interface LearnDto extends AuditedEntityDto<string> {
  userId: string;
  wordId: string;
  dateReview: string;
  dateofLearn: string;
  level: number;
  note: string;
  vn: string;
  en: string;
}

export interface TestDto {
  wordsList: string[];
  isright: boolean[];
}
