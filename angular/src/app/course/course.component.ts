import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CourseService, CourseDto } from '@proxy/courses';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss'],
  providers: [ListService],

})
export class CourseComponent implements OnInit {

  course = { items: [], totalCount: 0 } as PagedResultDto<CourseDto>;
  constructor(public readonly list: ListService, private Service: CourseService) {
  }

  ngOnInit(): void {
    const StreamCreator = (query) => this.Service.getList(query);
  
  this.list.hookToQuery(StreamCreator).subscribe((response) => {
    this.course = response;
    console.log('cou',this.course);
    
  });

  }
}
