using WorkDayApplication.DataAccess.Utilities;

namespace WorkDayApplication.DataAccess
{
    public class LoginDataAccess
    {
        public string ValidatePassword(string loginName,string password) {
            string query = "Select CoLoginPassword from TaLogin where CoLoginName = " + loginName;
            string dbPassword = DataAccessUtility.GetData(query).ToString();
            return dbPassword;
        }
    }
}
