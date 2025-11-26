<%@ Page Title="Monthly Pay" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="employeemonthlysalary.aspx.cs" Inherits="HRMS.employeemonthlysalary" %>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>  
<script type="text/javascript" src="scripts/html2canvas.min.js"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>.bodyinvoice{
    background: #eee
}</style>
     <script>
            var resizefunc = [];
        </script>
    <script type="text/javascript">  
        
function ConvertToImage(btnExport)  
{  
    debugger;  
    html2canvas($("#divsalaryslips")[0]).then(function(canvas)  
    {  
        debugger;  
        var base64 = canvas.toDataURL();  
        $("[id*=hfImageData]").val(base64);  
        debugger;  
        __doPostBack(btnExport.name, "");  

    });  
    return false;  
}  
</script> 

        <!-- jQuery  -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js	"></script>
   
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
     <link href="assets/plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet" />
		<link href="assets/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css" rel="stylesheet" />
		<link href="assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.min.css" rel="stylesheet" />
		<link href="assets/plugins/clockpicker/css/bootstrap-clockpicker.min.css" rel="stylesheet" />
		<link href="assets/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" />

   
    <div class="card-box">
     <div class="row">
							<div class="col-sm-12">
								
									<h2 class="m-t-0 header-title"><b>Employee Monthly Pay</b></h2>
                                </div>
         </div>
        </div>
        <div class="card-box">
        <div class="row">
                            <label>Salary Month</label>
                  </div>
              <div class="row">
              
                              <div class="col-lg-6">
                        <div class="p-12">
                        
                         <asp:DropDownList ID="ddlmonth" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged">
                          </asp:DropDownList>
</div></div>
<div class="col-lg-6">
                        <div class="p-12">
                          
                            <asp:DropDownList ID="ddlyear" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"></asp:DropDownList>
                              
                              
                        </div>
                                     </div>
                                        </div>
									<div class="row">
                          <div class="col-lg-12">
                        <div class="form-group">
                            <label>Employee Code</label>
                            
                         <asp:DropDownList ID="ddlempcode" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlempcode_SelectedIndexChanged"></asp:DropDownList>
                              </div>
                                     </div>
                                        </div>
                                                 
        </div>
    

          <div class="card-box" id="divsalary" visible="false" runat="server">
             
                             
                                									

         
        <div class="row" id="divattendance" runat="server" visible="false">
            <div class="col-lg-12">              
            <div class="col-sm-12" >
                        
                        <div class="alert alert-success" role="alert">
                            <h4 class="alert-heading">Employee Attendance Data for selected Month!</h4>
                            <span>
                                <span>Total Working days of Selected month:</span><span id="p_work" runat="server"></span><br />
                                <span>Employee Working days Count:</span><span id="p_working_days" runat="server"></span><br />
                                <span>Late Count:</span><span id="p_late" runat="server"></span><br />
                                <span>Leave Count:</span><span id="p_leave_days" class="m" runat="server"></span><br />
                                <span>Absent Count:</span><span id="p_absent_days" class="m" runat="server"></span><br />
                 </span>
