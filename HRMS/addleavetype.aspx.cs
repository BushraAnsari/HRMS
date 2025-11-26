using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addleavetype : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
            }

        }
        public void bind()
        {
            var bind = (from a in dx.tbl_leave_type where a.status == true select a).ToList();
            rptleavetype.DataSource = bind;
            rptleavetype.DataBind();

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {

                var chk = (from a in dx.tbl_leave_type where a.leave_type_name == txtleavetype.Text && a.status == true select a).FirstOrDefault();
                if (chk == null)
                {
                    tbl_leave_type dep = new tbl_leave_type();
                    dep.leave_type_name = txtleavetype.Text;
                    dep.total_in_year = int.Parse(yearly.Text);
                    dep.status = true;
                    dx.tbl_leave_type.Add(dep);
                    dx.SaveChanges();
                    bind();
                }
                else
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Already exist', 'error');", true);

            }
            catch (Exception ex)
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
                    string meassage = custome_class.deleteleavetype(id);
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
            var bind = (from ep in dx.tbl_leave_type
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                Save.Visible = false;
                txtleavetype.Text = bind.leave_type_name.ToString();
                yearly.Text = bind.total_in_year.ToString();
                d_id.Value = id.ToString();
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

                txtleavetype.Text = null;
                yearly.Text = null;
                d_id.Value = null;


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

            var chk = (from a in dx.tbl_leave_type where a.id == dept_id select a).FirstOrDefault();


            if (chk != null)
            {
                var chks = (from a in dx.tbl_leave_type where a.leave_type_name == txtleavetype.Text select a).FirstOrDefault();


                if (chks == null || chk.leave_type_name==txtleavetype.Text)
                {
                    chk.leave_type_name = txtleavetype.Text;
                    chk.total_in_year = int.Parse(yearly.Text);
                    dx.SaveChanges();
                    bind();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Updated', 'success');", true);
                }
                else
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Already Exist', 'warning');", true);

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Not Exist', 'warning');", true);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Save.Visible = true;
            txtleavetype.Text = null;
            yearly.Text = null;
            btnUpdate.Visible = false;

        }
    }
}