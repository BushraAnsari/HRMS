using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class salarydetuctionpolicy : System.Web.UI.Page
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
            custome_class.Bindgrade(ddlgrade);
            var bind = (from a in dx.tbl_salary_detuction_policy where a.Status == true
                        join s in dx.tbl_emp_grade on a.fk_emp_grade equals s.id select new {a.id,
                            a.absent_detuction,
                            a.late_detuction,
                            emp_grade=s.Empgrade


                        }).ToList();
            rptdept.DataSource = bind;
            rptdept.DataBind();



        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var grade = long.Parse(ddlgrade.SelectedValue);
            var chk = (from a in dx.tbl_salary_detuction_policy where a.fk_emp_grade == grade && a.Status == true select a).FirstOrDefault();
            if (chk == null)
            {
                tbl_salary_detuction_policy dep = new tbl_salary_detuction_policy();
                dep.fk_emp_grade = grade;
                dep.late_detuction = txtlate.Text;
                dep.absent_detuction = txtabsent.Text;
                dep.Status = true;
                dx.tbl_salary_detuction_policy.Add(dep);
                dx.SaveChanges();
                bind();
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
                    string meassage = custome_class.deletesalarypolicy(id);
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
            var bind = (from ep in dx.tbl_salary_detuction_policy
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                Save.Visible = false;
                ddlgrade.Enabled = false;
                ddlgrade.CssClass = "form-control";
                txtabsent.Text = bind.absent_detuction.ToString();
                txtlate.Text = bind.late_detuction.ToString();
                ddlgrade.SelectedValue = bind.fk_emp_grade.ToString();
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

                txtabsent.Text = null;
                txtlate.Text = null;
                ddlgrade.SelectedIndex = 0;
                d_id.Value = null;
                ddlgrade.Enabled = true;

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

            var chk = (from a in dx.tbl_salary_detuction_policy where a.id == dept_id select a).FirstOrDefault();


            if (chk != null)
            {
                var grade = long.Parse(ddlgrade.SelectedValue);
                chk.absent_detuction = txtabsent.Text;
                chk.late_detuction = txtlate.Text;
                chk.fk_emp_grade = grade;
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
            txtabsent.Text = null;
            txtlate.Text = null;
            ddlgrade.SelectedIndex = 0;
            btnUpdate.Visible = false;
            d_id.Value = null;
            ddlgrade.Enabled = true;
        }
    }
}