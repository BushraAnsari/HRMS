using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class detuction_policy : System.Web.UI.Page
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
            

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var grade= long.Parse(ddlgrade.SelectedValue); 
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
    }
}