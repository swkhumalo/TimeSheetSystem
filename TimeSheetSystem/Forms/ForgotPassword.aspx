<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TimeSheetSystem.Forms.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <link rel="icon" href="../img/Logo1160IDnr1.png"/>
    <title>Time Sheet System |Password Recovery </title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Styles/registration.css" rel="stylesheet" />
  
</head>
<body>
         <div class="box">
           <h2>Admin Password Recovery</h2>
            <form runat="server">
                <div>
                    <asp:Textbox class="input" runat="server" type="" required="" ID="txtEmail"></asp:Textbox>
                    <label>Email</label>
                </div>

                <asp:Button CssClass="button" ID="btnRecovery" runat="server" Text="Send" OnClick="btnRecovery_Click"/>
                <asp:LinkButton class="Linkbutton"  Font-Underline="false" ID="btnBack" runat="server" OnClick="btnBack_Click">Back</asp:LinkButton>
            &nbsp;</form>
        </div>
</body>
</html>
