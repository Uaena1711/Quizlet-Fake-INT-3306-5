import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CourseRoutingModule } from './course-routing.module';
import { CourseComponent, CourseCreateComponent } from './course.component';

import { ReactiveFormsModule } from '@angular/forms';
import { LessionComponent, LessionCreateComponent } from './lession.component';
import { WordComponent } from './word.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AllCourseComponent, CourseCheckPassComponent } from './all-course.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {TestComponent} from'./test/test.component'




@NgModule({
  imports: [
    CommonModule,
    CourseRoutingModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MDBBootstrapModule,
    NgbModule
  ],
  declarations: [CourseComponent,CourseCreateComponent, LessionComponent, LessionCreateComponent, AllCourseComponent, WordComponent,TestComponent,
    CourseCheckPassComponent]
  
})
export class CourseModule { }
