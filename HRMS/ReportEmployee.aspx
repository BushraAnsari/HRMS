<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportEmployee.aspx.cs" Inherits="HRMS.ReportEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/buttons.bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/fixedHeader.bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/responsive.bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/scroller.bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/dataTables.colVis.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/fixedColumns.dataTables.min.css" rel="stylesheet" type="text/css"/>


    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/core.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/components.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css"/>
    <script src="assets/js/modernizr.min.js"></script>
    <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box table-responsive">
                            <h4 class="m-t-0 header-title"><b>Employee Report</b></h4>
                         

                            <table id="datatable" style="width:100%" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Emp Code</th>
                                    <%--<th>Department</th>--%>
                                    <th>Sub Dep</th>
                                    <th>Full Name</th>
                                    <th>Father Name</th>
                                    <th>Gender</th>
                                    <th>CNIC</th>
                                    <%--<th>Marital</th>--%>
                                    <th>SuperVisor</th>
                                    <th>Mobile</th>
                                    <%--<th>Grade</th>
                                    <th>Leave Policy</th>--%>
                                    <th>Status</th>
                                </tr>
                                </thead>


                                <tbody>
                                      <asp:Repeater ID="rptitemdetails"  runat="server" >

                                         <ItemTemplate>
                                             <tr>
                                    <td><%# Container.ItemIndex+1 %></td>
                                    <td><%#Eval("EmployeeCode") %></td>
                                   <%-- <td><%#Eval("Department_name") %></td>--%>
                                    <td><%#Eval("Sub_department_name") %></td>
                                    <td><%#Eval("FullName") %></td>
                                    <td><%#Eval("FatherFullName") %></td>
                                    <td><%#Eval("Gender") %></td>
                                    <td><%#Eval("CNIC") %></td>
                               <%--     <td><%#Eval("MaritalStatus") %></td>--%>
                                    <td><%#Eval("SuperVioserName")%></td>
                                    <td><%#Eval("MobilePhone") %></td>
                                   <%-- <td><%#Eval("Empgrade") %></td>
                                    <td><%#Eval("Leavepolicy") %></td>--%>
                                    <td><%#Eval("Employee_status_name") %></td              
                                </tr>

                                             </ItemTemplate>
                                             </asp:Repeater>
                                          
                                
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

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


<script type="text/javascript">
    $(document).ready(function () {
        $('#datatable').dataTable();
        $('#datatable').dataTable( {
  "pagingType": "full_numbers"
} );
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
