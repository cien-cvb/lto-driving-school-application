import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Instructor } from 'src/app/models/instructor'; 
import { InstuctorService } from 'src/app/services/instuctor.service'; 

@Component({
  selector: 'app-instuctor-details',
  templateUrl: './instuctor-details.component.html',
  styleUrls: ['./instuctor-details.component.css']
})
export class InstuctorDetailsComponent implements OnInit {

  id: number;
  instructor: Instructor = new Instructor();

  constructor(private instructorService: InstuctorService, private router: Router,
      private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.instructorService.getInstructorByID(this.id).subscribe(data => {
      this.instructor = data;
    }, error => console.log(error));
  }

}
