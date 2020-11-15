import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CourseService, CourseDto } from '@proxy/courses';
import { query } from '@angular/animations';
import { ServerHttpService } from '../CourseService/server-http.service';
import {MatDialog} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';



@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss'],
  providers: [ListService],

})
export class CourseComponent implements OnInit {
  courses: [];
  constructor(public readonly list: ListService, 
              private Service: ServerHttpService, 
              private router: Router,
              private dialog: MatDialog
              ) {
  }

  ngOnInit(): void {
    this.Service.getCourses().subscribe((data =>{
      console.log(data);
      this.courses = data;
    }))
  };
  public openDialog() {
    this.dialog.open(CourseCreateComponent, {
      height: '400px',
      width: '500px',
    });
    this.Service.addMode = true;
    this.Service.idCourse = '';
    this.Service.name = '';
  }
  public openDialogEdit(id,name, userId, publishDate, price, creationTime, creatorId){
    this.dialog.open(CourseCreateComponent, {
      height: '400px',
      width: '500px',
    });
    this.Service.addMode = false;
    this.Service.idCourse = id;
    this.Service.name = name;
    this.Service.userId = userId;
    this.Service.publishDate = publishDate;
    this.Service.price = price;
    this.Service.creationTime = creationTime;
    this.Service.creatorId = creatorId;
  }
  public deleteCourse(id){
    this.Service.deleteCourse(id).subscribe((data=>{
      console.log(data);
      location.reload();
    }))
  }
}
@Component({
  selector: 'CourseCreateComponent',
  templateUrl: './CourseCreate.component.html',
  styleUrls: ['./course.component.scss'],
})
export class CourseCreateComponent implements OnInit {
  form: FormGroup;
  hide = true;
  name: '';
  password: '';
  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private Service: ServerHttpService, 
    private router: Router,
    ) {
  }
  ngOnInit(){
    this.name = this.Service.name;
    this.form = this.fb.group({
     name: this.name,
     password: this.password
    })
  }
  public closeDialog() {
    this.dialog.closeAll();
  }
  public save(){
    if (this.Service.addMode === false){
      this.name = this.form.controls.name.value;
      this.password = this.form.controls.password.value;
      this.Service.editCourse(
        {
          "name" :this.name, 
          "password": this.password,
          "userId" : this.Service.userId,
          "publishDate" : this.Service.publishDate,
          "price": this.Service.price,
          "creationTime": this.Service.creationTime,
          "creatorId" : this.Service.creatorId
        }, this.Service.idCourse
        ).subscribe((data=>{
        console.log(data);
        location.reload();
      }));
    } else {
    this.name = this.form.controls.name.value;
    this.password = this.form.controls.password.value;
    this.Service.addCourse(
        {
          "name" :this.name,
          "password": this.password
        }
        ).subscribe((data =>{
        console.log(data);
        location.reload();
        }));
    }
  }

}

