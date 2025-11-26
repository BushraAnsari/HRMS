using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRMS
{
    public partial class addemployee : System.Web.UI.Page
    {
        string password;
        string username;
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
            var showPiece = dx.tbl_Employe
                        .OrderByDescending(p => p.id)
                        .FirstOrDefault();
            int userid = int.Parse(showPiece.id.ToString());
            userid++;
            lblempcodeauto.Text = "EP-0000" + userid;
            var bind = (from a in dx.tbl_Employe where a.status == true select new {
                id=a.id,
                name = a.FirstName + " " + a.MiddleName + " " + a.LastName,
                empcode = a.EmployeeCode,
                cnic = a.CNIC,
                fathername = a.FatherFullName,
                nationality = a.Nationality,
                dob = a.Dateofbirth,
                gender = a.Gender,
                m_status = a.MaritalStatus,
                address = a.ResidenceAddress,
                p_phone=a.MobilePhone,
                w_phone=a.WorkPhone,
                p_email=a.PersonalEmail,
                w_email=a.WorkEmail,
                emergency_details = "Relation:"+a.EmergencyRelation + "\n Name:"+ a.EmergencyContactName+"\n Phone#:"+ a.EmergencyWorkPhone + "\n"



            }).ToList();
            rptdept.DataSource = bind;
            rptdept.DataBind();

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var chk = (from a in dx.tbl_Employe where a.CNIC == txtcnic.Text && a.status == true select new { a.EmployeeCode }).FirstOrDefault();
                if (chk == null)
                {
                    tbl_Employe emp = new tbl_Employe();
                    emp.EmployeeCode = lblempcodeauto.Text;
                    emp.FirstName = txtfirstname.Text;
                    emp.MiddleName = txtmiddlename.Text;
                    emp.LastName = txtlastname.Text;
                    emp.CNIC = txtcnic.Text;
                    emp.FatherFullName = txtfaterfullname.Text;
                    emp.Nationality = ddlnationlaltit.SelectedItem.Text;
                    emp.Dateofbirth = Convert.ToDateTime(txtdateofbirth.Text);
                    emp.Gender = ddlgender.SelectedItem.Text;
                    emp.MaritalStatus = ddlMaritalStatus.SelectedItem.Text;
                    //emp.Accomodation = ddlAccomodation.SelectedItem.Text;
                    emp.ResidenceAddress = txtResidenceAddress.Text;
                    emp.Country = ddlcountry.SelectedItem.Text;
                    emp.City = ddlcity.SelectedItem.Text;
                    emp.MobilePhone = txtmobilePhone.Text;
                    emp.WorkPhone = txtWorkPhone.Text;
                    emp.WorkEmail = txtWorkEmail.Text;
                    emp.PersonalEmail = txtPersonalEmail.Text;
                    //emp.HomeAddress1 = txtHomeAddress1.Text;
                    //emp.HomeAddress2 = txtHomeAddress2.Text;
                    emp.EmergencyContactName = txtEmergencyContactName.Text;
                    emp.EmergencyRelation = txtEmergencyRelation.Text;
                    //emp.EmergencyHomePhone = txtEmergencyHomePhone.Text;
                    emp.EmergencyWorkPhone = txtEmergencyWorkPhone.Text;
                    //emp.EmergencyMobile = txtEmergencyMobile.Text;
                    emp.inserteddatetime = DateTime.Now;
                    emp.status = true;
                    dx.tbl_Employe.Add(emp);
                    
                   
                        var chks = (from a in dx.tbl_login where a.Email == txtWorkEmail.Text && a.Active_status == true select a).FirstOrDefault();
                        if (chks == null)
                        {

                            tbl_login conn = new tbl_login();
                            var generator = new PasswordGenerator();
                            password = generator.Generate();
                            username = txtWorkEmail.Text;
                            conn.Email = txtWorkEmail.Text;
                            conn.username = txtWorkEmail.Text; ;
                            conn.password = password;
                            conn.Active_status = true;
                        conn.User_type = 2;
                            dx.tbl_login.Add(conn);
                        var email = (from a in dx.tbl_email_server where a.status == true select a).FirstOrDefault();
                        if (email != null) {

                            string message = custome_class.sendEmail(email.smtp_server,
                                                                    email.email_id, email.password,
                                                                    txtWorkEmail.Text, txtfirstname.Text + " " + txtmiddlename.Text + " " + txtlastname.Text,
                                                                    email.email_id, email.user_name, email.email_id, "Hello "+ txtfirstname.Text + " " + txtmiddlename.Text + " " + txtlastname.Text + " Welcome to Company" , "<b>Empoyee Code:</b>  "+lblempcodeauto.Text+"<br/>Details for login employee portal<br/> <b> ID:</b>"+txtWorkEmail.Text+"<br/><b>Password:</b>"+password);
                            
                        }
                        }
                    dx.SaveChanges();
                    string code = lblempcodeauto.Text;
                    bind();


                    
                    this.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/addempconnectivity.aspx?code="+code+"');", true);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'This Employee record already exists Employee Code is " + chk.EmployeeCode+ "', 'warning');", true);
                }
            }
            catch(Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong "+ex.Message+"', 'error');", true);
            }

        }
        protected void rptdept_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    string meassage = custome_class.deleteemprecord(id);
                    if (meassage == "success")
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Deleted', 'success');", true);
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
        public void bindupdate(int id)
        {
            var bind = (from ep in dx.tbl_Employe
                        where ep.id == id
                        select ep).FirstOrDefault();
            if (bind != null)
            {
                btnUpdate.Visible = true;
                btnsave.Visible = false;
                lblempcodeauto.Text = bind.EmployeeCode.ToString();
                txtfirstname.Text = bind.FirstName.ToString();
                txtmiddlename.Text = bind.MiddleName.ToString();
                txtlastname.Text = bind.LastName.ToString();
                txtcnic.Text = bind.CNIC.ToString();
                txtfaterfullname.Text = bind.FatherFullName.ToString();
                ddlnationlaltit.SelectedItem.Text = bind.Nationality.ToString();
                txtdateofbirth.Text =DateTime.Parse(bind.Dateofbirth.ToString()).ToString("yyyy-MM-dd");
                ddlgender.SelectedItem.Text = bind.Gender.ToString();
                ddlMaritalStatus.SelectedItem.Text = bind.MaritalStatus.ToString();
                txtResidenceAddress.Text = bind.ResidenceAddress.ToString();
                ddlcountry.SelectedItem.Text = bind.Country.ToString();
                ddlcity.SelectedItem.Text = bind.City.ToString();
                txtmobilePhone.Text = bind.MobilePhone.ToString();
                txtWorkPhone.Text=bind.WorkPhone.ToString();
                txtWorkEmail.Text=bind.WorkEmail.ToString();
                txtPersonalEmail.Text=bind.PersonalEmail.ToString();
                txtEmergencyContactName.Text=bind.EmergencyContactName.ToString();
                txtEmergencyRelation.Text=bind.EmergencyRelation==null?"": bind.EmergencyRelation.ToString();
                txtEmergencyWorkPhone.Text = bind.EmergencyWorkPhone.ToString();

                d_id.Value = id.ToString();
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                updateemployee();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Updated', 'Succesfully', 'success');", true);

                // txtpermonthamount.Visible = true;
                btnUpdate.Visible = false;
                btnsave.Visible = true;
                var showPiece = dx.tbl_Employe
                        .OrderByDescending(p => p.id)
                        .FirstOrDefault();
                int userid = int.Parse(showPiece.id.ToString());
                userid++;
                lblempcodeauto.Text = "EP-0000" + userid;
                txtfirstname.Text = null;
                txtmiddlename.Text = null;
                txtlastname.Text = null;
                txtcnic.Text = null;
                txtfaterfullname.Text = null;
                txtdateofbirth.Text = null;
                txtResidenceAddress.Text = null;
                txtmobilePhone.Text = null;
                txtWorkPhone.Text = null;
                txtWorkEmail.Text = null;
                txtPersonalEmail.Text = null;
                txtEmergencyContactName.Text = null;
                txtEmergencyRelation.Text = null;
                txtEmergencyWorkPhone.Text = null;

                d_id.Value = null;


                bind();


            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('ERROR!', 'Something went wrong " + ex.Message + "', 'error');", true);
            }
        }

        private void updateemployee()
        {
            int emp_id = int.Parse(d_id.Value.ToString());

            var chk = (from a in dx.tbl_Employe where a.id == emp_id select a).FirstOrDefault();


            if (chk != null)
            {
                chk.FirstName = txtfirstname.Text;
                chk.MiddleName = txtmiddlename.Text;
                chk.LastName = txtlastname.Text;
                chk.CNIC = txtcnic.Text;
                chk.FatherFullName = txtfaterfullname.Text;
                chk.Nationality = ddlnationlaltit.SelectedItem.Text;
                chk.Dateofbirth = Convert.ToDateTime(txtdateofbirth.Text);
                chk.Gender = ddlgender.SelectedItem.Text;
                chk.MaritalStatus = ddlMaritalStatus.SelectedItem.Text;
                //chk.Accomodation = ddlAccomodation.SelectedItem.Text;
                chk.ResidenceAddress = txtResidenceAddress.Text;
                chk.Country = ddlcountry.SelectedItem.Text;
                chk.City = ddlcity.SelectedItem.Text;
                chk.MobilePhone = txtmobilePhone.Text;
                chk.WorkPhone = txtWorkPhone.Text;
                chk.WorkEmail = txtWorkEmail.Text;
                chk.PersonalEmail = txtPersonalEmail.Text;
                //chk.HomeAddress1 = txtHomeAddress1.Text;
                //chk.HomeAddress2 = txtHomeAddress2.Text;
                chk.EmergencyContactName = txtEmergencyContactName.Text;
                chk.EmergencyRelation = txtEmergencyRelation.Text;
                //chk.EmergencyHomePhone = txtEmergencyHomePhone.Text;
                chk.EmergencyWorkPhone = txtEmergencyWorkPhone.Text;
                //chk.EmergencyMobile = txtEmergencyMobile.Text;
                chk.inserteddatetime = DateTime.Now;
                chk.status = true;

                dx.SaveChanges();
                bind();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Me', 'Updated', 'success');", true);

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Alert!', 'Not Exist', 'warning');", true);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnsave.Visible = true;
            btnUpdate.Visible = false;
            var showPiece = dx.tbl_Employe
                         .OrderByDescending(p => p.id)
                         .FirstOrDefault();
            int userid = int.Parse(showPiece.id.ToString());
            userid++;
            lblempcodeauto.Text = "EP-0000" + userid;
            txtfirstname.Text = null;
            txtmiddlename.Text = null;
            txtlastname.Text = null;
            txtcnic.Text = null;
            txtfaterfullname.Text = null;
            txtdateofbirth.Text = null;
            txtResidenceAddress.Text = null;
            txtmobilePhone.Text = null;
            txtWorkPhone.Text = null;
            txtWorkEmail.Text = null;
            txtPersonalEmail.Text = null;
            txtEmergencyContactName.Text = null;
            txtEmergencyRelation.Text = null;
            txtEmergencyWorkPhone.Text = null;

            d_id.Value = null;


        }
    }
}