<%@ Page Title="ERP HR & ACCOUNTS SYSTEM" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addemployee.aspx.cs" Inherits="HRMS.addemployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc." />
        <meta name="author" content="Coderthemes" />

        <link rel="shortcut icon" href="assets/images/favicon_1.ico" />

        <title>ERP HR & ACCOUNTS SYSTEM</title>

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

     

        <script src="assets/js/modernizr.min.js"></script>


    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- jQuery  -->
     <script>var resizefunc = [];</script>
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.slimscroll.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>


        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>
    <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>

<script src="assets/plugins/datatables/dataTables.buttons.min.js"></script>
<script src="assets/plugins/datatables/buttons.bootstrap.min.js"></script>
<script src="assets/plugins/datatables/jszip.min.js"></script>
<script src="assets/plugins/datatables/pdfmake.min.js"></script>
<script src="assets/plugins/datatables/vfs_fonts.js"></script>
<script src="assets/plugins/datatables/buttons.html5.min.js"></script>
<script src="assets/plugins/datatables/buttons.print.min.js"></script>
<script src="assets/plugins/datatables/dataTables.fixedHeader.min.js"></script>
<script src="assets/plugins/datatables/dataTables.keyTable.min.js"></script>
<script src="assets/plugins/datatables/dataTables.responsive.min.js"></script>
<script src="assets/plugins/datatables/responsive.bootstrap.min.js"></script>
<script src="assets/plugins/datatables/dataTables.scroller.min.js"></script>
<script src="assets/plugins/datatables/dataTables.colVis.js"></script>
<script src="assets/plugins/datatables/dataTables.fixedColumns.min.js"></script>

<script src="assets/pages/datatables.init.js"></script>


