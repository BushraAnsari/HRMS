<%@ Page Title="Yearly Leaves" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addleavetype.aspx.cs" Inherits="HRMS.addleavetype" %>
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

    <div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<h4 class="m-t-0 header-title"><b>Yearly Allowed Leaves</b></h4>
									
									<div class="row">

                                                            <div class="col-lg-6">
                        <div class="p-20">
                            <label>Employe Leave Type</label>
                            
                            <asp:TextBox ID="txtleavetype" class="form-control" runat="server" placeholder="Enter Name" ></asp:TextBox>
                             
                            <label>Total in Year</label>
                            
                            <asp:TextBox ID="yearly" class="form-control" runat="server" placeholder="Allowed Yearly" TextMode="Number" ></asp:TextBox>
                             <asp:Button ID="Save" CssClass="btn btn-warning"  OnClick="Save_Click"  runat="server" Text="Save"  />
                            <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                            <asp:HiddenField ID="d_id" runat="server" />
                            
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>

                                        
									</div>
                                     <table id="datatable-buttons" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Leave type Name</th>
                                    <th>Allowed Yearly</th>
                                      <th>Action</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptleavetype"   runat="server" OnItemCommand="rptdept_ItemCommand">
                                         <ItemTemplate>
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                          <td><%#Eval("leave_type_name") %></td>
                                         <td><%#Eval("total_in_year") %></td>
                                          <td>
                                            <asp:LinkButton id="imgBtnEdit" CssClass="ti-pencil" commandname="Edit" ToolTip="Edit a record." CommandArgument='<%#Eval("id") %>' runat="server"/>
                                            
		  <asp:LinkButton ToolTip="Delete a record." CssClass="bg-icon md-delete " OnClientClick="javascript:return confirm('Are you sure to delete record?')" id="BtnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"/>
                                                
		   
             </td>
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>

                                </tbody>
                            </table>


                                   
								</div>
							</div>
						</div>				
</asp:Content>
