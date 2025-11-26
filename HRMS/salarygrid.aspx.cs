using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class salarygrid : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                custome_class.BindDeprtAll(ddldept);
                custome_class.bindmonth(ddlmonth);
                custome_class.bindyear(ddlyear);


                bind();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            foreach (RepeaterItem item in rptsalaryslip.Items)
            {
                
                HiddenField lblempcode = (HiddenField)item.FindControl("HiddenCode");

                Control divsalaryslips = (Control)item.FindControl("divsalaryslips");
                string filename = lblempcode.Value + ddlmonth.SelectedItem.Text + ddlyear.SelectedItem.Text + ".pdf";
                salary_class.print_salary_slip(divsalaryslips, "attachment; filename =" + filename);

            }

           

        }
        public void clear()
        {
        }

        protected void btnsavess_Click(object sender, EventArgs e)
        {
            try
            {
                bind_slip();
                foreach (RepeaterItem item in rptleavetype.Items)
                {
                    CheckBox late = (CheckBox)item.FindControl("BtnLate");
                    CheckBox absent = (CheckBox)item.FindControl("BtnAbsent");
                    CheckBox loan = (CheckBox)item.FindControl("BtnLoan");

                    HiddenField lblempcode = (HiddenField)item.FindControl("HiddenID");
                    HiddenField lblsalary = (HiddenField)item.FindControl("hiddensalary");
                    HiddenField lbltotded = (HiddenField)item.FindControl("HiddenDeduct");
                    HiddenField lblnetpay = (HiddenField)item.FindControl("hiddennetpay");
                    HiddenField lbllate = (HiddenField)item.FindControl("hiddenlate");
                    HiddenField lblabsent = (HiddenField)item.FindControl("hiddenabsent");
                    HiddenField lblloan = (HiddenField)item.FindControl("hiddenloan");
               
                    long epid = long.Parse(lblempcode.Value);
                    long userid = long.Parse(Session["userid"].ToString());
                    string year = ddlyear.SelectedItem.Text;
                    string month = ddlmonth.SelectedItem.Text;
                    int deduction = int.Parse(lbltotded.Value);
                    int net_pay = int.Parse(lblnetpay.Value);
                    int late_pay = int.Parse(lbllate.Value);
                    int loan_pay = int.Parse(lblloan.Value);
                    int absent_pay = int.Parse(lblabsent.Value);

                    tbl_salary connec = new tbl_salary();
                    connec.fk_emp_id = epid;

                    if (late.Checked == false && lbllate.Value != "0") { deduction = deduction - late_pay; net_pay = net_pay + late_pay; }
                    if (loan.Checked == false && lblloan.Value != "0") { deduction = deduction - int.Parse(lblloan.Value); net_pay = net_pay + loan_pay; }
                    if (absent.Checked == false && lblabsent.Value != "0") { deduction = deduction - int.Parse(lblabsent.Value); net_pay = net_pay + absent_pay; }

                    connec.gross_deduction_amount = deduction;
                    connec.gross_earning_amount = int.Parse(lblsalary.Value);

                    connec.net_pay = net_pay;
                    connec.inserted_by = userid;
                    connec.salary_month = month;
                    connec.salary_year = year;


                    if (lblloan.Value != "0" && loan.Checked == true)
                    {
                        epid = long.Parse(lblempcode.Value);
                        int loanamount = int.Parse(lblloan.Value);
                        var tbl = new tbl_loanpaidemp();
                        var loans = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status == "Active" select a).FirstOrDefault();
                        int totalloanamount = int.Parse(loans.remaining_loan_amount.ToString());
                        loans.remaining_loan_amount = totalloanamount - loanamount;
                        loans.remaining_month_payable = loans.remaining_month_payable - 1;
                        if (loans.payable_amount_per_month >= loans.remaining_loan_amount)
                        {
                            loans.Status = "Expired";
                            loans.remaining_month_payable = 0;
                        }
                        dx.SaveChanges();
                    }
                    dx.tbl_salary.Add(connec);
                    dx.SaveChanges();
                    
                    //foreach (RepeaterItem items in rptsalaryslip.Items)
                    //{
                    //    Control divsalaryslips = (Control)items.FindControl("divsalaryslips");
                    //    string filename = lblempcode.Value + ddlmonth.SelectedItem.Text + ddlyear.SelectedItem.Text + ".pdf";
                    //    salary_class.print_salary_slip(divsalaryslips, "attachment; filename =" + filename);

                    //}

                    
                    

                }
                bind();

            }
                catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);

            }





            

        }


        public void bind_slip()
        {
            int year = int.Parse(ddlyear.SelectedItem.Text);
            int month = ddlmonth.SelectedIndex + 1;

            
                var query = dx.tbl_employee_salary

                 .GroupBy(x => new { empid = x.fk_employee_id })
                 .Select(x => new
                 {
                     empid = x.Key.empid,
                     Amount = x.Sum(s => s.amount)

                 });





               // long dept = long.Parse(ddldept.SelectedValue);
                var salary_result = from a in dx.tbl_salary
                                    where a.salary_year == ddlyear.SelectedItem.Text && a.salary_month == ddlmonth.SelectedItem.Text
                                    select a;


                var result = from emp in query

                             join
                     de in salary_result

                     on emp.empid equals de.fk_emp_id
                     into tempstorage
                             from dx in tempstorage.DefaultIfEmpty()


                             select new
                             {
                                 empid = (dx != null) ? 0 : emp.empid,
                                 //empid= emp.empid,
                                 Amount = emp.Amount,
                                 month = dx.salary_month,
                                 year = dx.salary_year

                             };

            var binds = from ep in result
                        join e in dx.tbl_Employe on ep.empid equals e.id
                        join d in dx.tbl_employee_conectivity on e.id equals d.employe_fk
                        join c in dx.tbl_dept on d.Dept_fk equals c.id
                        join j in dx.tbl_job_descrion on d.jobtitle_fk equals j.id

                        select new
                        {
                            EmployeeID = e.id,
                            EmployeeCode = e.EmployeeCode,
                            EmployeeName = e.FirstName + " " + e.LastName,
                            amount = ep.Amount,
                            job_title= j.Designation,
                            department_name= c.Department_name



                        };
            long userid = long.Parse(Session["userid"].ToString());
            var username = (from a in dx.tbl_login where a.id == userid select a.username).FirstOrDefault();

            var all = from ep in binds.AsEnumerable()
                      let absents = salary_class.get_absent_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                      let lates = salary_class.get_late_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                      let late_days = salary_class.get_late(ep.EmployeeID, year, month)
                      let absent_days = salary_class.get_absent_days(ep.EmployeeID, year, month)

                      let loans = salary_class.loan(ep.EmployeeID)
                      let total_decuction = loans + absents + lates
                      select new
                      {
                         
                          EmployeeID = ep.EmployeeID,
                          EmployeeCode = ep.EmployeeCode,
                          EmployeeName = ep.EmployeeName,
                          leave_days = absent_days[2],
                          absent_days= absent_days[3],
                          late_days= late_days,
                              salary = ep.amount,
                              absent = absents,
                              late = lates,
                              loan = loans,
                              total_deduction = loans + absents + lates,
                              net_pay = ep.amount - total_decuction,
                              department_name= ep.department_name,
                              job_title= ep.job_title,
                              salary_month = ddlmonth.SelectedItem.Text,
                              salary_year= ddlyear.SelectedItem.Text,
                              in_words= custome_class.NumberToWords(Convert.ToInt16(ep.amount - total_decuction)),
                              user_name=username



        };

            if (binds != null)
                {

                rptsalaryslip.DataSource = all.ToList();
                    rptsalaryslip.DataBind();
                foreach (RepeaterItem items in rptleavetype.Items)
                {
                    CheckBox latess = (CheckBox)items.FindControl("BtnLate");
                    CheckBox absentss = (CheckBox)items.FindControl("BtnAbsent");
                    CheckBox loanss = (CheckBox)items.FindControl("BtnLoan");
                    bool late = latess.Checked;
                    bool loan = loanss.Checked;
                    bool absent = absentss.Checked;

                    if (late == false)
                    {
                        var chng = from ep in binds.AsEnumerable()
                                   let absents = salary_class.get_absent_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                                   let lates = 0
                                   let late_days = salary_class.get_late(ep.EmployeeID, year, month)
                                   let absent_days = salary_class.get_absent_days(ep.EmployeeID, year, month)

                                   let loans = salary_class.loan(ep.EmployeeID)
                                   let total_decuction = loans + absents + lates

                                   select new
                                   {

                                       EmployeeID = ep.EmployeeID,
                                       EmployeeCode = ep.EmployeeCode,
                                       EmployeeName = ep.EmployeeName,
                                       leave_days = absent_days[2],
                                       absent_days = absent_days[3],
                                       late_days = late_days,
                                       salary = ep.amount,
                                       absent = absents,
                                       late = 0,
                                       loan = loans,
                                       total_deduction = loans + absents + lates,
                                       net_pay = ep.amount - total_decuction,
                                       department_name = ep.department_name,
                                       job_title = ep.job_title,
                                       salary_month = ddlmonth.SelectedItem.Text,
                                       salary_year = ddlyear.SelectedItem.Text,
                                       in_words = custome_class.NumberToWords(Convert.ToInt16(ep.amount - total_decuction)),
                                       user_name = username



                                   };

                        rptsalaryslip.DataSource = chng.ToList();
                        rptsalaryslip.DataBind();
                    }
                    if (absent == false)
                    {
                        var chng = from ep in binds.AsEnumerable()
                                   let absents = 0
                                   let lates = salary_class.get_late_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                                   let late_days = salary_class.get_late(ep.EmployeeID, year, month)
                                   let absent_days = salary_class.get_absent_days(ep.EmployeeID, year, month)

                                   let loans = salary_class.loan(ep.EmployeeID)
                                   let total_decuction = loans + absents + lates

                                   select new
                                   {

                                       EmployeeID = ep.EmployeeID,
                                       EmployeeCode = ep.EmployeeCode,
                                       EmployeeName = ep.EmployeeName,
                                       leave_days = absent_days[2],
                                       absent_days = absent_days[3],
                                       late_days = late_days,
                                       salary = ep.amount,
                                       absent = 0,
                                       late = lates,
                                       loan = loans,
                                       total_deduction = loans + absents + lates,
                                       net_pay = ep.amount - total_decuction,
                                       department_name = ep.department_name,
                                       job_title = ep.job_title,
                                       salary_month = ddlmonth.SelectedItem.Text,
                                       salary_year = ddlyear.SelectedItem.Text,
                                       in_words = custome_class.NumberToWords(Convert.ToInt16(ep.amount - total_decuction)),
                                       user_name = username




                                   };
                        rptsalaryslip.DataSource = chng.ToList();
                        rptsalaryslip.DataBind();
                    }
                    if (loan == false)
                    {
                        var chng = from ep in binds.AsEnumerable()
                                   let absents = salary_class.get_absent_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                                   let lates = salary_class.get_late_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                                   let late_days = salary_class.get_late(ep.EmployeeID, year, month)
                                   let absent_days = salary_class.get_absent_days(ep.EmployeeID, year, month)

                                   let loans = 0
                                   let total_decuction = loans + absents + lates

                                   select new
                                   {

                                       EmployeeID = ep.EmployeeID,
                                       EmployeeCode = ep.EmployeeCode,
                                       EmployeeName = ep.EmployeeName,
                                       leave_days = absent_days[2],
                                       absent_days = absent_days[3],
                                       late_days = late_days,
                                       salary = ep.amount,
                                       absent = absents,
                                       late = lates,
                                       loan = 0,
                                       total_deduction = loans + absents + lates,
                                       net_pay = ep.amount - total_decuction,
                                       department_name = ep.department_name,
                                       job_title = ep.job_title,
                                       salary_month = ddlmonth.SelectedItem.Text,
                                       salary_year = ddlyear.SelectedItem.Text,
                                       in_words = custome_class.NumberToWords(Convert.ToInt16(ep.amount - total_decuction)),
                                       user_name = username




                                   };
                        rptsalaryslip.DataSource = chng.ToList();
                        rptsalaryslip.DataBind();
                    }






                }
                foreach (RepeaterItem item in rptsalaryslip.Items)
                {

                    Repeater rptr = (Repeater)item.FindControl("rptslip");
                    HiddenField lblempcode = (HiddenField)item.FindControl("HiddenID");
                    long empid = Convert.ToInt32(lblempcode.Value);

                    var salary_define = (from ep in dx.tbl_employee_salary
                                         where ep.fk_employee_id==empid
                                         select ep).ToList();


                    rptr.DataSource = salary_define;
                    rptr.DataBind();
                }

               
                ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#custom-width-modal').modal('toggle');</script>");

            }

        }

        public void bind()
        {
            int year = int.Parse(ddlyear.SelectedItem.Text);
            int month = ddlmonth.SelectedIndex + 1;

            if (ddldept.SelectedItem.Text != "All")
            {
                var query = dx.tbl_employee_salary

                 .GroupBy(x => new { empid = x.fk_employee_id })
                 .Select(x => new
                 {
                     empid = x.Key.empid,
                     Amount = x.Sum(s => s.amount)

                 });





                long dept = long.Parse(ddldept.SelectedValue);
                var salary_result = from a in dx.tbl_salary
                                    where a.salary_year == ddlyear.SelectedItem.Text && a.salary_month == ddlmonth.SelectedItem.Text
                                    select a;


                var result = from emp in query

                             join
                     de in salary_result

                     on emp.empid equals de.fk_emp_id
                     into tempstorage
                             from dx in tempstorage.DefaultIfEmpty()


                             select new
                             {
                                 empid = (dx != null) ? emp.empid : 0,
                                 //empid= emp.empid,
                                 Amount = emp.Amount,
                                 id= dx.id,
                                 month = dx.salary_month,
                                 year = dx.salary_year

                             };
                var binds = from ep in result
                            join e in dx.tbl_Employe on ep.empid equals e.id
                            join d in dx.tbl_employee_conectivity on e.id equals d.employe_fk
                            where d.Dept_fk == dept
                            select new
                            {
                                EmployeeID = e.id,
                                EmployeeCode = e.EmployeeCode,
                                EmployeeName = e.FirstName + " " + e.LastName,
                                amount = ep.Amount,
                                id = ep.id


                            };
                


                var all = from ep in binds.AsEnumerable()
                          let absents = salary_class.get_absent_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                          let lates = salary_class.get_late_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                          let loans = salary_class.loan(ep.EmployeeID)
                          let total_decuction = loans + absents + lates
                          select new
                          {
                              EmployeeID = ep.EmployeeID,
                              EmployeeCode = ep.EmployeeCode,
                              EmployeeName = ep.EmployeeName,
                              salary = ep.amount,
                              absent = absents,
                              late = lates,
                              loan = loans,
                              total_deduction = loans + absents + lates,
                              net_pay = ep.amount - total_decuction,
                              id= ep.id



                          };


                //var salary = from eps in all
                //             join a in dx.tbl_salary on eps.EmployeeID equals a.fk_emp_id
                //             where a.fk_emp_id != eps.EmployeeID && a.salary_month!=ddlmonth.SelectedItem.Text && a.salary_year!=ddlyear.SelectedItem.Text
                //             select new
                //             {
                //                 EmployeeID = eps.EmployeeID,
                //                 EmployeeCode = eps.EmployeeCode,
                //                 EmployeeName = eps.EmployeeName,
                //                 salary = eps.salary,
                //                 absent = eps.absent,
                //                 late = eps.late,
                //                 loan = eps.loan,
                //                 total_deduction = eps.total_deduction,
                //                 net_pay = eps.net_pay




                //             };

                //                SELECT*
                //FROM tableA a
                //FULL OUTER JOIN tableB b
                //    ON a.column = a.column
                //WHERE a.column IS NULL OR b.column IS NULL




                if (binds != null)
                {
                    rptleavetype.DataSource = all.ToList();
                    rptleavetype.DataBind();
                    chklate.Checked = true;
                    chkabsent.Checked = true;
                    chkloan.Checked = true;
                    foreach (RepeaterItem item in rptleavetype.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox late = (CheckBox)item.FindControl("BtnLate");
                            CheckBox absent = (CheckBox)item.FindControl("BtnAbsent");
                            CheckBox loan = (CheckBox)item.FindControl("BtnLoan");
                            late.Checked = true;
                            loan.Checked = true;
                            absent.Checked = true;


                        }
                    }
                }
            }
            else
            {
                {





                    var query = dx.tbl_employee_salary

                       .GroupBy(x => new { empid = x.fk_employee_id })
                       .Select(x => new
                       {
                           empid = x.Key.empid,
                           Amount = x.Sum(s => s.amount)

                       });
                    //empid= emp.empid,
                    var salary_result = from a in dx.tbl_salary
                                        where a.salary_year == ddlyear.SelectedItem.Text && a.salary_month == ddlmonth.SelectedItem.Text
                                        select a;


                    var result = from emp in query

                                 join
                         de in salary_result

                         on emp.empid equals de.fk_emp_id
                         into tempstorage
                                 from dx in tempstorage.DefaultIfEmpty()


                                 select new
                                 {
                                     empid = (dx != null) ? emp.empid : 0,
                                     //empid= emp.empid,
                                     Amount = emp.Amount,
                                     month = dx.salary_month,
                                     year = dx.salary_year,
                                     id= dx.id

                                 };


                    var binds = from ep in result
                                join e in dx.tbl_Employe on ep.empid equals e.id

                                select new
                                {
                                    EmployeeID = e.id,
                                    EmployeeCode = e.EmployeeCode,
                                    EmployeeName = e.FirstName + " " + e.LastName,
                                    amount = ep.Amount,
                                    id=ep.id



                                };





                    var all = from ep in binds.AsEnumerable()
                              let absents = salary_class.get_absent_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                              let lates = salary_class.get_late_deduction(ep.EmployeeID, year, month, Convert.ToInt32(ep.amount))
                              let loans = salary_class.loan(ep.EmployeeID)
                              let total_decuction = loans + absents + lates
                              select new
                              {
                                  EmployeeID = ep.EmployeeID,
                                  EmployeeCode = ep.EmployeeCode,
                                  EmployeeName = ep.EmployeeName,
                                  salary = ep.amount,
                                  absent = absents,
                                  late = lates,
                                  loan = loans,
                                  total_deduction = loans + absents + lates,
                                  net_pay = ep.amount - total_decuction,
                                  id= ep.id




                              };












                    if (binds != null)
                    {
                        rptleavetype.DataSource = all.ToList();
                        rptleavetype.DataBind();
                        chklate.Checked = true;
                        chkabsent.Checked = true;
                        chkloan.Checked = true;
                        foreach (RepeaterItem item in rptleavetype.Items)
                        {
                            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                            {
                                CheckBox late = (CheckBox)item.FindControl("BtnLate");
                                CheckBox absent = (CheckBox)item.FindControl("BtnAbsent");
                                CheckBox loan = (CheckBox)item.FindControl("BtnLoan");
                                late.Checked = true;
                                loan.Checked = true;
                                absent.Checked = true;


                            }
                        }
                    }
                }

            }
        }
        

        public void updateleave(DateTime set)
        {
            long empid = long.Parse(ddldept.SelectedValue);
            var chk = (from a in dx.tbl_employeeleave where a.fk_empid == empid && a.Date == set && a.status == true select a).FirstOrDefault();
            if (chk != null)
            {
                //int empid = int.Parse(ddldept.SelectedValue);
                //int leavid = int.Parse(ddlleave.SelectedValue);
                chk.fk_empid = empid;
               // chk.fk_leavetypeid = leavid;
                chk.Date = set;
                chk.status = true;

                dx.SaveChanges();

            }
            else
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Not exist', 'error');", true);
        }

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnsave.Visible = true;
           // btnUpdate.Visible = false;
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
                    string meassage = custome_class.deletesalaryrecord(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Salary Record Deleted', 'success');", true);
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
                    
                    //leavetype = id;

                    //==== Call delete method and pass id as argument.
                    //bindEmployeeDetailToEdit(id);

                    break;

            }
        }

        protected void chklate_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptleavetype.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox late = (CheckBox)item.FindControl("BtnLate");
                    
                    if (chklate.Checked == true)
                    {
                        late.Checked = true;
                      

                    }
                    else {
                        late.Checked = false;
                      
                    }


                }
            }
        }
                protected void chkabsent_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptleavetype.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    
                    CheckBox absent = (CheckBox)item.FindControl("BtnAbsent");
                    if (chkabsent.Checked == true)
                    {
                       
                        absent.Checked = true;
                     

                    }
                    else
                    {
                        
                        absent.Checked = false;
                       
                    }


                }
            }

        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();

        }

        protected void chkloan_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptleavetype.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                     CheckBox loan = (CheckBox)item.FindControl("BtnLoan");
                    if (chkloan.Checked == true)
                    {
                        
                        loan.Checked = true;

                    }
                    else
                    {
                        
                        loan.Checked = false;
                    }


                }
            }
        }



    }
}