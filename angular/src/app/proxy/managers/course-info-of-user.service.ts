import type { CourseInfoOfUserCreateUpdateDto, CourseInfoOfUserDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CourseInfoOfUserService {
  apiName = 'Default';

  create = (input: CourseInfoOfUserCreateUpdateDto) =>
    this.restService.request<any, CourseInfoOfUserDto>({
      method: 'POST',
      url: `/api/app/courseInfoOfUser`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/courseInfoOfUser/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CourseInfoOfUserDto>({
      method: 'GET',
      url: `/api/app/courseInfoOfUser/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CourseInfoOfUserDto>>({
      method: 'GET',
      url: `/api/app/courseInfoOfUser`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getmyLearningCourse = () =>
    this.restService.request<any, CourseInfoOfUserDto[]>({
      method: 'GET',
      url: `/api/app/courseInfoOfUser/myLearningCourse`,
    },
    { apiName: this.apiName });

  outCourseByIdCOurse = (IdCOurse: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/courseInfoOfUser/outCourse`,
      params: { idCOurse: IdCOurse },
    },
    { apiName: this.apiName });

  update = (id: string, input: CourseInfoOfUserCreateUpdateDto) =>
    this.restService.request<any, CourseInfoOfUserDto>({
      method: 'PUT',
      url: `/api/app/courseInfoOfUser/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
