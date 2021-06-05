import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {IEmployee} from './model/employee';
import { of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) {}
   SERVICE_URL = 'https://localhost:44320'; // Service URL, real time will go to ENV specific file
   headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Access-Control-Allow-Origin', '*');
  /**
   * Save method will call backend service using Angular HttpClient, Backend service will save the employee details 
   * and return the update employee object in response .
   * @param employee  Service request object
   * @returns IEmployee type object
   */
  save(employee: IEmployee): Observable<IEmployee> {
   return  this.http.post<IEmployee>(this.SERVICE_URL+'/api/employee', employee, { 'headers': this.headers })
  }

    /**
   * This method will call backend service using Angular HttpClient to get the list of all the employees.
   * @returns List IEmployee type object
   */
     get(): Observable<IEmployee[]> {
        return  this.http.get<IEmployee[]>(this.SERVICE_URL+'/api/employee', { 'headers': this.headers })
     }
     
    /**
   * This method will call backend service using Angular HttpClient to get the list of all the employees.
   * @returns List IEmployee type object
   */
     delete(id:any): Observable<any> {
      return  this.http.delete<any>(this.SERVICE_URL+'/api/employee/'+id)
     }
     
}
