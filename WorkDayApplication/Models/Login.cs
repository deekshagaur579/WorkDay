//using WorkDayEntityModel;
using System.Linq;
using System.Collections.Generic;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using WorkDayApplication.DataAccess.Utilities;
using WorkDayApplication.DataAccess;

namespace WorkDayApplication.Models
{
    public class Login
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        //WorkDayEntitiesNew entity = new WorkDayEntitiesNew();
        public bool ValidateLogin(string userid, string password)
        {
            LoginDataAccess LDA = new LoginDataAccess();
            string dbPassword = LDA.ValidatePassword(userid, password);
            if (dbPassword == password)
            {
                return true;
            }
            return false;
        }
    }
}
