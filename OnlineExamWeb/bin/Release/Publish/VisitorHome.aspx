<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorHome.aspx.cs" Inherits="OnlineExamWeb.VisitorHome" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .form {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 100%;
            margin: 0 auto 100px;
            padding: 45px;
            text-align: left;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

        input[type=submit] {
            font-family: "Roboto", sans-serif;
            text-transform: uppercase;
            outline: 0;
            background: #4CAF50;
            width: 10%;
            border: 0;
            padding: 10px;
            color: #FFFFFF;
            font-size: 14px;
            -webkit-transition: all 0.3 ease;
            transition: all 0.3 ease;
            cursor: pointer;
        }

        td, th {
            text-align: center;
        }

        .notification-menu {
            position: absolute;
            top: 100%;
            left: 0;
            z-index: 1000;
            display: none;
            float: left;
            min-width: 360px;
            padding: 5px 0;
            margin: 2px 0 0;
            margin-top: 2px;
            font-size: 14px;
            text-align: left;
            list-style: none;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ccc;
            border: 1px solid rgba(0,0,0,.15);
            border-radius: 4px;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
            box-shadow: 0 6px 12px rgba(0,0,0,.175);
        }

        .time {
            text-align: inherit;
        }

        .badgeAlert {
            display: inline-block;
            min-width: 10px;
            padding: 3px 7px;
            font-size: 12px;
            font-weight: 700;
            color: #fff;
            line-height: 1;
            vertical-align: baseline;
            white-space: nowrap;
            text-align: center;
            background-color: #d9534f;
            border-radius: 10px;
            position: absolute;
            margin-top: -10px;
            margin-left: -10px
        }

        nav div li a {
            color: blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="VisitorHome.aspx">WebSiteName</a>
                </div>
                <ul class="nav navbar-nav">
                    <li><a href="VisitorHome.aspx">Home</a></li>
                    <li><a href="Results.aspx">Results</a></li>
                    <%-- <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Page 1-1</a></li>
                            <li><a href="#">Page 1-2</a></li>
                            <li><a href="#">Page 1-3</a></li>
                        </ul>
                    </li>
                    <li><a href="#">Page 2</a></li>--%>
                </ul>

                <ul class="nav navbar-nav navbar-right">

                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" id="ausername" runat="server">Page 1<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="Logout.aspx">Logout</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" id="a1" runat="server"><span class="glyphicon glyphicon-bell alertNotificacao"></span>
                            <span class='badgeAlert'>2</span>
                            <span class="caret"></span></a>
                        <ul class="dropdown-menu notification-menu">
                            <li><a href="Logout.aspx">Logout</a></li>
                            2
                            <li><a href="Logout.aspx">Logout</a></li>
                            <li><a href="Logout.aspx">Logout</a></li>
                            <li><a href="Logout.aspx">Logout</a></li>
                            <li><a href="Logout.aspx">Logout</a></li>

                        </ul>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container" id="dvView" runat="server">

            <div class="row">
                <h2>List of Question Paper</h2>
                <div class="col-md-12 form">


                    <table class="table">
                        <thead>
                            <tr>
                                <th>Code</th>
                                <th>Title</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody id="tBody" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function ($) {
            window.location.lasthash.push(window.location.hash);
            window.location.hash = curr;
            //if (window.history && window.history.pushState) {

            //    window.history.pushState('forward', null, './#forward');

            //    $(window).on('popstate', function () {
            //        //alert('Back button was pressed.');
            //    });

            //}
        });
    </script>
</body>
</html>


