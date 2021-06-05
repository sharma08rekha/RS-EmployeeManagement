import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IEmployee } from '../model/employee';
import {EmployeeService} from '../employee.service'

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
})
export class EmployeelistComponent  {
  @Output() selection = new EventEmitter();
  @Output() deletion = new EventEmitter();

  @Input() employees: IEmployee[] = [];
  errorMessage: string;
  successMessage: string;
  constructor(private employeeService: EmployeeService) { }

  /**
   * This function will be called on click on Employee name/ Position section and will emit an event to parent component to info the selection 
   * so that parent call communicate with Employee details component.
   * @param employee 
   */
  selectEmployee(employee: IEmployee){
    this.selection.emit(employee);  
  }
  /**
   * The function will be called on click of Delete button and this will call delete operation on Employee service to delete the record.
   * @param employee 
   */
  deleteEmployee(employee: IEmployee){

    this.employeeService.delete(employee.id).subscribe((data: any) => { // Process the service response
      console.log('Response data  ',data);
      this.employees.splice(this.employees.findIndex(emp => emp.id === employee.id), 1)
      this.successMessage = "Employee record deleted successfully!"
      this.deletion.emit();
    }, (error) => {  //Handle service error     
      console.error('error caught in component',error)
      this.errorMessage = "Employee service thrown an error ";
    });

  }
  /**
   * This function will clear the error/success messages
   */
  clearMessage(){
    this.successMessage = "";
    this.successMessage = "";
  }
/**
 * 
 * @param position This method will return Position label based on position id
 */
  getPositionName(position){
  
    let positionLabel = '';

    switch (position) {
      case 1: 
          positionLabel = 'Project Manager';
          break;
      case 2: 
          positionLabel = 'Production Manager';
          break;
      case 3:
          positionLabel = 'General Manager'; 
          break;
      case 4:
          positionLabel = 'HR Director'; 
          break;
      case 5: 
          positionLabel = 'Senior Editor'; 
          break;          
      case 6: 
        positionLabel = 'Editor'; 
          break;
    }
    return positionLabel;

  }
}
