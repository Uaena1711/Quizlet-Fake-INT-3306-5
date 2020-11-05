import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ServerHttpService } from '../CourseService/server-http.service';


@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss'],
  providers: [ListService],

})
export class CourseComponent implements OnInit {

  courses : [];
  constructor(public readonly list: ListService, private Service: ServerHttpService) {
  }

  ngOnInit(): void {
    this.Service.getCourses().subscribe((data =>{
      console.log(data)
      this.courses = data.items
    }))
  };
}
