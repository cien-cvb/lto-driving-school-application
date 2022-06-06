import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';


@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  id: number;
  students: Student[];
  student: Student;

  constructor(private studentService: StudentService, private router: Router) { }

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

}
