<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionPaper.aspx.cs" Inherits="OnlineExamWeb.QuestionPaper" ValidateRequest="false"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.5.1/standard/ckeditor.js"></script>
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
            width: 20%;
            border: 0;
            padding: 10px;
            color: #FFFFFF;
            font-size: 10px;
            -webkit-transition: all 0.3 ease;
            transition: all 0.3 ease;
            cursor: pointer;
        }

        td, th {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">WebSiteName</a>
                </div>
                <ul class="nav navbar-nav">
                     <li><a href="InstitutionHome.aspx">Home</a></li>
                    <li><a href="QuestionPaper.aspx">Question Paper</a></li>
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
                </ul>
            </div>
        </nav>
        <div class="container" id="dvAdd" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <h2>Create Question Paper</h2>
                    <div class="form">
                        <div class="form-group">
                            <label for="">Question Paper Code</label>
                             <h3>
                                <asp:Label ID="lblQuestionPaperCode" Text="" runat="server" Visible="false"/></h3>
                            <asp:TextBox ID="txtQuestionPaperCode" runat="server" placeholder="Question Paper Code" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Title</label>
                            <asp:TextBox ID="txtTitle" runat="server" placeholder="Title" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Hidden Title</label>
                            <asp:TextBox ID="txtHiddenTitle" runat="server" placeholder="Hidden Title" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Question Count</label>
                            <h3>
                                <asp:Label Text="0" runat="server" ID="txtQuestionCount"></asp:Label></h3>
                        </div>
                        <div class="form-group">
                            <label for="">Category</label>
                            <asp:DropDownList ID="ddlCategory" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">General Instructions</label>
                            <textarea name="txtGeneralInstructions" id="txtGeneralInstructions" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Page_Load" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container" id="dvView" runat="server">
            <div class="row">
                <h2>Question Papers</h2>
                <div class="col-md-12 form">


                    <div class="form-group">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Question Paper" OnClick="btnAdd_Click" />

                    </div>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Code</th>
                                <th>Title</th>
                                 <th>QuestionCount</th>
                                <th style="width:20%">Action</th>
                            </tr>
                        </thead>
                        <tbody id="tBody" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnu" runat="server" />
        <asp:HiddenField ID="hdnid" runat="server" Value="0" />
        <asp:HiddenField ID="hdnapi" runat="server" Value="" />

    </form>
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
            // debugger;
            //var Title = obj.Table.length;
            var str = "";
            for (var i = 0; i < obj.Table.length; i++) {
                var item = obj.Table[i];
                str = str + "<tr><td>" + item.QuestionPaperCode + "</td><td>" + item.Title + "</td><td>" + item.QuestionCount + "</td><td><a class='btn btn-primary' href='Question.aspx?code=" + item.QuestionPaperCode + "' title='Add Questions'><span class='glyphicon glyphicon-plus'></span></a>  <a class='btn btn-primary' href='QuestionPaper.aspx?ecode=" + item.QuestionPaperCode + "' title='Edit Question Paper'><span class='glyphicon glyphicon-pencil'></span></a>  <a  class='btn btn-primary' href='QuestionPaper.aspx?pcode=" + item.QuestionPaperCode + "' title='Publish Question Paper'><span class='glyphicon glyphicon-new-window'></span></a>  <a  class='btn btn-primary' href='QuestionPaper.aspx?dcode=" + item.QuestionPaperCode + "' title='Delete Question Paper'><span class='glyphicon glyphicon-trash'></span></a></td></tr>";
            }
            $("#tBody").html(str);


        }



        function deletequestionpaper(code) {
            //alert('a');
            debugger;
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