<script src="assets/js/jquery.core.js"></script>
<script src="assets/js/jquery.app.js"></script>


        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>

     <div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<h4 class="m-t-0 header-title"><b>New Employee Add</b></h4>
									<br />
									<div class="row">
                                           
                                        <fieldset>
                                            <legend>
                                                Employee Code: <asp:Label ID="lblempcodeauto" runat="server" Text="EP-00001" ForeColor="Green" ></asp:Label>
                                            </legend>
                                        </fieldset>
                                     
                          <div class="col-lg-3">
                        <div class="form-group">
                            <label>First Name</label>
                            
                          <asp:TextBox ID="txtfirstname" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                                     </div>
                                                <div class="col-lg-3">
                        <div class="form-group">
                            <label>Middle Name</label>
                            
                          <asp:TextBox ID="txtmiddlename" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                                     </div>
                                                       <div class="col-lg-3">
                        <div class="form-group">
                            <label>Last Name</label>
                            
                          <asp:TextBox ID="txtlastname" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                                     </div>
                                                                             <div class="col-lg-3">
                        <div class="form-group">
                            <label>Employe CNIC</label>
                             <asp:TextBox ID="txtcnic" class="form-control" runat="server" ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                           <div class="col-lg-3">
                        <div class="form-group">
                            <label>Father Full Name</label>
                             <asp:TextBox ID="txtfaterfullname" class="form-control" runat="server" ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                           
                                                          <div class="col-lg-3">
                        <div class="form-group">
                            <label>Nationality</label>
                            
                          <asp:DropDownList ID="ddlnationlaltit"  class="form-control" runat="server">
                                
                              <asp:ListItem Value="1">Pakistani</asp:ListItem>
                              
                          </asp:DropDownList>
                              </div>
                                     </div>
                                                        <div class="col-lg-3">
                        <div class="form-group">
                            <label>Date of Birth</label>
                            
                          <asp:TextBox ID="txtdateofbirth" class="form-control" TextMode="Date" runat="server"  ></asp:TextBox>
                              </div>

                                        </div>
                                                      <div class="col-lg-3">
                        <div class="form-group">
                            <label>Gender</label>
                            
                          <asp:DropDownList ID="ddlgender"  class="form-control" runat="server">
                              <asp:ListItem Value="0">Select</asp:ListItem>
                              <asp:ListItem Value="1">Male</asp:ListItem>
                              <asp:ListItem Value="2">Female</asp:ListItem>
                          </asp:DropDownList>
                          
                              </div>
                                     </div>
                                                  <div class="col-lg-3">
                        <div class="form-group">
                            <label>Marital Status</label>
                            
                          <asp:DropDownList ID="ddlMaritalStatus"  class="form-control" runat="server">
                              <asp:ListItem Value="0">Select</asp:ListItem>
                              <asp:ListItem Value="1">Un-Married</asp:ListItem>
                              <asp:ListItem Value="2">Married</asp:ListItem>
                          </asp:DropDownList>
                          
                              </div>
                                     </div>
                                               
                                                               <div class="col-lg-3">
                        <div class="form-group">
                            <label>Residence Address</label>
                            
                          <asp:TextBox ID="txtResidenceAddress" class="form-control"  runat="server"  ></asp:TextBox>
                              </div>
                                        </div>
                                                                         <div class="col-lg-3">
                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList ID="ddlcountry"  class="form-control" runat="server">
                          <asp:ListItem Value="1">Pakistan</asp:ListItem>
                                </asp:DropDownList>

                              </div>
                                        </div>
                                                         <div class="col-lg-3">
                        <div class="form-group">
                            <label>City</label>
                            
                            <asp:DropDownList ID="ddlcity"  class="form-control" runat="server">
                                <asp:ListItem Value="1">Karachi</asp:ListItem>
                            </asp:DropDownList>
                                    </div>
                                </div>
                                                                   <div class="col-lg-3">
                        <div class="form-group">
                            <label>Mobile Phone</label>
                             <asp:TextBox ID="txtmobilePhone" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Work Phone</label>
                             <asp:TextBox ID="txtWorkPhone" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Work Email</label>
                             <asp:TextBox ID="txtWorkEmail" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Personal Email</label>
                             <asp:TextBox ID="txtPersonalEmail" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                   
                                                                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Emergency Contact Name</label>
                             <asp:TextBox ID="txtEmergencyContactName" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Emergency Relation</label>
                             <asp:TextBox ID="txtEmergencyRelation" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                   
                                                                     <div class="col-lg-3">
                        <div class="form-group">
                            <label>Emergency Contact</label>
                             <asp:TextBox ID="txtEmergencyWorkPhone" class="form-control" runat="server"  ></asp:TextBox>
                           
                                    </div>
                                </div>  
                                                                     
                                              <div class="col-lg-3">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-warning" OnClick="btnsave_Click" Text="Next" />
                           <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                            <asp:HiddenField ID="d_id" runat="server" />
                            
                            </div>
                                                                         </div>
                                        </div>
                                    </div>
                                </div>
         </div>
    <div class="row">
							<div class="col-sm-12">
        
    <div class="card-box" id="databox">
              <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>ID#</th>
                                    <th>Name</th>
                                    <th>CNIC</th>
                                    <th>Father Name</th>
                                    <th>DOB</th>
                                    <th>Gender</th>
                                    <th>Address</th>
                                    <th>Contact</th>
                                    <th>Emergency Details</th>
                                      <th>Action</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptdept"   runat="server" OnItemCommand="rptdept_ItemCommand">
                                         <ItemTemplate>
                                     <tr>
                                          
                                         <td><%#Eval("empcode") %></td>
                                          <td><%#Eval("name") %></td>
                                         <td><%#Eval("cnic") %></td>
                                         
                                         <td><%#Eval("fathername") %></td>
                                         
                                         <td><%#Eval("dob") %></td>
                                         <td><%#Eval("gender") %></td>
                                         <td><%#Eval("address") %></td>
                                         <td>
                                             <b>Phone</b><br />Work:<%#Eval("w_phone") %><br />Personal:<%#Eval("p_phone") %><br /><b>Email</b><br />Work:<%#Eval("w_email") %><br />Personal:<%#Eval("p_email") %></td>
                                         <td><%#Eval("emergency_details") %></td>
                                         <td>
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("id") %>' runat="server"/>
                                            
		  <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                                
		   
             </td>
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>

                                </tbody>
                            </table>

    </div>
                          
               
 			</div></div>
  
    <script type="text/javascript">
    $(document).ready(function () {
        $('#datatable').dataTable();
        $('#datatable-keytable').DataTable({keys: true});
        $('#datatable-responsive').DataTable();
        $('#datatable-colvid').DataTable({
            "dom": 'C<"clear">lfrtip',
            "colVis": {
                "buttonText": "Change columns"
            }
        });
        $('#datatable-scroller').DataTable({
            ajax: "assets/plugins/datatables/json/scroller-demo.json",
            deferRender: true,
            scrollY: 380,
            scrollCollapse: true,
            scroller: true
        });
        var table = $('#datatable-fixed-header').DataTable({fixedHeader: true});
        var table = $('#datatable-fixed-col').DataTable({
            scrollY: "300px",
            scrollX: true,
            scrollCollapse: true,
            paging: false,
            fixedColumns: {
                leftColumns: 1,
                rightColumns: 1
            }
        });
    });
    TableManageButtons.init();

</script>
</asp:Content>


