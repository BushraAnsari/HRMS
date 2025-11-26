using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addempgrade : System.Web.UI.Page
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
            var bind = (from a in dx.tbl_emp_grade where a.status == true select a).ToList();
            rptgrade.DataSource = bind;
            rptgrade.DataBind();

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                 var chk = dx.tbl_emp_grade.Where(x => x.Empgrade == txtgradename.Text).FirstOrDefault();
               
                if (chk == null)
                {
                    tbl_emp_grade grade = new tbl_emp_grade();
                    grade.Empgrade = txtgradename.Text;
                    grade.Note = txtnote.Text;
                    grade.status = true;
                    dx.tbl_emp_grade.Add(grade);
                    dx.SaveChanges();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Grade Has been Generrated', 'success');", true);
                    bind();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Grading record already exists', 'warning');", true);
                }
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong" + ex.Message + "', 'error');", true);
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                updategrade();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);

                // txtpermonthamount.Visible = true;
                btnUpdate.Visible = false;
                btnsave.Visible = true;

                txtgradename.Text = null;
                txtnote.Text = null;
                g_id.Value = null;


                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }
        }
        protected void rptgrade_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    string meassage = custome_class.deletegrade(id);
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

                    bindgrade(id);
                    //leavetype = id;

                    //==== Call delete method and pass id as argument.
                    //bindEmployeeDetailToEdit(id);

                    break;

            }
        }

        private void bindgrade(int id)
        {
            var bind = (from ep in dx.tbl_emp_grade
                        where ep.id == id
                        select new
                        {
                            ep.id,
                            ep.Empgrade,
                            ep.Note,

                        })
                               .FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                btnsave.Visible = false;
                txtgradename.Text = bind.Empgrade.ToString();
                txtnote.Text = bind.Note.ToString();
                g_id.Value = id.ToString();
            }
        }

        private void updategrade()
        {
            int grade_id = int.Parse(g_id.Value.ToString());

            var chk = (from a in dx.tbl_emp_grade where a.id == grade_id select a).FirstOrDefault();


            if (chk != null)
            {
                chk.Empgrade = txtgradename.Text;
                chk.Note = txtnote.Text;
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
            btnsave.Visible = true;
            txtnote.Text = null;
            txtgradename.Text = null;
                btnUpdate.Visible = false;
        }
    }
}