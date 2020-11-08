import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CoursesPermissionCreateUpdateDto, CoursesPermissionDto, StatusResult } from '../log-courses-permission/models';

@Injectable({
  providedIn: 'root',
})
export class CoursesPermissionService {
  apiName = 'Default';

  addPermissionByIdAndPass = (id: string, pass: string) =>
    this.restService.request<any, StatusResult>({
      method: 'POST',
      url: `/api/app/coursesPermission/${id}/permission`,
      params: { pass: pass },
    },
    { apiName: this.apiName });

  checkCoursesPermissionById = (id: string) =>
    this.restService.request<any, StatusResult>({
      method: 'POST',
      url: `/api/app/coursesPermission/${id}/checkCoursesPermission`,
    },
    { apiName: this.apiName });

  create = (input: CoursesPermissionCreateUpdateDto) =>
    this.restService.request<any, CoursesPermissionDto>({
      method: 'POST',
      url: `/api/app/coursesPermission`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/coursesPermission/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CoursesPermissionDto>({
      method: 'GET',
      url: `/api/app/coursesPermission/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CoursesPermissionDto>>({
      method: 'GET',
      url: `/api/app/coursesPermission`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CoursesPermissionCreateUpdateDto) =>
    this.restService.request<any, CoursesPermissionDto>({
      method: 'PUT',
      url: `/api/app/coursesPermission/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
