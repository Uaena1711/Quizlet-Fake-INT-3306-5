import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllCourseComponent } from './all-course.component';

import { CourseComponent } from './course.component';
import { LessionComponent } from './lession.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { WordComponent } from './word.component';

const routes: Routes =
[

  { path: 'course', component: CourseComponent},
  { path: '', component: AllCourseComponent},
  { path: 'course/:nameCourse/:idcourse', component: LessionComponent},
  { path: 'course/:nameCourse/:idcourse/lession/:nameLession/:idLession', component: WordComponent},
  { path: ':nameCourse/:idcourse', component: LessionComponent,  canActivate: [AuthGuard, PermissionGuard]},
  { path: ':nameCourse/:idcourse/lession/:nameLession/:idLession', component: WordComponent,  canActivate: [AuthGuard, PermissionGuard]}


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
