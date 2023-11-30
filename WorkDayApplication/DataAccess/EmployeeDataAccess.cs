using System;
using System.Collections.Generic;
using System.Data;
using WorkDayApplication.DataAccess.Utilities;
using WorkDayApplication.Models;

namespace WorkDayApplication.DataAccess
{
    public class EmployeeDataAccess
    {
        public List<Employee> GetEmployeeList()
        {
            string query = "Select CoId,CoLoginName,CoFirstName,CoLastName,CoCreated,CoUpdated,CoRole,CoAddressLine1,CoAddressLine2,CoAddressLine3,CoDesignation,CoDepartment,CoActive from TaEmployee ";
            DataTable dt = DataAccessUtility.ExecuteQuery(query);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Employee()
                {
                    id = Convert.ToInt32(dr["CoId"]),
                    LoginName = dr["CoLoginName"].ToString(),
                    FirstName = dr["CoFirstName"].ToString(),
                    LastName = dr["CoLastName"].ToString(),
                    AddressLine1 = dr["CoAddressLine1"].ToString(),
                    AddressLine2 = dr["CoAddressLine2"].ToString(),
                    AddressLine3 = dr["CoAddressLine3"].ToString(),
                    Department = dr["CoDepartment"].ToString(),
                    Designation = dr["CoDesignation"].ToString(),
                    Role = dr["CoRole"].ToString(),
                    Active = Convert.ToBoolean(dr["CoActive"].ToString())
                });
            }
            return list;
        }

        public void ChangeEmployeeStatus(int id, bool newValue)
        {
            string query = "Update TaEmployee set CoActive =" + Convert.ToInt32(newValue) + " where CoId = " + id;
            DataAccessUtility.Update(query);
        }
    }
}
