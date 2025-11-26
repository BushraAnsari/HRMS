using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



namespace HRMS
{
    public class salary_class
    {
        HRMSEntities dx = new HRMSEntities();

        public static List<int> get_absent_days(long epid, int year, int month)
        {
            HRMSEntities dx = new HRMSEntities();
            List<int> absent_details = new List<int>();

            List<DateTime> salaried_days = new List<DateTime>();
            List<DateTime> weeklyholidays = new List<DateTime>();
            List<DateTime> yearlyholidays = new List<DateTime>();
            List<DateTime> onetimeholidays = new List<DateTime>();
            List<DateTime> leaveholidays = new List<DateTime>();
            List<DateTime> working = new List<DateTime>();
            List<DateTime> holidays = new List<DateTime>();



            //check working days
            var working_days = (from a in dx.tbl_emp_attendance where a.fk_emp == epid && a.Type == "Time In" && a.month == month && a.year == year select a).ToList();
            for (int i = 0; i < working_days.Count; i++)
            {
                DateTime dt = DateTime.Parse(working_days[i].date.ToString());
                DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                if (settime.Month == month && settime.Year == year)
                {

                    if (!custome_class.repeatholiday(salaried_days, settime))
                    {

                        working.Add(settime);
                        salaried_days.Add(settime);


                    }
                }
            }



            //check leave
            var leave = (from a in dx.tbl_emp_attendance where a.fk_emp == epid && a.leave == true && a.month == month && a.year == year select a).ToList();
            for (int i = 0; i < leave.Count; i++)
            {
                DateTime dt = DateTime.Parse(leave[i].date.ToString());
                DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                if (settime.Month == month && settime.Year == year)
                {

                    if (!custome_class.repeatholiday(salaried_days, settime))
                    {

                        leaveholidays.Add(settime);
                        salaried_days.Add(settime);


                    }
                }
            }





            //check one time holiday
            var onetimeholiday = (from a in dx.tbl_emp_holiday where a.repeat_time == 0 select a).ToList();
            for (int i = 0; i < onetimeholiday.Count; i++)
            {
                DateTime dt = DateTime.Parse(onetimeholiday[i].holiday_date.ToString());
                DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                if (settime.Month == month && settime.Year == year)
                {
                    if (!custome_class.repeatholiday(holidays, settime))
                    { holidays.Add(settime); }


                    if (!custome_class.repeatholiday(salaried_days, settime))
                    {
                        onetimeholidays.Add(settime);
                        salaried_days.Add(settime);


                    }
                }
            }

            //check weekly holiday
            var weeklyholiday = (from a in dx.tbl_emp_holiday where a.repeat_time == 1 select a).ToList();
            for (int i = 0; i < weeklyholiday.Count; i++)
            {

                int weekday = int.Parse(weeklyholiday[i].holiday_day.ToString());
                weeklyholidays = custome_class.weeklyholidayslist(year, month, weekday);

                for (int j = 0; j < weeklyholidays.Count; j++)
                {
                    if (!custome_class.repeatholiday(holidays, weeklyholidays[j]))
                    { holidays.Add(weeklyholidays[j]); }
                    if (!custome_class.repeatholiday(salaried_days, weeklyholidays[j]))
                    {
                        salaried_days.Add(DateTime.Parse(weeklyholidays[j].ToString()));


                    }
                }


            }



            //check yearly holiday
            var yearlyholiday = (from a in dx.tbl_emp_holiday where a.repeat_time == 2 select a).ToList();
            for (int i = 0; i < yearlyholiday.Count; i++)
            {
                DateTime dt = DateTime.Parse(yearlyholiday[i].holiday_date.ToString());
                DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                if (settime.Month == month)
                {
                    
                    yearlyholidays = custome_class.yearlyholidayslist(month, year, settime);

                    for (int j = 0; j < yearlyholidays.Count; j++)
                    {
                        if (!custome_class.repeatholiday(holidays, yearlyholidays[j]))
                        { holidays.Add(yearlyholidays[j]); }
                        if (!custome_class.repeatholiday(salaried_days, yearlyholidays[j]))
                        {

                            salaried_days.Add(DateTime.Parse(yearlyholidays[j].ToString()));
                        }
                    }


                }
            }

            //txtabsent.Text="Absent Count:"+ custome_class.absentdays(month, year, salaried_days).Count+
            //               "Employee present: "+count_working+
            //               "Weekly Holiday Count"+weeklyholidays.Count+
            //               "Yearly Holiday Count" + yearlyholidays.Count+
            //               "One Time Holiday Count" + onetimeholiday.Count+
            //               "Holiday Count" + salaried_days.Count+
            //               "                   ";


            int days = DateTime.DaysInMonth(year, month);
            int absent = days - salaried_days.Count;

            //wroking_days_of_month absent_details[0]
            absent_details.Add(days - holidays.Count);

            //wroking_days_of_employee absent_details[1]
            absent_details.Add(working.Count);

            //leave_days absent_details[2]
            absent_details.Add(leaveholidays.Count);

            //absent_days absent_details[3]
            absent_details.Add(absent);





            return absent_details;


        }
        public static double get_absent_deduction(long epid, int year, int month, long total_salary)
        {
            try
            {


                List<int> absent_details = salary_class.get_absent_days(epid, year, month);
                int absent = absent_details[3];
                HRMSEntities dx = new HRMSEntities();


                //p_work.InnerText = absent_details[0].ToString();
                //p_working_days.InnerText = absent_details[1].ToString();
                //p_leave_days.InnerText = absent_details[2].ToString();
                //p_absent_days.InnerText = absent_details[3].ToString();



                //check late days
                var emp = (from a in dx.tbl_employee_conectivity where a.employe_fk == epid && a.status == true select a).FirstOrDefault();
                if (emp != null)
                {

                    var deduction = (from a in dx.tbl_salary_detuction_policy where a.fk_emp_grade == emp.grade_fk select a).FirstOrDefault();
                    if (deduction != null)
                    {
                        double p1 = double.Parse(deduction.absent_detuction) / 100;

                        double perdaysalarydesuct = total_salary * p1;
                        double absentdeduct = absent * perdaysalarydesuct;
                        // divsalary.Visible = true;
                        return absentdeduct;

                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                return 0;

            }


        }


        public static int get_late(long epid,int year,int month)
        {
            List<DateTime> late_days_list = new List<DateTime>();
            HRMSEntities dx = new HRMSEntities();

            //check late days
            var late_days = (from a in dx.tbl_emp_attendance where a.fk_emp == epid && a.Type == "Time In" && a.month == month && a.year == year && a.late == true select a).ToList();
            for (int i = 0; i < late_days.Count; i++)
            {
                DateTime dt = DateTime.Parse(late_days[i].date.ToString());
                DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));
                if (settime.Month == month && settime.Year == year)
                {

                    late_days_list.Add(settime);

                }
            }
            
            return late_days_list.Count;
        }
        public static double get_late_deduction(long epid,int year,int month,long total_salary)
        {
            
                HRMSEntities dx = new HRMSEntities();
                double late = get_late(epid,year,month);
               

                //check late days
                var emp = (from a in dx.tbl_employee_conectivity where a.employe_fk == epid && a.status == true select a).FirstOrDefault();
                if (emp != null)
                {
                    var deduction = (from a in dx.tbl_salary_detuction_policy where a.fk_emp_grade == emp.grade_fk select a).FirstOrDefault();
                    if (deduction != null)
                    {
                        double p1 = double.Parse(deduction.late_detuction) / 100;

                        var perdaysalarydesuct = total_salary * p1;
                        var latededuct = late * perdaysalarydesuct;

                        return latededuct;


                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 0;
                }

            }
        public static double loan(long epid)
        {
            HRMSEntities dx = new HRMSEntities();
            var loan = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status == "Active" select a).FirstOrDefault();
            if (loan != null)
            {

                if (loan.payable_amount_per_month > loan.remaining_loan_amount)
                {

                    return loan.remaining_loan_amount;
                }
                else
                {
                    return Convert.ToDouble(loan.payable_amount_per_month);
                }
               
               
            }
            else return 0;

        }
        

