using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace WorkDayApplication.DataAccess.Utilities
{
    public static class DataAccessUtility
    {
        public static object GetData(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkDayConnectionString"].ConnectionString;
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                           return result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

        }
        public static DataTable ExecuteQuery(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkDayConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(query))
            {
                throw new NullReferenceException("Query Parameter Can not be Null or Empty");
            }
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static void Update(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkDayConnectionString"].ConnectionString;
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void SendMail(string subject, string body)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("gaurdeeksha579@gmail.com");
                    mail.To.Add("deekshagaur579@gmail.com");
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                   // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("gaurdeeksha579@gmail.com", "FamilyFamily@579");
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

