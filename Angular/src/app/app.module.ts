import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidebarComponent } from './containers/sidebar/sidebar.component';
import { StudentFormComponent } from './views/student/student-form/student-form.component';
import { StudentListComponent } from './views/student/student-list/student-list.component';
import { InstructorListComponent } from './views/instructor/instructor-list/instructor-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DefaultHeaderComponent } from './containers/default-header/default-header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from "ngx-bootstrap/modal";
import { CourseListComponent } from './views/course/course-list/course-list.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { CourseFormComponent } from './views/course/course-form/course-form.component';
import { EnrollmentListComponent } from './views/enrollment/enrollment-list/enrollment-list.component';
import { InstructorFormComponent } from './views/instructor/instructor-form/instructor-form.component';
import { ToastrModule } from 'ngx-toastr';
import { StudentDetailsComponent } from './views/student/student-details/student-details.component';
import { InstuctorDetailsComponent } from './views/instructor/instuctor-details/instuctor-details.component';
import { EnrollmentFormComponent } from './views/enrollment/enrollment-form/enrollment-form.component';
import { CertificatesComponent } from './views/certificate/certificates/certificates.component';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';
import { PdfViewerComponent } from './views/pdf-viewer/pdf-viewer.component';
import { NgxPrintModule } from 'ngx-print';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { LoginComponent } from './views/login/login.component';
import { ReportsComponent } from './views/reports/reports.component';


@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    StudentFormComponent,
    StudentListComponent,
    InstructorListComponent,
    DefaultHeaderComponent,
    CourseListComponent,
    DashboardComponent,
    CourseFormComponent,
    EnrollmentListComponent,
    InstructorFormComponent,
    StudentDetailsComponent,
    InstuctorDetailsComponent,
    EnrollmentFormComponent,
    CertificatesComponent,
    PdfViewerComponent,
    LoginComponent,
    ReportsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    ModalModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgxPrintModule,
    NgxExtendedPdfViewerModule,
    PdfViewerModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
