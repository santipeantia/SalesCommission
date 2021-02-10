<%@ Page Title="" Language="C#" MasterPageFile="~/salecommission.master" AutoEventWireup="true" CodeFile="report-monthly-invoice.aspx.cs" Inherits="report_monthly_invoice" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section class="content-header">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
        <script src="jquery-1.11.2.min.js"></script>
       
        <script>
            function successalert() {
                Swal.fire({
                    type: 'success',
                    title: 'Data has been saved..',
                    text: 'Save data successful..!',
                    footer: 'Please contact system administrator..'
                })
            }

            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0');
            var yyyy = today.getFullYear();
            var tt = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();

            var firstdate = yyyy + '-' + mm + '-01';
            var currentdate3 = yyyy + '-' + mm + '-' + dd;
            
            var datepickertrans = $('#datepickertrans');
            var datepickerend = $('#datepickerend');
            datepickertrans.val(firstdate);
            datepickerend.val(currentdate3);


            //$(function () {

            //    $('#table2').DataTable({
            //        'paging': true,
            //        'iDisplayLength': 50,
            //        'lengthChange': true,
            //        'searching': true,
            //        'ordering': true,
            //        'info': true,
            //        'fixedColumns': true,
            //        'autoWidth': false
            //    })
            //});


            

        </script>

        <script>
            $(document).ready(function () {

                $("#txtPercentProcessFee").on('keyup', function () {
                    
                    var netcom = $('#txtNetCom').val(); // document.getElementById("txtNetCom").value;
                    var txtAmountProcessFee = $('#txtAmountProcessFee').val();
                    var txtGrandCommission = $('#txtGrandCommission').val();

                    var txtPercentProcessFee = $(this).val();

                    var calAmountProcessFee = netcom * (txtPercentProcessFee / 100);
                    var calGrandCommission = netcom - calAmountProcessFee;
                    
                    $('#txtAmountProcessFee').val(parseFloat(calAmountProcessFee).toFixed(2));
                    $('#txtGrandCommission').val(parseFloat(calGrandCommission).toFixed(2));

                    //alert(gc);
                });


                $('#table2 td').hover(function () {
                    rIndex = this.parentElement.rowIndex;
                    cIndex = this.cellIndex;
                    if ((rIndex != 0 & cIndex == 2)) {
                        $(this).css('cursor', 'pointer');
                    }
                });

                var table = $('#table2');
                $('#table2 td').click(function () {

                    rIndex = this.parentElement.rowIndex;
                    cIndex = this.cellIndex;

                    if ((rIndex != 0 & cIndex == 2)) {
                        //alert(rIndex + '' + cIndex);

                        var strVal0 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(0)');
                        var strVal1 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(1)');
                        var strVal2 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(2)');
                        var strVal3 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(3)');
                        var strVal4 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(4)');
                        var strVal5 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(5)');
                        var strVal6 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(6)');
                        var strVal7 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(7)');
                        var strVal8 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(8)');
                        var strVal9 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(9)');
                        var strVal10 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(10)');
                        var strVal11 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(11)');
                        var strVal12 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(12)');
                        var strVal13 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(13)');
                        var strVal14 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(14)');
                        var strVal15 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(15)');
                        var strVal16 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(16)');
                        var strVal17 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(17)');
                        var strVal18 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(18)');
                        var strVal19 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(19)');
                        var strVal20 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(20)');
                        var strVal21 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(21)');
                        var strVal22 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(22)');
                        var strVal23 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(23)');
                        var strVal24 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(24)');
                        var strVal25 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(25)');
                        var strVal26 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(26)');
                        var strVal27 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(27)');
                        var strVal28 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(28)');
                        var strVal29 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(29)');
                        var strVal30 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(30)');
                        var strVal31 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(31)');
                        var strVal32 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(32)');
                        var strVal33 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(33)');
                        var strVal34 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(34)');
                        var strVal35 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(35)');
                        var strVal36 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(36)');
                        var strVal37 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(37)');
                        var strVal38 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(38)');
                        var strVal39 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(39)');

                        //alert(strVal5.text());

                        $('#txtCustCode').val(strVal26.text());
                        $('#txtCustName').val(strVal27.text());
                        //$('#txtContactName').val(strVal2.text());
                        //$('#txtCardID').val(strVal3.text());

                        setTimeout(function () {
                            $("#myModalEdit").modal({ backdrop: false });
                            $("#myModalEdit").modal("show");
                        }, 100);
                    }
                });

            });
        </script>
               

        <h1>Reporting Monthly Invoice
            <small>Control panel</small>
        </h1>

    </section>

    <section class="content">
        <%= strMsgAlert %>

        <%-- Application Forms--%>
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <div class="box-body">

                            <div id="divOption">
                                <div class="user-block">
                                    <img class="img-circle img-bordered-sm" src="../../dist/img/architect_person.png" alt="User Image">
                                    <span class="username">
                                        <a href="#">Reporting Monthly Invoice</a>
                                        <span class="pull-right">
                                            <button type="button" class="btn btn-default btn-sm checkbox-toggle hidden" onclick="openModal()" data-toggle="tooltip" title="New Entry!">
                                                <i class="fa fa-plus"></i>
                                            </button>
                                            <span class="btn-group">
                                                <button id="btnDownload" runat="server"  type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF"><i class="fa fa-download"></i></button>
                                                <button type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF" onclick="window.print()"><i class="fa fa-credit-card"></i></button>
                                                <button id="btnExportExcel" runat="server" type="button" class="btn btn-default btn-sm" onserverclick="btnExportExcel_click" data-toggle="tooltip" title="Print Excel"><i class="fa fa-table"></i></button>
                                            </span>
                                        </span>

                                    </span>
                                    <span class="description">Details for sale commission</span>
                                </div>
                                <br />

                                <div class="row" style="margin-left: 35px;">

                                    <div class="col-md-2">
                                        <label class="txtLabel">From Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickertrans" name="datepickertrans" value="<%= Session["startdate"].ToString() %>" autocomplete="off">
                                            <div class="input-group-addon input-sm">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">End Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickerend" name="datepickerend" value="<%= Session["enddate"].ToString() %>" autocomplete="off">
                                            <div class="input-group-addon input-sm">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">Commission</label>
                                        <div class="txtLabel">
                                            <select id="selectRentCom" name="selectRentCom" class="form-control input-sm" style="width: 100%">
                                                <option value="0" <%= Session["sel0"] %> >ไม่ได้คอมมิชชั่น</option>
                                                <option value="1" <%= Session["sel1"] %> >ได้รับค่าคอมมิชชั่น</option>
                                                <option value="2" <%= Session["sel2"] %> >เลือกข้อมูลทั้งหมด</option>
                                            </select>
                                        </div>
                                    </div>

                                </div>

                                <div class="row" style="margin-left: 35px;">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-2" style="padding-top: 5px">
                                        <button type="button" id="btnGetCommission" name="btnGetCommission" runat="server"  onserverclick="btnGetCommission_click" class="btn btn-primary btn-flat btn-block btn-sm">Click here</button>
                                    </div>
                                </div>
                            </div>


                            <hr />

                            <%--Details of Projects--%>
                            <div id="divProjects">
                                <div class="user-block">
                                    <img class="img-circle img-bordered-sm" src="../../dist/img/blue_box.png" alt="User Image">
                                    <span class="username">
                                        <a href="#">Summary Project</a>

                                    </span>
                                    <span class="description">Details of all projecs</span>
                                </div>
                                <br />
                                <div class="row" style="">
                                   <%-- <asp:Panel ID="pnlContent" runat="server" ScrollBars="Horizontal" Width="100%">--%>
                                        <div class="">
                                            <table id="table2" class="table table-bordered table-striped table-hover table-condensed" style="width: 5000px">
                                                <thead>
                                                    <tr>
                                                        <td>No</td>
                                                        <td>DocuDate</td>
                                                        <td>InvNo</td>
                                                        <td>ProductCode</td>
                                                        <td>Product</td>
                                                        <td>GoodGroupCode</td>
                                                        <td>GoodGroupName</td>
                                                        <td>GoodCode</td>
                                                        <td>Model</td>
                                                        <td>GoodName</td>
                                                        <td>Amount</td>
                                                        <td>RF</td>
                                                        <td>RentAmount</td>
                                                        <td>TotalPrice</td>
                                                        <td>RentCom</td>
                                                        <td>NetCom</td>
                                                        <td>RentOther</td>
                                                        <td>NetPrice</td>
                                                        <td>NetRF_B</td>
                                                        <td>NetRF_P</td>
                                                        <td>NetCutSale</td>
                                                        <td>NetItem</td>
                                                        <td>GoodPattnCode</td>
                                                        <td>GoodPattnName</td>
                                                        <td>GoodColorCode</td>
                                                        <td>GoodColorName</td>
                                                        <td>CustCode</td>
                                                        <td>CustName</td>
                                                        <td>CustTypeCode</td>
                                                        <td>CustTypeName</td>
                                                        <td>sRemark</td>
                                                        <td>GoodClassCode</td>
                                                        <td>GoodClassName</td>
                                                        <td>EmpCode</td>
                                                        <td>SaleName</td>
                                                        <td>Trs_P</td>
                                                        <td>JobsCode</td>
                                                        <td>JobsName</td>
                                                        <td>CustPONo</td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%= strTblDetail %>
                                                </tbody>
                                            </table>
                                        </div>
                                    <%--</asp:Panel>--%>
                                    
                                </div>

                            </div>
                            <hr />

     
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- /.modal myModalEdit -->
        <div class="modal modal-default fade" id="myModalEdit">
            <div class="modal-dialog"  >
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Reporting Monthly Invoice</h4>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="post clearfix">
                                <div class="row" style="margin-bottom: 5px">
                                    <div class="col-md-4 txtLabel">Customer Code</div>
                                    <div class="col-md-8 ">
                                        <input type="text" class="form-control input input-sm txtLabel" id="txtCustCode" name="txtCustCode" autocomplete="off" readonly placeholder="" value="" required>
                                    </div>
                                </div>

                                <div class="row" style="margin-bottom: 5px">
                                    <div class="col-md-4 txtLabel">Customer Name</div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control input input-sm txtLabel" id="txtCustName" name="txtCustName" autocomplete="off" readonly placeholder="" value="" required>
                                    </div>
                                </div>

                                <div class="row" style="margin-bottom: 5px">
                                    <div class="col-md-4 txtLabel">Contact Name</div>
                                    <div class="col-md-8 ">
                                        <input type="text" class="form-control input input-sm txtLabel" id="txtContactName" name="txtContactName" autocomplete="off"  placeholder="" value="" required>
                                    </div>
                                </div>

                                <div class="row" style="margin-bottom: 5px">
                                    <div class="col-md-4 txtLabel">Card ID</div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control input input-sm txtLabel" id="txtCardID" name="txtCardID" autocomplete="off"  placeholder="" value="" required>
                                    </div>
                                </div>
                            </div>
                            <!-- /.post -->
                        </div>
                    </div>

                    <div class="modal-footer clearfix">
                        
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" id="btnSubmitUpdate" onclick="ValidateUpdate()" class="btn btn-primary">Update Changes</button>
                        <button type="button" class="btn btn-primary hidden" id="btnUpdateData" onserverclick="btnUpdateData_click" runat="server">Update Changes</button>
                    </div>
                </div>
            </div>
        </div>


        <script>
            function ValidateUpdate() {

                var str1 = document.getElementById("txtCustCode").value;
                var str2 = document.getElementById("txtCustName").value;
                var str3 = document.getElementById("txtContactName").value;
                var str4 = document.getElementById("txtCardID").value;

                if ((str1 == "") || (str2 == "") || (str3 == "") || (str4 == "") ){
                    alert('ชื่อข้อมูลไม่สามารถเป็นค่าว่างได้โปรดตรวจสอบ...');
                } else {
                    document.getElementById("<%= btnUpdateData.ClientID %>").click();
                }

            }
        </script>


    </section>
</asp:Content>

