<%@ Page Title="Loan Paid Employee" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addemployeeloan.aspx.cs" Inherits="HRMS.addemployeeloan" %>
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
    <div class="card-box">
     <div class="row">
							<div class="col-sm-12">
								
									<h4 class="m-t-0 header-title"><b>Add Loan Paid Employee</b></h4>
									<br />
									<div class="row">
                          <div class="col-lg-3">
                        <div class="form-group">
                            <label>Employee Code</label>
                            
                         <asp:DropDownList ID="ddlempid"  class="form-control" runat="server" OnSelectedIndexChanged="ddlempcode_SelectedIndexChanged"></asp:DropDownList>
                              </div>
                                     </div>
                                                <div class="col-lg-3">
                        <div class="form-group">
                            <label>Loan amount</label>
                            <br />
                             <asp:TextBox ID="txtloanamount" class="form-control" TextMode="number" runat="server" AutoPostBack="true" OnTextChanged="txtloanamount_TextChanged" ></asp:TextBox>
                           </div>
                                     </div>
                                                       <div class="col-lg-3">
                        <div class="form-group">
                            <label>Payable Time in month</label>
                            <br />
                             <asp:TextBox ID="txtlpayabletime" class="form-control" TextMode="number" runat="server" Text="12" AutoPostBack="true" OnTextChanged="txtlpayabletime_TextChanged"></asp:TextBox>
                           
                              </div>
                                     </div>
                                        <div class="col-lg-3">
                        <div class="form-group">
                            <label>Payable amount per month</label>
                            <br />
                             <asp:TextBox ID="txtpermonthamount" class="form-control" TextMode="number" runat="server" ReadOnly="true"/> </asp:TextBox>
                           
                              </div>
                                     </div>
                                                
                                              <div class="col-lg-3">
                        <div class="form-group">
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                            <br />
                            <asp:Button ID="btnsave" name="ctl00$ContentPlaceHolder1$Save" runat="server"  CssClass="btn btn-warning"   Width="100px"  Text="Save" OnClick="Btnsave_Click" />
                          <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                   
                         </div>
                                                  
                                                                         </div>
                                        </div>
                                </div>
         </div>
        </div>
    <div class="card-box">
        <div class="row">
            <div class="col-sm-12">
                               <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Employee Code</th>
                                    <th>Name</th>
                                    <th>Loan Amount</th>
                                    <th>Payable Month</th>
                                    <th>Remaining Loan Amount</th>
                                    <th>Payable amount per month</th>
                                    
                                    <th>Applied Date</th>
                                      <th>Status</th>
                                    <th>Action</th>


                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptleavetype"   runat="server" OnItemCommand="rptleavetype_ItemCommand">
                                         <ItemTemplate>
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                         <td><%#Eval("EmployeeCode") %></td>
                                         <td><%#Eval("FirstName") %> <%#Eval("LastName") %></td>

                                          <td><%#Eval("loan_amount") %></td>
                                         <td><%#Eval("payabletime_in_month") %></td>
                                         <td><%#Eval("remaining_loan_amount") %></td>

                                           <td><%#Eval("payable_amount_per_month") %></td>
                                         <td><%#Eval("applied_from") %></td>
                                         
           <td><%#Eval("Status") %></td>
                                         
                                         <td>
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("loan_id") %>' runat="server"/>
                                            
		  <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("loan_id") %>' runat="server"/>
                                                
		   
             </td>
                                           
                            
             
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>
                                    

                                </tbody>
                            </table>
                                    </div>
            </div>
        </div>
                                
        
                           
               
 			


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
