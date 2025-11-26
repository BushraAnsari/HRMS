using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class salary_slip : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
           }

        }
        public void generate_slip(DropDownList ddlempcode,string absentcount,string leavecount,string latecount,
                            string late_deduct, string absent_deduct,
                        string bonus, string salary, string total_deduct,
                        string net_pay, bool loan, string loan_amount,string month,string year)
        {
            HRMSEntities dx = new HRMSEntities();
            long userid = long.Parse(Session["userid"].ToString());
            long epid = long.Parse(ddlempcode.SelectedValue);
            var list = (from a in dx.tbl_Employe
                        join es in dx.tbl_employee_conectivity on a.id equals es.employe_fk
                        join d in dx.tbl_dept on es.Dept_fk equals d.id
                        join jb in dx.tbl_job_descrion on es.jobtitle_fk equals jb.id
                        where a.id == epid && a.status == true
                        select new
                        {
                            dept_name = d.Department_name,
                            emp_name = a.FirstName + " " + a.LastName,
                            designation = jb.Designation,



                        }).FirstOrDefault();



            var user = (from a in dx.tbl_login
                        join es in dx.tbl_employee_conectivity on a.id equals es.userid_fk
                        join d in dx.tbl_Employe on es.employe_fk equals d.id
                        where a.id == userid
                        select new
                        {
                            user_name = d.FirstName + "" + d.LastName,



                        }).FirstOrDefault();
            if (loan == false)
            {
                spanloan.InnerText = "-";
            }
            else
            {
                spanloan.InnerText = loan_amount ;
            }
            if (late_deduct  == "0")
            {
                spanlate.InnerText = "-";
            }
            else
            {
                spanlate.InnerText = late_deduct ;
            }
            if (bonus == "")
            {
                spanbonus.InnerText = "-";
            }
            else
            {
                spanbonus.InnerText = bonus ;
            }
            if (absent_deduct == "")
            {
                spanabsent.InnerText = "-";
            }
            else
            {
                spanabsent.InnerText = absent_deduct;
            }




            spanuserid.InnerText = user.user_name;
            spandept.InnerText = list.dept_name;
            spanempname.InnerText = list.emp_name;
            spandes.InnerText = list.designation;
            spanmonth.InnerText = month + "," + year;
            spansumearn.InnerText = salary;
            spandetsum.InnerText = total_deduct;
            spannetsum.InnerText = net_pay;
            spanabsentcount.InnerText = absentcount;
            spanlatecount.InnerText = latecount;
            spanleavecount.InnerText = leavecount;
            spanempcode.InnerText = ddlempcode.SelectedItem.Text;
            spaninwords.InnerText = custome_class.NumberToWords(int.Parse(net_pay));
            string filename = spanempcode.InnerText + spanmonth.InnerText + ".pdf";
            salary_class.print_salary_slip(divsalaryslip, "attachment; filename =" + filename);



        }
        public void bind()
        {
         

        }
        

        protected void btnsave_Click(object sender, EventArgs e)
        {
            }

        protected void btnsavess_Click(object sender, EventArgs e)
        {
            string filename = spanempcode.InnerText + spanmonth.InnerText + ".pdf";
            salary_class.print_salary_slip(divsalaryslip, "attachment; filename =" + filename);

        }
    }
}
    