</div>
                                       </div>  </div></div>
            <div class="card-box" > 
                 <div class="row">
                                <h3 class="m-t-0 header-title"><b>Earnings </b></h3>
									<br />
                  </div>
            <div class="row" ><asp:Repeater ID="rptsalarycom"  runat="server" >
                                         <ItemTemplate>
                                 <div class="col-lg-12">
                        <div class="form-group">
                           <label><asp:Label ID="lblsalarycom" runat="server" Text='<%#Eval("salary_component")%>'></asp:Label></label>
                            
                            <asp:TextBox ID="txtamount" Text='<%#Eval("amount")%>' onkeypress="return event.charCode >= 48 && event.charCode <= 57" class="form-control" runat="server" ></asp:TextBox>
                         
                       
                        </div>
                    </div>
                                             </ItemTemplate>
                         
                                             </asp:Repeater>
                                           
                                        
                         </div>
             
              <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group" runat="server">
                        
                           <label><asp:Label ID="Label1" runat="server"></asp:Label>Total Earnings </label>
                               <asp:TextBox ID="txtsum"  class="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                         
                            </div></div></div>
          </div>               
                         
    
							
    <div class="card-box">
        <div class="row">                          
        <div class="form-group">         
                                   <div class="col-lg-12">
                                               <h3 class="m-t-0 header-title">Deduction</h3>
                                       </div>
            </div>
            </div>
            <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group" id="divloan" runat="server">
                        
                           <label><asp:Label ID="lblLoan" runat="server"></asp:Label>Per Month Loan Pay </label>
                               <asp:TextBox ID="txtloan"  class="form-control" runat="server" AutoPostBack="True" TextMode="Number" OnTextChanged="txtloan_TextChanged"></asp:TextBox>
                         
                            </div></div></div>
            <div class="row">

                          <div class="col-lg-12">
                        <div class="form-group" id="absent" runat="server">
                        
                           <label><asp:Label ID="Lblabsent" runat="server"></asp:Label>Absent Deduction </label>
                               <asp:TextBox ID="txtabsent"  class="form-control" runat="server"></asp:TextBox>
                         
                            </div></div></div>
            <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group" id="leave" runat="server">
                        
                           <label><asp:Label ID="lbllate" runat="server"></asp:Label>Late Deduction </label>
                               <asp:TextBox ID="txtlate"  class="form-control" runat="server"></asp:TextBox>
                         
                            </div></div></div>
            <div class="row">
                          <div class="col-lg-12">
                        <div class="form-group" runat="server">
                        
                           <label><asp:Label ID="Label2" runat="server"></asp:Label>Total Deduction </label>
                               <asp:TextBox ID="txtdetsum"  class="form-control" runat="server"></asp:TextBox>
                         
                            </div></div></div>
                  </div>
            <div class="card-box">
    <div class="row">
							<div class="col-sm-12">
								
									<h3 class="m-t-0 header-title"><b>Bonus </b></h3>
                                    </div>
        </div>
									
									<div class="row">

                                
                              
                         
                              
                         <div class="col-lg-6">
											
			                                <div class="p-12">
												<label>Stat Bonus</label>
												<div class="input-group clockpicker m-b-15">
													 <asp:TextBox id="txtbonusper" type="text" class="form-control" runat="server" AutoPostBack="True" TextMode="Number" OnTextChanged="txtbonusper_TextChanged">
</asp:TextBox>
													<span class="input-group-addon"> <span>%</span> </span>
												<%--<asp:RangeValidator id="Range1"
           ControlToValidate="txtbonusper"
           MinimumValue="0"
           MaximumValue="100"
           Type="Integer"
           Text="The value must be 0 to 100"
           runat="server"/>--%>
                                                </div>
                                                </div>
                             </div>
                                                   <div class="col-lg-6">
											
			                                <div class="p-12">
												<label></label>
												
											<asp:TextBox id="txtbonuss" type="text" class="form-control" runat="server" AutoPostBack="True" TextMode="Number" OnTextChanged="txtbonuss_TextChanged">
</asp:TextBox>            
												
                                                </div>
                                            
                             </div>
                                        
									</div>
                                   


                                   
								</div>        
						
    <div class="card-box">
        <div class="row">                          
        <div class="form-group">         
                                   <div class="col-lg-12">
                                               
                        
                           <label><asp:Label ID="lblsum" runat="server"></asp:Label>Net Pay: </label>
                               <asp:TextBox ID="txtnetsum"  class="form-control" runat="server" AutoPostBack="true" ></asp:TextBox>
                         
                            
                           </div>
                       
                        </div>
            </div>
                    </div>
        
                          <div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<div class="row">

                                
                                           <div class="col-lg-12"><asp:Button ID="btnsave" OnClick="btnsave_Click" CssClass="btn btn-warning"  runat="server" Text="Save"  />
</div>
                                        
									</div>
                                   


                                   
								</div>
							</div>
						</div> 
              </div>
    <asp:Button ID="btnsalarygrid" CssClass="btn btn-warning"  runat="server" Text="Generate Multiple PaySlip" OnClick="btnsalarygrid_Click"  />

   
    <div id="custom-width-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
                                        
        <div class="modal-dialog" id="divsalaryslip" runat="server" style="width:70%;">
                                            <div class="modal-content">
                                               
			    <button type="button" class="close" onclick="Custombox.close();">
			        <span>&times;</span><span class="sr-only">Close</span>

			    </button>
                                                <asp:HiddenField ID="hfImageData" runat="server" ClientIDMode="Static" />              
                                                <div id="divsalaryslips" runat="server">                    
			    
                <h4 class="custom-modal-title">PAY SLIP</h4>
			    <div class="custom-modal-text">
			      <div class="container mt-5 mb-5">
                      <br />
        <div class="row">
            <div class="col-md-12">
                <div class="text-center lh-1 mb-2">
                     <span class="fw-normal" style="font-weight:bolder">Payment slip for the month of </span><span style="font-weight:bold;text-transform:uppercase" id="spanmonth" runat="server" class="fw-normal"></span>
