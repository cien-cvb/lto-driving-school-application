import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidebarComponent } from './containers/sidebar/sidebar.component';
import { StudentFormComponent } from './views/student/student-form/student-form.component';
import { StudentListComponent } from './views/student/student-list/student-list.component';
import { InstructorFormComponent } from './views/instructor/instructor-form/instructor-form.component';
import { InstructorListComponent } from './views/instructor/instructor-list/instructor-list.component';
import { NgbdSortableHeader } from './views/student/student-list/sortable.directive';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    StudentFormComponent,
    StudentListComponent,
    InstructorFormComponent,
    InstructorListComponent,
    NgbdSortableHeader, 
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
