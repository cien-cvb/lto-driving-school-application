import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/models/student'; 
import { StudentService } from 'src/app/services/student.service'; 
import { EnrollmentService } from 'src/app/services/enrollment.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})

export class StudentDetailsComponent implements OnInit {

  id: number;
  student: Student = new Student();

  constructor(private toastr: ToastrService, public enrollmentService: EnrollmentService, private studentService: StudentService, private router: Router,
      private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.resetForm();
    this.id = this.route.snapshot.params['id'];
    this.studentService.getStudentByID(this.id).subscribe(data => {
        this.student = data;
    }, error => console.log(error));
  }

  resetForm(form? : NgForm){
    if(form != null)
      form.reset();
      this.enrollmentService.formData = {
        enrollmentID: null,
        studID: null,
        instId: null,
        enrollmentTypeID: null,
        mvTypeID: null,
        courseID: null,
        enrollmentDate: null,
        dlCodes: null,
        assessment: null,
        overallRating: null,
        dateStarted: null,
        dateCompleted: null,
        remarks: null,
        deleteFlag: null,
    }
  }
  onBack(){
    this.router.navigate(['students'])
  }

  saveEnrollment(){
    this.enrollmentService.createEnrollment(this.enrollmentService.formData).subscribe( res => {
        console.log(this.enrollmentService.formData);
        this.toastr.success('New Enrollment was saved successfully', 'Saved!');
        this.resetForm();
        this.triggerdFalseClick();
      }
    ),
    (error: any) => console.log(error);
  }
  
  onSubmit(form: NgForm){
    if(form.value.id == null){
      this.saveEnrollment();
    }
  }
  
  @ViewChild('reset') reset: ElementRef<HTMLElement>
  triggerdFalseClick(){
    let el: HTMLElement = this.reset.nativeElement;
    el.click();
  }
  
  onReset(){
    this.resetForm();
  }
  
  

}

