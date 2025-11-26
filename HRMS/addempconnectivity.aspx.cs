using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addempconnectivity : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
     

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                custome_class.BindDeprt(ddldept);
                custome_class.Bindemployee(ddlempcode);
                custome_class.Bindemployee(ddlsupervisor);
                custome_class.bindtitle(ddljobtittle);
                custome_class.Bindemployestatus(ddlempstatus);
                custome_class.Bindgrade(ddlgrade);
                if (Request["code"] != null)
                {
                    string code = Request["code"];
                    var id = (from a in dx.tbl_Employe where a.EmployeeCode == code select a).FirstOrDefault();
                    ddlempcode.SelectedValue = id.id.ToString();
                    ddlempcode.Enabled = false;
                    ddlempcode.CssClass = "form-control";

                }

                txtcontractdatestart.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtcontractdateend.Text = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
                txtconfimationdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtjoindate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                bind();
                //custome_class.bindpolicy(ddlleavingpolicy);
            }
        }
        public void bind()
        {
           // getuserid();


            var bind = (from ep in dx.tbl_employee_conectivity
                        join a in dx.tbl_Employe on ep.employe_fk equals a.id
                        join d in dx.tbl_dept on ep.Dept_fk equals d.id
                        join g in dx.tbl_emp_grade on ep.grade_fk equals g.id
                        join j in dx.tbl_job_descrion on ep.jobtitle_fk equals j.id
                       join r in dx.tbl_Employe on ep.Supervisor_fk equals r.id
                       join emp_st in dx.tbl_Employee_status on ep.Emplyeestatus_fk equals emp_st.id
                        where a.status == true
                        select new
                        {
                            id = ep.id,
                            name = a.FirstName + " " + a.MiddleName + " " + a.LastName,
                            empcode = a.EmployeeCode,
                            dept_name = d.Department_name,
                            job= j.Designation,
                            join_date=ep.Joindate,
                            conf_date=ep.Confirmationdate,
                            grade=g.Empgrade,
                            report_person=r.FirstName+" "+r.MiddleName+" "+r.LastName,
                            emp_status= emp_st.Employee_status_name,
                            con_start_date= ep.ContractStartDate,
                            con_end_date=ep.ContractEndDate
                            

                        }).ToList();
            rptdept.DataSource = bind;
            rptdept.DataBind();

        }
        protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getuserid();
            

        }
        protected void ddlempcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            getuserid();
        }
        protected long getuserid() {
            long empid = long.Parse(ddlempcode.SelectedValue);
            var chkuser = (from a in dx.tbl_Employe where a.id == empid  && a.status == true select a).FirstOrDefault();
            string username = chkuser.WorkEmail;
            var chkuserid = (from a in dx.tbl_login where a.Email == username select a).FirstOrDefault();
            long userid = chkuserid.id;


            return userid;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                long epid = long.Parse(ddlempcode.SelectedValue);
                var chk = (from a in dx.tbl_employee_conectivity where a.employe_fk == epid && a.status == true select a).FirstOrDefault();
                if (chk == null)
                {

                    tbl_employee_conectivity connec = new tbl_employee_conectivity();
                    connec.employe_fk = long.Parse(ddlempcode.SelectedValue);
                    connec.Dept_fk = long.Parse(ddldept.SelectedValue);
                    connec.jobtitle_fk = long.Parse(ddljobtittle.SelectedValue);
                    connec.Joindate = Convert.ToDateTime(txtjoindate.Text);
                    connec.Confirmationdate = Convert.ToDateTime(txtconfimationdate.Text);
                    connec.grade_fk = long.Parse(ddlgrade.SelectedValue);
                    connec.Supervisor_fk = long.Parse(ddlsupervisor.SelectedValue);
                    connec.userid_fk = getuserid();
                    connec.Emplyeestatus_fk = long.Parse(ddlempstatus.SelectedValue);
                    connec.ContractStartDate = Convert.ToDateTime(txtcontractdatestart.Text);
                    connec.ContractEndDate = Convert.ToDateTime(txtcontractdateend.Text);
                    connec.inserteddatetime = DateTime.Now;
                    connec.insertedby = long.Parse(Session["userid"].ToString());
                    connec.status = true;
                    dx.tbl_employee_conectivity.Add(connec);
                    dx.SaveChanges();
                    bind();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Employee Connection Has been Generated', 'success');", true);

                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Employee Connection record already exists', 'warning');", true);

                }
            }
            catch(Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!',"+ex.Message+", 'warning');", true);
            }


        }
        protected void rptdept_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    string meassage = custome_class.deleteempcon(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Deleted', 'success');", true);
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
        public void bindupdate(int id)
        {
            var bind = (from ep in dx.tbl_employee_conectivity
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                btnsave.Visible = false;
                ddlempcode.SelectedValue = bind.employe_fk.ToString();
                ddldept.SelectedValue = bind.Dept_fk.ToString();
                ddljobtittle.SelectedValue = bind.jobtitle_fk.ToString();
                txtjoindate.Text = DateTime.Parse(bind.Joindate.ToString()).ToString("yyyy-MM-dd");
                txtconfimationdate.Text = DateTime.Parse(bind.Confirmationdate.ToString()).ToString("yyyy-MM-dd");
                ddlgrade.SelectedValue = bind.grade_fk.ToString();
                ddlsupervisor.SelectedValue = bind.Supervisor_fk.ToString();
                ddlempstatus.SelectedValue = bind.Emplyeestatus_fk.ToString();
                txtcontractdatestart.Text = DateTime.Parse(bind.ContractStartDate.ToString()).ToString("yyyy-MM-dd");
                txtcontractdateend.Text = DateTime.Parse(bind.ContractEndDate.ToString()).ToString("yyyy-MM-dd");

                d_id.Value = id.ToString();
                ddlempcode.Enabled = false;
                ddlempcode.CssClass = "form-control";
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                updateempcon();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);

                // txtpermonthamount.Visible = true;
                btnUpdate.Visible = false;
                btnsave.Visible = true;

                ddlempcode.SelectedIndex = 0;
                ddldept.SelectedIndex = 0;
                ddljobtittle.SelectedIndex = 0;
                ddlgrade.SelectedIndex = 0;
                ddlsupervisor.SelectedIndex = 0;
                ddlempstatus.SelectedIndex = 0;
                d_id.Value = null;
                ddlempcode.Enabled = true;
                bind();



            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }

        private void updateempcon()
        {
            int update_id = int.Parse(d_id.Value.ToString());

            var chk = (from a in dx.tbl_employee_conectivity where a.id == update_id select a).FirstOrDefault();


            if (chk != null)
            {
                chk.Dept_fk = long.Parse(ddldept.SelectedValue);
                chk.jobtitle_fk = long.Parse(ddljobtittle.SelectedValue);
                chk.Joindate = Convert.ToDateTime(txtjoindate.Text);
                chk.Confirmationdate = Convert.ToDateTime(txtconfimationdate.Text);
                chk.grade_fk = long.Parse(ddlgrade.SelectedValue);
                chk.Supervisor_fk = long.Parse(ddlsupervisor.SelectedValue);
                chk.userid_fk = getuserid();
                chk.Emplyeestatus_fk = long.Parse(ddlempstatus.SelectedValue);
                chk.ContractStartDate = Convert.ToDateTime(txtcontractdatestart.Text);
                chk.ContractEndDate = Convert.ToDateTime(txtcontractdateend.Text);
                chk.inserteddatetime = DateTime.Now;
                chk.insertedby = long.Parse(Session["userid"].ToString());
                chk.status = true;
                dx.SaveChanges();




            }
        }
            protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnsave.Visible = true;
            
            ddlempcode.SelectedIndex=0;
            ddldept.SelectedIndex=0;
            ddljobtittle.SelectedIndex=0;
            ddlgrade.SelectedIndex=0;
            ddlsupervisor.SelectedIndex=0;
            ddlempstatus.SelectedIndex=0;
            d_id.Value = null;
            ddlempcode.Enabled = true;
            bind();



        }

        protected void ddlempstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlempstatus.SelectedItem.Text == "Permenant") {
                divcontract.Visible = false;
            }
        }
    }
}