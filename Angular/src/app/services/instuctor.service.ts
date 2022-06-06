import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import  {HttpClient} from '@angular/common/http'
import { Instructor } from '../models/instructor'; 

@Injectable({
  providedIn: 'root'
})
export class InstuctorService {

  formData: Instructor;

  private baseURL = "https://drisitproapi.azurewebsites.net";
  private instURL = this.baseURL + "/api/instructor";
  
  constructor(private httpClient: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>();

  get refreshNeeded$(){
    return this._refreshNeeded$; 
  }

  getInstructorList(): Observable<Instructor[]>{
    return this.httpClient.get<Instructor[]>(`${this.instURL}`)
  }

  getInstructorByID(id: number): Observable<Instructor>{
    return this.httpClient.get<Instructor>(`${this.instURL}/${id}`);
  }

  createInstructor(instructor: Instructor): Observable<Object>{
    return this.httpClient
    .post(`${this.instURL}`, instructor)
    .pipe(
      tap(() => {
        this.refreshNeeded$.next();
      })
    );
  }

}
