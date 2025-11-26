<%@ Page Title="Salary Details" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="salarydefine.aspx.cs" Inherits="HRMS.salarydefine" %>
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
    
    
    <div class="row">
							<div class="col-sm-12">
							  <div class="card-box table-responsive">
									<h1 class="m-t-0 header-title"><b>Salary Define</b></h1>
									
									<div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                         <label>Employe Code</label>
                                            <asp:DropDownList ID="ddlempcode"  class="form-control" runat="server"></asp:DropDownList>
                              </div>
                                     </div>
                                            </div>
                                            <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                            
                                 <asp:Repeater ID="rptsalarycom"  runat="server" >
                                         <ItemTemplate>
                           <label><asp:Label ID="lblsalarycom" runat="server" Text='<%#Eval("salary_components")%>'></asp:Label></label>
                            
                            <asp:TextBox ID="txtamount"  onkeypress="return event.charCode >= 48 && event.charCode <= 57" class="form-control" runat="server" ></asp:TextBox>
                         </ItemTemplate>
                                     <FooterTemplate>
                                         <asp:Label ID="lblsum" runat="server"></asp:Label>
        </FooterTemplate>
                                             </asp:Repeater>
                         
                       </div>
                        </div>
                    </div>
                                            <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                             
            
                                              <asp:Button ID="btnsave" OnClick="btnsave_Click"  runat="server" CssClass="btn btn-warning" Text="Save" />             
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                          <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                   
                         </div> <asp:HiddenField ID="d_id" runat="server" />
                           
                                                  
                                                                         </div>
                                        </div>
                                  </div>
                                <div class="card-box table-responsive">
                                 <table id="datatable" class="table table-striped table-bordered">
                                
                                      
                                      <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Employee Code</th>
                                    <th>Name</th>
                                    
                                   
                                  <th>Amount</th>
                                    <th>Action</th>

                                </tr>
                                </thead>
                                     <tbody>
                                         <tr>
                                  <asp:Repeater ID="rptleavetype"   runat="server" OnItemCommand="rptleavetype_ItemCommand">
                                         <ItemTemplate>
                                             <td><%# Container.ItemIndex+1 %></td>
                                <td><%#Eval("EmployeeCode") %></td>
                                         <td><%#Eval("name") %></td>
                              
                                             <td><%#Eval("Amount") %></td>
                                 
                                
                                      
                                        <td style="Width:20px;" >
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("id") %>' runat="server"/>

		  <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                                 <%--  <asp:LinkButton ID="btndlt" CssClass="bg-icon md-delete "  OnClick="btndlt_Click" style=" float:right;" runat="server" >
                                             </asp:LinkButton>--%>
		   
            
                                           
                            
             
                                        

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
   
</script>


                                     <div id="custom-width-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
                                        <div class="modal-dialog" style="width:50%;">
                                            <div class="modal-content">
                                                
                                               
                                               
			    <button type="button" class="close" onclick="Custombox.close();">
			        <span>&times;</span><span class="sr-only">Close</span>
			    </button>
			    <h4 class="custom-modal-title">Confiramtion POP</h4>
			    <div class="custom-modal-text">
			      This Employee Code is <asp:Label ID="lblcode" runat="server"></asp:Label>and total Salary is <asp:Label ID="lblsum" runat="server"></asp:Label>
			    </div>
                                                 <asp:Button ID="btnsavess" OnClick="btnsavess_Click" runat="server" Width="150px"  Text="Saved" CssClass="btn-success" />
                                                <asp:Button ID="btnClose" Width="150px" runat="server" Text="Close" CssClass="btn-danger" />
			</div>

                                             
                                              
                                            </div>
                                         </div>

</asp:Content>