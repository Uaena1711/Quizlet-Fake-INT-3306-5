import type { LessonInfoOfUserCreateUpdateDto, LessonInfoOfUserDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LessonInfoOfUserService {
  apiName = 'Default';

  create = (input: LessonInfoOfUserCreateUpdateDto) =>
    this.restService.request<any, LessonInfoOfUserDto>({
      method: 'POST',
      url: `/api/app/lessonInfoOfUser`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/lessonInfoOfUser/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, LessonInfoOfUserDto>({
      method: 'GET',
      url: `/api/app/lessonInfoOfUser/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LessonInfoOfUserDto>>({
      method: 'GET',
      url: `/api/app/lessonInfoOfUser`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMyLessonListByIdcourse = (idcourse: string) =>
    this.restService.request<any, LessonInfoOfUserDto[]>({
      method: 'GET',
      url: `/api/app/lessonInfoOfUser/myLessonList`,
      params: { idcourse: idcourse },
    },
    { apiName: this.apiName });

  learnLessonByIdlesson = (idlesson: string) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/lessonInfoOfUser/learnLesson`,
      params: { idlesson: idlesson },
    },
    { apiName: this.apiName });

  update = (id: string, input: LessonInfoOfUserCreateUpdateDto) =>
    this.restService.request<any, LessonInfoOfUserDto>({
      method: 'PUT',
      url: `/api/app/lessonInfoOfUser/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
