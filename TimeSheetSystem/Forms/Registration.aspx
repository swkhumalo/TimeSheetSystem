<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TimeSheetSystem.Forms.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <link rel="icon" href="../img/Logo1160IDnr1.png"/>
    <title>Time Sheet System |User Registration </title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Styles/registration.css" rel="stylesheet" />
    <link href="../js/sweetalert2.css" rel="stylesheet" />

</head>
<body>
    
    <div class="box">
           <h2>Sign Up</h2>
            <form runat="server">
                <div>
                    <asp:Textbox class="input" runat="server" type="" required="" ID="txtName"></asp:Textbox>
                    <label>Initials & Surname</label>
                </div>
                <div>
                    <asp:Textbox class="input" runat="server" type="" required="" ID="txtEmail"></asp:Textbox>
                    <label>Email</label>
                </div>
                <div>
                    <asp:Textbox class="input" runat="server" type="" required="" ID="txtPassword" TextMode="Password" MaxLength="8"></asp:Textbox>
                    <label>Password</label>
                </div>
                <div>
                    <asp:Textbox class="input" runat="server" type="" required="" ID="txtconfirmPassword" TextMode="Password" MaxLength="8"></asp:Textbox>
                    <label>Confirm Password</label>
                </div>
                <asp:Button CssClass="button" ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click"/>
                
                <asp:LinkButton class="Linkbutton" ID="btnAccountLogin"  Font-Underline="false" runat="server" OnClick="btnAccountLogin_Click">Already Have Account?</asp:LinkButton>
            </form>
        </div>

    <script src="../js/sweetalert2.min.js"></script>
    <script type="text/javascript">
        function validation()
        {
            var password = 'sbu';
            var confirmpassword = 'a';

            var passWord = document.getElementById('password').value;
            var confirmPassword = document.getElementById('confirmPassword').value;

            if ((password == passWord) && (confirmpassword == confirmPassword))
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
