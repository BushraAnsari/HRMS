using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class ReportEmployee : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                bind();

            }
        }
        public void bind()
        {
            var rpt = dx.SP_Employe_report1();
            rptitemdetails.DataSource = rpt;
            rptitemdetails.DataBind();
        }
    }
}