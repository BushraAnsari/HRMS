using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addleaverequest : System.Web.UI.Page
    {
        HRMSEntities dx = new HRMSEntities();
        public string dats;
        public long empid;
        public long leavetype;
        public long leavetype_id;



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                custome_class.Bindemployee(ddlempcode);
                custome_class.bindleavetype(ddlleave);

                bind();
                //string code = ddlempcode.Text;

            }


            // divsequencedate.Visible = false;


        }
        public int count_leaves()
        {
            long leave = Convert.ToInt32(ddlleave.SelectedValue);
            int count = 0;
            var leave_qry_employee = (from a in dx.tbl_employeeleave where a.fk_empid == empid && a.fk_leavetypeid == leave && a.status == true select a).ToList();
            for (int i = 0; i < leave_qry_employee.Count; i++)
            {

                DateTime settimes = DateTime.Parse(leave_qry_employee[i].Date.ToString());
                DateTime today = DateTime.Now;
                if (settimes.Year == today.Year)
                {
                    count++;
                }

            }
            return count;
        }
            protected void btnDelete_Click(object sender, EventArgs e)
        {

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
                    string meassage = custome_class.deleteleaverecord(id);
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
                //case ("Edit"):

                //    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                //    id = Convert.ToInt32(e.CommandArgument);
                //    bindupdate(id);
                //    //leavetype = id;

                //    //==== Call delete method and pass id as argument.
                //    //bindEmployeeDetailToEdit(id);

                //    break;

            }
        }

        public void bind()
        {
            var bind = (from ep in dx.tbl_employeeleave
                        join e in dx.tbl_Employe on ep.fk_empid equals e.id
                        join es in dx.tbl_leave_type on ep.fk_leavetypeid equals es.id
                        select new
                        {
                            ep.id,
                            e.EmployeeCode,
                            e.FirstName,
                            e.LastName,
                            es.leave_type_name,
                            ep.Date,
                            ep.status
                        }).ToList();


            if (bind != null)
            {
                rptleavetype.DataSource = bind;
                rptleavetype.DataBind();
            }

        }
        //public int bindupdate(int id)
        //{
        //    var bind = (from ep in dx.tbl_employeeleave where ep.id == id
        //                join e in dx.tbl_Employe on ep.fk_empid equals e.id
        //                join es in dx.tbl_leave_type on ep.fk_leavetypeid equals es.id
        //                select new
        //                {
        //                    empid = e.id,
        //                    leaveid = es.id,
        //                    dateleave = ep.Date,
        //                }).FirstOrDefault();


        //    if (bind != null)
        //    {
        //        divdate.Visible = true;
        //        divsequencedate.Visible = false;
        //        btndate.Visible = false;
        //        btnUpdate.Visible = true;


        //        DateTime dt = DateTime.Parse(bind.dateleave.ToString());
        //        DateTime settime = DateTime.Parse(dt.ToString("dd/MM/yyyy"));

        //        //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Leave Request Added', 'success');", true);
        //        txtdate.Text = settime.ToString();




        //        ddlempcode.SelectedValue = bind.empid.ToString();
        //        ddlleave.SelectedValue = bind.leaveid.ToString();
        //        //txtdate.Text = bind.dateleave.ToString();
        //        // leavetype_id = id;









        //    }
        //    return id;
        //}
        
        protected void Save_Click(object sender, EventArgs e)
        {
            
                if (divdate.Visible == true && divsequencedate.Visible == false)
                {

                    long leave = Convert.ToInt32(ddlleave.SelectedValue);
                    var leave_qry = (from a in dx.tbl_leave_type where a.id == leave && a.status == true select a).FirstOrDefault();
                    int allowed_yearly = Convert.ToInt32(leave_qry.total_in_year);
                int count = count_leaves();
                    if (count < allowed_yearly)
                    {
                        DateTime dt = DateTime.Parse(txtdate.Text);
                        DateTime settime = DateTime.Parse(dt.ToString("yyyy-MM-dd"));

                        addleave(settime);
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Leave Request Added', 'success');", true);
                    }
                    else {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exceed limit', 'success');", true);
                    }
                    bind();
                }
                else if (divsequencedate.Visible == true && divdate.Visible == false)
                {

                    long leave = Convert.ToInt32(ddlleave.SelectedValue);
                    


                        var leave_qry = (from a in dx.tbl_leave_type where a.id == leave && a.status == true select a).FirstOrDefault();
                        int allowed_yearly = Convert.ToInt32(leave_qry.total_in_year);


                        
                    

                        DateTime d1 = DateTime.Parse(txtfrom.Text);
                    DateTime d2 = DateTime.Parse(txtto.Text);
                    if (d2 > d1)
                    {

                        TimeSpan days = d2 - d1;
                        int days2 = int.Parse(days.TotalDays.ToString());

                        for (int i = 0; i <= days2; i++)
                        {

                            if (i == 0) {
                                if (count_leaves() < allowed_yearly)
                                {
                                    DateTime dt = DateTime.Parse(txtfrom.Text);
                                    DateTime settime = DateTime.Parse(dt.ToString("yyyy-MM-dd"));

                                    dats = settime + "\n";
                                    addleave(settime);
                                }

                            }
                            else
                            {
                                if (count_leaves() < allowed_yearly)
                                {
                                    DateTime dt = DateTime.Parse(txtfrom.Text);
                                    DateTime daysse = dt.AddDays(i);

                                    DateTime settime = DateTime.Parse(daysse.ToString("yyyy-MM-dd"));
                                    dats = dats + settime + "\n ";
                                    addleave(settime);
                                }

                            }
                            

                        }

                        bind();



                    }
                    else
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Please Choose a valid range!', 'error');", true);


                }

            
        }
        public void addleave(DateTime set)
        {
            var chk2= (from a in dx.tbl_emp_attendance where a.fk_emp == empid && a.date == set && a.leave==true select a).FirstOrDefault();

            var chk = (from a in dx.tbl_employeeleave where a.fk_empid == empid && a.Date == set && a.status == true select a).FirstOrDefault();
            if (chk == null && chk2 == null)
            {
                tbl_employeeleave dep = new tbl_employeeleave();
                int empid = int.Parse(ddlempcode.SelectedValue);
                dep.fk_empid = int.Parse(ddlempcode.SelectedValue);
                dep.fk_leavetypeid = int.Parse(ddlleave.SelectedValue);
                dep.Date = set;
                dep.status = true;

                tbl_emp_attendance empa = new tbl_emp_attendance();
                empa.fk_emp = int.Parse(ddlempcode.SelectedValue);
                empa.month = set.Month;
                empa.year = set.Year;
                empa.leave = true;
                empa.date = set;
                



                dx.tbl_emp_attendance.Add(empa);
                dx.tbl_employeeleave.Add(dep);
                dx.SaveChanges();
                

            }
            else
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Already exist', 'error');", true);



        }
        //public void updateleave(DateTime set)
        //{

        //    var chk = (from a in dx.tbl_employeeleave where a.fk_empid == empid && a.Date == set && a.status == true select a).FirstOrDefault();
        //    var chk2 = (from a in dx.tbl_emp_attendance where a.fk_emp == empid && a.date == set && a.status == true select a).FirstOrDefault();
        //    if (chk!=null && chk2!=null)
        //    {
        //        int empid = int.Parse(ddlempcode.SelectedValue);
        //        int leavid = int.Parse(ddlleave.SelectedValue);
        //        chk2.fk_emp = empid;
        //        chk.fk_empid = empid;
        //        chk2.leave = true;
        //        chk.fk_leavetypeid = leavid;
        //        chk2.date = set;
        //        chk.Date = set;
        //        chk.status = true;

        //        dx.SaveChanges();

        //    }
        //    else
        //        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Not exist', 'error');", true);
        //}
    
            protected void adddate_Click(object sender, EventArgs e)
        {
            if (divsequencedate.Visible == false && divdate.Visible==true) {
                divdate.Visible = false;
                divsequencedate.Visible = true;
                btndate.Text = "Want to choose only one Date";


                

            }
            else if (divsequencedate.Visible == true && divdate.Visible==false) { 
                divsequencedate.Visible = false;
                divdate.Visible = true;
                btndate.Text = "Want to choose date in sequence 'TO' 'FROM'";


            }

        }

        protected void ddlempcode_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        protected void ddlleave_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void btnUpdate_Click(object sender, EventArgs e)

        {
            ////try
            ////{


            //    DateTime dt = DateTime.Parse(txtdate.Text);
            //    DateTime settime = DateTime.Parse(dt.ToString("yyyy-MM-dd"));

            //    //dats = settime + "\n";
            //    updateleave(settime);
            //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);
            //    divdate.Visible = true;
            //    divsequencedate.Visible = false;
            //    btndate.Text = "Want to choose date in sequence 'TO' 'FROM'";


            //    btndate.Visible = true;
            //    btnUpdate.Visible = false;
                
            //    bind();


            ////}
            ////catch (Exception ex)
            ////{
            ////    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            ////}

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
    }
}