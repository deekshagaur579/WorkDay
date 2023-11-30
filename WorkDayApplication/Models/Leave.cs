using System;
using WorkDayApplication.DataAccess;
using WorkDayApplication.DataAccess.Utilities;

namespace WorkDayApplication.Models
{
    public class Leave
    {
        public int CoId { get; set; }
        public int CoLeaveAccountId { get; set; }
        public Nullable<System.DateTime> CoStartdate { get; set; }
        public Nullable<System.DateTime> CoEndDate { get; set; }
        public Nullable<System.DateTime> CoApplydate { get; set; }
        public string coReason { get; set; }
        public string CoApprovedStatus { get; set; }

        public void ApplyLeave(int Leaveid)
        {
            LeaveDataAccess LDA = new LeaveDataAccess();
            LDA.SaveApplyLeave(Leaveid);
            LDA.UpdateAppliedLeaves(Leaveid);
            DataAccessUtility.SendMail("Leave Applied","<h1>Leave Applied</h1>");
        }
        public void CancelLeave(int Leaveid)
        {
            LeaveDataAccess LDA = new LeaveDataAccess();
            LDA.SaveCancelLeave(Leaveid);
            LDA.UpdateCancelledLeaves(Leaveid);
            DataAccessUtility.SendMail("Leave Cancelled", "<h1>Leave Cancelled</h1>");
        }
        public void ApproveLeave(int Leaveid)
        {
            LeaveDataAccess LDA = new LeaveDataAccess();
            LDA.SaveApprovedLeave(Leaveid);
            DataAccessUtility.SendMail("Leave Approved", "<h1>Leave Approved</h1>");
        }
    }
}
