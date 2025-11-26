using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addleavingpolicy : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var chk = dx.tbl_leaving_policy.Where(x => x.Leavepolicy == txtpolicyname.Text).FirstOrDefault();
                if (chk == null)
                {
                    tbl_leaving_policy leave = new tbl_leaving_policy();
                    leave.Leavepolicy = txtpolicyname.Text;
                    leave.col_1 = decimal.Parse(TextBox1.Text);
                    leave.col_2 = decimal.Parse(TextBox2.Text);
                    leave.col_3 = decimal.Parse(TextBox3.Text);
                    leave.col_4 = decimal.Parse(TextBox4.Text);
                    leave.col_5 = decimal.Parse(TextBox5.Text);
                    leave.col_6 = decimal.Parse(TextBox6.Text);
                    leave.col_7 = decimal.Parse(TextBox7.Text);
                    leave.Note = txtnote.Text;
                    leave.status = true;
                    dx.tbl_leaving_policy.Add(leave);
                    dx.SaveChanges();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Employee Has been Generrated', 'success');", true);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Policy record already exists', 'warning');", true);
                }
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }
    }
}