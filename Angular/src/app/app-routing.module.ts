import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './views/course/course-list/course-list.component';
import { InstructorListComponent } from './views/instructor/instructor-list/instructor-list.component';
import { StudentListComponent } from './views/student/student-list/student-list.component';

const routes: Routes = [
  {path: 'students', component: StudentListComponent},
  {path: '', redirectTo: 'students', pathMatch: 'full'},
  {path: 'instructors', component: InstructorListComponent},
  {path: 'courses', component: CourseListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
