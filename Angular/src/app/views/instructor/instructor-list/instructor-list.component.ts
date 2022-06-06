import { Component, OnInit } from '@angular/core';
import { Instructor } from 'src/app/models/instructor';
import { InstuctorService } from 'src/app/services/instuctor.service';

@Component({
  selector: 'app-instructor-list',
  templateUrl: './instructor-list.component.html',
  styleUrls: ['./instructor-list.component.css'],
  providers: []
})
export class InstructorListComponent implements OnInit {

  instructors: Instructor[];

  constructor(private instructorService: InstuctorService) {
    
  }

  ngOnInit(): void {
    this.instructorService.refreshNeeded$.subscribe(()=>{
      this.getInstructors();
    });

    this.getInstructors();
  }

  getInstructors(){
    this.instructorService.getInstructorList().subscribe(res => {
      this.instructors = res;
      console.log(this.instructors);
    });
   
  }
}
