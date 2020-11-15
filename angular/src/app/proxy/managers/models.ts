import type { AuditedEntityDto } from '@abp/ng.core';

export interface CourseInfoOfUserCreateUpdateDto {
  courseId: string;
  userId: string;
  progress: number;
}

export interface CourseInfoOfUserDto extends AuditedEntityDto<string> {
  courseId: string;
  userId: string;
  coursename: string;
  progress: number;
}

export interface LessonInfoOfUserCreateUpdateDto {
  lessonId: string;
  userId: string;
  progress: number;
}

export interface LessonInfoOfUserDto extends AuditedEntityDto<string> {
  lessonId: string;
  userId: string;
  progress: number;
  lessonName: string;
}
