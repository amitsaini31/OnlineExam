<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginback.aspx.cs" Inherits="OnlineExamWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">

            <div class="form">
                <asp:Label ID="lblmessage" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                <div class="register-form">

                    <h2>Registration</h2>

                    <asp:TextBox ID="txtregemail" runat="server" placeholder="email"></asp:TextBox>
                    <asp:TextBox ID="txtregpassword" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="txtregconfirmpassword" runat="server" placeholder="confirm password" TextMode="Password"></asp:TextBox>
                    <asp:DropDownList ID="ddlRole" runat="server">
                        <asp:ListItem Text="Visitor" Value="Visitor"></asp:ListItem>
                        <asp:ListItem Text="Institution" Value="Institution"></asp:ListItem>
                    </asp:DropDownList>
                    <button id="btnregister" runat="server" onserverclick="btnregister_Click">REGITER</button>
                    <p class="message">Already registered? <a href="#">Sign In</a></p>
                </div>
                <div class="login-form">
                    <h2>Login</h2>
                    <asp:TextBox ID="txtemail" runat="server" placeholder="username"></asp:TextBox>
                    <asp:TextBox ID="txtpassword" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                    <button id="btnLogin" runat="server" onserverclick="btnlogin_Click">LOGIN</button>
                    <p class="message">Not registered? <a href="#">Create an account</a></p>
                    <p class="guest"><a href="GuestLogin.aspx">Start as Guest</a></p>
                </div>
            </div>
        </div>
    </form>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

        .login-page {
            width: 360px;
            padding: 8% 0 0;
            margin: auto;
        }

        .form {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 360px;
            margin: 0 auto 100px;
            padding: 45px;
            text-align: center;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

            .form input {
                font-family: "Roboto", sans-serif;
                outline: 0;
                background: #f2f2f2;
                width: 100%;
                border: 0;
                margin: 0 0 15px;
                padding: 15px;
                box-sizing: border-box;
                font-size: 14px;
            }

            .form select {
                font-family: "Roboto", sans-serif;
                outline: 0;
                background: #f2f2f2;
                width: 100%;
                border: 0;
                margin: 0 0 15px;
                padding: 15px;
                box-sizing: border-box;
                font-size: 14px;
            }

            .form button {
                font-family: "Roboto", sans-serif;
                text-transform: uppercase;
                outline: 0;
                background: #f4511e;
                width: 100%;
                border: 0;
                padding: 15px;
                color: #FFFFFF;
                font-size: 14px;
                -webkit-transition: all 0.3 ease;
                transition: all 0.3 ease;
                cursor: pointer;
            }

                .form button:hover, .form button:active, .form button:focus {
                    background: #ff3d00;
                }

            .form .message {
                margin: 15px 0 0;
                color: #b3b3b3;
                font-size: 12px;
            }

                .form .message a {
                    color: #f4511e;
                    text-decoration: none;
                }

            .form .guest {
                margin: 15px 0 0;
                color: #b3b3b3;
                font-size: 12px;
            }

                .form .guest a {
                    color: #f4511e;
                    text-decoration: none;
                }

            .form .register-form {
                display: none;
            }

        .container {
            position: relative;
            z-index: 1;
            max-width: 300px;
            margin: 0 auto;
        }

            .container:before, .container:after {
                content: "";
                display: block;
                clear: both;
            }

            .container .info {
                margin: 50px auto;
                text-align: center;
            }

                .container .info h1 {
                    margin: 0 0 15px;
                    padding: 0;
                    font-size: 36px;
                    font-weight: 300;
                    color: #1a1a1a;
                }

                .container .info span {
                    color: #4d4d4d;
                    font-size: 12px;
                }

                    .container .info span a {
                        color: #000000;
                        text-decoration: none;
                    }

                    .container .info span .fa {
                        color: #EF3B3A;
                    }

        body {
            background: White;
            font-family: "Roboto", sans-serif;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>

        $(document).ready(function () {
            $('.message a').click(function () {
                $('.form div').animate({ height: "toggle", opacity: "toggle" }, "slow");

            });
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