        public static void print_salary_slip(Control employeelistDiv,string filename) {
            //HttpContext.Current.Response.Flush();

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            HttpContext.Current.Response.ContentType = "application/pdf";
            //HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename =" + filename);
            //HttpContext.Current.Server.MapPath(("/PDF/") + filename);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            employeelistDiv.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

            Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
           HTMLWorker htmlparser = new HTMLWorker(Doc);

            PdfWriter.GetInstance(Doc, HttpContext.Current.Response.OutputStream);
            PdfWriter writer = PdfWriter.GetInstance(Doc, memoryStream);

            Doc.Open();

            htmlparser.Parse(stringReader);
            Doc.Close();
            
            byte[] bytes = memoryStream.ToArray();
            System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/PDF/") + filename, bytes);
            //HttpContext.Current.Response.Write(Doc);

            
            //HttpContext.Current.Response.ClearHeaders();



            //System.Diagnostics.Process.Start(filename);
        }
        public static void print_salary(Control employeelistDiv, string filename)
        {

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            HttpContext.Current.Response.ContentType = "application/pdf";
            //HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename =" + filename);
            //HttpContext.Current.Server.MapPath(("/PDF/") + filename);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            employeelistDiv.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

            Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);

            PdfWriter.GetInstance(Doc, HttpContext.Current.Response.OutputStream);
            PdfWriter writer = PdfWriter.GetInstance(Doc, memoryStream);

            Doc.Open();

            htmlparser.Parse(stringReader);
            Doc.Close();

            byte[] bytes = memoryStream.ToArray();
            System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/PDF/") + filename, bytes);
            //HttpContext.Current.Response.Write(Doc);


        }






    }

    }

