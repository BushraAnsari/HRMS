using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class empsalaryslip : System.Web.UI.Page
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

                int UID = int.Parse(Session["userid"].ToString());

                    
                    //empid= emp.empid,
                    var binds = from a in dx.tbl_salary
                                        join c in dx.tbl_employee_conectivity on a.fk_emp_id equals c.employe_fk
                                        where c.userid_fk==UID
                                        select new {
                                            id = a.id,
                                            salary_month= a.salary_month,
                                            salary_year= a.salary_year,
                                            gd= a.gross_deduction_amount,
                                            ge=a.gross_deduction_amount,
                                            net_pay= a.net_pay,
                                            slip_url=a.slip_url
                                           




                                        };


                    
                    if (binds != null)
                    {
                        rptleavetype.DataSource = binds.ToList();
                        rptleavetype.DataBind();
                        
                    }
                

            
        }
        


        protected void rptleavetype_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //====== Here we use switch state to distinguish which link button is clicked based 
            //====== on command name supplied to the link button.
            switch (e.CommandName)
            {
                //==== This case will fire when link button placed
                //==== inside repeater having command name "Delete" is clicked.

                case ("Download"):
                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                    var slip = (from a in dx.tbl_salary where a.id==id select a).FirstOrDefault();
                    if(slip.slip_url!=null)
                    this.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('"+slip.slip_url+"','_newtab');", true);


                    //==== Call delete method and pass id as argument.
                    //string meassage = custome_class.deletesalaryrecord(id);
                    //if (meassage == "success")
                    //{
                    //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Salary Record Deleted', 'success');", true);
                    //    bind();
                    //}
                    //else
                    //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Something went wrong" + meassage + "', 'error');", true);




                    break;

                //==== This case will fire when link button placed
                //==== inside repeater having command name "Edit" is clicked.
                case ("Edit"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    id = Convert.ToInt32(e.CommandArgument);
                    
                    //leavetype = id;

                    //==== Call delete method and pass id as argument.
                    //bindEmployeeDetailToEdit(id);

                    break;

            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}