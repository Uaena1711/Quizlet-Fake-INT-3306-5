import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CourseService, CourseDto } from '@proxy/courses';



@Component({
  selector: 'app-course',
  templateUrl: './search.conponent.html',
  styleUrls: ['./search.conponent.css'],
  providers: [ListService],

})
export class SearchComponent implements OnInit {
  total: number;
  text: '';
  isSearch: boolean;
  course = { items: [], totalCount: 0 } as PagedResultDto<CourseDto>;
  constructor(public readonly list: ListService, private Service: CourseService) {
  }

  ngOnInit(): void {
    this.isSearch = false;

  }
  search(text: string){
    const StreamCreator = (query) => this.Service.getListssssByInputAndText(query, text);
    this.list.hookToQuery(StreamCreator).subscribe((response) => {
      this.course = response;
    });
    this.total = this.course.totalCount;
    console.log(this.course);
    this.isSearch = true;
  }
}
