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

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    StudentFormComponent,
    StudentListComponent,
    InstructorListComponent,
    DefaultHeaderComponent,
    CourseListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    ModalModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