</div>
                <div class="d-flex justify-content-end">  </div>
                <br />
                <div class="row">
                    <div class="col-md-16">
                        <div class="row">
                            <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">EMP Code:</span> <small id="spanempcode" runat="server" class="ms-3"></small> </div>
                            </div>
                            <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">EMP Name:</span> <small id="spanempname" runat="server" class="ms-3"></small> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Late Count:</span> <small id="spanlatecount" runat="server" class="ms-3"></small> </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Rec No.:</span> <small id="id" runat="server" class="ms-3">101523065714</small> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Designation:</span> <small id="spandes" runat="server" class="ms-3"></small> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Absent Count:</span> <small id="spanabsentcount" runat="server" class="ms-3"></small> </div>
                            </div>
                            
                        </div>
                        <div class="row">
                           
                            <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Mode of Pay:</span> <small class="ms-3">CASH</small> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Department:</span> <small id="spandept" runat="server" class="ms-3"></small> </div>
                            </div>
                             <div class="col-md-4">
                                <div> <span class="fw-bolder" style="font-weight:bolder">Leave Count:</span> <small id="spanleavecount" runat="server" class="ms-3"></small> </div>
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
                                <td><small id="spanbonus" runat="server" class="ms-3"></small></td>
                               
                            </tr>
                            
                            
                           
                           
                           
                            
                            <tr class="border-top">
                                <th scope="row">Total Earning</th>
                                <td><small id="spansumearn" runat="server" class="ms-3"></small></td>
                               
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
                                <td><small id="spanabsent" runat="server" class="ms-3"></small></td>
                               
                            </tr>
                            <tr>
                                <th scope="row">Late</th>
                                <td><small id="spanlate" runat="server" class="ms-3"></small>
</td>                               
                            </tr>
                            <tr>
                                <th scope="row">Loan</th>
                                <td><small id="spanloan" runat="server" class="ms-3"></small> </td>
                               
                            </tr>
                            <tr>
                                
                               
                            </tr>
                          
                            
                            <tr class="border-top">
                                
                                <th scope="row">Total Deductions</th>
                                <td><small id="spandetsum" runat="server" class="ms-3"></small></td>
                            </tr>
                        </tbody>
                    </table>
                            </div></div>
                </div>
    <br />
                <div class="row">
                    <div class="col-md-10"> 
                        <span style="font-weight:bolder">Net Pay : </span>
                            <span id="spannetsum" style="font-weight:bold" runat="server" class="ms-3"></span>

                         </div>
                    </div>
                <div class="row">
                    <div class="col-md-10">
                         <span style="font-weight:bolder">In Words:</span> 
                        <span>
                            <span class="ms-3" style="font-weight:bold;text-transform:uppercase" id="spaninwords" runat="server"></span>

                        </span> 

                    </div>
                   
                </div>
                <br />
                
                <div class="d-flex justify-content-end">
                    <div class="d-flex flex-column mt-2" style="font-weight:bolder;display:ruby-text-container;float:right">Created by: @<span id="spanuserid" runat="server" class="fw-bolder"></span>  </div>
                </div>
            
        </div>
    </div>
                </div>
                    <br />
                    </div>
                                                                 </div>
                                                                 <div class="custom-modal-text">
                    <div class="row" style="float:right">
                        
                                                 <asp:Button ID="btnsavess" OnClick="btnsavess_Click" runat="server" Width="150px"  Text="Saved" OnClientClick="return ConvertToImage(this)" CssClass="btn-success" />
                                                <asp:Button ID="btnClose" Width="150px" runat="server" Text="Close" CssClass="btn-danger" />
                        </div>
			</div>

                                             
                                              
                                              
                                            </div>
                                         </div>
     </div>
            
 			

</asp:Content>
