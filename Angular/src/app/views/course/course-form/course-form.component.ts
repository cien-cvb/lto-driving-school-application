import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CourseService } from 'src/app/services/course.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit {

  constructor(public courseService: CourseService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form != null)
      form.reset();
      this.courseService.formData = {
        courseId: null,
        courseName: null,
        courseType: null,
        courseHours: null,
        courseFee: null,     
    }
}

saveCourse(){
  this.courseService.createCourse(this.courseService.formData).subscribe( res => {
      console.log(this.courseService.formData);
      // this.toastr.success('New Course was added successfully', 'Saved!');
      this.resetForm();
      this.triggerdFalseClick();
    }
  ),
  (error: any) => console.log(error);
}

onSubmit(form: NgForm){
  if(form.value.id == null){
    this.saveCourse();
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
