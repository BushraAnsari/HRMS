<%@ Page Title="Paid Salary" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"  CodeBehind="empsalaryslip.aspx.cs" Inherits="HRMS.empsalaryslip" %>
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
     <div class="card-box table-responsive">
								


    <div class="row">
							<div class="col-sm-12">
							 	<h1 class="m-t-0 header-title"><b>Paid Salary</b></h1>
									<br />
									
            </div>
            </div>
         
                                <div class="row">
                                 <table id="datatable" class="table table-striped table-bordered">
                                
                                      
                                      <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Month</th>
                                    <th>Year</th>
                                    
                                  
                                  <th>Gross Earning</th>
                                      <th>
                                Gross Deduction 
               
                                       
                                                               
                         </th>
                                  
                                     <th>Net Pay</th>
                                    <th>Action</th>
                                </tr>
                                </thead>
                                     <tbody>
                                         <asp:Repeater ID="rptleavetype"   runat="server" OnItemCommand="rptleavetype_ItemCommand">
                                         <ItemTemplate>
                                  
                                       
                                            
                                             <tr>
                                  
                                 <td><%# Container.ItemIndex+1 %></td>
                                <td> <%#Eval("salary_month") %> </td>
                                             <td><%#Eval("salary_year") %></td>
                                              <td><%#Eval("ge") %> </td>
                                                 <td><%#Eval("gd") %> </td>
                                            <td><%#Eval("net_pay") %> </td>
                                                  <td style="Width:20px;" >
                                                      <a href='<%#Eval("slip_url") %>'/>
               <asp:LinkButton  ToolTip="Download Salary Slip" CssClass="bg-icon ion-android-download"  id="BtnDelete" CommandName="Download" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                              
             </td>
                     
                                      
                                     
                                      
		   
            
                                           
                            
             
                                        

                                
                                             
                                    </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>

                                </tbody>
                            </table>
                                  </div> 
                                  </div>

    <div id="custom-width-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
      
      <asp:Repeater ID="rptsalaryslip" runat="server">
                                         <ItemTemplate>
                                              <div class="modal-dialog" id="divsalaryslip" runat="server" style="width:70%;">
                                            <div class="modal-content">
                                               
			    <button type="button" class="close" onclick="Custombox.close();">
			        <label>&times;</label><label class="sr-only">Close</label>
			    </button>
                                     <asp:HiddenField ID="hiddenID" Value ='<%#Eval("EmployeeID")%>' runat="server" /> 
                                                <asp:HiddenField ID="HiddenCode" Value ='<%#Eval("EmployeeCode")%>' runat="server" /> 
                                                <div id="divsalaryslips" runat="server">                    
			    
                <h4 class="custom-modal-title">PAID SALARY</h4>
			    <div class="custom-modal-text">
			      <div class="container mt-5 mb-5">
                      <br />
        <div class="row">
            <div class="col-md-12">
                <div class="text-center lh-1 mb-2">
                     <label class="fw-normal" style="font-weight:bolder">Payment slip for the month of  &nbsp; </label><%#Eval("salary_month")%>,<%#Eval("salary_year")%><label style="font-weight:bold;text-transform:uppercase" id="spanmonth" runat="server" class="fw-normal"></label></div>
                <div class="d-flex justify-content-end">  </div>
                <br />
                <div class="row">
                    <div class="col-md-16">
                        <div class="row">
                            <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">EMP Code:</label><%#Eval("EmployeeCode")%><label id="spanempcode" runat="server" class="ms-3"></label></div>
                            </div>
                            <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">EMP Name:</label><%#Eval("EmployeeName")%><label id="spanempname" runat="server" class="ms-3"></label></div>
                            </div>
                             <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Late Count:</label><%#Eval("late_days")%><label id="spanlatecount" runat="server" class="ms-3"></label></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Rec No.:</label> <label id="id" runat="server" class="ms-3">101523065714</label> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Designation:</label> <%#Eval("job_title")%><label id="spandes" runat="server" class="ms-3"></label> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Absent Count:</label><%#Eval("absent_days")%><label id="spanabsentcount" runat="server" class="ms-3"></label></div>
                            </div>
                            
                        </div>
                        <div class="row">
                           
                            <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Mode of Pay:</label> <label class="ms-3">CASH</label> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Department:</label><%#Eval("department_name")%><label id="spandept" runat="server" class="ms-3"></label></div>
                            </div>
                             <div class="col-md-4">
                                <div> <label class="fw-bolder" style="font-weight:bolder">Leave Count:</label><%#Eval("leave_days")%><label id="spanleavecount" runat="server" class="ms-3"></label></div>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    <br />
                    <div class="row">
                            <div class="col-md-6">
                   <table class="mt-4 table table-bordered">
                        <thead class="bg-dark text-white">
                            <tr>
                                <th scope="col">Earnings</th>
                                <th scope="col">Amount</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptslip"  runat="server" >
                             <ItemTemplate>
                            <tr>
                                <th scope="row"><%#Eval("salary_component")%></th>
                                <td><%#Eval("amount")%></td>
                               
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <th scope="row">Bonus</th>
                                <td><label id="spanbonus" runat="server" class="ms-3"></label></td>
                               
                            </tr>
                            
                            
                           
                           
                           
                            
                            <tr class="border-top">
                                <th scope="row">Total Earning</th>
                                <td><label id="spansumearn" runat="server" class="ms-3"><%#Eval("salary")%></label></td>
                               
                            </tr>
                        </tbody>
                    </table>
                                 </div>
                        <div class="col-md-6">
                    <table class="mt-4 table table-bordered">
                        <thead class="bg-dark text-white">
                            <tr>
                                
                                <th scope="col">Deductions</th>
                                <th scope="col">Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">Absent</th>
                                <td><label id="spanabsent" runat="server" class="ms-3"><%#Eval("absent")%></label></td>
                               
                            </tr>
                            <tr>
                                <th scope="row">Late</th>
                                <td><label id="spanlate" runat="server" class="ms-3"><%#Eval("late")%></label>
