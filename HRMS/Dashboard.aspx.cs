using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class Dashboard : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
            }

        private void bind()
        {
            //bind salary amount
            string month= System.Globalization.CultureInfo.CurrentCulture
        .DateTimeFormat.GetMonthName(DateTime.Now.Month);
            int year= DateTime.Now.Year;
            
            DateTime today = DateTime.Parse(DateTime.Now.Date.ToString("yyyy-MM-dd"));
            var salary = (from a in dx.tbl_salary where a.salary_month == month && a.salary_year == year.ToString() select a).ToList();
            double total = 0;
            for (int i = 0; i < salary.Count; i++) {
                total = total + salary[i].net_pay;

            }
            lblsalary.Text = total.ToString();

            //bind total employee
            var employee = (from a in dx.tbl_Employe where a.status == true select a).ToList();
            lbltotemployee.Text = employee.Count.ToString();

            //bind today present employee
            var today_emp = (from a in dx.tbl_emp_attendance where a.date==today && a.leave != true select a).ToList();
            lbltodayemployee.Text = today_emp.Count.ToString();


            //bind leave
            var today_leave = (from a in dx.tbl_emp_attendance where a.date == today && a.leave==true select a).ToList();
            lblleave.Text = today_leave.Count.ToString();










        }
    }
    }
