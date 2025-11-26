<%@ Page Title="Leave" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="empleaverequest.aspx.cs" Inherits="HRMS.empleaverequest" %>
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


    <div class="card-box">
    <div class="row">
							<div class="col-sm-12">
								
									<h4 class="m-t-0 header-title"><b>Request for Leave</b></h4>
                                    </div>
        </div>
                                    <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group">
                            <label>Employee Code</label>
                            
                              </div>
                                     </div>
                                        </div>
                                    <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group">
                            <label>Leave Type</label>
                            
                         <asp:DropDownList ID="ddlleave" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ddlleave_SelectedIndexChanged"></asp:DropDownList>
                              </div>
                                     </div>
                                        </div>
                                    <div id="divsequencedate" runat="server" class="row" visible="false">
                          <div class="col-lg-6">
                        <div class="form-group">
                                                        <label>From </label>

                            
                            <asp:TextBox ID="txtfrom" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>

                        </div>
                                     </div>
                                         <div class="col-lg-6">
                        <div class="form-group">
                                                        <label>to </label>

                            
                            <asp:TextBox ID="txtto" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>

                        </div>
                                     </div>
                                        </div>
									
                                   <div id="divdate" runat="server" class="row">
                          <div class="col-lg-12">
                        <div class="form-group" id="txtonedate">
                                                        <label id="idupdate" runat="server">Date</label>
                            
                            <asp:TextBox ID="txtdate" class="form-control" runat="server" AutoPostBack="true" TextMode="Date" ></asp:TextBox> </div>
                                     </div>
                           
                                        </div>
                           
                                   <div class="row">
                          <div class="col-lg-6">
                        <div class="form-group">
                                                     
                            
                         <asp:Button ID="btndate" CssClass="alert-info" style=" float:left; " OnClick="adddate_Click"  runat="server" Text="Want to choose date in sequence 'TO' 'FROM' "  />
    
                            </div>

                          </div>
                           
                                        </div>
                           
                            
									
                                    <div class="row">

                                                            <div class="col-lg-6">
                        <div class="p-20">
                             
    
                            <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                   
                       
                            <asp:Button ID="btnSave" CssClass="btn btn-warning " OnClick="Save_Click"  runat="server" Text="Save"  />
                           
                        </div>
                    </div>

                                        
									</div>
        </div>
    <div class="card-box">

                                     <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Employee Code</th>
                                    <th>Employee Name</th>
                                    <th>Leave Type Name</th>
                                    
                                    <th>Leave Date</th>
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
                                         <td><%#Eval("FirstName")%> <%#Eval("LastName")%></td>

                                          <td><%#Eval("leave_type_name") %></td>
                                         <td><%#Eval("Date") %></td>
                                           <td><%#Eval("Status") %></td>
                                         
           
                    <td style="Width:20px;" >
               <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                              
             </td>
                                                               
                                           
                            
             
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>
                                    

                                </tbody>
                            </table>


                                   
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
