import type { Word, WordCreateOrUpdateDto, WordDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class WordService {
  apiName = 'Default';

  create = (input: WordCreateOrUpdateDto) =>
    this.restService.request<any, WordDto>({
      method: 'POST',
      url: `/api/app/word`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/word/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, WordDto>({
      method: 'GET',
      url: `/api/app/word/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<WordDto>>({
      method: 'GET',
      url: `/api/app/word`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getWordOfLessionById = (id: string) =>
    this.restService.request<any, Word[]>({
      method: 'GET',
      url: `/api/app/word/${id}/wordOfLession`,
    },
    { apiName: this.apiName });

  update = (id: string, input: WordCreateOrUpdateDto) =>
    this.restService.request<any, WordDto>({
      method: 'PUT',
      url: `/api/app/word/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
