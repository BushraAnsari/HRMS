using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class add_subdept : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
                custome_class.BindDeprt(ddldept);
            }

        }
        protected string dept(object id)
        {
            string Name = "";
            if (id != null)
            {
                long _deptid = long.Parse(id.ToString());
                var qr = (from a in dx.tbl_dept where a.id == _deptid select a).FirstOrDefault();
                if (qr != null)
                {
                    return qr.Department_name.ToString();
                }
                else
                {
                    Name = "NA";
                }
            }
            else
            {
                Name = "NA";
            }

            return Name;
        }
        public void bind()
        {
            var bind = (from a in dx.tbl_sub_dept where a.status == true select a).ToList();
            rptsubdept.DataSource = bind;
            rptsubdept.DataBind();

        }
        

        protected void btnsave_Click(object sender, EventArgs e)
        {
            tbl_sub_dept sub_dep = new tbl_sub_dept();
            sub_dep.fk_dept_id = long.Parse(ddldept.SelectedValue);
            sub_dep.Sub_department_name = txtsubdeptname.Text;
            sub_dep.status = true;
            dx.tbl_sub_dept.Add(sub_dep);
            dx.SaveChanges();
            bind();
        }
    }
}
    
