<%@ Page Title="" Language="C#" MasterPageFile="~/salecommission.master" AutoEventWireup="true" CodeFile="accounting-update.aspx.cs" Inherits="accounting_update" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <!-- Header content -->
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

                //$("input[name=txtPercentProcessFee]").change(function(){
                //    var gsum = 0;
                //    alert('change' + gsum);
                //});

               

                //$('#txtPercentProcessFee').keyup(function () {

                //   alert('change 555 ..');

                //});


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
                                            if ((rIndex != 0 & cIndex == 5) || (rIndex != 0 & cIndex == 35)) {
                                                $(this).css('cursor', 'pointer');
                                            }
                });

                var table = $('#table2');
                $('#table2 td').click(function () {

                    rIndex = this.parentElement.rowIndex;
                    cIndex = this.cellIndex;

                    if ((rIndex != 0 & cIndex == 5) || (rIndex != 0 & cIndex == 35)) {
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
                        var strVal24 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(24)'); // ContactName

                        var strVal25 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(25)'); // RecpName
                        var strVal26 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(26)');
                        var strVal27 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(27)');
                        var strVal28 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(28)');
                        var strVal29 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(29)');
                        var strVal30 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(30)');
                        var strVal31 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(31)');
                        var strVal32 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(32)'); // txtGrandCommission

                        var strVal33 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(33)'); // gVat  0.05
                        var strVal34 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(34)'); // gwVat

                        var strVal35 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(35)');
                        var strVal36 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(36)');
                        var strVal37 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(37)');
                        var strVal38 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(38)');
                        var strVal39 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(39)');
                        var strVal40 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(40)');
                        var strVal41 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(41)');
                        var strVal42 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(42)');
                        var strVal43 = $("#table2").find('tr:eq(' + rIndex + ')').find('td:eq(43)');

                        //alert(strVal5.text());

                        $('#txtID').val(strVal0.text());
                        $('#txtBrchID').val(strVal1.text());
                        $('#txtDocuDate').val(strVal2.text());
                        $('#txtInvNo').val(strVal3.text());
                        $('#txtCustID').val(strVal4.text());
                        $('#txtCustName').val(strVal5.text());
                        $('#txtProductCode').val(strVal6.text());
                        $('#txtGoodGroupName').val(strVal7.text());
                        $('#txtGoodCode').val(strVal8.text());
                        $('#txtGoodName1').val(strVal9.text());
                        $('#txtAmount').val(strVal10.text());
                        $('#txtRF').val(strVal11.text());
                        $('#txtRentAmount').val(strVal12.text());
                        $('#txtTotalPrice').val(strVal13.text());
                        $('#txtRentCom').val(strVal14.text());
                        $('#txtRentOther').val(strVal15.text());
                        $('#txtNetCom').val(strVal16.text());
                        $('#txtNetPrice').val(strVal17.text());
                        $('#txtNetRF_B').val(strVal18.text());
                        $('#txtNetRF_P').val(strVal19.text());
                        $('#txtNetCutSale').val(strVal20.text());
                        $('#txtTotalCutSale').val(strVal21.text());
                        $('#txtSaleName').val(strVal22.text());
                        $('#txtProject').val(strVal23.text());
                       
                        $('#txtRecpName').val(strVal25.text()); // RecpName
                        $('#txtContactName').val(strVal24.text());  //ContactName

                        $('#txtCardID').val(strVal26.text());
                        $('#txtCheqDate').val(strVal27.text());
                        $('#txtDocuNo').val(strVal28.text());
                        $('#datearDocuDate').val(strVal29.text());
                        $('#txtPercentProcessFee').val(strVal30.text());
                        $('#txtAmountProcessFee').val(strVal31.text());
                        $('#txtGrandCommission').val(strVal32.text());

                        var isPaid
                        if (strVal35.text() == "ชำระแล้ว") {
                            isPaid = "1";
                        }else if (strVal35.text() == "แบ่งชำระบางส่วน") {
                            isPaid = "2";
                        }else if (strVal35.text() == "รอทำจ่ายเช็ค") {
                            isPaid = "3";
                        } else {
                            isPaid = "0";
                        }

                        $('#selectisPaid').val(isPaid);
                        $('#selectisPaid').change();

                        $('#dateDatePaid').val(strVal36.text());
                        $('#txtisRemark').val(strVal37.text());

                        $('#txtisRemarkAcc').val(strVal43.text());

                        $('#txtContactName2').val(strVal38.text());
                        $('#txtCardID2').val(strVal39.text());
                        $('#txtContactName3').val(strVal40.text());
                        $('#txtCardID3').val(strVal41.text());

                        $('#selectisPaidType').val(strVal42.text());
                        $('#selectisPaidType').change();

                        setTimeout(function () {
                            $("#myModalEdit").modal({ backdrop: false });
                            $("#myModalEdit").modal("show");
                        }, 100);

                        

                    }
                });

            });
        </script>
               

        <h1>Sale Commission [Accounting]
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
                                        <a href="#">Sale Commission[Accounting]</a>
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
                                </div>

                                <div class="row" style="margin-left: 35px;">
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
                                            <table id="table2" class="table table-bordered table-striped table-hover table-condensed" style="width: 4000px">
                                                <thead>
                                                    <tr>
                                                        <td class="hidden">ID</td>
                                                        <td class="hidden">BrchID</td>
                                                        <td>Date</td>
                                                        <td>InvNo</td>
                                                        <td class="hidden">CustID</td>
                                                        <td>Customer</td>
                                                        <td class="hidden">ProductCode</td>
                                                        <td>ProductGroup</td>
                                                        <td class="hidden">GoodCode</td>
                                                        <td>Model</td>
                                                        <td>ปริมาณ</td>
                                                        <td>ราคา RF</td>
                                                        <td>ราคาขาย</td>
                                                        <td>รวมเงิน</td>
                                                        <td>ค่าคอม</td>
                                                        <td>Entertain</td>
                                                        <td>รวมค่าคอม</td>
                                                        <td>ราคาขายสุทธิ</td>
                                                        <td>RF สุทธิ</td>
                                                        <td>RF(%)</td>
                                                        <td>หักยอดขาย</td>
                                                        <td>ยอดคงเหลือ</td>
                                                        <td>พนักงานขาย</td>
                                                        <td>โครงการ</td>
                                                         <td>ชื่อผู้รับเช็ค</td>
                                                        <td>ชื่อหัก ณ ที่จ่าย</td>
                                                       
                                                        <td>บัตรประชาชน</td>
                                                        <td>ส่งทำเช็ค</td>
                                                        <td>เลขที่ใบรับ</td>
                                                        <td>วันที่รับชำระ</td>
                                                        <td>ค่าคอมฯ</td>
                                                        <td>ค่าดำเนินการ</td>
                                                        <td>ค่าคอมสุทธิ</td>

                                                        <td>หัก5%</td>
                                                        <td>หัก5%สุทธิ</td>

                                                        <td>สถานะ</td>
                                                        <td>วันที่จ่าย</td>
                                                        <td>อื่นๆ</td>
                                                        <td class="hidden">ชื่อลูกค้า2</td>
                                                        <td class="hidden">บัตรประชาชน2</td>
                                                        <td class="hidden">ชื่อลูกค้า2</td>
                                                        <td class="hidden">บัตรประชาชน3</td>
                                                        <td class="hidden">การชำระเงิน</td>
                                                        <td class="">อื่นๆ(Acc)</td>
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
            <div class="modal-dialog"  style="width: 60%">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Sale Commission [Accounting]</h4>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">

                             <!-- Post -->
                                        <div class="post clearfix">
                                            <div class="row hidden" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ID</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtID" name="txtID" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">BrchID</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtBrchID" name="txtBrchID" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">DocuDate</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtDocuDate" name="txtDocuDate" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">InvNo</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtInvNo" name="txtInvNo" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel hidden">CustID</div>
                                                <div class="col-md-2 hidden">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCustID" name="txtCustID" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">Customer Name</div>
                                                <div class="col-md-10">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCustName" name="txtCustName" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel hidden">ProductCode</div>
                                                <div class="col-md-4 hidden">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtProductCode" name="txtProductCode" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">Product Group</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtGoodGroupName" name="txtGoodGroupName" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel hidden">GoodCode</div>
                                                <div class="col-md-4 hidden">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtGoodCode" name="txtGoodCode" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">Model</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtGoodName1" name="txtGoodName1" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ปริมาณ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtAmount" name="txtAmount" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">ราคา RF</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtRF" name="txtRF" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>  
                                                
                                                 <div class="col-md-2 txtLabel">ราคาขาย</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtRentAmount" name="txtRentAmount" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">รวมเงิน</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtTotalPrice" name="txtTotalPrice" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">ค่าคอม/หน่วย</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtRentCom" name="txtRentCom" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">ค่า Entertain</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtRentOther" name="txtRentOther" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">รวมค่าคอม(บาท)</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtNetCom" name="txtNetCom" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">ราคาขายสุทธิ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtNetPrice" name="txtNetPrice" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">RF สุทธิ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtNetRF_B" name="txtNetRF_B" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">RF(%)</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtNetRF_P" name="txtNetRF_P" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">หักยอดขาย</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtNetCutSale" name="txtNetCutSale" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">ยอดคงเหลือ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtTotalCutSale" name="txtTotalCutSale" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">พนักงานขาย</div>
                                                <div class="col-md-10">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtSaleName" name="txtSaleName" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                             <div class="row" style="margin-bottom: 5px">                                                                                      
                                                <div class="col-md-2 txtLabel">โครงการ</div>
                                                <div class="col-md-10">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtProject" name="txtProject" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ชื่อผู้รับเช็ค</div>
                                                <div class="col-md-4">
                                                    
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtContactName" name="txtContactName" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>

                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ชื่อผู้หัก ณ ที่จ่าย</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtRecpName" name="txtRecpName" autocomplete="off" readonly  placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">บัตรประชาชน(1)</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCardID" name="txtCardID" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ชื่อลูกค้า(2)</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtContactName2" name="txtContactName2" autocomplete="off" readonly  placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">บัตรประชาชน(2)</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCardID2" name="txtCardID2" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ชื่อลูกค้า(3)</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtContactName3" name="txtContactName3" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">บัตรประชาชน(3)</div>
                                                <div class="col-md-4">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCardID3" name="txtCardID3" autocomplete="off" readonly  placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">ส่งทำเช็ค(เดือน)</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtCheqDate" name="txtCheqDate" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                            
                                                <div class="col-md-2 txtLabel">วันที่รับชำระ</div>
                                                <div class="col-md-2"> 
                                                    <div class="input-group date">
                                                        <input type="text" class="form-control input-sm pull-left txtLabel" id="datearDocuDate" name="datearDocuDate" readonly autocomplete="off">
                                                        <div class="input-group-addon input-sm">
                                                            <i class="fa fa-calendar"></i>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-2 txtLabel">เลขที่รับชำระหนี้</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtDocuNo" name="txtDocuNo" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">                              
                                                <div class="col-md-2 txtLabel">หักค่าดำเนินการ(%)</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtPercentProcessFee" name="txtPercentProcessFee" autocomplete="off" readonly  placeholder="" value="" required>
                                                </div>

                                                <div class="col-md-2 txtLabel">หักค่าดำเนินการ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtAmountProcessFee" name="txtAmountProcessFee" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                                                                                
                                                <div class="col-md-2 txtLabel">คอมมิชชั่นสุทธิ</div>
                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input input-sm txtLabel" id="txtGrandCommission" name="txtGrandCommission" autocomplete="off" readonly placeholder="" value="" required>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">                                              
                                                                                                
                                                <div class="col-md-2 txtLabel">วันที่จ่าย</div>
                                                <div class="col-md-2">
                                                    <div class="input-group date">
                                                        <input type="text" class="form-control input-sm pull-left txtLabel" id="dateDatePaid" name="dateDatePaid" autocomplete="off">
                                                        <div class="input-group-addon input-sm">
                                                            <i class="fa fa-calendar"></i>
                                                        </div>
                                                    </div>                                                    
                                                </div>

                                                 <div class="col-md-2 txtLabel">สถานะ/ประเภทชำระเงิน</div>
                                                <div class="col-md-2">
                                                    <%--<input type="text" class="form-control input input-sm txtLabel" id="txtisPaid" name="txtisPaid" autocomplete="off"  placeholder="" value="" required>--%>
                                                    <div class="txtLabel">
                                                        <select id="selectisPaid" name="selectisPaid" class="form-control input-sm" style="width: 100%">
                                                            <option value="3">รอทำจ่ายเช็ค</option>
                                                            <option value="0">ยังไม่จ่าย</option>
                                                            <option value="1">ชำระแล้ว</option>   
                                                            <option value="2">แบ่งชำระบางส่วน</option>
                                                        </select>
                                                    </div>
                                                </div>

                                               <%-- <div class="col-md-2 txtLabel">ประเภทการชำระ</div>--%>
                                                <div class="col-md-2">
                                                    <%--<input type="text" class="form-control input input-sm txtLabel" id="txtisPaid" name="txtisPaid" autocomplete="off"  placeholder="" value="" required>--%>
                                                    <div class="txtLabel">
                                                        <select id="selectisPaidType" name="selectisPaidType" class="form-control input-sm" style="width: 100%">
                                                            <option value="0">เงินสด</option>
                                                            <option value="1">เช็คสั่งจ่าย</option>                                                            
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <input type="text" class="form-control input-sm pull-left txtLabel" id="txtpayamount" name="txtpayamount" autocomplete="off">
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">หมายเหตุ</div>
                                                <div class="col-md-10">
                                                    <textarea cols="40" rows="2" id="txtisRemark" name="txtisRemark" readonly class="form-control input input-sm txtLabel"></textarea>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px">
                                                <div class="col-md-2 txtLabel">หมายเหตุ(Acc)</div>
                                                <div class="col-md-10">
                                                    <textarea cols="40" rows="2" id="txtisRemarkAcc" name="txtisRemarkAcc" class="form-control input input-sm txtLabel"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.post -->


                                                        
                        </div>
                    </div>

                    <div class="modal-footer clearfix">
                        <span class="pull-left">
                            <button type="button" id="btnDelete" onserverclick="btnDelete_click" runat="server" class="btn btn-danger hidden" >Delete</button>
                        </span>

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" id="btnSubmitUpdate" onclick="ValidateUpdate()" class="btn btn-primary">Update Changes</button>
                        <button type="button" class="btn btn-primary hidden" id="btnUpdateData" onserverclick="btnUpdateData_click" runat="server">Update Changes</button>
                    </div>
                </div>
            </div>
        </div>

        <script>
            function ValidateUpdate() {

                var str1 = document.getElementById("txtProject").value;
                var str2 = document.getElementById("txtContactName").value;
                var str3 = document.getElementById("txtCardID").value;

                if (str1 == "") {
                    alert('ชื่อข้อมูลโครงการไม่สามารถเป็นค่าว่างได้โปรดตรวจสอบ...');
                } else {
                    document.getElementById("<%= btnUpdateData.ClientID %>").click();
                }

            }
        </script>


    </section>
</asp:Content>

