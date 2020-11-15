import { HttpClient, HttpHeaders,HttpErrorResponse } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable, pipe } from 'rxjs';
import { throwError } from 'rxjs/internal/observable/throwError';
import { catchError } from 'rxjs/operators'; 

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    //Authorization: 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ServerHttpService {
  private REST_API_SERVER = 'https://localhost:44340/api/app/course';
  public idCourse = '';
  public name;
  public userId;
  public publishDate;
  public price;
  public creationTime;
  public creatorId;

  public addMode = true;
  public getCourses(): Observable<any>{
    const url = `${this.REST_API_SERVER}/coursesOfUser`;
    return this.httpClient
          .get<any>(url, httpOptions)
          .pipe(catchError(this.handleError));
  }
  public searchCourses(text): Observable<any>{
    const url = `${this.REST_API_SERVER}/ssss?text=`+ text;
    return this.httpClient
          .get<any>(url, httpOptions)
          .pipe(catchError(this.handleError));
  }
  public getAllCourses(): Observable<any>{
    const url = `${this.REST_API_SERVER}`;
    return this.httpClient
          .get<any>(url, httpOptions)
          .pipe(catchError(this.handleError));
  }
  public deleteCourse(id: number) {
    const url = `${this.REST_API_SERVER}/` + id;
    return  this.httpClient
            .delete<any>(url)
            .pipe(catchError(this.handleError));
  }
  public addCourse(course) {
    const url = `${this.REST_API_SERVER}`;
    return  this.httpClient
            .post<any>(url, course)
            .pipe(catchError(this.handleError));
  }
  public editCourse(course, id){
    const url = `${this.REST_API_SERVER}/` + id;
    return  this.httpClient
            .put<any>(url, course)
            .pipe(catchError(this.handleError));
  }
  constructor(private httpClient: HttpClient) { }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}
