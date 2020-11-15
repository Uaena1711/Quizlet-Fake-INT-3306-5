import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ServerHttpService } from '../LessionService/server-http.service';


@Component({
  selector: 'app-lession',
  templateUrl: './lession.component.html',
  styleUrls: ['./course.component.scss']
})
export class LessionComponent implements OnInit {
  nameCourse: '';
  lession: [];
  constructor(private route : ActivatedRoute,
              private Service : ServerHttpService,
              private dialog: MatDialog
    ) { }

  ngOnInit(): void {
   this.nameCourse =  this.route.snapshot.params.nameCourse;
   this.Service.idCourse = this.route.snapshot.params.idcourse;
   this.Service.getLessionOfCourse(this.Service.idCourse).subscribe((data =>{
     this.lession = data;
   }))
  }
  public openDialog(){
    this.dialog.open(LessionCreateComponent, {
      height: '300px' ,
      width: '500px'
    });
    this.Service.addMode = true;
    this.Service.idLession = '';
    this.Service.name = '';
  }
  public openDialogEdit(id, name){
    this.dialog.open(LessionCreateComponent, {
      height: '300px' ,
      width: '500px'
    });
    this.Service.addMode= false;
    this.Service.idLession= id;
    this.Service.name = name;
  }
  public deleteLession(id){
    this.Service.deleteLession(id).subscribe((data =>{
      console.log(data);
      location.reload();
    }))
  }
}
 @Component({
   selector: 'LessionCreateComponent',
   templateUrl: './LessionCreate.component.html',
   styleUrls: ['./course.component.scss'],
 })
 export class LessionCreateComponent implements OnInit {
  form: FormGroup;
  name: '';
  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private Service: ServerHttpService,

  ){}
  ngOnInit(){
    this.name = this.Service.name;
    this.form = this.fb.group({
      name: this.name
    })
  }
  public closeDialog() {
    this.dialog.closeAll();
  }
  public save(){
    if(this.Service.addMode === false){
      this.name = this.form.controls.name.value;
      this.Service.editLession({
        "name": this.name,
        "courseId": this.Service.idCourse,
      }, this.Service.idLession).subscribe((data=>{
        console.log(data);
        location.reload();
      }))
    } else{
    this.name = this.form.controls.name.value;
    this.Service.addLession({
      "name": this.name,
      "courseId": this.Service.idCourse
    }).subscribe((data=>{
      console.log(data);
      location.reload();
    }))
   }
  }
 }