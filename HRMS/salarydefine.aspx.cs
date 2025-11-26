using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class salarydefine : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                custome_class.Bindemployee(ddlempcode);
                var list = (from a in dx.tbl_salary_components where a.status == true select a).ToList();
                rptsalarycom.DataSource = list;
                rptsalarycom.DataBind();
                bind();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            decimal amounts = 0;
            foreach (RepeaterItem item in rptsalarycom.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtamount = (TextBox)item.FindControl("txtamount");
                    if (txtamount.Text != "")
                    {
                        amounts = amounts += decimal.Parse(txtamount.Text);
                    }
                    lblsum.Text = amounts.ToString();
                }
            }
            lblcode.Text = ddlempcode.SelectedItem.Text;
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#custom-width-modal').modal('toggle');</script>");

            bind();

        }
        public void clear()
        {
            ddlempcode.SelectedIndex = 0;
            foreach (RepeaterItem item in rptsalarycom.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtamount = (TextBox)item.FindControl("txtamount");
                    Label lblsalarycom = (Label)item.FindControl("lblsalarycom");
                    txtamount.Text = "";

                }
            }
        }

        protected void btnsavess_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptsalarycom.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtamount = (TextBox)item.FindControl("txtamount");
                    Label lblsalarycom = (Label)item.FindControl("lblsalarycom");
                    if (txtamount.Text != "")
                    {
                        long empid = long.Parse(ddlempcode.SelectedValue);
                        var chk = (from a in dx.tbl_employee_salary where a.fk_employee_id == empid && a.salary_component==lblsalarycom.Text select a).FirstOrDefault();
                        if (chk == null)
                        {
                            tbl_employee_salary sal = new tbl_employee_salary();
                            sal.fk_employee_id = long.Parse(ddlempcode.SelectedValue);
                            sal.salary_component = lblsalarycom.Text;
                            sal.amount = int.Parse(txtamount.Text);
                           sal.status = true;
                            dx.tbl_employee_salary.Add(sal);
                            dx.SaveChanges();
                            bind();
                        }
                        else
                            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', ' " + lblsalarycom.Text + "  Already exist for Employee', 'error');", true);

                    }

                }
            }
            clear();
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Salary Has been Saved', 'success');", true);
        }


       

        public void bind()
        {

            


            var querys = dx.tbl_employee_salary

                 .GroupBy(x => new { empid = x.fk_employee_id })
                 .Select(x => new
                 {
                     empid = x.Key.empid,
                     Amount = x.Sum(s => s.amount)

                 });
            var bind = from emp in querys

                         join
                 de in dx.tbl_Employe on emp.empid equals de.id
                         select new
                         {
                             id =  emp.empid,
                             EmployeeCode=de.EmployeeCode,
                             name=de.FirstName+" "+de.MiddleName+" "+de.LastName,

                             Amount = emp.Amount,
                             
                         };




            if (bind != null)
            {
                rptleavetype.DataSource = bind.ToList() ;
                rptleavetype.DataBind();
            }

        }
        public void bindupdate(int id)
        {
            foreach (RepeaterItem item in rptsalarycom.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var bind = (from ep in dx.tbl_employee_salary
                                
                                where ep.fk_employee_id == id
                                select new
                                {
                                    ep.id,
                                    ep.salary_component,
                                    ep.amount

                                })
                                 .ToList();
                    if (bind != null)
                    {
                        btnUpdate.Visible = true;
                        btnsave.Visible = false;
                        ddlempcode.SelectedValue = id.ToString();
                        d_id.Value = id.ToString();
                        ddlempcode.Enabled = false;
                        ddlempcode.CssClass = "form-control";
                        TextBox txtamount = (TextBox)item.FindControl("txtamount");
                        Label lbl = (Label)item.FindControl("lblsalarycom");
                        txtamount.Text = null;

                        for (int i = 0; i < bind.Count; i++) {
                            
                            if (lbl.Text == bind[i].salary_component.ToString())
                            {
                                txtamount.Text = bind[i].amount.ToString();
                            }
                        }
                      
                    }
                    
                    
                }
            }

         }
            
        

        public void update()
        {
            long empid = long.Parse(ddlempcode.SelectedValue);
            var chk = (from a in dx.tbl_employee_salary where a.fk_employee_id == empid && a.status == true select a).ToList();
            if (chk != null)
            {
                //int empid = int.Parse(ddlempcode.SelectedValue);
                //int leavid = int.Parse(ddlleave.SelectedValue);
                foreach (RepeaterItem item in rptsalarycom.Items)
                {
                    TextBox txtamount = (TextBox)item.FindControl("txtamount");
                    Label lbl = (Label)item.FindControl("lblsalarycom");
                    
                    for (int i = 0; i < chk.Count; i++)
                    {

                        if (lbl.Text == chk[i].salary_component.ToString())
                        {
                            chk[i].amount= long.Parse(txtamount.Text);
                        }
                    }

                    dx.SaveChanges();
                }
                bind();
            }
            else
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Not exist', 'error');", true);
        }


        protected void btnUpdate_Click(object sender, EventArgs e)

        {
            try
            {


                update();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Succesfully', 'Updated', 'success');", true);
                foreach (RepeaterItem item in rptsalarycom.Items)
                {
                    TextBox txtamount = (TextBox)item.FindControl("txtamount");
                    txtamount.Text = null;


                }
                btnsave.Visible = true;
                ddlempcode.Enabled = true;
                btnUpdate.Visible = false;
                d_id.Value = null;
                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptsalarycom.Items)
            {
                TextBox txtamount = (TextBox)item.FindControl("txtamount");
                txtamount.Text = null;


            }
            btnsave.Visible = true;
            ddlempcode.Enabled = true;
            btnUpdate.Visible = false;
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
                    string meassage = custome_class.deleteempsalary(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Succesfully', 'Deleted', 'success');", true);
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