using System;
using System.Collections.Generic;
using WorkDayApplication.DataAccess;

namespace WorkDayApplication.Models
{
    public class LeaveAccount
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LeaveType { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> Created { get; set; }
        public Nullable<decimal> Updated { get; set; }
        public Nullable<decimal> Opening { get; set; }
        public Nullable<decimal> Credited { get; set; }
        public Nullable<decimal> Availed { get; set; }
        public Nullable<decimal> Applied { get; set; }
        public Nullable<decimal> Approved { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public List<LeaveAccount> GetLeaveAccount(string LoginName)
        {
            LeaveDataAccess LDA = new LeaveDataAccess();
            return LDA.GetLeaveAccount(LoginName);
        }
    }
}
