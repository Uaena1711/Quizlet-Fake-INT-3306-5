import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ServerHttpService } from '../CourseService/server-http.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss'],
  providers: [ListService],

})
export class CourseComponent implements OnInit {

  courses : [];
  constructor(public readonly list: ListService, private Service: ServerHttpService, private router: Router) {
  }

  ngOnInit(): void {
    this.Service.getCourses().subscribe((data =>{
      console.log(data)
      this.courses = data.items
    }))
  };
  public deleteCourse(id){
    this.Service.deleteCourse(id).subscribe((data=>{
      console.log(data);
      this.router.navigate(['courses']);
    }))
   
  }
}
