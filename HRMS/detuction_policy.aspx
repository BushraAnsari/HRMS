<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="detuction_policy.aspx.cs" Inherits="HRMS.detuction_policy" %>
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

    <div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<h4 class="m-t-0 header-title"><b>Slary Detuction Policy</b></h4>
									
									<div class="row">

                                                            <div class="col-lg-6">
                         <label>Grade</label>
                            
                          <asp:DropDownList ID="ddlgrade"  class="form-control" runat="server"></asp:DropDownList>
                                                                
                            <label>One Absent detuction from Monthly Salary in "%"</label>
                            
                            <asp:TextBox ID="txtabsent" class="form-control" runat="server" placeholder="Enter Name" ></asp:TextBox>
                             
                            <label>One Late detuction from Monthly Salary in "%" </label>
                            
                            <asp:TextBox ID="txtlate" class="form-control" runat="server" placeholder="Allowed Yearly" TextMode="Number" ></asp:TextBox>
                             <asp:Button ID="Save" CssClass="btn btn-warning" style=" float:right; " OnClick="Save_Click"  runat="server" Text="Save"  />
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>

                                        
									</div>

                                   
								</div>
							</div>
						</div>				
</asp:Content>
