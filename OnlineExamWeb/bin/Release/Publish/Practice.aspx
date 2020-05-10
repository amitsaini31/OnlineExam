<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="OnlineExamWeb.Practice" %>

<%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<style>
    /* The container */
    .labelcontainer {
        display: block;
        position: relative;
        padding: 5px 5px 5px 35px;
        margin-bottom: 12px;
        cursor: pointer;
        font-size: 15px;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        border: 2px solid #27c971;
        word-wrap: break-word;
    }

    label {
        font-weight: 200;
    }
    /* Hide the browser's default checkbox */
    .labelcontainer input {
        position: absolute;
        opacity: 0;
        cursor: pointer;
        height: 0;
        width: 0;
    }

        .labelcontainer input ~ .checkmark {
            background-color: #ccc;
            margin: 5px;
        }

    /* Create a custom checkbox */
    .checkmark {
        position: absolute;
        top: 0;
        left: 0;
        height: 25px;
        width: 25px;
        background-color: #eee;
        border-radius: 50%;
    }

    /* On mouse-over, add a grey background color */
    .labelcontainer:hover input ~ .checkmark {
        background-color: #ccc;
        margin: 5px;
    }

    /* When the checkbox is checked, add a blue background */
    .labelcontainer input:checked ~ .checkmark {
        background-color: #78D25F;
        margin: 5px;
    }

    /* Create the checkmark/indicator (hidden when not checked) */
    .checkmark:after {
        content: "";
        position: absolute;
        display: none;
    }

    /* Show the checkmark when checked */
    .labelcontainer input:checked ~ .checkmark:after {
        display: block;
    }

    /* Style the checkmark/indicator */
    .labelcontainer .checkmark:after {
        left: 9px;
        top: 5px;
        width: 5px;
        height: 10px;
        border: solid white;
        border-width: 0 3px 3px 0;
        -webkit-transform: rotate(45deg);
        -ms-transform: rotate(45deg);
        transform: rotate(45deg);
        font-size: 20px;
    }

    .paddingdiv {
        margin-left: 10px;
        margin-right: 10px;
    }
    .footer{
        position:fixed;
    }
   
</style>

