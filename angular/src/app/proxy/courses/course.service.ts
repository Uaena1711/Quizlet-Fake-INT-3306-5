import type { CourseCreateUpdateDto, CourseDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  apiName = 'Default';

  create = (input: CourseCreateUpdateDto) =>
    this.restService.request<any, CourseDto>({
      method: 'POST',
      url: `/api/app/course`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/course/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CourseDto>({
      method: 'GET',
      url: `/api/app/course/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CourseDto>>({
      method: 'GET',
      url: `/api/app/course`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CourseCreateUpdateDto) =>
    this.restService.request<any, CourseDto>({
      method: 'PUT',
      url: `/api/app/course/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
