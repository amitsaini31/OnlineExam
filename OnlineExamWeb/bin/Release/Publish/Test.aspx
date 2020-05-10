<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="OnlineExamWeb.Test" %>

<html class="" lang="en">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link rel="shortcut icon" href="https://www.wscubetech.com/images/fav.png">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <!--<noscript id="deferred-styles">-->
    <!-- <link rel="stylesheet" type="text/css" href="css/style_min.css"> -->
    <link rel="stylesheet preload" as="style" href="quiz_files/css1.css">
    <link rel="stylesheet preload" as="style" href="quiz_files/css2.css">
    <link rel="stylesheet preload" as="style" href="quiz_files/css5.css">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/mediaquiery_min.css" id="mediaquiery_min">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/responsive3.css" id="responsive3">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/responsive2.css" id="responsive2">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/responsive1.css" id="responsive1">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/responsive0.css" id="responsive0">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/cmq.css" id="styles">
    <link rel="stylesheet preload" as="style" type="text/css" href="quiz_files/owl.css" id="owl.carousel">
    <!--</noscript>-->
    <link rel="canonical" href="https://www.wscubetech.com/quiz-test-html">

    <style>
        .form {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 100%;
            margin: 0 auto 20px;
            padding: 45px;
            text-align: left;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

        .a-left {
            float: left !important
        }

        .a-right {
            float: right !important
        }

        .instructions {
            margin-top: 10px;
        }

        .questioncount {
            font-family: "Open Sans";
            font-weight: 400;
            font-style: normal;
            color: #3fa3da;
            font-size: 18px;
            padding-top: 3px;
            letter-spacing: 0.6px;
            word-spacing: 0.7px;
        }
    </style>
</head>


<!-- Register form  start-->
<body class="loaded" id="myvideo">

    <%-- <nav class="navbar navbar-inverse" id="navbar">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">WebSiteName</a>
            </div>
            <ul class="nav navbar-nav">
                <li><a href="Results.aspx">Results</a></li>
               
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
    </nav>--%>

    <link as="style" href="quiz_files/css3.css" rel="stylesheet preload">
    <link rel="stylesheet preload" as="style" href="quiz_files/css4.css">

    <section class="container-fluid training_page quiz-part-mobile">
        <div class="container form">
            <div>
                <label id="lblIPAdd" runat="server"></label>
                <a class="btn btn-primary" id="btnback" style="float: right; background-color: red" href="Visitor.aspx">Back</a>
            </div>
            <div class="row">
                <div class="bs-example" data-example-id="disabled-active-pagination">
                    <nav aria-label="...">

                        <ul class="pagination" id="ulpaging" style="display: none;">
                            <li><a href="#" onclick="GetQuestion()">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                        </ul>
                    </nav>
                </div>
                <!-- Mobile Respomsive Menu start -->
                <!-- End -->
                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12 padding_right1 padding_left1 remove_padding_mobile">
                    <%-- <div class="col-md-12 col-sm-12 col-xs-12 heading-html padding_zero">
                            <img src="quiz_files/html2.png" alt="" class="img-responsive wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.3s" style="visibility: visible; animation-duration: 1s; animation-delay: 0.3s; animation-name: fadeInLeft;">
                            <h1 id="hdTitle">HTML Quiz
                            </h1>
                        </div>--%>

                    <div id="leveldiv" style="border: 0px red solid; margin-top: 3	0px;">
                        <div id="begonline">
                            <div class="on_test programring" id="dvTestTitle">
                            </div>
                            <div class="prgm_test">
                                <div id="clickme">
                                    <div class="test_box">
                                        <div class="questioncount" id="dvTestDetail" runat="server"></div>
                                        <div class="instructions" runat="server">
                                            <h4>General Instructions :</h4>
                                            <div id="dvTestGeneralInstructions"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="pgeneralinstructions" runat="server"></div>
                        </div>
                        <div id="rndbox" style="display: none;">
                            <div id="quesbox">
                                <div class="col-md-12 col-sm-12 col-xs-12 instruc padding_zero wow fadeInDown animated animated animated" data-wow-duration="1s" data-wow-delay="0.3s" style="visibility: visible; animation-duration: 1s; animation-delay: 0.3s; animation-name: fadeInDown;">Instruction:</div>
                                <div class="col-md-12 col-xs-12 col-sm-12 total-ques padding_zero wow fadeInLeft animated animated animated" data-wow-duration="1s" data-wow-delay="0.3s " style="visibility: visible; animation-duration: 1s; animation-delay: 0.3s; animation-name: fadeInLeft;">
                                    Total Number of Questions:
                                                <span>30</span>
                                </div>
                                <div class="col-md-12 col-xs-12 col-sm-12 total-ques2 padding_zero wow fadeInLeft animated animated animated" data-wow-duration="1s" data-wow-delay="0.3s" style="visibility: visible; animation-duration: 1s; animation-delay: 0.3s; animation-name: fadeInLeft;">Time alloted: <span>30                         minutes</span></div>
                                <div class="col-md-12 col-xs-12 col-sm-12 each-div padding_zero wow fadeInLeft animated animated animated" data-wow-duration="1s" data-wow-delay="0.3s" style="visibility: visible; animation-duration: 1s; animation-delay: 0.3s; animation-name: fadeInLeft;">
                                    Each question carry 1 mark each, no negative marking
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <%-- <form method="post" action="" id="form_submit">--%>
                        <input type="hidden" name="id" value="html">
                        <div id="showquesbox" class="showquesbox_classs" style="display: none;">
                            <div class="col-md-12 col-sm-12 col-xs-12 padding_zero time-details">
                                <div class="col-md-6 col-xs-12 text-left padding_zero">
                                    <div class="ques-mark" id="lblquestionno">
                                        <h3>Question :</h3>
                                    </div>
                                    <div class="ques-limite ">
                                        <div id="dvCurrentquestion" style="float: left; padding-right: 5px;">2 of 30</div>

                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12 text-right padding_zero watch_time">
                                    <%--<img src="quiz_files/watch.png" alt="" class="img-responsive " style="float: left; margin-left: 60%;">
                                                <div id="my_div1" style="float: left;" class="ques-limite" align="right">Time left: 29:49</div>--%>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="questions" id="ques" style="display: block;">
                                <div id="questions">
                                    <div class="questionnumber open-div" id="lblQuestion">1. What is the difference between XML and HTML? </div>
                                </div>

                                <div class="answer row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="a_ans">
                                            <div class="radiobtn">
                                                <input type="radio" id="ans11" name="ans[14]" value="1" class="radio" onchange="optionselect('A')">
                                                <label for="ans11" id="lblA" class="col-md-12">
                                                    <div class="pull-left pp">A</div>
                                                    HTML is used for exchanging data, XML is not.
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="answer row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 ">
                                        <div class="a_ans">
                                            <div class="radiobtn">
                                                <input type="radio" id="ans21" name="ans[14]" value="2" class="radio" onchange="optionselect('B')">
                                                <label for="ans21" id="lblB" class="col-md-12">
                                                    <div class="pull-left pp">B</div>
                                                    XML is used for exchanging data, HTML is not
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="answer row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="a_ans">
                                            <div class="radiobtn">
                                                <input type="radio" id="ans31" name="ans[14]" value="3" class="radio" onchange="optionselect('C')">
                                                <label for="ans31" id="lblC" class="col-md-12">
                                                    <div class="pull-left pp">C</div>
                                                    HTML can have user defined tags, XML cannot 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="answer row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="a_ans">
                                            <div class="radiobtn">
                                                <input type="radio" id="ans41" name="ans[14]" value="4" class="radio" onchange="optionselect('D')">
                                                <label for="ans41" id="lblD" class="col-md-12">
                                                    <div class="pull-left pp">D</div>
                                                    HTML can have user defined tags, XML cannot
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br>
                            </div>
                            <div style="clear: both;"></div>
                        </div>

                        <a class='a-left btn btn-primary' style="display: none;" role='button' id="btnprev" href="#" onclick="prevquestion()">❮ Previous</a>
                        <a class='a-right btn btn-primary' style="display: none;" role='button' id="btnnext" href="#" onclick="nextquestion()">Next ❯</a>
                        <div id="nextprev">
                            <%-- <div class="submit_test">
                                                    <input type="submit" name="endtest" title="Submit" value="SUBMIT TEST" class="start" style="border-radius: 3px;" id="endtest" onclick="return confirmsubmit()">

                                                </div>--%>

                            <div class="next_quiz">
                                <%-- <input id="btnprev" type="button" name="next" title="Prev" id="prev" onclick="question('p')" value="« Prev" class="nextbtn" style="margin-right: 10px; margin-top: 19px; display: none;">
                                <input id="btnnext" type="button" name="next" title="Next" id="next" onclick="question('n')" value="Next »" class="nextbtn" style="margin-top: 19px; display: none;">--%>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <%--<input type="hidden" id="current_show_ques" value="2">--%>
                        <input type="hidden" id="total_question" value="30">
                        <div style="clear: both;"></div>
                    </div>
                    <%--  </form>--%>
                </div>


                <button class="test" id="btnstart"><a title="Start Test" onclick="starttest()">Start Test</a></button>



                <button class="test" id="btnsubmit" style="display: none;"><a title="Submit Test" onclick="confirmsubmit()">Submit Test</a></button>


            </div>
            <input type="hidden" id="hdncode" runat="server" />
            <input type="hidden" id="hdncurrentquestion" runat="server" />
            <input type="hidden" id="hdnquestioncount" runat="server" />
            <input type="hidden" id="hdnu" runat="server" />
            <input type="hidden" id="hdnapi" runat="server" />
            <input type="hidden" id="hdntotalquestions" runat="server" value="0" />

        </div>
        </div>
       
        <script>

            $(document).ready(function ($) {
                Initialload();
                //window.location.lasthash.push(window.location.hash);
                //window.location.hash = curr;
                //if (window.history && window.history.pushState) {

                //    window.history.pushState('forward', null, './#forward');

                //    $(window).on('popstate', function () {
                //        //alert('Back button was pressed.');
                //    });

                //}
            });



            function optionselect(select) {
                $.ajax({
                    type: "POST",
                    url: $("#hdnapi").val() + $("#hdncode").val() + "/" + $("#hdncurrentquestion").val() + "/" + select + "/" + $("#hdnu").val() + "/questionattempt",
                    //data: '{"productid" : "0"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () { },
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }

                });
            }
            function Initialload() {
                $.ajax({
                    type: "POST",
                    url: $("#hdnapi").val() + $("#hdncode").val() + "/initialload",
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
                var Title = obj.Table[0].Title;
                var QuestionCount = obj.Table[0].QuestionCount;
                var GeneralInstructions = obj.Table[0].GeneralInstructions;
                $("#hdntotalquestions").val(QuestionCount);
                var table1 = obj.Table1[0];

                $("#lblQuestion").html(table1.Question);

                $("#lblA").html(' <div class="pull-left pp">A</div><div>' + table1.MCQ1 + '</div>');
                $("#lblB").html(' <div class="pull-left pp">B</div><div>' + table1.MCQ2 + '</div>');
                $("#lblC").html(' <div class="pull-left pp">C</div><div>' + table1.MCQ3 + '</div>');
                $("#lblD").html(' <div class="pull-left pp">D</div><div>' + table1.MCQ4 + '</div>');


                var QuestionPaperCode = obj.Table[0].QuestionPaperCode;
                $("#dvTestTitle").html("Title : " + Title);
                $("#dvTestDetail").html("Number of Questions : " + QuestionCount);
                $("#dvTestGeneralInstructions").html(GeneralInstructions);
                createpagination(QuestionCount);
            }


            $(document).on('keydown', function (event) {
                if (event.key == "Escape") {
                    e.preventDefault();
                    return false;
                }
                if (e.which == 122) {
                    e.preventDefault();
                    return false;
                }
                if (e.which == 123) {
                    e.preventDefault();
                    return false;
                }

            });
            $(document).keyup(function (e) {

            });

            function confirmsubmit() {
                if (confirm("Are You Sure to Submit Test")) {
                    window.location.href = "TestComplete.aspx?code=" + $("#hdncode").val();
                }
                return false;
            }

            function openFullscreen() {
                var elem = document.documentElement;
                if (elem.requestFullscreen) {
                    elem.requestFullscreen();
                } else if (elem.mozRequestFullScreen) { /* Firefox */
                    elem.mozRequestFullScreen();
                } else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                    elem.webkitRequestFullscreen();
                } else if (elem.msRequestFullscreen) { /* IE/Edge */
                    elem.msRequestFullscreen();
                }
            }
            function starttest() {
                $.ajax({
                    type: "POST",
                    url: $("#hdnapi").val() + $("#hdncode").val() + "/" + $("#hdnu").val() + "/starttest",
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

                $("#hdncurrentquestion").val('1');
                $("#dvCurrentquestion").html(" <h3>1</h3>");
                //openFullscreen();
                document.getElementById('showquesbox').style.display = "block";
                document.getElementById('btnstart').style.display = "none";
                document.getElementById('btnback').style.display = "none";
                document.getElementById('begonline').style.display = "none";
                //document.getElementById('navbar').style.display = "none";
                if ($("#hdncurrentquestion").val() == '1') {
                    document.getElementById('btnprev').style.display = "none";
                }

                document.getElementById('btnsubmit').style.display = "block";
                document.getElementById("ulpaging").style.display = "block";
                GetQuestion(1);
            }

            function GetQuestion(i) {

                $('.radio').prop('checked', false);
                $.ajax({
                    type: "GET",
                    url: $("#hdnapi").val() + $("#hdncode").val() + "/" + i + "/" + $("#hdnu").val() + "/getquestion",
                    //data: '{"productid" : "0"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: Ongetquestion,
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            }
            function Ongetquestion(response) {
                var obj = jQuery.parseJSON(response);
                var table1 = obj.Table[0];
                $("#hdncurrentquestion").val(table1.RowNum);
                $("#lblQuestion").html(table1.Question);
                $("#dvCurrentquestion").html(" <h3>" + table1.RowNum + " out of " + $("#hdntotalquestions").val() + " </h3>");

                if ($("#hdncurrentquestion").val() == '1') {
                    document.getElementById('btnprev').style.display = "none";
                }
                else {
                    document.getElementById('btnprev').style.display = "block";
                }

                if ($("#hdncurrentquestion").val() == $("#hdntotalquestions").val()) {
                    document.getElementById('btnnext').style.display = "none";
                }
                else {
                    document.getElementById('btnnext').style.display = "block";
                }

                $("#lblA").html(' <div class="pull-left pp">A</div>' + table1.MCQ1);
                $("#lblB").html(' <div class="pull-left pp">B</div>' + table1.MCQ2);
                $("#lblC").html(' <div class="pull-left pp">C</div>' + table1.MCQ3);
                $("#lblD").html(' <div class="pull-left pp">D</div>' + table1.MCQ4);
                var table = obj.Table1[0];
                switch (table.Answer) {
                    case 'A':
                        {
                            $('#ans11').prop('checked', true);
                            break;
                        }
                    case 'B':
                        {
                            $('#ans21').prop('checked', true);
                            break;
                        }
                    case 'C':
                        {
                            $('#ans31').prop('checked', true);
                            break;
                        }
                    case 'D':
                        {
                            $('#ans41').prop('checked', true);
                            break;
                        }
                }

                return false;
            }

            function createpagination(questioncount) {
                var html = '<li><a>Questions : </a></li>';
                questioncount = questioncount + 1;
                for (i = 1; i < questioncount; i++) {
                    html = html + '<li><a href="#"  onclick="GetQuestion(' + i + ')">' + i + '</a></li>';
                }
                $("#ulpaging").html(html);
            }

            function nextquestion() {
                //alert($("#hdncurrentquestion").val());
                var q = parseInt($("#hdncurrentquestion").val()) + 1;
                GetQuestion(q);

            }

            function prevquestion() {
                var q = parseInt($("#hdncurrentquestion").val()) - 1;
                GetQuestion(q);

            }

        </script>
    </section>

</body>
</html>
