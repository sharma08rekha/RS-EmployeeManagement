import { Component, ViewChild } from '@angular/core';
import { IEmployee } from './model/employee';
import {EmployeeService} from './employee.service'
import {EmployeedetailsComponent} from './employeedetails/employeedetails.component'
import {EmployeelistComponent} from './employeelist/employeelist.component'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild("employeedetails") employeedetailsRef : EmployeedetailsComponent;
  @ViewChild("employeellist") employeellist : EmployeelistComponent;

  title = 'EmployeeManagement';
  errorMessage: string;

  employees: IEmployee[] = [];
  selectedEmp: IEmployee | undefined;
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
      this.employeeService.get().subscribe((data: IEmployee[]) => { // Process the service response
      this.employees = data;
      }, (error) => {  //Handle service error     
        console.error('error caught in component',error)
        this.errorMessage = "Employee service thrown an error ";
      });
  }

  onEmployeeUpdate(employee: IEmployee){
    if(this.employees && this.employees.length> 0){
      let newArray = this.employees.filter(function(emp) {
        return emp.id == employee.id;
      });
      if (newArray && newArray.length == 0) {
        this.employees.push(employee);
        this.selectedEmp = employee;
      } else{
        this.employees.forEach(emp => {
          if(emp.id == employee.id){
            emp.fullName = employee.fullName
            emp.address = employee.address
            emp.phoneNumber = employee.phoneNumber
            emp.position = employee.position
          }
        });
      }
  
    } else{
      this.employees.push(employee);
    }
  }
  
  onEmployeeSelection(employee: IEmployee){
    this.employeellist.clearMessage();
    this.employeedetailsRef.resetSelectedEmployee(employee);
  }
  onEmployeeDelete(){
    this.employeedetailsRef.resetSelectedEmployee({"id": 0, "fullName": "", "address": "", "phoneNumber": "", "position":0});

  }

  addEmployee(){
    this.employeellist.clearMessage();
    this.employeedetailsRef.resetSelectedEmployee({"id": 0, "fullName": "", "address": "", "phoneNumber": "", "position":0});
  }
}
