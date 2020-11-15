import type { LearnCreateUpdateDto, LearnDto, TestDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LearnService {
  apiName = 'Default';

  create = (input: LearnCreateUpdateDto) =>
    this.restService.request<any, LearnDto>({
      method: 'POST',
      url: `/api/app/learn`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/learn/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, LearnDto>({
      method: 'GET',
      url: `/api/app/learn/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LearnDto>>({
      method: 'GET',
      url: `/api/app/learn`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getMyReviewByFrom = (from: number) =>
    this.restService.request<any, LearnDto[]>({
      method: 'GET',
      url: `/api/app/learn/myReview`,
      params: { from: from },
    },
    { apiName: this.apiName });

  getMyWortdListByLearnid = (learnid: string) =>
    this.restService.request<any, LearnDto[]>({
      method: 'GET',
      url: `/api/app/learn/myWortdList`,
      params: { learnid: learnid },
    },
    { apiName: this.apiName });

  testResultByTestDto = (testDto: TestDto) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: `/api/app/learn/testResult`,
      body: testDto,
    },
    { apiName: this.apiName });

  update = (id: string, input: LearnCreateUpdateDto) =>
    this.restService.request<any, LearnDto>({
      method: 'PUT',
      url: `/api/app/learn/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  updateLevelLearningWordByIdwordAndB = (idword: string, b: boolean) =>
    this.restService.request<any, LearnDto>({
      method: 'PUT',
      url: `/api/app/learn/levelLearningWord`,
      params: { idword: idword, b: b },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
