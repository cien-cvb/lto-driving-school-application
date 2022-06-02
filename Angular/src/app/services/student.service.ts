import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import  {HttpClient} from '@angular/common/http'
import { Student } from 'src/app/models/student';

@Injectable({
  providedIn: 'root'
})

export class StudentService {

  formData!: Student;

  private baseUrl = "http://localhost:55891/api/student";


  constructor(private httpClient: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>();

  get refreshNeeded$(){
    return this._refreshNeeded$; 
  }

  getStudentList(): Observable<Student[]>{
    return this.httpClient.get<Student[]>(`${this.baseUrl}`)
  }

}