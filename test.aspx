<%@ Page Language="C#" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
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
    <form id="form1" runat="server">   
    </form>

    <div class="container mt-5 mb-5">
        <div class="row">
            <div class="col-md-12">
                <div class="text-center lh-1 mb-2">
                    <h6 class="fw-bold">Payslip</h6> <span class="fw-normal">Payment slip for the month of </span><span id="spanmonth" runat="server" class="fw-normal"></span>
</div>
                <div class="d-flex justify-content-end"> <span>Department:</span><span id="spandept" runat="server"></span> </div>
                <div class="row">
                    <div class="col-md-10">
                        <div class="row">
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">EMP Code</span> <small id="spanempcode" runat="server" class="ms-3"></small> </div>
                            </div>
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">EMP Name</span> <small id="spanempname" runat="server" class="ms-3"></small> </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">Rec No.</span> <small id="id" runat="server" class="ms-3">101523065714</small> </div>
                            </div>
                            
                        </div>
                        <div class="row">
                           
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">Mode of Pay</span> <small class="ms-3">CASH</small> </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">Designation</span> <small id="spandes" runat="server" class="ms-3"></small> </div>
                            </div>
                            <div class="col-md-6">
                                <div> <span class="fw-bolder">Ac No.</span> <small id="spanaccnum" runat="server" class="ms-3"></small> </div>
                            </div>
                        </div>
                    </div>
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
                            <tr>
                                <th scope="row">Basic</th>
                                <td>16250.00</td>
                               
                            </tr>
                            <tr>
                                <th scope="row">DA</th>
                                <td>550.00</td>
                               
                            </tr>
                            <tr>
                                <th scope="row">HRA</th>
                                <td>1650.00 </td>
                               
                            </tr>
                            <tr>
                                <th scope="row">WA</th>
                                <td>120.00 </td>
                               
                            </tr>
                            <tr>
                                <th scope="row">CA</th>
                                <td>0.00 </td>
                                
                            </tr>
                            <tr>
                                <th scope="row">CCA</th>
                                <td>0.00 </td>
                                <td>SPL. Deduction</td>
                                <td>500.00</td>
                            </tr>
                            <tr>
                                <th scope="row">MA</th>
                                <td>3000.00</td>
                                <td>EWF</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">Sales Incentive</th>
                                <td>0.00</td>
                                <td>CD</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">Leave Encashment</th>
                                <td>0.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Holiday Wages</th>
                                <td>500.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Special Allowance</th>
                                <td>100.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Bonus</th>
                                <td>1400.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Individual Incentive</th>
                                <td>2400.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr class="border-top">
                                <th scope="row">Total Earning</th>
                                <td>25970.00</td>
                                <td>Total Deductions</td>
                                <td>2442.00</td>
                            </tr>
                        </tbody>
                    </table>
                                 </div>
                        <div class="col-md-6">
                    <table class="mt-4 table table-bordered">
                        <thead class="bg-dark text-white">
                            <tr>
                                <th scope="col">Earnings</th>
                                <th scope="col">Amount</th>
                                <th scope="col">Deductions</th>
                                <th scope="col">Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">Basic</th>
                                <td>16250.00</td>
                                <td>PF</td>
                                <td>1800.00</td>
                            </tr>
                            <tr>
                                <th scope="row">DA</th>
                                <td>550.00</td>
                                <td>ESI</td>
                                <td>142.00</td>
                            </tr>
                            <tr>
                                <th scope="row">HRA</th>
                                <td>1650.00 </td>
                                <td>TDS</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">WA</th>
                                <td>120.00 </td>
                                <td>LOP</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">CA</th>
                                <td>0.00 </td>
                                <td>PT</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">CCA</th>
                                <td>0.00 </td>
                                <td>SPL. Deduction</td>
                                <td>500.00</td>
                            </tr>
                            <tr>
                                <th scope="row">MA</th>
                                <td>3000.00</td>
                                <td>EWF</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">Sales Incentive</th>
                                <td>0.00</td>
                                <td>CD</td>
                                <td>0.00</td>
                            </tr>
                            <tr>
                                <th scope="row">Leave Encashment</th>
                                <td>0.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Holiday Wages</th>
                                <td>500.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Special Allowance</th>
                                <td>100.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Bonus</th>
                                <td>1400.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <th scope="row">Individual Incentive</th>
                                <td>2400.00</td>
                                <td colspan="2"></td>
                            </tr>
                            <tr class="border-top">
                                <th scope="row">Total Earning</th>
                                <td>25970.00</td>
                                <td>Total Deductions</td>
                                <td>2442.00</td>
                            </tr>
                        </tbody>
                    </table>
                            </div></div>
                </div>
                <div class="row">
                    <div class="col-md-4"> <br> <span class="fw-bold">Net Pay : 24528.00</span> </div>
                    <div class="border col-md-8">
                        <div class="d-flex flex-column"> <span>In Words</span> <span>Twenty Five thousand nine hundred seventy only</span> </div>
                    </div>
                </div>
                <div class="d-flex justify-content-end">
                    <div class="d-flex flex-column mt-2"> <span class="fw-bolder">For Kalyan Jewellers</span> <span class="mt-4">Authorised Signatory</span> </div>
                </div>
            </div>
        </div>
    </div>



















</body>
</html>
