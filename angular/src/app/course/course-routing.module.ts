import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CourseComponent } from './course.component';
import { LessionComponent } from './lession.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { WordComponent } from './word.component';

const routes: Routes =
[
  { path: '', component: CourseComponent  },
  { path: ':nameCourse/:idcourse', component: LessionComponent,  canActivate: [AuthGuard, PermissionGuard]},
  { path: ':nameCourse/:idcourse/lession/:nameLession/:idLession', component: WordComponent,  canActivate: [AuthGuard, PermissionGuard]}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
