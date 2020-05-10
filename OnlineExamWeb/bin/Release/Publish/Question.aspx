<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="OnlineExamWeb.Question" ValidateRequest="false" %>

<!DOCTYPE html>

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
            width: 10%;
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
                            <li><a href="Login.aspx">Logout</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container" id="dvAdd" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <h2>Submit Your Questions</h2>
                    <div class="form">
                        <div class="form-group">
                            <label for="">Question Paper Code : </label>
                            <h3>
                                <asp:Label ID="txtQuestionPaperCode" Text="" runat="server" /></h3>
                        </div>
                        <div class="form-group">
                            <label for="">Question</label>
                            <textarea name="txtQuestion" id="txtQuestion" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <label for="">Choice 1</label>
                            <textarea name="txtMCQ1" id="txtMCQ1" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <label for="">Choice 2</label>
                            <textarea name="txtMCQ2" id="txtMCQ2" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <label for="">Choice 3</label>
                            <textarea name="txtMCQ3" id="txtMCQ3" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <label for="">Choice 4</label>
                            <%--<asp:TextBox ID="txtMCQ4" runat="server" placeholder="Choice 4" class="form-control"></asp:TextBox>--%>
                            <textarea name="txtMCQ4" id="txtMCQ4" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <label for="">Answer</label>
                            <%--<asp:TextBox ID="txtAnswer" runat="server" placeholder="Answer could be A / B / C / D" class="form-control"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlAnswer" runat="server" class="form-control">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="A">Choice 1</asp:ListItem>
                                <asp:ListItem Value="B">Choice 2</asp:ListItem>
                                <asp:ListItem Value="C">Choice 3</asp:ListItem>
                                <asp:ListItem Value="D">Choice 4</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">Explaination</label>
                            <textarea name="txtExplaination" id="txtExplaination" rows="10" cols="80" runat="server" class="form-control"></textarea>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/Question.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container" id="dvView" runat="server">
            <div class="row">
                <h2 id="htitle" runat="server"></h2>
                <div class="col-md-12 form">


                    <div class="form-group">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Question" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/QuestionPaper.aspx" />
                    </div>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Question</th>
                                <th style="width:20%">Action</th>
                            </tr>
                        </thead>
                        <tbody id="tBody" runat="server">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hdncode" runat="server" />
        <asp:HiddenField ID="hdnid" runat="server" Value="0" />
        <asp:HiddenField ID="hdnapi" runat="server" Value="0" />

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
            CKEDITOR.replace('txtQuestion');
            CKEDITOR.replace('txtMCQ1');
            CKEDITOR.replace('txtMCQ2');
            CKEDITOR.replace('txtMCQ3');
            CKEDITOR.replace('txtMCQ4');
            CKEDITOR.replace('txtExplaination');

        });

        function Initialload() {
            $.ajax({
                type: "POST",
                url: $("#hdnapi").val() + $("#hdncode").val() + "/questionsbycode",
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
            debugger;
            //var Title = obj.Table.length;
            var str = "";
            for (var i = 0; i < obj.Table.length; i++) {
                var item = obj.Table[i];
                str = str + "<tr><td  style='text-align:left;'>" + item.Question + "</td><td><a class='btn btn-primary' href='Question.aspx?ecode=" + item.ID + "' title='Edit Question'><span class='glyphicon glyphicon-pencil'></span></a>  <a  class='btn btn-primary' href='Question.aspx?dcode=" + item.ID + "' title='Delete Question'><span class='glyphicon glyphicon-trash'></span></a></td></tr>";
            }
            $("#tBody").html(str);


        }
    </script>
</body>
</html>
