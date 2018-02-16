<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="TimeSheetSystem.Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="../img/Logo1160IDnr1.png"/>
    <title>Time Sheet System |Sign In </title>
    <link href="../Styles/Signin.css" rel="stylesheet" />
    <meta name="description" content="The description of my page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <div class="title"><h1>Sign In</h1></div>
        <div class="container">
            <div class="left"></div>
            <div class="right">
                <div class="formBox">
                     <form id="form1" runat="server">  
                        <div>
                            <asp:Textbox class="input" runat="server" type="" required="" ID="txtEmail"></asp:Textbox>
                            <label>Email</label>
                        </div>
                        <div>
                            <asp:Textbox class="input" runat="server" type="" required="" ID="txtPassword" TextMode="Password" MaxLength="8"></asp:Textbox>
                            <label>Password</label>
                        </div>
                        <asp:Button CssClass="button" ID="btnAdmin" runat="server" Text="Admin" OnClick="btnAdmin_Click" />
                        
                         <asp:LinkButton class="Linkbutton" ID="btnForgetPassword" runat="server"  Font-Underline="false" OnClick="btnForgetPassword_Click">Forget Password?</asp:LinkButton>
                        |&nbsp;<asp:LinkButton class="Linkbutton" ID="btnLinkRegister"  Font-Underline="false" runat="server" OnClick="btnLinkRegister_Click" >Sign-Up</asp:LinkButton>
                     </form>
                </div>
            </div>
        </div>

    <script src="../js/sweetalert2.min.js"></script>
    <script type="text/javascript">
        function btnSignIn_Click1()
        {
            var txtEmail = 'sbu';
            var txtPassword = 'a';

            var userName = document.getElementById('txtEmail').value;
            var password = document.getElementById('txtPassword').value;

            if ((username == txtEmail) && (password == txtPassword))
            {
                swal('Good job!', 'You clicked the button!', 'success');
            }
            else
            {
                swal('Oops...','Something went wrong!','error')
            }
        }
        </script>
</body>
</html>
