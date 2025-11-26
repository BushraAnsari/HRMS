<%@ Page Title="Salary Deduction Policy" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="salarydetuctionpolicy.aspx.cs" Inherits="HRMS.salarydetuctionpolicy" %>
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
    <div class="card-box">
								
    <div class="row">
							<div class="col-sm-12">
									<h1 class="m-t-0 header-title"><b>Slary Detuction Policy</b></h1>
								
								</div>
        </div>
                                <div class="row">

                                                            <div class="col-lg-6">
                         <label>Grade</label>
                            
                          <asp:DropDownList ID="ddlgrade"  class="form-control" runat="server"></asp:DropDownList>
                                                                
                            <label>One Absent detuction from Monthly Salary</label>
                            
                            <div class="input-group clockpicker m-b-15">
													 <asp:TextBox id="txtabsent" type="text" class="form-control" runat="server" AutoPostBack="True" TextMode="Number">
</asp:TextBox>
													<span class="input-group-addon"> <span>%</span> </span>
                                </div>
                                                               
                             
                            <label>One Late detuction from Monthly Salary </label>
                            
                             <div class="input-group clockpicker m-b-15">
													 <asp:TextBox id="txtlate" type="text" class="form-control" runat="server" AutoPostBack="True" TextMode="Number">
</asp:TextBox>
													<span class="input-group-addon"> <span>%</span> </span>
                                </div>
                                       <asp:Button ID="Save" CssClass="btn btn-warning" OnClick="Save_Click"  runat="server" Text="Save"  />
                             <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                            <asp:HiddenField ID="d_id" runat="server" />
                            
                                                                <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                        
                            </div>
                    </div>

                                        
									
							</div>
<div class="card-box"> <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Late Deduction</th>
                                    <th>Absent Deduction</th>
                                    <th>Grade</th>
                                      <th>Action</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptdept"   runat="server" OnItemCommand="rptdept_ItemCommand" >
                                         <ItemTemplate>
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                          <td><%#Eval("late_detuction") %>%</td>
                                         <td><%#Eval("absent_detuction") %>%</td>
                                         <td><%#Eval("emp_grade") %></td>
                                         <td>
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("id") %>' runat="server"/>
                                            
		  <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                                
		   
             </td>
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>

                                </tbody>
                            </table></div>										
</asp:Content>