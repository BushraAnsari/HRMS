using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addemptimeset : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                custome_class.Bindgrade(ddlemp);
                bind();
            }
        }

        public void bind()
        {
            var rec = (from a in dx.tbl_emp_time_set
                       join b in dx.tbl_emp_grade on a.fk_grade_id equals b.id
                       select new { a.id,a.timeIN, a.timeout, b.Empgrade, b.Note}
                       ).ToList();
            rpttimeset.DataSource = rec;
            rpttimeset.DataBind();
        }
        
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                long userid = long.Parse(ddlemp.SelectedValue);
                var chk = (from a in dx.tbl_emp_time_set where a.fk_grade_id == userid && a.status == true select a).FirstOrDefault();
            if (chk == null)
                {
                    tbl_emp_time_set set = new tbl_emp_time_set();
                    set.fk_grade_id = userid;
                    set.timeIN = TimeSpan.Parse(txttimeint.Value);
                    set.timeout = TimeSpan.Parse(txttimeout.Value);
                    set.status = true;
                    dx.tbl_emp_time_set.Add(set);
                    dx.SaveChanges();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Succesfully', 'Saved', 'success');", true);
                    bind();
                }
            else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Employee Time record already exists', 'warning');", true);
                }

            }
            catch(Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
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
                    string meassage = custome_class.deletetimeset(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Succesfully','Deleted', 'success');", true);
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
            var bind = (from ep in dx.tbl_emp_time_set
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                Save.Visible = false;
                ddlemp.SelectedValue = bind.fk_grade_id.ToString();
                txttimeint.Value = bind.timeIN.ToString();
                txttimeout.Value = bind.timeout.ToString();
                d_id.Value = id.ToString();
                ddlemp.Enabled = false;
                ddlemp.CssClass = "form-control";
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                updatedept();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);

                // txtpermonthamount.Visible = true;
                btnUpdate.Visible = false;
                Save.Visible = true;

                ddlemp.SelectedIndex = 0;
                txttimeint.Value=null;
                txttimeout.Value = null;
                d_id.Value = null;
                ddlemp.Enabled = true;


                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }

        private void updatedept()
        {
            int dept_id = int.Parse(d_id.Value.ToString());
            long g_id = long.Parse(ddlemp.SelectedValue);
            
            var chk = (from a in dx.tbl_emp_time_set where a.id == dept_id select a).FirstOrDefault();


            if (chk != null)
            {
                chk.fk_grade_id = g_id;
                chk.timeIN = TimeSpan.Parse(txttimeint.Value);
                chk.timeout = TimeSpan.Parse(txttimeout.Value);
                dx.SaveChanges();
                bind();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Successfully', 'Updated', 'success');", true);

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Not Exist', 'warning');", true);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Save.Visible = true;
            btnUpdate.Visible = false;
            ddlemp.SelectedIndex = 0;
            txttimeint.Value = null;
            txttimeout.Value = null;
            d_id.Value = null;
            ddlemp.Enabled = true;

        }

    }
}