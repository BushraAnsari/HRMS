<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="add_subdept.aspx.cs" Inherits="HRMS.add_subdept" %>
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
									<h4 class="m-t-0 header-title"><b>Sub Department Add</b></h4>
									
									<div class="row">

                                
                              
                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>Department Name</label>
                            
                            <asp:DropDownList ID="ddldept"  class="form-control" runat="server"></asp:DropDownList>
                              </div>
                                     </div>
                              
                                 <div class="col-lg-6">
                        <div class="form-group">
                              <label>Sub Department Name</label>
                            <asp:TextBox ID="txtsubdeptname" class="form-control" runat="server"  ></asp:TextBox>
                             <asp:Button ID="btnsave" runat="server" CssClass="btn btn-inverse btn-custom btn-rounded waves-effect waves-light" style=" float:right; " Text="Save" OnClick="btnsave_Click" />
                            <%--<asp:Button ID="Save" CssClass="btn btn-warning" style=" float:right; "  runat="server" Text="Save"   />--%>
                            <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>

                                        
									</div>
                                     <table id="datatable-buttons" class="table table-striped table-bordered">
                                <thead>
                                <tr>
                                    <th>Sno</th>
                                    <th>Department Name</th>
                                    <th>Sub Department Name</th>
                                      <th>Status</th>
                                    

                                  

                                </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="rptsubdept"   runat="server" >
                                         <ItemTemplate>
                                     <tr>
                                          
                                          <td><%# Container.ItemIndex+1 %></td>
                                         <td><%#dept(Eval("fk_dept_id")) %></td>
                                          <td><%#Eval("Sub_department_name") %></td>
                                         <td><%#Eval("status") %></td>
                                        

                                </tr>
                                             </ItemTemplate>
                                             </asp:Repeater>

                                </tbody>
                            </table>


                                   
								</div>
							</div>
						</div>				
</asp:Content>
