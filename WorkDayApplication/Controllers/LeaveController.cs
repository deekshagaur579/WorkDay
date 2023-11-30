using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkDayApplication.Models;

namespace WorkDayApplication.Controllers
{
    public class LeaveController : Controller
    {
        public ActionResult LeaveAccount()
        {
            LeaveAccount leaveacc = new LeaveAccount();
            return View(leaveacc.GetLeaveAccount("232403"));
        }

        // GET: LeaveController/Details/5
        public ActionResult ApplyLeave(int Leaveid)
        {
            Leave leave = new Leave();
            leave.ApplyLeave(Leaveid);
            return RedirectToAction("LeaveAccount");
        }
        public ActionResult CancelLeave(int Leaveid)
        {
            Leave leave = new Leave();
            leave.CancelLeave(Leaveid);
            return RedirectToAction("LeaveAccount");
        }
        public ActionResult ApproveLeave(int Leaveid)
        {
            Leave leave = new Leave();
            leave.ApproveLeave(Leaveid);
            return RedirectToAction("LeaveAccount");
        }

        //// GET: LeaveController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LeaveController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LeaveController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LeaveController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LeaveController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: LeaveController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
