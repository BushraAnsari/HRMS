<%@ Page Title=">ERP HR & ACCOUNTS SYSTEM" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addempconnectivity.aspx.cs" Inherits="HRMS.addempconnectivity" %>
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

     <script>
            var resizefunc = [];
        </script>

        <!-- jQuery  -->
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

     <div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<h4 class="m-t-0 header-title"><b>New Employee Add</b></h4>
									<br />
									<div class="row">
                          <div class="col-lg-3">
                        <div class="form-group">
                            <label>Employee Code</label>
                            
                         <asp:DropDownList ID="ddlempcode"  class="form-control" runat="server"></asp:DropDownList>
                              </div>
                                     </div>
                                                <div class="col-lg-3">
                        <div class="form-group">
                            <label>Department</label>
                            
                          <asp:DropDownList ID="ddldept"  class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldept_SelectedIndexChanged"></asp:DropDownList>
                              </div>
                                     </div>
                                                       
                                                                             <div class="col-lg-3">
                        <div class="form-group">
                            <label>Job Tittle</label>
                            <asp:DropDownList ID="ddljobtittle"  class="form-control" runat="server"></asp:DropDownList>
                           
                                    </div>
                                </div>
                                                                           <div class="col-lg-3">
                        <div class="form-group">
                            <label>Join Date</label>
                             <asp:TextBox ID="txtjoindate" class="form-control" TextMode="Date" runat="server" ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                                              <div class="col-lg-3">
                        <div class="form-group">
                            <label>Confirmation Date</label>
                             <asp:TextBox ID="txtconfimationdate" class="form-control" TextMode="Date" runat="server" ></asp:TextBox>
                           
                                    </div>
                                </div>
                                                          <div class="col-lg-3">
                        <div class="form-group">
                            <label>Grade</label>
                            
                          <asp:DropDownList ID="ddlgrade"  class="form-control" runat="server"></asp:DropDownList>
                              </div>
                                     </div>
                                                        <div class="col-lg-3">
                        <div class="form-group">
                            <label>Department Head / Report Person</label>
                            
                           <asp:DropDownList ID="ddlsupervisor"  class="form-control" runat="server"></asp:DropDownList>
                              </div>

                                        </div>
                                                     
                                                  <div class="col-lg-3">
                        <div class="form-group">
                            <label>Employee Status</label>
                            
                          <asp:DropDownList ID="ddlempstatus"  class="form-control" runat="server" OnSelectedIndexChanged="ddlempstatus_SelectedIndexChanged">
                             
                          </asp:DropDownList>
                          
                              </div>
                                     </div>
                                        <div runat="server" id="divcontract">
                                                <div class="col-lg-3" >
                        <div class="form-group">
                            <label>Contract Date Start</label>
                         <asp:TextBox ID="txtcontractdatestart" class="form-control" TextMode="Date" runat="server" ></asp:TextBox>
                           
                          
                              </div>
                                     </div>
                                                               <div class="col-lg-3">
                        <div class="form-group">
                            <label> <label>Contract Date End</label></label>
                            
                         <asp:TextBox ID="txtcontractdateend" class="form-control" TextMode="Date" runat="server" ></asp:TextBox>
                              </div>
                                        </div>
                                                </div>
                                              <div class="col-lg-3">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" CssClass="btn btn btn-warning"   Width="100px"  Text="Save" />
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
                                    <th>Dept Name</th>
                                    <th>Job Title</th>
                                    <th>Join date</th>
                                    <th>Confirmation Date</th>
                                    <th>Grade</th>
                                    <th>Report Person</th>
                                    <th>Status</th>
                                      <th>Contract Details</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptdept"   runat="server" OnItemCommand="rptdept_ItemCommand">
                                         <ItemTemplate>
                                     <tr>
                                          
                                         <td><%#Eval("empcode") %></td>
                                          <td><%#Eval("name") %></td>
                                         <td><%#Eval("dept_name") %></td>
                                         
                                         <td><%#Eval("job") %></td>
                                         
                                         <td><%#Eval("join_date") %></td>
                                         <td><%#Eval("conf_date") %></td>
                                         <td><%#Eval("grade") %></td>
                                         <td><%#Eval("report_person") %></td>
                                         <td><%#Eval("emp_status") %></td>
                                         <td>
                                             <b>Start:</b><%#Eval("con_start_date") %><br /><b>End:</b><%#Eval("con_end_date") %></td>
                                         
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