<form runat="server">
    <div class="container">
        <h1>Knowledge Booster</h1>
        <div class="row paddingdiv">
            <h3 id="question">Custom Radio Buttons</h3>
            <label class="labelcontainer col-md-12">
                <div id="lblA">One</div>
                <input type="radio" name="radio" id="radio1">
                <span class="checkmark"></span>
            </label>
            <label class="labelcontainer col-md-12">
                <div id="lblB">Two</div>
                <input type="radio" name="radio" id="radio2">
                <span class="checkmark"></span>
            </label>
            <label class="labelcontainer col-md-12">
                <div id="lblC">One</div>
                <input type="radio" name="radio" id="radio3">
                <span class="checkmark"></span>
            </label>
            <label class="labelcontainer col-md-12" id="radio4">
                <div id="lblD">One</div>
                <input type="radio" name="radio">
                <span class="checkmark"></span>
            </label>

        </div>
        <div class="footer">
            <button type="button" class="btn btn-success" style="width: 49%" id="btncheck" data-toggle="modal" data-target="#myModal" >Check Answer</button>
            <button type="button" class="btn btn-success" style="width: 49%" id="btnnext">Next Question</button>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Answer</h4>
                    </div>
                    <div class="modal-body" id="answer">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            LoadQuestion();
            $("#btnnext").click(function () {

                $("input[name='radio']").prop('checked', false);

                LoadQuestion();
            });
            $("input[type='radio']").on('change', function () {

                $("#btncheck").prop("disabled", false);
            });

        });
        $(document).keydown(function (e) {
            //alert(e.keyCode);
            if (e.keyCode == 39) {
                LoadQuestion();
            }
        });
        function LoadQuestion() {
            $.ajax({
                type: "GET",
                url: $("#hdnapi").val() + "/getrsquestion",
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
            var str = "";
            for (var i = 0; i < obj.Table.length; i++) {
                var item = obj.Table[i];
                str = str + "<tr><td  style='text-align:left;'>" + item.QuestionPaperCode + "</td><td  style='text-align:left;'>" + item.Question + "</td><td><a href='Q.aspx?ecode=" + item.ID + "' title='Edit Question'><i class='fas fa-edit action edit' ></i></a>  <a  href='Q.aspx?dcode=" + item.ID + "' title='Delete Question'><i class='fas fa-trash action delete' ></i></span></a></td></tr>";
            }
            $("#question").html(item.Question);
            $("#lblA").html(item.A);
            $("#lblB").html(item.B);
            $("#lblC").html(item.C);
            $("#lblD").html(item.D);
            $("#answer").html(item.Answer);
            $("#btncheck").prop("disabled", true);
        }
    </script>
    
    <input type="hidden" id="hdnapi" runat="server" />
</form>--%>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Quick Quiz - Play</title>
    <link rel="stylesheet" href="js/app.css" />
    <link rel="stylesheet" href="js/game.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form runat="server">
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered modal-sm">
                <div class="modal-content justify-center">
                    <div class="modal-header">
                        <h4 class="modal-title" id="mdltitle">Title</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <p id="answer"></p>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-primary" onclick=" LoadQuestion()">Next Question</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="container container-height">
            <div id="loader"></div>
            <div id="game" class="justify-center flex-column ">
                <h2 id="question">What is the answer to this questions?</h2>
                <div class="choice-container">
                    <p class="choice-prefix">A</p>
                    <p class="choice-text" data-number="A" id="lblA" >Choice 1</p>
                </div>
                <div class="choice-container">
                    <p class="choice-prefix">B</p>
                    <p class="choice-text" data-number="B" id="lblB" >Choice 2</p>
                </div>
                <div class="choice-container">
                    <p class="choice-prefix">C</p>
                    <p class="choice-text" data-number="C" id="lblC" >Choice 3</p>
                </div>
                <div class="choice-container">
                    <p class="choice-prefix">D</p>
                    <p class="choice-text" data-number="D" id="lblD" >Choice 4</p>
                </div>
                <input type="hidden" id="hdnanswer" />
            </div>

        </div>
        <script src="game.js"></script>
        <script>
            $(document).ready(function () {
                LoadQuestion();
                //$("#btnnext").click(function () {

                //    $("input[name='radio']").prop('checked', false);

                //    LoadQuestion();
                //});
                //$("input[type='radio']").on('change', function () {

                //    $("#btncheck").prop("disabled", false);
                //});

            });
            $(document).keydown(function (e) {
                //alert(e.keyCode);
                if (e.keyCode == 39) {
                    LoadQuestion();
                }
            });
            $(".choice-text").click(function () {
                //alert($(this).attr("data-number"));
                //alert($("#hdnanswer").val());
                Reset();

                if ($(this).attr("data-number") == $("#hdnanswer").val()) {
                    $(this).css("background-color", "green");
                    $(this).css("color", "White");
                }
                else {
                    $(this).css("background-color", "#960f0f");
                    $(this).css("color", "White");
                }
                $("#myModal").modal("show");
            });
            function Reset() {

                $(".choice-text").css("background-color", "White");
                $(".choice-text").css("color", "Black");
                //$(element).html();
                ////alert(answer);
                //$("#myModal").modal("show");
            }
            function LoadQuestion() {

                Reset();

                $("#myModal").modal("hide");

                $("#loader").show();
                $("#game").hide();

                $.ajax({
                    type: "GET",
                    url: $("#hdnapi").val() + "/getrsquestion",
                    //data: '{"productid" : "0"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: OnInitialLoadSuccess,
                    failure: function (response) {
                        //alert(response.responseText);
                    },
                    error: function (response) {
                        //alert(response.responseText);
                    }
                });
            }

            function OnInitialLoadSuccess(response) {
                var obj = jQuery.parseJSON(response);
                //var Title = obj.Table.length;

                $(obj.Table).each(function () {
                    $("#question").html(obj.Table[0].Question);
                    $("#lblA").html(obj.Table[0].A);
                    $("#lblB").html(obj.Table[0].B);
                    $("#lblC").html(obj.Table[0].C);
                    $("#lblD").html(obj.Table[0].D);
                    $("#answer").html(obj.Table[0].Answer);
                    $("#hdnanswer").val(obj.Table[0].AnsKey);
                    $("#btncheck").prop("disabled", true);

                    $("#loader").hide();
                    $("#game").show();
                })
                

            }
        </script>
        <input type="hidden" id="hdnapi" runat="server" />

    </form>
</body>
</html>

