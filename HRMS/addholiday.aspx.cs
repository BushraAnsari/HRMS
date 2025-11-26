using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addholiday : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                //custome_class.BindDeprt(ddldept);
                //custome_class.Bindemployee(ddlsupervisor);
                //custome_class.bindtitle(ddljobtittle);
                //custome_class.Bindemployestatus(ddlempstatus);
                //custome_class.Bindgrade(ddlgrade);
                //custome_class.bindpolicy(ddlleavingpolicy);


            }
            bind();
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            int rid = int.Parse(ddlholiday.SelectedValue);

            try
            {


                var pkTime = TimeZoneInfo.ConvertTime(DateTime.Now,
                                 TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time"));
                if (divdate.Visible ==true) {
                    DateTime date = DateTime.Parse(txtdate.Text);

                   


                    var chk = (from a in dx.tbl_emp_holiday where a.repeat_time == rid && a.holiday_date == date select a).FirstOrDefault();


                    if (chk == null)
                    {
                        tbl_emp_holiday connec = new tbl_emp_holiday();

                        connec.repeat_time = rid;
                        connec.holiday_date = date;
                        
                        dx.tbl_emp_holiday.Add(connec);
                        dx.SaveChanges();
                        bind();
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Holiday Added', 'success');", true);

                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Holiday Already Exist', 'warning');", true);

                    }
                }
                else if (divday.Visible == true)
                {
                    int day = int.Parse(ddlday.SelectedValue);



                    var chk = (from a in dx.tbl_emp_holiday where a.repeat_time == rid && a.holiday_day == day select a).FirstOrDefault();


                    if (chk == null)
                    {
                        tbl_emp_holiday connec = new tbl_emp_holiday();

                        connec.repeat_time = rid;
                        connec.holiday_day = day;

                        dx.tbl_emp_holiday.Add(connec);
                        dx.SaveChanges();
                        bind();
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Holiday Added', 'success');", true);

                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Employee Loan already exists', 'warning');", true);

                    }
                }
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);

            }

        }

        protected void ddlgradeid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {

        }

        protected void ddlholiday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlholiday.SelectedValue == "0") { divdate.Visible = true; divday.Visible = false; }
            else if (ddlholiday.SelectedValue == "1") { divday.Visible = true; divdate.Visible = false; }
            else if (ddlholiday.SelectedValue == "2") { divdate.Visible = true; divday.Visible = false; }
            //try
            //{
            //    long epid = long.Parse(ddlempid.SelectedValue);
            //    long loanamount = long.Parse(txtloanamount.Text);
            //    int payabletime = int.Parse(txtlpayabletime.Text);
            //    txtpermonthamount.Text = (loanamount / payabletime).ToString();
            //}
            //catch { }

        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    long epid = long.Parse(ddlempid.SelectedValue);
            //    long loanamount = long.Parse(txtloanamount.Text);
            //    int payabletime = int.Parse(txtlpayabletime.Text);
            //    txtpermonthamount.Text = (loanamount / payabletime).ToString();
            //}
            //catch { }
        }


        
            protected void ddlday_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    long epid = long.Parse(ddlempid.SelectedValue);
            //    long loanamount = long.Parse(txtloanamount.Text);
            //    int payabletime = int.Parse(txtlpayabletime.Text);
            //    txtpermonthamount.Text = (loanamount / payabletime).ToString();
            //}
            //catch { }
        }
        public void bind()
        {
            var bind = (from ep in dx.tbl_emp_holiday
                        select new
                        {
                            ep.id,
                            ep.repeat_time,
                            ep.holiday_date,
                            holiday_day=ep.holiday_day.ToString()
                        }).ToList();


            if (bind != null)
            {
                rptleavetype.DataSource = bind;
                rptleavetype.DataBind();
            }

        }
        public void bindupdate(int id)
        {
            var bind = (from ep in dx.tbl_emp_holiday
                        where ep.id == id
                        join e in dx.tbl_emp_grade on ep.grade_id equals e.id
                        select new
                        {
                                e.id,

                                 ep.repeat_time,
                                ep.holiday_day,
                                ep.holiday_date})
                                .FirstOrDefault();
            if (bind != null)
            {
                btnupdate.Visible = true;
                btnsave.Visible = false;
                ddlholiday.Enabled = false;
                ddlholiday.CssClass = "form-control";
                //txtpermonthamount.Visible = false;
                if (bind.repeat_time == 1)
                {
                    divdate.Visible = false;
                    divday.Visible = true;
                    ddlholiday.SelectedValue = "1";
                }
                else if (bind.repeat_time == 2)
                {
                    divdate.Visible = true;
                    divday.Visible = false;
                    ddlholiday.SelectedValue = "2";
                }
                else if (bind.repeat_time==0) {
                    divdate.Visible = true;
                    divday.Visible = false;
                    ddlholiday.SelectedValue = "0";
                }
                txtdate.Text = bind.holiday_date.ToString();
                ddlday.SelectedValue = bind.holiday_day.ToString();
               // btnupdate.Visible = true;
                  
            }
           
            
        }

        public void updateholiday()
        {

            
            if (divdate.Visible == true)
            {
                DateTime date = DateTime.Parse(txtdate.Text);
                int rid = int.Parse(ddlholiday.SelectedValue);





                var chk = (from a in dx.tbl_emp_holiday where a.repeat_time == rid select a).FirstOrDefault();


                if (chk != null)
                {
                    chk.repeat_time = rid;
                    chk.holiday_date = date;

                    dx.tbl_emp_holiday.Add(chk);
                    dx.SaveChanges();
                    bind();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Holiday Updated', 'success');", true);

                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Holiday Not Exist', 'warning');", true);

                }
            }
            else if (divday.Visible == true)
            {
                int day = int.Parse(ddlday.SelectedValue);
                int rid = int.Parse(ddlholiday.SelectedValue);



                var chk = (from a in dx.tbl_emp_holiday where a.repeat_time == rid select a).FirstOrDefault();


                if (chk != null)
                {
                    chk.repeat_time = rid;
                    chk.holiday_day = day;

                   // dx.tbl_emp_holiday.Add(chk);
                    dx.SaveChanges();
                    bind();
                    
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Holiday Updated', 'success');", true);

                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Holiday not Exist', 'warning');", true);

                }
            }
        }
           


        protected void Btnupdate_Click(object sender, EventArgs e)

        {
            try


           {


                updateholiday();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);
                ddlholiday.Enabled = true;
                // txtpermonthamount.Visible = true;
                //btnUpdate.Visible = false;
                btnsave.Visible = true;
                btnupdate.Visible = false;

                txtdate.Text = "";
                ddlholiday.SelectedValue = "";
                ddlday.SelectedValue = "";

                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            btnsave.Visible = true;
           divdate.Visible=false;
            ddlholiday.SelectedValue = "";
            divday.Visible=false;
            //btnUpdate.Visible = false;
            ddlholiday.Enabled = true;
        }

        protected void rptleavetype_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //====== Here we use switch state to distinguish which link button is clicked based 
            //====== on command name supplied to the link button.
            switch (e.CommandName)
            {
                //==== This case will fire when link button placed
                //==== inside repeater having command name "Delete" is clicked.

                case ("Delete"):
                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);

                    //==== Call delete method and pass id as argument.
                    string meassage = custome_class.deleteholiday(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Leave Request Deleted', 'success');", true);
                        bind();
                    }
                    else
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Something went wrong" + meassage + "', 'error');", true);




                    break;

                //==== This case will fire when link button placed
                //==== inside repeater having command name "Edit" is clicked.
                case ("Edit"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    id = Convert.ToInt32(e.CommandArgument);
                
                    bindupdate(id);
                    //leavetype = id;

                    //==== Call delete method and pass id as argument.
                    //bindEmployeeDetailToEdit(id);

                    break;

            }
        }

        
    }





}