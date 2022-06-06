import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './views/course/course-list/course-list.component';
import { InstructorListComponent } from './views/instructor/instructor-list/instructor-list.component';
import { StudentListComponent } from './views/student/student-list/student-list.component';
import { DashboardComponent } from './views/dashboard/dashboard.component'; 
import { EnrollmentListComponent } from './views/enrollment/enrollment-list/enrollment-list.component';
import { StudentDetailsComponent } from './views/student/student-details/student-details.component';
import { CertificatesComponent } from './views/certificate/certificates/certificates.component';

const routes: Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: 'students', component: StudentListComponent},
  {path: 'instructors', component: InstructorListComponent},
  {path: 'courses', component: CourseListComponent},
  {path: 'enrollment', component: EnrollmentListComponent},
  {path: 'student-details/:id', component: StudentDetailsComponent},
  {path: 'certificates', component: CertificatesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
