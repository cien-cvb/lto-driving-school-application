import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  courses: Course[];

  constructor(private courseService: CourseService) {
    
  }

  ngOnInit(): void {
    this.courseService.refreshNeeded$.subscribe(()=>{
      this.getCourses();
    });

    this.getCourses();
  }

  getCourses(){
    this.courseService.getCourseList().subscribe(res => {
      this.courses = res;
      console.log(this.courses);
    });
   
  }

}
