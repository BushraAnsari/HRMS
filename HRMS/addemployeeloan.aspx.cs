using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addemployeeloan : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //custome_class.BindDeprt(ddldept);
                custome_class.Bindemployee(ddlempid);
                //custome_class.Bindemployee(ddlsupervisor);
                //custome_class.bindtitle(ddljobtittle);
                //custome_class.Bindemployestatus(ddlempstatus);
                //custome_class.Bindgrade(ddlgrade);
                //custome_class.bindpolicy(ddlleavingpolicy);


            }
            bind();
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            long epid = long.Parse(ddlempid.SelectedValue);
            long loanamount = long.Parse(txtloanamount.Text);
            int payabletime = int.Parse(txtlpayabletime.Text);
            try
            {


                var pkTime = TimeZoneInfo.ConvertTime(DateTime.Now,
                                 TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time"));

                var chk = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status == "Active" select a).FirstOrDefault();


                if (chk == null)
                {
                    tbl_loanpaidemp connec = new tbl_loanpaidemp();

                    connec.emp_id = long.Parse(ddlempid.SelectedValue);
                    connec.loan_amount = loanamount;
                    connec.payabletime_in_month = payabletime;
                    connec.applied_from = pkTime.ToString();
                    connec.remaining_loan_amount = int.Parse(loanamount.ToString());
                    connec.Status = "Active";
                    connec.payable_amount_per_month = int.Parse(txtpermonthamount.Text);
                    connec.remaining_month_payable = payabletime;


                    dx.tbl_loanpaidemp.Add(connec);
                    dx.SaveChanges();
                    bind();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Employee Loan Added', 'success');", true);

                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Employee Loan already exists', 'warning');", true);

                }
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);

            }

        }

        protected void ddlempcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {

        }

        protected void txtloanamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long epid = long.Parse(ddlempid.SelectedValue);
                long loanamount = long.Parse(txtloanamount.Text);
                int payabletime = int.Parse(txtlpayabletime.Text);
                txtpermonthamount.Text = (loanamount / payabletime).ToString();
            }
            catch { }

        }

        protected void txtlpayabletime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long epid = long.Parse(ddlempid.SelectedValue);
                long loanamount = long.Parse(txtloanamount.Text);
                int payabletime = int.Parse(txtlpayabletime.Text);
                txtpermonthamount.Text = (loanamount / payabletime).ToString();
            }
            catch { }
        }
        public void bind()
        {
            var bind = (from ep in dx.tbl_loanpaidemp
                        join e in dx.tbl_Employe on ep.emp_id equals e.id
                        select new
                        {
                            ep.loan_id,
                            e.EmployeeCode,
                            e.FirstName,
                            e.LastName,
                            ep.loan_amount,
                            ep.remaining_loan_amount,
                            ep.payabletime_in_month,
                            ep.payable_amount_per_month,
                            ep.applied_from,
                            ep.Status
                        }).ToList();


            if (bind != null)
            {
                rptleavetype.DataSource = bind;
                rptleavetype.DataBind();
            }

        }
        public void bindupdate(int id)
        {
            var bind = (from ep in dx.tbl_loanpaidemp
                        where ep.loan_id == id
                        join e in dx.tbl_Employe on ep.emp_id equals e.id
                        select new
                        {
                                e.id,
                                 ep.loan_amount,
                                ep.payabletime_in_month,
                                ep.payable_amount_per_month,
                                ep.applied_from,
                                ep.Status })
                                .FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                btnsave.Visible = false;
                ddlempid.Enabled = false;
                ddlempid.CssClass = "form-control";
                //txtpermonthamount.Visible = false;
                ddlempid.SelectedValue = bind.id.ToString();
                txtloanamount.Text = bind.loan_amount.ToString();
                txtpermonthamount.Text = bind.payable_amount_per_month.ToString();
                txtlpayabletime.Text = bind.payabletime_in_month.ToString();
            }
           
            
        }

        public void updateloan()
        {

            long epid = long.Parse(ddlempid.SelectedValue);
            long loanamount = long.Parse(txtloanamount.Text);
            int payabletime = int.Parse(txtlpayabletime.Text);
            var tbl = new tbl_loanpaidemp();
            //var ctx = new
            var chk = (from a in dx.tbl_loanpaidemp where a.emp_id == epid && a.Status=="Active" select a).FirstOrDefault();



            if (chk != null)
            {

                if (chk.loan_amount < loanamount) {
                    long newamount = loanamount - chk.loan_amount;
                    int newremaing = int.Parse((chk.remaining_loan_amount + newamount).ToString());
                    chk.loan_amount = loanamount;
                    chk.remaining_loan_amount = newremaing;
                    

                    if (payabletime > chk.payabletime_in_month) {

                        int additional_month = int.Parse((payabletime - chk.payabletime_in_month).ToString());
                        int newremaingmonth = additional_month + chk.payabletime_in_month;
                        int newpayable = newremaing / newremaingmonth;

                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month = newpayable;

                    }
                    else if (payabletime < chk.payabletime_in_month)
                    {

                        int lesser_month = int.Parse((chk.payabletime_in_month- payabletime).ToString());
                        int newremaingmonth = chk.payabletime_in_month - lesser_month;
                        int newpayable = newremaing / newremaingmonth;

                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month = newpayable;


                    }
                    else if (payabletime == chk.payabletime_in_month)
                    {

                        int newpayable = newremaing / payabletime;

                        chk.payable_amount_per_month = newpayable;
                        
                    }


                }
                else if (chk.loan_amount > loanamount)
                {
                    long newamount = chk.loan_amount- loanamount;
                    int newremaing = int.Parse((chk.remaining_loan_amount - newamount).ToString());
                    chk.loan_amount = loanamount;
                    chk.remaining_loan_amount = newremaing;


                    if (payabletime > chk.payabletime_in_month)
                    {

                        int additional_month = int.Parse((payabletime - chk.payabletime_in_month).ToString());
                        int newremaingmonth = additional_month + chk.payabletime_in_month;
                        int newpayable = newremaing / newremaingmonth;


                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month = newpayable;

                    }
                    else if (payabletime < chk.payabletime_in_month)
                    {

                        int lesser_month = int.Parse((chk.payabletime_in_month - payabletime).ToString());
                        int newremaingmonth = chk.payabletime_in_month - lesser_month;
                        int newpayable = newremaing / newremaingmonth;

                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month =newpayable;


                    }
                    else if (payabletime == chk.payabletime_in_month)
                    {
                        int newpayable = newremaing / payabletime;

                        chk.payable_amount_per_month = newpayable;

                    }


                }
                else if (chk.loan_amount == loanamount)
                {
                    
                    int newremaing = int.Parse((chk.remaining_loan_amount).ToString());
                   


                    if (payabletime > chk.payabletime_in_month)
                    {

                        int additional_month = int.Parse((payabletime - chk.payabletime_in_month).ToString());
                        int newremaingmonth = additional_month + chk.payabletime_in_month;
                        int newpayable = newremaing / newremaingmonth;


                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month = newpayable;

                    }
                    else if (payabletime < chk.payabletime_in_month)
                    {

                        int lesser_month = int.Parse((chk.payabletime_in_month - payabletime).ToString());
                        int newremaingmonth = chk.payabletime_in_month - lesser_month;
                        int newpayable = newremaing / newremaingmonth;

                        chk.payabletime_in_month = payabletime;
                        chk.remaining_month_payable = newremaingmonth;
                        chk.payable_amount_per_month = newpayable;


                    }
                    else if (payabletime == chk.payabletime_in_month)
                    {

                        int newpayable = newremaing / payabletime;

                        chk.payable_amount_per_month = newpayable;

                    }


                }
                
                //dx.tbl_loanpaidemp.Add(chk);
                dx.SaveChanges();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Employee Loan Updated', 'success');", true);

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Employee Loan Expired', 'warning');", true);

            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)

        {
            try
           {


                updateloan();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);
                ddlempid.Enabled = true;
               // txtpermonthamount.Visible = true;
                btnUpdate.Visible = false;
                btnsave.Visible = true;

                txtloanamount.Text = "";
                txtlpayabletime.Text = "";
                txtpermonthamount.Text = "";
                ddlempid.SelectedValue = "";

                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnsave.Visible = true;
            txtloanamount.Text = "";
            txtlpayabletime.Text = "";
            txtpermonthamount.Text = "";
            ddlempid.SelectedValue = "";
            btnUpdate.Visible = false;
            ddlempid.Enabled=true;
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
                    string meassage = custome_class.deleteloanrecord(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Leave Request Deleted', 'success');", true);
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