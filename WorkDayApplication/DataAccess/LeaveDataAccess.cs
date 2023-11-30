using System;
using System.Collections.Generic;
using System.Data;
using WorkDayApplication.DataAccess.Utilities;
using WorkDayApplication.Models;

namespace WorkDayApplication.DataAccess
{
    public class LeaveDataAccess
    {
        public List<LeaveAccount> GetLeaveAccount(string loginName)
        {
            string query = "Select CoId,CoLoginName,CoLeaveType,CoYear,CoCreated,CoUpdated,CoOpening,CoCredited,CoAvailed,CoApplied,coApproved,CoBalance from TaAccountLeave where CoLoginName = " + loginName;
            DataTable dt = DataAccessUtility.ExecuteQuery(query);
            List<LeaveAccount> list = new List<LeaveAccount>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new LeaveAccount()
                {
                    Id = Convert.ToInt32(dr["CoId"]),
                    LoginName = dr["CoLoginName"].ToString(),
                    LeaveType = dr["CoLeaveType"].ToString(),
                    Year = Convert.ToInt32(dr["CoYear"]),
                    Opening = Convert.ToInt32(dr["CoOpening"]),
                    Credited = Convert.ToInt32(dr["CoCredited"]),
                    Availed = Convert.ToInt32(dr["CoAvailed"]),
                    Applied = Convert.ToInt32(dr["CoApplied"]),
                    Approved = Convert.ToInt32(dr["coApproved"]),
                    Balance = Convert.ToInt32(dr["CoBalance"])
                });
            }
            return list;
        }

        public void SaveApplyLeave(int Leaveid)
        {
            string query = @"insert into TaLeave(
                                CoLeaveAccountId,
                                CoStartdate,
                                CoEndDate,
                                CoApplydate,
                                coReason,
                                CoApprovedStatus)
                                values(" + Leaveid + @",
                                GETDATE(),
                                GETDATE(),
                                GETDATE(),
                                'Clicked Apply Leave',
                                'Applied'
                                );";
            DataAccessUtility.Update(query);
        }
        public int SaveCancelLeave(int Leaveid)
        {
            string IdQuery = "Select TOP 1 CoId from TaLeave where CoLeaveAccountId = " + Leaveid+ " order by CoId desc";
            int Id = Convert.ToInt32(DataAccessUtility.GetData(IdQuery));
            string query = "update TaLeave set CoApprovedStatus ='Cancelled' where CoId = " + Id;
            DataAccessUtility.Update(query);
            return Id;
        }

        public int SaveApprovedLeave(int Leaveid)
        {
            string IdQuery = "Select TOP 1 CoId from TaLeave where CoLeaveAccountId = " + Leaveid + " order by CoId desc";
            int Id = Convert.ToInt32(DataAccessUtility.GetData(IdQuery));
            string query = "update TaLeave set CoApprovedStatus ='Approved' where CoId = " + Id;
            DataAccessUtility.Update(query);
            return Id;
        }

        public void UpdateAppliedLeaves(int leaveId)
        {
            string balancequery = "Select CoBalance from TaAccountLeave where CoId = " + leaveId;
            int balance = Convert.ToInt32(DataAccessUtility.GetData(balancequery));
            string appliedquery = "Select CoApplied from TaAccountLeave where CoId = " + leaveId;
            int applied = Convert.ToInt32(DataAccessUtility.GetData(appliedquery));
            string query = "Update TaAccountLeave set CoApplied = " + (applied+1) + ",CoBalance = " +( balance-1) + " where CoId = " + leaveId;
            DataAccessUtility.Update(query);
        }
        public void UpdateCancelledLeaves(int leaveId)
        {
            string balancequery = "Select CoBalance from TaAccountLeave where CoId = " + leaveId;
            int balance = Convert.ToInt32(DataAccessUtility.GetData(balancequery));
            string appliedquery = "Select CoApplied from TaAccountLeave where CoId = " + leaveId;
            int applied = Convert.ToInt32(DataAccessUtility.GetData(appliedquery));
            string query = "Update TaAccountLeave set CoApplied = " + (applied - 1) + ",CoBalance = " + (balance + 1) + " where CoId = " + leaveId;
            DataAccessUtility.Update(query);
        }
    }
}
