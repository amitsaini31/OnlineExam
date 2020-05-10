<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineExamWeb.Register" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>EdigitalWiki</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Bitter:400,700">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lora">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/lightbox2/2.8.2/css/lightbox.min.css">
    <link rel="stylesheet" href="assets/css/styles.min.css">
</head>

<body>
    <div class="register-photo">
        <div class="form-container">
            <div class="image-holder"></div>
            <form runat="server">

                <h2 class="text-center"><strong>Create</strong> an account.</h2>
                <label id="lblmessage" runat="server" visible="false"></label>
                <div class="form-group">
                    <input class="form-control" type="text" name="email" placeholder="Email" id="txtemail" runat="server">
                </div>
                <div class="form-group">
                    <input class="form-control" type="password" name="password" placeholder="Password" id="txtpassword" runat="server">
                </div>
                <div class="form-group">
                    <input class="form-control" type="password" name="confirm-password" placeholder="Confirm Password" id="txtconfirmpassword" runat="server">
                </div>
                <div class="form-group">
                    <%-- <select class="form-control" id="ddlRole" runat="server">
                        <optgroup label="Select Your Role">
                            <option value="Visitor" selected>Visitor</option>
                            <option value="Institution">Institution</option>
                        </optgroup>
                    </select></div>--%>
                    <asp:DropDownList class="form-control" ID="ddlRole" runat="server">
                         <asp:ListItem Text="Select Your Role" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Visitor" Value="Visitor"></asp:ListItem>
                        <asp:ListItem Text="Institution" Value="Institution"></asp:ListItem>
                    </asp:DropDownList>


                    <div class="form-group">
                        <div class="form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="checkbox">I agree to the license terms.</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btn-block" type="submit" runat="server" onserverclick="btnregister_Click">Sign Up</button>
                    </div>
                    <a href="Login.aspx" class="already">You already have an account? Login here.</a>
            </form>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/lightbox2/2.8.2/js/lightbox.min.js"></script>
</body>

</html>
