import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { Lesson } from '../lessons/models';
import type { LessionCreateorUpdateDto, LessionDto } from '../lesssion/models';

@Injectable({
  providedIn: 'root',
})
export class LessionService {
  apiName = 'Default';

  create = (input: LessionCreateorUpdateDto) =>
    this.restService.request<any, LessionDto>({
      method: 'POST',
      url: `/api/app/lession`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/lession/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, LessionDto>({
      method: 'GET',
      url: `/api/app/lession/${id}`,
    },
    { apiName: this.apiName });

  getLessionOfCoursesById = (id: string) =>
    this.restService.request<any, Lesson[]>({
      method: 'GET',
      url: `/api/app/lession/${id}/lessionOfCourses`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LessionDto>>({
      method: 'GET',
      url: `/api/app/lession`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: LessionCreateorUpdateDto) =>
    this.restService.request<any, LessionDto>({
      method: 'PUT',
      url: `/api/app/lession/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
