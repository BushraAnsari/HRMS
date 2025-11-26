using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace HRMS
{
    public class custome_class
    {
        
        public static string sendEmail(string host,string user_name,string pass,
                                        string to_email,string to_name,
                                        string from_email,string from_name,string rply_to,
                                        string subjet,string body)
        {
            try
            {

                SmtpClient mySmtpClient = new SmtpClient(host);
                mySmtpClient.EnableSsl = true;

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential(user_name, pass);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(from_email, from_name);
                MailAddress to = new MailAddress(to_email, to_name);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyTo = new MailAddress(rply_to);
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = subjet;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = body;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
                return "success";
            }

            catch (SmtpException ex)
            {
                return new ApplicationException
                  ("SmtpException has occured: " + ex.Message).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string deletesalarypolicy(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_salary_detuction_policy.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_salary_detuction_policy.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletetimeset(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_emp_time_set.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_emp_time_set.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deleteleavetype(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_leave_type.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_leave_type.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletesalarycomp(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_salary_components.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_salary_components.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletejobdesc(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_job_descrion.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_job_descrion.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deleteempcon(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_employee_conectivity.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_employee_conectivity.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deleteemprecord(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_Employe.Where(x => x.id == id).FirstOrDefault();
                var chk = dx.tbl_login.Where(x => x.Email == dt.WorkEmail).FirstOrDefault();
                if (chk != null) { dx.tbl_login.Remove(chk); }
                dx.tbl_Employe.Remove(dt);
                
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public static string deleteleaverecord(int id)
        {
            try
            {
               
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_employeeleave.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_employeeleave.Remove(dt);
                dx.SaveChanges();
                return "success";
               

            }
            catch (Exception ex)
            {
                return ex.Message;
               
            }
        }
        public static string deleteempstatus(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_Employee_status.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_Employee_status.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletegrade(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_emp_grade.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_emp_grade.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletedept(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_dept.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_dept.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deletesalaryrecord(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_salary.Where(x => x.id == id).FirstOrDefault();
                //File.Delete(dt.slip_url);
                dx.tbl_salary.Remove(dt);
                dx.SaveChanges();
                return "success";


            }

            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string generate_noti(long u_id,string content)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                tbl_noti noti = new tbl_noti();
                noti.fk_userid = u_id;
                noti.noti_content = content;
                noti.read_status = false;
                noti.del_status = false;
                dx.tbl_noti.Add(noti);
                dx.SaveChanges();
                
                return "success";


            }

            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deleteloanrecord(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_loanpaidemp.Where(x => x.loan_id == id).FirstOrDefault();
                dx.tbl_loanpaidemp.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static string deleteholiday(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_emp_holiday.Where(x => x.id == id).FirstOrDefault();
                dx.tbl_emp_holiday.Remove(dt);
                dx.SaveChanges();
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }


        public static void bindpolicy(DropDownList _ddlpolicy)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_leaving_policy.Where(x => x.status == true).ToList();
                _ddlpolicy.DataTextField = "Leavepolicy";
                _ddlpolicy.DataValueField = "id";
                _ddlpolicy.DataSource = dt;
                _ddlpolicy.DataBind();
                _ddlpolicy.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void bindleavetype(DropDownList _ddlpolicy)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_leave_type.Where(x => x.status == true).ToList();
                _ddlpolicy.DataTextField = "leave_type_name";
                _ddlpolicy.DataValueField = "id";
                _ddlpolicy.DataSource = dt;
                _ddlpolicy.DataBind();
                _ddlpolicy.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void Bindgrade(DropDownList _ddlgrade)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_emp_grade.Where(x => x.status == true).ToList();
                _ddlgrade.DataTextField = "Empgrade";
                _ddlgrade.DataValueField = "id";
                _ddlgrade.DataSource = dt;
                _ddlgrade.DataBind();
                _ddlgrade.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void BindDeprt(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_dept.Where(x => x.Status == true).ToList();
                _ddlVend.DataTextField = "Department_name";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void BindDeprtAll(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_dept.Where(x => x.Status == true).ToList();
                _ddlVend.DataTextField = "Department_name";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("All", "All"));


            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void BindSubDeprt(DropDownList _ddlVend,long id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_sub_dept.Where(x => x.fk_dept_id == id).ToList();
                _ddlVend.DataTextField = "Sub_department_name";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void Bindemployee(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_Employe.Where(x => x.status == true).ToList();
                _ddlVend.DataTextField = "EmployeeCode";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void Bindemployeesal(DropDownList _ddlVend,string year,string month)
        {
            HRMSEntities dx = new HRMSEntities();


            try
            {


                var query = dx.tbl_employee_salary

                 .GroupBy(x => new { empid = x.fk_employee_id })
                 .Select(x => new
                 {
                     empid = x.Key.empid,
                     Amount = x.Sum(s => s.amount)

                 });





                var salary_result = from a in dx.tbl_salary
                                    where a.salary_year == year && a.salary_month == month
                                    select a;


                var result = from emp in query

                             join
                     de in salary_result

                     on emp.empid equals de.fk_emp_id
                     into tempstorage
                             from dxs in tempstorage.DefaultIfEmpty()


                             select new
                             {
                                 empid = (dxs != null) ? 0 : emp.empid,
                                 //empid= emp.empid,
                                 Amount = emp.Amount,
                                 month = dxs.salary_month,
                                 year = dxs.salary_year

                             };
                var dt = (from ep in result
                             join e in dx.tbl_Employe on ep.empid equals e.id

                             select e).ToList();
                            

                
                _ddlVend.DataTextField = "EmployeeCode";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }

        public static string deleteempsalary(int id)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_employee_salary.Where(x => x.fk_employee_id == id).ToList();
                for (int i = 0; i < dt.Count; i++)
                {
                    dx.tbl_employee_salary.Remove(dt[i]);
                    dx.SaveChanges();
                }
                return "success";


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public static void Bindemployestatus(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_Employee_status.Where(x => x.status == true).ToList();
                _ddlVend.DataTextField = "Employee_status_name";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static void bindtitle(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
                var dt = dx.tbl_job_descrion.Where(x => x.status == true).ToList();
                _ddlVend.DataTextField = "Designation";
                _ddlVend.DataValueField = "id";
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
                _ddlVend.Items.Insert(0, new ListItem("Select", ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }

        
        public static List<DateTime> weeklyholidayslist(int year,int month, int weekday)

        {
            List<DateTime> holidays = new List<DateTime>();

            
           
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
            {
                    if (weekday == 0 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 1 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Tuesday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 2 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Wednesday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 3 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Thursday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 4 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Friday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 5 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));

                    else if (weekday == 6 && beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                        holidays.Add(beginingOfThisMonth.AddDays(i));
                
            }
          

            return holidays;


        }

        
        public static List<DateTime> yearlyholidayslist(int month, int year, DateTime yearly)

        {
            List<DateTime> holidays = new List<DateTime>();



            int chkmonth = yearly.Month;
            int chkday = yearly.Day;
            int daysThisMonth = DateTime.DaysInMonth(year, month);



            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
            {
                if (chkmonth == beginingOfThisMonth.AddDays(i).Month && beginingOfThisMonth.AddDays(i).Day == chkday)
                    holidays.Add(beginingOfThisMonth.AddDays(i));


            }

            return holidays;


        }


        public static List<DateTime>absentdays(int month, int year, List<DateTime> days)

        {
            List<DateTime> absent = new List<DateTime>();



           
            int daysThisMonth = DateTime.DaysInMonth(year, month);



            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            DateTime dts = DateTime.Parse(beginingOfThisMonth.ToString());
            DateTime settimes = DateTime.Parse(dts.ToString("dd/MM/yyyy"));
            for (int j = 0; j < days.Count; j++)
            {
                for (int i = 0; i < daysThisMonth; i++)
                {

               
                    DateTime dt = DateTime.Parse(days[j].ToString());
                    DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                    if (settimes.AddDays(i).Date != settime && !repeatholiday(absent, settimes.AddDays(i).Date))
                    {
                        absent.Add(settimes.AddDays(i).Date);
                    }
                }


            }

            return absent;


        }


       


        public static void bindmonth(DropDownList _ddlVend)
        {
            try
            {
                HRMSEntities dx = new HRMSEntities();
               
                var dt = System.Globalization.CultureInfo.CurrentCulture
        .DateTimeFormat.MonthGenitiveNames;
                
                _ddlVend.DataSource = dt;
                _ddlVend.DataBind();
            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        
        public static void bindyear(DropDownList _ddlVend)
        {
            try
            {
               
               
                _ddlVend.Items.Insert(0, new ListItem(DateTime.Now.Year+"", DateTime.Now.Year + ""));
                _ddlVend.Items.Insert(1, new ListItem(DateTime.Now.Year-1 + "", DateTime.Now.Year-1 + ""));

            }
            catch (Exception ex)
            {
                //  cls.clsErrorLogs.LogErrors(ex);
            }
        }
        public static bool repeatholiday(List<DateTime> lvi,DateTime dt)
        {
            bool found = false;
            for (int i = 0; i < lvi.Count; i++) {
                if (lvi[i] == dt) {
                    found = true; ;
                }
                
                    
            }
         return found;   
        }
        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }





    }
    

}