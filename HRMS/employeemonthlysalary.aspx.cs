using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class employeemonthlysalary : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!Page.IsPostBack)
            {
                custome_class.bindmonth(ddlmonth);
                custome_class.bindyear(ddlyear);
                custome_class.Bindemployeesal(ddlempcode,ddlyear.SelectedItem.Text,ddlmonth.SelectedItem.Text);
                divloan.Visible = false;

            }

        }
        protected void btnsave_Click(object sender, EventArgs e)

        {
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
            if (divloan.Visible == false)
            {
                spanloan.InnerText = "-";
            }
            else
            {
                spanloan.InnerText = txtloan.Text;
            }
            if (txtlate.Text == "0")
            {
                spanlate.InnerText = "-";
            }
            else
            {
                spanlate.InnerText = txtlate.Text;
            }
            if (txtbonuss.Text == "")
            {
                spanbonus.InnerText = "-";
            }
            else
            {
                spanbonus.InnerText = txtbonuss.Text;
            }
            if (txtabsent.Text == "")
            {
                spanabsent.InnerText = "-";
            }
            else
            {
                spanabsent.InnerText = txtabsent.Text;
            }




            spanuserid.InnerText = user.user_name;
            spandept.InnerText = list.dept_name;
            spanempname.InnerText = list.emp_name;
            spandes.InnerText = list.designation;
            spanmonth.InnerText = ddlmonth.Text + "," + ddlyear.Text;
            spansumearn.InnerText = txtsum.Text;
            spandetsum.InnerText = txtdetsum.Text;
            spannetsum.InnerText = txtnetsum.Text;
            spanabsentcount.InnerText = p_absent_days.InnerText;
            spanlatecount.InnerText = p_late.InnerText;
            spanleavecount.InnerText = p_leave_days.InnerText;
            spanempcode.InnerText = ddlempcode.SelectedItem.Text;
            spaninwords.InnerText = custome_class.NumberToWords(int.Parse(txtnetsum.Text));


            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#custom-width-modal').modal('toggle');</script>");



        }

        protected void btnsavess_Click(object sender, EventArgs e)
        {
            try
            {

                long epid = long.Parse(ddlempcode.SelectedValue);
                long userid = long.Parse(Session["userid"].ToString());
                string year = ddlyear.SelectedItem.Text;
                string month = ddlmonth.SelectedItem.Text;
                var chk = (from a in dx.tbl_salary where a.fk_emp_id == epid && a.salary_year == year && a.salary_month == month select a).FirstOrDefault();
                if (chk == null)
                {
                    tbl_salary connec = new tbl_salary();
                    connec.fk_emp_id = epid;
                    connec.gross_deduction_amount = int.Parse(txtdetsum.Text);
                    connec.gross_earning_amount = int.Parse(txtsum.Text);

                    if (txtbonuss.Text != "") connec.stat_bonus = int.Parse(txtbonuss.Text);
                    connec.net_pay = int.Parse(txtnetsum.Text);
                    connec.inserted_by = userid;
                    connec.salary_month = month;
                    connec.salary_year = year;


                    if (divloan.Visible != false)
                    {
                        epid = long.Parse(ddlempcode.SelectedValue);
                        int loanamount = int.Parse(txtloan.Text);
                        var tbl = new tbl_loanpaidemp();
                        var loan = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status == "Active" select a).FirstOrDefault();
                        int totalloanamount = int.Parse(loan.remaining_loan_amount.ToString());
                        loan.remaining_loan_amount = totalloanamount - loanamount;
                        loan.remaining_month_payable = loan.remaining_month_payable - 1;
                        if (loan.payable_amount_per_month >= loan.remaining_loan_amount)
                        {
                            loan.Status = "Expired";
                            loan.remaining_month_payable = 0;
                        }
                        dx.SaveChanges();





                    }
                    dx.tbl_salary.Add(connec);
                    dx.SaveChanges();
                    int empid = int.Parse(ddlempcode.SelectedValue);
                    string fl = custome_class.Encrypt(ddlempcode.SelectedItem.Text +
                        ddlmonth.SelectedItem.Text + ddlyear.SelectedItem.Text, "");

                    string filename = fl + ".pdf";
                    salary_class.print_salary(divsalaryslips,  filename);
                    var slip = (from a in dx.tbl_salary
                                where a.fk_emp_id == empid &&
       a.salary_month == ddlmonth.SelectedItem.Text &&
       a.salary_year == ddlyear.SelectedItem.Text
                                select a).FirstOrDefault();
                    slip.slip_url = "PDF/"+filename;
                    dx.SaveChanges();
                    ClientScript.RegisterStartupScript(GetType(), "Hide", "<script> $('#custom-width-modal').modal('hide');</script>");
                    var uids = (from a in dx.tbl_employee_conectivity where epid == a.employe_fk select a).FirstOrDefault();
                    string content = "Your salary has been Genrated for Month <b>" + month + "</b><a href='/empsalaryslip.aspx'>Tab to view</a>";
                    custome_class.generate_noti(Convert.ToInt32(uids.userid_fk), content);


                    //                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Employee Salary Generated', 'success');", true);

                }
                else
                {
                   // ExportToImage();
                    //string filename =custome_class.Encrypt(ddlempcode.SelectedItem.Text + 
                    //    ddlmonth.SelectedItem.Text + ddlyear.SelectedItem.Text + ".pdf", "&*");

                    //salary_class.print_salary_slip(divsalaryslips, filename);
                   
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Employee Salary already exists for this month', 'warning');", true);

                }
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);

            }

        }

        private void ExportToImage()
        {
            string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64);
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "attachment; filename=HTML.png");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            MemoryStream storeStream = new MemoryStream();
            MemoryStream ms = new MemoryStream(bytes);
            //write to file  
            FileStream file = new FileStream(Server.MapPath("~/Images/") + "HTML100.png", FileMode.Create,
            FileAccess.Write);
            ms.WriteTo(file);
            file.Close();
            ms.Close();
            Response.End();
        }

        protected void ddlempcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int epid = int.Parse(ddlempcode.SelectedValue);
                var list = (from a in dx.tbl_employee_salary where a.fk_employee_id == epid && a.status == true select a).ToList();
                var loan = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status == "Active" select a).FirstOrDefault();
                if (loan != null)
                {
                    txtloan.Text = loan.payable_amount_per_month.ToString();
                    if (loan.payable_amount_per_month > loan.remaining_loan_amount)
                    {
                        txtloan.Text = loan.remaining_loan_amount.ToString();
                    }

                    divloan.Visible = true;
                }
                else { divloan.Visible = false; }
                if (list != null)
                {
                    rptsalarycom.DataSource = list;
                    rptsalarycom.DataBind();
                    rptslip.DataSource = list;
                    rptslip.DataBind();
                    decimal amounts = 0;
                    //txtsum.Text = "";
                    foreach (RepeaterItem item in rptsalarycom.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            TextBox txtamount = (TextBox)item.FindControl("txtamount");
                            if (txtamount.Text != "")
                            {
                                amounts = amounts += decimal.Parse(txtamount.Text);
                            }
                            txtsum.Text = amounts.ToString();
                            txtnetsum.Text = amounts.ToString();
                            if (divloan.Visible == true)
                                txtnetsum.Text = (int.Parse(txtnetsum.Text) - int.Parse(txtloan.Text)).ToString();

                            if (txtnetsum.Text != "" && txtloan.Text != "")
                                txtnetsum.Text = (int.Parse(txtnetsum.Text) - int.Parse(txtloan.Text)).ToString();
                        }
                    }

                }
                else
                {
                    divsalary.Visible = false;
                    divattendance.Visible = false;
                    txtsum.Text = "0";

                }




                int year = int.Parse(ddlyear.SelectedItem.Text);
                int month = ddlmonth.SelectedIndex + 1;
                long total_salary = long.Parse(txtsum.Text);
                List<int> absent_details = salary_class.get_absent_days(epid, year, month);


                double absent = salary_class.get_absent_deduction(epid, year, month, total_salary);
                if (absent_details != null)
                {
                    divsalary.Visible = true;
                    divattendance.Visible = true;
                    p_work.InnerText = absent_details[0].ToString();
                    p_working_days.InnerText = absent_details[1].ToString();
                    p_leave_days.InnerText = absent_details[2].ToString();
                    p_absent_days.InnerText = absent_details[3].ToString();
                }
                double late_details = salary_class.get_late(epid, year, month);
                if (late_details != 0)
                {
                    p_late.InnerText = late_details.ToString();
                    divsalary.Visible = true;

                }


                double late = salary_class.get_late_deduction(epid, year, month, total_salary);
                double total_deduction;
                if (divloan.Visible != true)
                {
                    total_deduction = absent + late;
                }
                else
                {
                    total_deduction = absent + late + double.Parse(txtloan.Text);
                }
                txtdetsum.Text = total_deduction.ToString();
                txtlate.Text = late.ToString();
                txtabsent.Text = absent.ToString();

                txtnetsum.Text = (total_salary - total_deduction).ToString();



            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Something Went Wrong!', '" + ex.Message + ", 'error');", true);
            }


        }
        protected void txtbonusper_TextChanged(object sender, EventArgs e)
        {
            if (txtsum.Text != "")
            {
                float perc = float.Parse(txtbonusper.Text);
                float percent = 100;
                float amount = float.Parse(txtsum.Text);
                float deduct = float.Parse(txtdetsum.Text);
                float per_amount1 = perc / percent;
                float per_amount2 = per_amount1 * amount;
                float per_amount3 = amount + per_amount2;
                txtbonuss.Text = per_amount2.ToString();
                // txtsum.Text = per_amount3.ToString();
                txtnetsum.Text = (per_amount3 - deduct).ToString();
                txtnetsum.Text = (per_amount3 - deduct).ToString();

            }
        }
        protected void txtbonuss_TextChanged(object sender, EventArgs e)
        {
            if (txtsum.Text != "")
            {
                float perc = float.Parse(txtbonuss.Text);
                float percent = 100;
                float amount = float.Parse(txtsum.Text);
                float deduct = float.Parse(txtdetsum.Text);

                float per_amount1 = perc / amount;
                float per_amount2 = per_amount1 * percent;
                float per_amount3 = amount + float.Parse(txtbonuss.Text);
                //txtsum.Text = per_amount3.ToString();
                txtbonusper.Text = per_amount2.ToString();
                txtnetsum.Text = (per_amount3 - deduct).ToString();
            }
        }
        protected void txtloan_TextChanged(object sender, EventArgs e)
        {
            if (txtnetsum.Text != "" && txtloan.Text != "")
                txtnetsum.Text = (int.Parse(txtnetsum.Text) - int.Parse(txtloan.Text)).ToString();
        }







        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            custome_class.Bindemployeesal(ddlempcode, ddlyear.SelectedItem.Text, ddlmonth.SelectedItem.Text);

            if (ddlempcode.SelectedValue != "")
            {
                int epid = int.Parse(ddlempcode.SelectedValue);
                int year = int.Parse(ddlyear.SelectedItem.Text);
                int month = ddlmonth.SelectedIndex + 1;
                long total_salary = long.Parse(txtsum.Text);
                double absent;
                double late;
                if (salary_class.get_absent_deduction(epid, year, month, total_salary) != 0 || salary_class.get_late_deduction(epid, year, month, total_salary) != 0)
                {
                    List<int> absent_details = salary_class.get_absent_days(epid, year, month);
                    divattendance.Visible = true;
                    absent = salary_class.get_absent_deduction(epid, year, month, total_salary);
                    late = salary_class.get_late_deduction(epid, year, month, total_salary);

                    txtlate.Text = late.ToString();
                    txtabsent.Text = late.ToString();



                    double total_deduction;
                    if (divloan.Visible != true)
                    {
                        total_deduction = absent + late;
                    }
                    else
                    {
                        total_deduction = absent + late + double.Parse(txtloan.Text);
                    }
                    txtdetsum.Text = total_deduction.ToString();
                    txtlate.Text = late.ToString();
                    txtabsent.Text = absent.ToString();

                    txtnetsum.Text = (total_salary - total_deduction).ToString();
                }
            }
        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            custome_class.Bindemployeesal(ddlempcode, ddlyear.SelectedItem.Text, ddlmonth.SelectedItem.Text);

            if (ddlempcode.SelectedValue != "")
            {
                int epid = int.Parse(ddlempcode.SelectedValue);
                int year = int.Parse(ddlyear.SelectedItem.Text);
                int month = ddlmonth.SelectedIndex + 1;
                long total_salary = long.Parse(txtsum.Text);
                double absent;
                double late;
                if (salary_class.get_absent_deduction(epid, year, month, total_salary) != 0 || salary_class.get_late_deduction(epid, year, month, total_salary) != 0)
                {
                    List<int> absent_details = salary_class.get_absent_days(epid, year, month);
                    divattendance.Visible = true;
                    absent = salary_class.get_absent_deduction(epid, year, month, total_salary);
                    late = salary_class.get_late_deduction(epid, year, month, total_salary);

                    txtlate.Text = late.ToString();
                    txtabsent.Text = late.ToString();



                    double total_deduction;
                    if (divloan.Visible != true)
                    {
                        total_deduction = absent + late;
                    }
                    else
                    {
                        total_deduction = absent + late + double.Parse(txtloan.Text);
                    }
                    txtdetsum.Text = total_deduction.ToString();
                    txtlate.Text = late.ToString();
                    txtabsent.Text = absent.ToString();

                    txtnetsum.Text = (total_salary - total_deduction).ToString();
                }
            }
        }

        protected void btnsalarygrid_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/multiplesalary.aspx','_newtab');", true);

        }

    }



}