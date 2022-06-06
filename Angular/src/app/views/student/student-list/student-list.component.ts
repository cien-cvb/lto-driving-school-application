import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
})
export class StudentListComponent implements OnInit {

  id: number;
  students: Student[];
  student: Student;

  constructor(private studentService: StudentService, private router: Router) {
    
  }

  ngOnInit(): void {
    this.studentService.refreshNeeded$.subscribe(()=>{
      this.getStudents();
    });

    this.getStudents();
  }

  getStudents(){
    this.studentService.getStudentList().subscribe(res => {
      this.students = res;
      console.log(this.students);
    });  
  }

  onViewStudentDetails(id: number){
     this.router.navigate(['student-details', id])
  }

}
