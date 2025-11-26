<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addleavingpolicy.aspx.cs" Inherits="HRMS.addleavingpolicy" %>
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
									<h4 class="m-t-0 header-title"><b>Employee Leave Policy</b></h4>
									
									<div class="row">

                                
                              
                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>Employee Leave Policy Name</label>
                             <asp:TextBox ID="txtpolicyname" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>1</label>
                             <asp:TextBox ID="TextBox1" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>2</label>
                             <asp:TextBox ID="TextBox2" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>3</label>
                             <asp:TextBox ID="TextBox3" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>4</label>
                             <asp:TextBox ID="TextBox4" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>5</label>
                             <asp:TextBox ID="TextBox5" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                          <div class="col-lg-6">
                        <div class="form-group">
                            <label>6</label>
                             <asp:TextBox ID="TextBox6" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                <div class="col-lg-6">
                        <div class="form-group">
                            <label>7</label>
                             <asp:TextBox ID="TextBox7" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                                        <div class="col-lg-6">
                        <div class="form-group">
                            <label>Remarks</label>
                             <asp:TextBox ID="txtnote" class="form-control" runat="server"  ></asp:TextBox>
                              </div>
                             </div>
                         
                                               <div class="col-lg-6">
                        <div class="form-group">
                            <br />
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-warning" OnClick="btnsave_Click" Text="Employee Policy Add" />
                            </div>
                                                                         </div>
                              
                       
        
                                        </div>
                                    </div>
                                </div>
          </div>
   
                           
               
 			

</asp:Content>
