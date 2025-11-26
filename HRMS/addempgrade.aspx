<%@ Page Title="ERP HR & ACCOUNTS SYSTEM" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addempgrade.aspx.cs" Inherits="HRMS.addempgrade" %>
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
        </script><!-- jQuery  --><script src="assets/js/jquery.min.js"></script><script src="assets/js/bootstrap.min.js"></script><script src="assets/js/detect.js"></script><script src="assets/js/fastclick.js"></script><script src="assets/js/jquery.slimscroll.js"></script><script src="assets/js/jquery.blockUI.js"></script><script src="assets/js/waves.js"></script><script src="assets/js/wow.min.js"></script><script src="assets/js/jquery.nicescroll.js"></script><script src="assets/js/jquery.scrollTo.min.js"></script><script src="assets/js/jquery.core.js"></script><script src="assets/js/jquery.app.js"></script><div class="row">
							<div class="col-sm-12">
								<div class="card-box">
									<h4 class="m-t-0 header-title"><b>Employee Grade</b></h4>
									
									<div class="row">

                                
                              
                          <div class="col-lg-5">
                        <div class="form-group">
                            <label>Grading Name</label>
                             <asp:TextBox ID="txtgradename" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                 
                       <div class="row">
                                        <div class="col-lg-5">
                        <div class="form-group">
                            <label>Remarks</label>
                             <asp:TextBox ID="txtnote" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                         </div>
                                        <div class="row">
                                               <div class="col-lg-12">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-warning" OnClick="btnsave_Click" Text="Save" />
                         <asp:Button text="Update" id="btnUpdate" CssClass="btn btn-warning"  onclick="btnUpdate_Click" visible="false" runat="server"/>
                             <asp:Button text="Cancel" id="btnCancel" runat="server" CssClass="btn btn-warning" OnClick="btnCancel_Click"/>
                            <asp:HiddenField ID="g_id" runat="server" />    
                        </div>
                                                                         </div>
                              </div>
                       
        
                                        </div>
                                    </div>
                                <div class="card-box">
                                     <table id="datatable-buttons" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Name</th>
                                    <th>Remarks</th>
                                      
                                    <th>Action</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptgrade"   runat="server"  OnItemCommand="rptgrade_ItemCommand">
                                         <ItemTemplate>
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                          <td><%#Eval("Empgrade") %></td>
                                          <td><%#Eval("Note") %></td>
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

