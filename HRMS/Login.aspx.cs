
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class Login : System.Web.UI.Page
    {

        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            var login = (from a in dx.tbl_login where a.username == txtusername.Value && a.password == txtpassword.Value && a.Active_status == true select a).SingleOrDefault();
            if (login != null)
            {
                Session["userid"] = login.id;
                Session["usertype"] = login.User_type;
                Session["User_Name"] = login.username;

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "ID or Password Incorrect";
                lblerror.ForeColor = System.Drawing.Color.Red;

            }

        }
    }
}