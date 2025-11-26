<%@ Page Title="HRMS|Holiday" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addholiday.aspx.cs" Inherits="HRMS.addholiday" %>
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
								
									<h1 class="m-t-0 header-title"><b>Add Holiday</b></h1>
									<br />
                                    </div>
        </div>
									
                                    <div class="row">

                                                <div class="col-lg-3">
                        <div class="form-group">
                            <label>Type </label>
                            <br />
                         <asp:DropDownList ID="ddlholiday"  class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlholiday_SelectedIndexChanged">
                             
                             <asp:ListItem Text="" Value=""></asp:ListItem>
                             
                             <asp:ListItem Text="Yearly" Value="2"></asp:ListItem>
                             <asp:ListItem Text="Weekly" Value="1"></asp:ListItem>
                             <asp:ListItem Text="One Time" Value="0"></asp:ListItem>
                            
                             
                            </asp:DropDownList>
                           
                            </div>
                                     </div></div>
                                    <div class="row" id="divdate" runat="server" visible="false">

                                                       <div class="col-lg-3"  >
                        <div class="form-group" runat="server">
                            <label>Date:</label>
                            <br />
                             <asp:TextBox ID="txtdate" class="form-control" TextMode="Date" runat="server" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                           
                              </div>
                                     </div>
                                        </div>
                                    <div class="row" id="divday" runat="server" visible="false">

                                        <div class="col-lg-3">
                        <div class="form-group"  runat="server">
                            <label>Day</label>
                            <br />
                            <asp:DropDownList ID="ddlday" class="form-control" TextMode="number" runat="server" OnSelectedIndexChanged="ddlday_SelectedIndexChanged">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                             
                                <asp:ListItem Text="Sunday" Value="6"> </asp:ListItem>
                             <asp:ListItem Text="Saturday" Value="5"></asp:ListItem>
                             <asp:ListItem Text="Friday" Value="4"></asp:ListItem>
                             <asp:ListItem Text="Thursday" Value="3"></asp:ListItem>
                             <asp:ListItem Text="Wednesday" Value="2"></asp:ListItem>
                             <asp:ListItem Text="Tuesday" Value="1"></asp:ListItem>
                             <asp:ListItem Text="Monday" Value="0"></asp:ListItem>

</asp:DropDownList>
                           
                              </div>
                                     </div>
</div>                                                
                                    <div class="row">
          
                                    <div class="col-lg-3">
                        <div class="form-group">
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                            <br />
                            <asp:Button ID="btnsave"  runat="server"  CssClass="btn btn-warning"   Width="100px"  Text="Save" OnClick="Btnsave_Click" />
                         <asp:Button ID="btnupdate" runat="server"  CssClass="btn btn-warning"   Width="100px"  Text="Update" OnClick="Btnupdate_Click" Visible="false"/>
                         <asp:Button ID="btncancel"  runat="server"  CssClass="btn btn-warning"   Width="100px"  Text="Cancel" OnClick="Btncancel_Click"/>
                              
                        </div>
                                                  
                                                                         </div>
                                        </div>
                                        </div>
    <div class="card-box">
                                    <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Repeatation</th>
                                    <th>Day</th>
                                    
                                    <th>Date</th>
                                    
                                   <th>Action</th>
                                    
                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptleavetype"   runat="server" OnItemCommand="rptleavetype_ItemCommand">
                                         <ItemTemplate>
                                        
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                         
                                         <td>
                                             <%# (int)Eval("repeat_time") ==0 ? "One Time": (int)Eval("repeat_time") ==1 ? "Weekly":"Yearly"%>
                                             
                                             </td>
                                           <td>

                                                 
                                           
                                               <%#(string)Eval("holiday_day")==null?"-":
                                                  (string)Eval("holiday_day")=="0"?"Monday":
                                                  (string)Eval("holiday_day")=="1"?"Tuesday":
                                                  (string)Eval("holiday_day")=="2"?"Wednesday":
                                                  (string)Eval("holiday_day")=="3"?"Thursday":
                                                  (string)Eval("holiday_day")=="4"?"Friday":
                                                  (string)Eval("holiday_day")=="5"?"Saturday":
                                                  (string)Eval("holiday_day")=="6"?"Sunday":"-"%>

                                           </td>

                                           <td><%#Eval("holiday_date") %></td>
                                         
                                         <td style="Width:20px;" >
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("id") %>' runat="server"/>

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
