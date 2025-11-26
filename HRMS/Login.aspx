<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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
</head>
<body>
    <form id="form1"   runat="server">
    <div>
     <div class="account-pages"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page">
        	<div class=" card-box">
            <div class="panel-heading"> 
                <h3 class="text-center">HR AND ACCOUNTS ERP SYSTEM </h3>
            </div> 


            <div class="panel-body">
          
                
                <div class="form-group ">
                    <div class="col-xs-12">
                        <input class="form-control" id="txtusername" runat="server" type="text" required="" placeholder="Username">
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-xs-12">
                        <input class="form-control" id="txtpassword" type="password" runat="server" required="" placeholder="Password">
                    </div>
                </div>

                <div class="form-group ">
                    <div class="col-xs-12">
                        <div class="checkbox checkbox-primary">
                            <input id="checkbox-signup" type="checkbox">
                            <label for="checkbox-signup">
                                Remember me
                            </label>
                        </div>
                        
                    </div>
                </div>
                
                <div class="form-group text-center m-t-40">
                    <div class="col-xs-12">
                       
                        <asp:Button ID="btnlogin" runat="server" BackColor="#5fbeaa" Text="Log In" Width="100%" Font-Bold="True" ForeColor="White" OnClick="btnlogin_Click" Height="44px" />
                        <asp:Label ID="lblerror" runat="server" Visible="false" ></asp:Label>
                    </div>
                </div>

        
           
            
            </div>   
            </div>                              
     
            
        </div>
        
        

     

	
    </div>
           
    	<script>
    	    debugger;
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
    </form>
</body>
</html>
