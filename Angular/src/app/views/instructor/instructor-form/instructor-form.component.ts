import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { InstuctorService } from 'src/app/services/instuctor.service'; 
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {

  constructor(public instructorService: InstuctorService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form != null)
      form.reset();
      this.instructorService.formData = {
        instId: null,
        instAccredNo: null,
        instFirstName: null,
        instLastName: null,
        instMiddleName: null,
        instSignature: null,
        instSuffix: null,
        instRegion: null,
        instCity: null,
        instBrgy: null,
        instZipCode: null,
        instLtoPid: null,
        instContactNo: null,
        instDln: null,
        instProvince: null,
        instAddressLine: null,
    }
}

saveInstructor(){
  this.instructorService.createInstructor(this.instructorService.formData).subscribe( res => {
      console.log(this.instructorService.formData);
      this.toastr.success('New Instructor was added successfully', 'Saved!');
      this.resetForm();
      this.triggerdFalseClick();
    }
  ),
  (error: any) => console.log(error);
}

onSubmit(form: NgForm){
  if(form.value.id == null){
    this.saveInstructor();
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
