import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import  {HttpClient} from '@angular/common/http'
import { Course } from '../models/course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  formData: Course;

  private baseURL = "https://drisitproapi.azurewebsites.net";
  private courseURL = this.baseURL + "/api/course";
  
  constructor(private httpClient: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>();

  get refreshNeeded$(){
    return this._refreshNeeded$; 
  }

  getCourseList(): Observable<Course[]>{
    return this.httpClient.get<Course[]>(`${this.courseURL}`)
  }

  createCourse(course: Course): Observable<Object>{
    return this.httpClient
    .post(`${this.courseURL}`, course)
    .pipe(
      tap(() => {
        this.refreshNeeded$.next();
      })
    );
  }
}