</td>                               
                            </tr>
                            <tr>
                                <th scope="row">Loan</th>
                                <td><label id="spanloan" runat="server" class="ms-3"><%#Eval("loan")%></label> </td>
                               
                            </tr>
                            <tr>
                                
                               
                            </tr>
                          
                            
                            <tr class="border-top">
                                
                                <th scope="row">Total Deductions</th>
                                <td><label id="spandetsum" runat="server" class="ms-3"><%#Eval("total_deduction")%></label></td>
                            </tr>
                        </tbody>
                    </table>
                            </div></div>
                </div>
    <br />
                <div class="row">
                    <div class="col-md-10"> 
                        <label style="font-weight:bolder">Net Pay : </label>
                            <label id="spannetsum" style="font-weight:bold" runat="server" class="ms-3"><%#Eval("net_pay")%></label>

                         </div>
                    </div>
                <div class="row">
                    <div class="col-md-10">
                         <label style="font-weight:bolder">In Words:</label> 
                        <label>
                            <label class="ms-3" style="font-weight:bold;text-transform:uppercase" id="spaninwords" runat="server">
                                <%#Eval("in_words")%>
                            </label>

                        </label> 

                    </div>
                   
                </div>
                <br />
                
                <div class="d-flex justify-content-end">
                    <div class="d-flex flex-column mt-2" style="font-weight:bolder;display:ruby-text-container;float:right">Created by: @<label id="spanuserid" runat="server" class="fw-bolder">
                        <%#Eval("user_name")%>
                                                                                                                                         </label>  </div>
                </div>
            
        </div>
    </div>
                </div>
                    <br />
                    </div>
                                                                 </div>
                                                                 

                                             
                                              
                                            </div>
                                         </div>
                                             

                                         </ItemTemplate>
          

      </asp:Repeater>
        <div class="custom-modal-text">
                    <div class="row" style="float:right">
                        
                                                 <asp:Button ID="btnsavess" runat="server" Width="150px"  Text="Saved" CssClass="btn-success" />
                                                <asp:Button ID="btnClose" Width="150px" runat="server" Text="Close" CssClass="btn-danger" />
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






                       
                                     

                                   
											
</asp:Content>