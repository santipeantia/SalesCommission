<%@ Page Title="" Language="C#" MasterPageFile="~/salecommission.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
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
        </script>

        <script>
            $(document).ready(function () {
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
                datepickerend.val(currentdate3)

            });
        </script>
               

        <h1>Sale Commission
            <small>Control panel</small>
        </h1>

    </section>

    <section class="content">
       
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
                                        <a href="#">Sale Commission</a>
                                        <span class="pull-right">
                                            <button type="button" class="btn btn-default btn-sm checkbox-toggle hidden" onclick="openModal()" data-toggle="tooltip" title="New Entry!">
                                                <i class="fa fa-plus"></i>
                                            </button>
                                            <span class="btn-group">
                                                <button id="btnDownload" runat="server"  type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF"><i class="fa fa-download"></i></button>
                                                <button type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF" onclick="window.print()"><i class="fa fa-credit-card"></i></button>
                                                <button id="btnExportExcel" runat="server" type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print Excel"><i class="fa fa-table"></i></button>
                                            </span>
                                        </span>

                                    </span>
                                    <span class="description">Details for weekly report</span>
                                </div>
                                <br />

                                <div class="row" style="margin-left: 35px;">

                                    <div class="col-md-2">
                                        <label class="txtLabel">From Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickertrans" name="datepickertrans" value="" autocomplete="off">
                                            <div class="input-group-addon input-sm">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">End Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickerend" name="datepickerend" value="" autocomplete="off">
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
                                    <div class="">
                                        <table id="tableProject" class="table table-bordered table-striped table-hover table-condensed" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <td>No</td>
                                                    <td>Year</td>
                                                    <td>Month</td>
                                                    <td>ProjectID</td>
                                                    <td>ProjectName</td>
                                                    <td class="hidden">CompanyID</td>
                                                    <td>CompanyName</td>
                                                    <td class="hidden">Architect</td>
                                                    <td class="hidden">Name</td>
                                                    <td>Location</td>
                                                    <td>ProdType</td>
                                                    <td>Status</td>
                                                    <td>Delivery</td>
                                                    <td>Quantity</td>
                                                    <td>LastUpdate</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                               
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                            </div>
                            <hr />

     
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>

