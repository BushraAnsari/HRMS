<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="salary_slip.aspx.cs" Inherits="HRMS.salary_slip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        <div class="modal-dialog" id="divsalaryslip" runat="server" style="width:70%;">
                                            <div class="modal-content">
                                               
			    <button type="button" class="close" onclick="Custombox.close();">
			        <span>&times;</span><span class="sr-only">Close</span>
			    </button>
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
                    <div class="row" style="float:right">
                        
                                                 <asp:Button ID="btnsavess" OnClick="btnsavess_Click" runat="server" Width="150px"  Text="Saved" CssClass="btn-success" />
                                                <asp:Button ID="btnClose" Width="150px" runat="server" Text="Close" CssClass="btn-danger" />
                        </div>
			</div>

                                             
                                              
                                            </div>
                                         </div>
    			
</asp:Content>
