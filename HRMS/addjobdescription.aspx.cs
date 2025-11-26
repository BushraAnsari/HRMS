using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addjobdescription : System.Web.UI.Page
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
            var bind = (from a in dx.tbl_job_descrion where a.status == true select a).ToList();
            rptdept.DataSource = bind;
            rptdept.DataBind();

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            tbl_job_descrion jb = new tbl_job_descrion();
            jb.Job_description = txtjobdescription.Text;
            jb.Designation = txtdesignation.Text;
            jb.salary_range_max = decimal.Parse(txtmax.Text);
            jb.salary_range_min = decimal.Parse(txtmin.Text);


                dx.tbl_job_descrion.Add(jb);
            dx.SaveChanges();
            bind();

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
                    string meassage = custome_class.deletejobdesc(id);
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
            var bind = (from ep in dx.tbl_job_descrion
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                Save.Visible = false;
                txtdesignation.Text = bind.Designation.ToString();
                txtjobdescription.Text = bind.Job_description.ToString();
                txtmax.Text = bind.salary_range_max.ToString();
                txtmin.Text = bind.salary_range_min.ToString();

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

                txtdesignation.Text = null;
                txtjobdescription.Text =null;
                txtmax.Text = null;
                txtmin.Text = null;
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

            var chk = (from a in dx.tbl_job_descrion where a.id == dept_id select a).FirstOrDefault();


            if (chk != null)
            {
                chk.Job_description = txtjobdescription.Text;
                chk.Designation = txtdesignation.Text;
                chk.salary_range_max = decimal.Parse(txtmax.Text);
                chk.salary_range_min = decimal.Parse(txtmin.Text);
                dx.SaveChanges();
                bind();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Updated', 'success');", true);

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Not Exist', 'warning');", true);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Save.Visible = true;
            txtdesignation.Text = null;
            txtjobdescription.Text = null;
            txtmax.Text = null;
            txtmin.Text = null;
            btnUpdate.Visible = false;

        }
    }
}