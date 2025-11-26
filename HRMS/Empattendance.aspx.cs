using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class Empattendance : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        long empid;
        TimeSpan time = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
        long gradeid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
                //var get = (from a in dx.tbl_emp_time_set where a.fk_grade_id == userid && a.status == true select a).FirstOrDefault();

            }
        }
        public void bind()
        {
            // getuserid();


            var bind = (from timein in dx.tbl_emp_attendance where timein.Type == "Time In"
                        from timeout in dx.tbl_emp_attendance where timeout.Type == "Time Out"
                        from leave in dx.tbl_emp_attendance where leave.Type == null
                        where timein.date == timeout.date && timein.fk_emp == timeout.fk_emp
                        join c in dx.tbl_Employe on timein.fk_emp equals c.id
                        
                        select new
                       
                        {

                            id = c.id,
                            empcode = c.EmployeeCode + "-" + c.FirstName + " " + c.MiddleName + " " + c.LastName,
                            date = timein.date,
                            timein = timein.inserteddatetime,
                            timeout = timeout.inserteddatetime,
                            lates = timein.late == true ? "Late" : "",
                            leaves = leave.leave == true ? "Leave" : "",
                            working = timeout.working_hours

                        });

           

           

            rptdept.DataSource = bind.ToList();
            rptdept.DataBind();

        }


        protected void btnin_Click(object sender, EventArgs e)
        {

            long userid = long.Parse(Session["userid"].ToString());
            var get = (from a in dx.tbl_employee_conectivity where a.userid_fk == userid && a.status == true select a).FirstOrDefault();
            if (get != null)
            {
                var employee_fk = get.employe_fk;
                empid = long.Parse(employee_fk.ToString());
                gradeid = long.Parse(get.grade_fk.ToString());
                tbl_emp_attendance timein = new tbl_emp_attendance();
                //long userid = long.Parse(Session["userid"].ToString());
                timein.fk_emp = empid;
                string date = DateTime.Now.ToString("yyyy-MM-dd").ToString();


                var gets = (from a in dx.tbl_emp_time_set where a.fk_grade_id == gradeid && a.status == true select a).FirstOrDefault();
                if (gets != null)
                {

                    
                    
                    var gettime = (from a in dx.tbl_emp_attendance where a.fk_emp == empid && a.date.ToString() == date select a).FirstOrDefault();
                    if (gettime == null)
                    {
                        timein.fk_emp_time_set = gets.id;
                        timein.date = DateTime.Now;
                        timein.time = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        timein.Type = "Time In";
                        timein.month = DateTime.Now.Month;
                        timein.year = DateTime.Now.Year;
                        timein.inserteddatetime = DateTime.Now;
                        timein.status = true;
                        DateTime dt = DateTime.Parse(gets.timeIN.ToString());
                        TimeSpan settime = TimeSpan.Parse(dt.ToString("HH:mm:ss"));
                        TimeSpan timenow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        if (timenow <= settime )
                            timein.late = false;
                        else
                            timein.late = true;

                        dx.tbl_emp_attendance.Add(timein);
                        dx.SaveChanges();
                    }
                    else
                    {
                        if (gettime.leave == true) {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Date Mark as Leave', 'warning');", true);
                        }
                        else
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Today Time in Record Already exist', 'warning');", true);
                    }
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Please insert time set for employe', 'warning');", true);
                }


            }



        
            else
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'ID not exist " + userid + "', 'error');", true);

            

               
           
        }

        protected void btnout_Click(object sender, EventArgs e)
        {
            long userid = long.Parse(Session["userid"].ToString());
            string date = DateTime.Now.ToString("yyyy-MM-dd").ToString();

            var get = (from a in dx.tbl_employee_conectivity where a.userid_fk == userid && a.status == true select a).FirstOrDefault();
            if (get != null)
            {
                var employee_fk = get.employe_fk;
                empid = long.Parse(employee_fk.ToString());
                gradeid = long.Parse(get.grade_fk.ToString());

                try
                {

                    var gettime = (from a in dx.tbl_emp_attendance where a.fk_emp == empid && a.Type == "Time In" && a.date.ToString() == date select a).FirstOrDefault();

                    if (gettime != null)
                    {
                        var gettimeout = (from a in dx.tbl_emp_attendance where a.fk_emp == empid && a.Type == "Time Out" && a.date.ToString() == date select a).FirstOrDefault();

                        if (gettimeout == null)
                        {
                            tbl_emp_attendance timein = new tbl_emp_attendance();
                            timein.fk_emp = empid;
                            var gets = (from a in dx.tbl_emp_time_set where a.fk_grade_id == gradeid && a.status == true select a).FirstOrDefault();
                            timein.fk_emp_time_set = gets.id;
                            timein.date = DateTime.Now;
                            timein.time = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            timein.Type = "Time Out";
                            timein.inserteddatetime = DateTime.Now;
                            timein.status = true;

                            TimeSpan minutes1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            TimeSpan minutes2 = TimeSpan.Parse(gettime.time.ToString());
                            double working_hours = Math.Round((minutes1.TotalHours - minutes2.TotalHours),2);
                            timein.working_hours = working_hours;
                            dx.tbl_emp_attendance.Add(timein);
                            dx.SaveChanges();
                        }
                        else
                            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Today Time Out Data Already exist', 'Please insert Today Time in Data ', 'error');", true);

                    }
                    else
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Time in Data not exist', 'Please insert Today Time in Data ', 'error');", true);

                }
                catch (Exception ex)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
                }
            }
            else
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'ID not exist " + userid + "', 'error');", true);

        }

    }
}