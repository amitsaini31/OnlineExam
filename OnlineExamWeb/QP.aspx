<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QP.aspx.cs" Inherits="OnlineExamWeb.QP" ValidateRequest="false" %>

<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/images/favicon.png">
    <title>Adminmart Template - The Ultimate Multipurpose admin template</title>
    <!-- Custom CSS -->
    <link href="../dist/css/style.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
    <style>
        .action {
            margin-right: 5px;
        }

        .edit {
            color: #35af43;
        }

        .delete {
            color: #e01212ed;
        }

        .publish {
            color: blue;
        }
    </style>
</head>

<body>
    <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <div class="preloader">
        <div class="lds-ripple">
            <div class="lds-pos"></div>
            <div class="lds-pos"></div>
        </div>
    </div>
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper" data-theme="light" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full" data-sidebar-position="fixed" data-header-position="fixed" data-boxed-layout="full">
        <!-- ============================================================== -->
        <!-- Topbar header - style you can find in pages.scss -->
        <!-- ============================================================== -->
        <header class="topbar" data-navbarbg="skin6">
            <nav class="navbar top-navbar navbar-expand-md">
                <div class="navbar-header" data-logobg="skin6">
                    <!-- This is for the sidebar toggle which is visible on mobile only -->
                    <a class="nav-toggler waves-effect waves-light d-block d-md-none" href="javascript:void(0)"><i
                        class="ti-menu ti-close"></i></a>
                    <!-- ============================================================== -->
                    <!-- Logo -->
                    <!-- ============================================================== -->
                    <div class="navbar-brand">
                        <!-- Logo icon -->
                        <a href="index.html">
                            <b class="logo-icon">
                                <!-- Dark Logo icon -->
                                <img src="../assets/images/logo-icon.png" alt="homepage" class="dark-logo" />
                                <!-- Light Logo icon -->
                                <img src="../assets/images/logo-icon.png" alt="homepage" class="light-logo" />
                            </b>
                            <!--End Logo icon -->
                            <!-- Logo text -->
                            <span class="logo-text">
                                <!-- dark Logo text -->
                                <img src="../assets/images/logo-text.png" alt="homepage" class="dark-logo" />
                                <!-- Light Logo text -->
                                <img src="../assets/images/logo-light-text.png" class="light-logo" alt="homepage" />
                            </span>
                        </a>
                    </div>
                    <!-- ============================================================== -->
                    <!-- End Logo -->
                    <!-- ============================================================== -->
                    <!-- ============================================================== -->
                    <!-- Toggle which is visible on mobile only -->
                    <!-- ============================================================== -->
                    <a class="topbartoggler d-block d-md-none waves-effect waves-light" href="javascript:void(0)"
                        data-toggle="collapse" data-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><i
                            class="ti-more"></i></a>
                </div>
                <!-- ============================================================== -->
                <!-- End Logo -->
                <!-- ============================================================== -->
                <div class="navbar-collapse collapse" id="navbarSupportedContent">
                    <!-- ============================================================== -->
                    <!-- toggle and nav items -->
                    <!-- ============================================================== -->
                    <ul class="navbar-nav float-left mr-auto ml-3 pl-1">
                        <!-- Notification -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle pl-md-3 position-relative" href="javascript:void(0)"
                                id="bell" role="button" data-toggle="dropdown" aria-haspopup="true"
                                aria-expanded="false">
                                <span><i data-feather="bell" class="svg-icon"></i></span>
                                <span class="badge badge-primary notify-no rounded-circle">5</span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-left mailbox animated bounceInDown">
                                <ul class="list-style-none">
                                    <li>
                                        <div class="message-center notifications position-relative">
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                                class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <div class="btn btn-danger rounded-circle btn-circle">
                                                    <i
                                                        data-feather="airplay" class="text-white"></i>
                                                </div>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Luanch Admin</h6>
                                                    <span class="font-12 text-nowrap d-block text-muted">Just see
                                                        the my new
                                                        admin!</span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:30 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                                class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-success text-white rounded-circle btn-circle"><i
                                                    data-feather="calendar" class="text-white"></i></span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Event today</h6>
                                                    <span
                                                        class="font-12 text-nowrap d-block text-muted text-truncate">Just
                                                        a reminder that you have event</span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:10 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                                class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-info rounded-circle btn-circle"><i
                                                    data-feather="settings" class="text-white"></i></span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Settings</h6>
                                                    <span
                                                        class="font-12 text-nowrap d-block text-muted text-truncate">You
                                                        can customize this template
                                                        as you want</span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:08 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                                class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-primary rounded-circle btn-circle"><i
                                                    data-feather="box" class="text-white"></i></span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Pavan kumar</h6>
                                                    <span
                                                        class="font-12 text-nowrap d-block text-muted">Just
                                                        see the my admin!</span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:02 AM</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <a class="nav-link pt-3 text-center text-dark" href="javascript:void(0);">
                                            <strong>Check all notifications</strong>
                                            <i class="fa fa-angle-right"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <!-- End Notification -->
                        <!-- ============================================================== -->
                        <!-- create new -->
                        <!-- ============================================================== -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i data-feather="settings" class="svg-icon"></i>
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Something else here</a>
                            </div>
                        </li>
                        <%--<li class="nav-item d-none d-md-block">
                            <a class="nav-link" href="javascript:void(0)">
                                <div class="customize-input">
                                    <select
                                        class="custom-select form-control bg-white custom-radius custom-shadow border-0">
                                        <option selected>EN</option>
                                        <option value="1">AB</option>
                                        <option value="2">AK</option>
                                        <option value="3">BE</option>
                                    </select>
                                </div>
                            </a>
                        </li>--%>
                    </ul>
                    <!-- ============================================================== -->
                    <!-- Right side toggle and nav items -->
                    <!-- ============================================================== -->
                    <ul class="navbar-nav float-right">
                        <!-- ============================================================== -->
                        <!-- Search -->
                        <!-- ============================================================== -->
                        <%-- <li class="nav-item d-none d-md-block">
                            <a class="nav-link" href="javascript:void(0)">
                                <form>
                                    <div class="customize-input">
                                        <input class="form-control custom-shadow custom-radius border-0 bg-white"
                                            type="search" placeholder="Search" aria-label="Search">
                                        <i class="form-control-icon" data-feather="search"></i>
                                    </div>
                                </form>
                            </a>
                        </li>--%>
                        <!-- ============================================================== -->
                        <!-- User profile and search -->
                        <!-- ============================================================== -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="javascript:void(0)" data-toggle="dropdown"
                                aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/images/users/profile-pic.jpg" alt="user" class="rounded-circle"
                                    width="40">
                                <span class="ml-2 d-none d-lg-inline-block"><span>Hello,</span> <span
                                    class="text-dark">Jason Doe</span> <i data-feather="chevron-down"
                                        class="svg-icon"></i></span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right user-dd animated flipInY">
                                <a class="dropdown-item" href="javascript:void(0)"><i data-feather="user"
                                    class="svg-icon mr-2 ml-1"></i>
                                    My Profile</a>
                                <a class="dropdown-item" href="javascript:void(0)"><i data-feather="credit-card"
                                    class="svg-icon mr-2 ml-1"></i>
                                    My Balance</a>
                                <a class="dropdown-item" href="javascript:void(0)"><i data-feather="mail"
                                    class="svg-icon mr-2 ml-1"></i>
                                    Inbox</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="javascript:void(0)"><i data-feather="settings"
                                    class="svg-icon mr-2 ml-1"></i>
                                    Account Setting</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="Logout.aspx"><i data-feather="power"
                                    class="svg-icon mr-2 ml-1"></i>
                                    Logout</a>
                                <div class="dropdown-divider"></div>
                                <div class="pl-4 p-3">
                                    <a href="javascript:void(0)" class="btn btn-sm btn-info">View
                                        Profile</a>
                                </div>
                            </div>
                        </li>
                        <!-- ============================================================== -->
                        <!-- User profile and search -->
                        <!-- ============================================================== -->
                    </ul>
                </div>
            </nav>
        </header>
        <!-- ============================================================== -->
        <!-- End Topbar header -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        <aside class="left-sidebar" data-sidebarbg="skin6">
            <!-- Sidebar scroll-->
            <div class="scroll-sidebar" data-sidebarbg="skin6">
                <!-- Sidebar navigation-->
                <nav class="sidebar-nav">
                    <ul id="sidebarnav">
                        <li class="sidebar-item"><a class="sidebar-link sidebar-link " href="InstitutionHome.aspx"
                            aria-expanded="false"><i data-feather="home" class="feather-icon"></i><span
                                class="hide-menu">Dashboard</span></a></li>
                        <li class="list-divider"></li>
                        <li class="nav-small-cap"><span class="hide-menu">Menu</span></li>
                        <li class="sidebar-item "><a class="sidebar-link sidebar-link " href="UserBatch.aspx"
                            aria-expanded="false"><i data-feather="database" class="feather-icon"></i><span
                                class="hide-menu">Batches
                                </span></a>
                        </li>
                        <li class="sidebar-item"><a class="sidebar-link sidebar-link " href="UserBatchMap.aspx"
                            aria-expanded="false"><i data-feather="database" class="feather-icon"></i><span
                                class="hide-menu">User Batch Mapping
                                </span></a>
                        </li>
                        <li class="sidebar-item selected"><a class="sidebar-link sidebar-link active" href="QP.aspx"
                            aria-expanded="false"><i data-feather="database" class="feather-icon"></i><span
                                class="hide-menu">Question Paper
                                </span></a>
                        </li>
                        <%-- <li class="sidebar-item"><a class="sidebar-link sidebar-link " href="QuestionPaper.aspx"
                            aria-expanded="false"><i data-feather="database" class="feather-icon"></i><span
                                class="hide-menu">Question Paper Old
                                </span></a>
                        </li>--%>
                        <li class="sidebar-item"><a class="sidebar-link sidebar-link" href="UserQuestion.aspx"
                            aria-expanded="false"><i data-feather="database" class="feather-icon"></i><span
                                class="hide-menu">Question
                                </span></a>
                        </li>
                        <li class="list-divider"></li>
                        <li class="nav-small-cap"><span class="hide-menu">Extra</span></li>
                        <li class="sidebar-item"><a class="sidebar-link sidebar-link" href="../../docs/docs.html"
                            aria-expanded="false"><i data-feather="edit-3" class="feather-icon"></i><span
                                class="hide-menu">Help</span></a></li>
                        <li class="sidebar-item"><a class="sidebar-link sidebar-link" href="Logout.aspx"
                            aria-expanded="false"><i data-feather="log-out" class="feather-icon"></i><span
                                class="hide-menu">Logout</span></a></li>
                    </ul>
                </nav>
                <!-- End Sidebar navigation -->
            </div>
            <!-- End Sidebar scroll-->
        </aside>
        <!-- ============================================================== -->
        <!-- End Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Page wrapper  -->
        <!-- ============================================================== -->
        <div class="page-wrapper">
            <!-- ============================================================== -->
            <!-- Bread crumb and right sidebar toggle -->
            <!-- ============================================================== -->
            <div class="page-breadcrumb">
                <div class="row">
                    <div class="col-7 align-self-center">
                        <h3 class="page-title text-truncate text-dark font-weight-medium mb-1">Batch</h3>
                        <%-- <div class="d-flex align-items-center">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb m-0 p-0">
                                    <li class="breadcrumb-item"><a href="index.html" class="text-muted">Home</a></li>
                                    <li class="breadcrumb-item text-muted active" aria-current="page">Library</li>
                                </ol>
                            </nav>
                        </div>--%>
                    </div>
                    <%-- <div class="col-5 align-self-center">
                        <div class="customize-input float-right">
                            <select class="custom-select custom-select-set form-control bg-white border-0 custom-shadow custom-radius">
                                <option selected>Aug 19</option>
                                <option value="1">July 19</option>
                                <option value="2">Jun 19</option>
                            </select>
                        </div>
                    </div>--%>
                </div>
            </div>
            <!-- ============================================================== -->
            <!-- End Bread crumb and right sidebar toggle -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- Container fluid  -->
            <!-- ============================================================== -->

            <form id="id" runat="server">

                <div class="container-fluid">
                    <!-- ============================================================== -->
                    <!-- Start Page Content -->
                    <!-- ============================================================== -->
                    <div class="row" id="dvAdd" runat="server">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">Add User Batch</h4>
                                    <h6 class="card-subtitle">Add new batch of users.</h6>

                                    <div class="form-actions" style="margin-bottom: 10px;">
                                        <div class="text-right">
                                            <button type="submit" class="btn btn-info" runat="server" onserverclick="btnSubmit_Click">Submit</button>
                                            <button type="reset" class="btn btn-dark" runat="server" onserverclick="Page_Load">Cancel</button>
                                        </div>
                                    </div>

                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">Question Paper Code</label>
                                                <div class="col-lg-10">
                                                    <h3>
                                                        <asp:Label ID="lblQuestionPaperCode" Text="" runat="server" Visible="false" /></h3>
                                                    <asp:TextBox ID="txtQuestionPaperCode" runat="server" placeholder="Question Paper Code" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">Title</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Title" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">Hidden Title</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox ID="txtHiddenTitle" runat="server" placeholder="Hidden Title" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">Question Count</label>
                                                <div class="col-lg-10">
                                                    <h3>
                                                        <asp:Label Text="0" runat="server" ID="txtQuestionCount"></asp:Label></h3>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">Category</label>
                                                <div class="col-lg-10">
                                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <label class="col-lg-2">General Instructions</label>
                                                <div class="col-lg-10">
                                                    <textarea name="txtGeneralInstructions" id="txtGeneralInstructions" rows="10" cols="80" runat="server" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-actions">
                                        <div class="text-right">
                                            <button type="submit" class="btn btn-info" runat="server" onserverclick="btnSubmit_Click">Submit</button>
                                            <button type="reset" class="btn btn-dark" runat="server" onserverclick="Page_Load">Cancel</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="dvView" runat="server">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">View QuestionPaper</h4>
                                    <h6 class="card-subtitle">Question Papers posted by You.</h6>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="form-actions">
                                                <div class="text-left">
                                                    <asp:Button ID="btnAdd" class="btn btn-info" runat="server" Text="Add New Question Paper" OnClick="btnAdd_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <h3 class="card-title text-center" id="lblNoRecords">No Record(s) Found.</h3>
                                    </div>
                                </div>

                                <div class="table-responsive" id="tblView">
                                    <table class="table table-hover">
                                        <thead class="thead-light">
                                            <tr>
                                                <th scope="col">Code</th>
                                                <th scope="col">Title</th>
                                                <th scope="col">Question Count</th>
                                                <%--<th scope="col" style="width: 20%;">Actions</th>--%>
                                            </tr>
                                        </thead>
                                        <tbody id="tbody">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <input type="hidden" id="hdnapi" runat="server" />
                    <input type="hidden" id="hdnid" runat="server" value="0" />
                    <input type="hidden" id="hdnu" runat="server" />
                </div>
            </form>
            <!-- Modal Dialog-->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog modal-dialog-centered modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="mdltitle"></h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <input type="hidden" id="trid" />
                            <div class="text-center" id="mdladdquestions">
                            </div>

                            <div class="text-center" id="mdledit">
                            </div>
                            <hr>
                            <div class="text-center" id="mdldelete">
                            </div>
                            <hr>
                            <div class="text-center" id="mdlpublish">
                            </div>
                            <hr>
                            <div class="text-center" id="mdlpublic">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- ============================================================== -->
            <!-- End PAge Content -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- Right sidebar -->
            <!-- ============================================================== -->
            <!-- .right-sidebar -->
            <!-- ============================================================== -->
            <!-- End Right sidebar -->
            <!-- ============================================================== -->
        </div>
        <!-- ============================================================== -->
        <!-- End Container fluid  -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- footer -->
        <!-- ============================================================== -->
        <footer class="footer text-center text-muted">
            All Rights Reserved by Adminmart. Designed and Developed by <a
                href="https://wrappixel.com">WrapPixel</a>.
           
        </footer>
        <!-- ============================================================== -->
        <!-- End footer -->
        <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- End Page wrapper  -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- All Jquery -->
    <!-- ============================================================== -->
    <script src="../assets/libs/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="../assets/libs/popper.js/dist/umd/popper.min.js"></script>
    <script src="../assets/libs/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- apps -->
    <!-- apps -->
    <script src="../dist/js/app-style-switcher.js"></script>
    <script src="../dist/js/feather.min.js"></script>
    <!-- slimscrollbar scrollbar JavaScript -->
    <script src="../assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js"></script>
    <script src="../assets/extra-libs/sparkline/sparkline.js"></script>
    <!--Wave Effects -->
    <!-- themejs -->
    <!--Menu sidebar -->
    <script src="../dist/js/sidebarmenu.js"></script>
    <!--Custom JavaScript -->
    <script src="../dist/js/custom.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.5.1/standard/ckeditor.js"></script>
    <script>
        $(document).ready(function () {
            Initialload();
            CKEDITOR.editorConfig = function (config) {
                config.language = 'en';
                config.uiColor = '#F7B42C';
                config.height = 300;
                config.toolbarCanCollapse = true;

            };
            CKEDITOR.replace('txtGeneralInstructions');

        });

        function Initialload() {
            $.ajax({
                type: "GET",
                url: $("#hdnapi").val() + "/" + $("#hdnu").val() + "/getquestionpaper",
                //data: '{"productid" : "0"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnInitialLoadSuccess,
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }

        function OnInitialLoadSuccess(response) {
            var obj = jQuery.parseJSON(response);
            //var Title = obj.Table.length;
            $("#lblNoRecords").show();
            var str = "";
            for (var i = 0; i < obj.Table.length; i++) {
                $("#lblNoRecords").hide();
                var item = obj.Table[i];
                //str = str + "<tr data-id='" + item.QuestionPaperCode + "'><td>" + item.QuestionPaperCode + "</td><td>"
                //    + item.Title + "</td><td>" + item.QuestionCount +
                //    "</td><td><a href='Q.aspx?code=" + item.QuestionPaperCode +
                //    "' ><i class='fas fa-plus-circle action edit' ></i></a><a href='QP.aspx?ecode="
                //    + item.QuestionPaperCode + "' ><i class='fas fa-edit action edit' ></i></a><a href='QP.aspx?dcode="
                //    + item.QuestionPaperCode + "' data-original-title='Delete'><i class='fas fa-trash action delete'></i></a><a href='QP.aspx?pcode="
                //    + item.QuestionPaperCode + "' data-original-title='Delete'><i class='fas fa-globe action publish'></i></a><a href='QP.aspx?pubcode="
                //    + item.QuestionPaperCode + "' data-original-title='Display To Public'><i class='fas fa-eye action public'></i></a></td></tr>";
                str = str + "<tr data-id='" + item.QuestionPaperCode + "'><td>" + item.QuestionPaperCode + "</td><td>"
                    + item.Title + "</td><td>" + item.QuestionCount +
                    "</td></tr>";
            }
            $("#tbody").html(str);
            $('tr').click(function () {
                $("#myModal").modal("show");
                $("#trid").val($(this).attr('data-id'));
                $("#mdltitle").html("Code : "
                    + $(this).attr('data-id'));
                $("#mdladdquestions").html("<a class='btn btn-primary' href='Q.aspx?code="
                    + $(this).attr('data-id') + "'>Add Questions</a> <hr>");
                $("#mdledit").html("<a class='btn btn-primary' href='QP.aspx?ecode="
                    + $(this).attr('data-id') + "'>Edit</a> ");

                $("#mdldelete").html("<a class='btn btn-primary' href='QP.aspx?dcode="
                    + $(this).attr('data-id') + "'>Delete</a> ");

                $("#mdlpublish").html("<a class='btn btn-primary' href='QP.aspx?pcode="
                    + $(this).attr('data-id') + "'>Publish</a> ");

                $("#mdlpublic").html("<a class='btn btn-primary' href='QP.aspx?pubcode="
                    + $(this).attr('data-id') + "'>Make Public</a> ");

                //$("#txtlname").val($(this).closest('tr').children()[1].textContent);
            });
        }



        function deletequestionpaper(code) {
            if (confirm("Want to delete " + code + "?")) {
                $.ajax({
                    type: "GET",
                    url: $("#hdnapi").val() + code + "/" + $("#hdnu").val() + "/deletequestionpaper",
                    //data: '{"productid" : "0"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        //alert('Question' + $("#hdncode").val() + ' Paper Deleted.');
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }

                });
            }
            else {
                return false;
            }
        }
    </script>

</body>

</html>
