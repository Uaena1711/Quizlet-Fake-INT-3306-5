import type { AuditedAggregateRoot } from '../volo/abp/domain/entities/auditing/models';

export interface Lesson extends AuditedAggregateRoot<string> {
  name: string;
  courseId: string;
}
