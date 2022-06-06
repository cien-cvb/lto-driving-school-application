import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import  {HttpClient} from '@angular/common/http'
import { Enrollment } from '../models/enrollment';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  formData: Enrollment;

  private baseURL = "https://localhost:5001";
  private enrollmentURL = this.baseURL + "/api/enrollment";
  
  constructor(private httpClient: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>();

  get refreshNeeded$(){
    return this._refreshNeeded$; 
  }

  getEnrollmentList(): Observable<Enrollment[]>{
    return this.httpClient.get<Enrollment[]>(`${this.enrollmentURL}`)
  }

  getenrollentByID(id: number): Observable<Enrollment>{
    return this.httpClient.get<Enrollment>(`${this.enrollmentURL}/${id}`);
  }

  createEnrollment(enrollment: Enrollment): Observable<Object>{
    return this.httpClient
    .post(`${this.enrollmentURL}`, enrollment)
    .pipe(
      tap(() => {
        this.refreshNeeded$.next();
      })
    );
  }

}