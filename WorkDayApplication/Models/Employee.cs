using System;
using System.Collections.Generic;
using WorkDayApplication.DataAccess;

namespace WorkDayApplication.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string  LoginName { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  Created { get; set; }
        public string  Updated { get; set; }
        public string  Role { get; set; }
        public string  AddressLine1 { get; set; }
        public string  AddressLine2 { get; set; }
        public string  AddressLine3 { get; set; }
        public string  Designation { get; set; }
        public string  Department { get; set; }
        public Boolean  Active { get; set; }

        public List<Employee> GetEmployeeList() {
            EmployeeDataAccess EDA = new EmployeeDataAccess();
            return EDA.GetEmployeeList();
        }

        public void ChangeStatus(int id, bool newValue)
        {
            EmployeeDataAccess EDA = new EmployeeDataAccess();
            EDA.ChangeEmployeeStatus(id, newValue);
        }
    }
}
