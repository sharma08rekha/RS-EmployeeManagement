import { Component, Input, OnChanges, OnInit,Output, EventEmitter, ViewChild } from '@angular/core';
import { IEmployee } from '../model/employee';
import {EmployeeService} from '../employee.service'
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employeedetails',
  templateUrl: './employeedetails.component.html',
  styleUrls: ['./employeedetails.component.css']
})
export class EmployeedetailsComponent implements  OnChanges {

  @Input() employee: IEmployee | undefined;
  @Output() update = new EventEmitter();
  @ViewChild("empFrom") employeeForm : FormGroup;

  employeeModel = {"id": 0, "fullName": "", "address": "", "phoneNumber": "", "position":0}
  fullName: string | undefined;
  errorMessage: string;
  successMessage: string;

  constructor(private employeeService: EmployeeService) { }


  ngOnChanges(){
    if(this.employee){
      this.prepareModel(this.employee);
    } else{
      this.employeeModel = {"id": 0, "fullName": "", "address": "", "phoneNumber": "", "position":0}
    }
  }

/**
 * This function will be called on click on submit button. Call the Employee service save operation which will internally make Http service 
 * to save the details.
 */
  onSubmit(){
    this.errorMessage ="";
    this.successMessage = "";
    this.employeeModel.position = +this.employeeModel.position;
    this.employeeModel.id = +this.employeeModel.id;

    this.employeeService.save(this.employeeModel).subscribe((data: IEmployee) => { // Process the service response
      this.prepareModel(data);
      this.successMessage = "Employee details updated successfully!"
      this.update.emit(data);
    }, (error) => {  //Handle service error     
      console.error('error caught in component',error)
      this.errorMessage = "Employee service thrown an error ";
    });
  }

  /**
   * Set the Form model properties with employee model
   * @param employee 
   */
  prepareModel(employee: IEmployee){
    this.employeeModel = {"id": 0, "fullName": "", "address": "", "phoneNumber": "", "position":0}
    this.employeeModel.id = employee.id;
    this.employeeModel.fullName = employee.fullName;
    this.employeeModel.address = employee.address;
    this.employeeModel.phoneNumber = employee.phoneNumber;
    this.employeeModel.position = +employee.position;
  }

  /**
   * 
   * @param event This function will call called on keypress of phone number field to allow only numeric entries.
   * @returns 
   */
  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }
/**
 * This function will set the form model with select employee and clear the message values.
 * @param emp
 */
  resetSelectedEmployee(emp: IEmployee){
    this.errorMessage ="";
    this.successMessage = "";
    this.prepareModel(emp)
  }
}

