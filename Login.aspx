<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SwimmingPoolAndGymManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body
        {
            background-image : url("images/img.jpg");
            background-repeat : no-repeat;
            background-size : cover;
            position: absolute; 
            top: 0; 
            left: 0; 
            right: 0; 
            bottom: 0; 
            margin : auto;
            min-width: 100%;
            min-height: 100%;
        }
        #form1
        {
            border-radius : 25px;
            height : 500px;
            width : 500px;
            margin-left : 1100px;
            margin-top : 50px;
            background-color : aqua ;

        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <br />
        <br />

        <h2 style="text-align:center">
            Swimming Pool & Gym Login
        </h2>

        <br />
        <br />
        <div style=" text-align: center">
             UserName 
            <asp:TextBox ID="TextBox1" runat="server" BackColor="White" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        
        <br />
        <br />
        
        <div style=" text-align: center">
             Password 
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" BackColor="White" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div>

        <br />
        <br />
       

        <div style=" text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log In" />
            <asp:Button ID="Register_button" runat="server" OnClick="Button2_Click" Text="Register" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Forgot Password ?" />
        </div>

        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Incorrect UserName or Password!!" style="text-align : center  ;color : red ;margin-left : 175px "></asp:Label>
        </div>

        
    </form>
</body>
</html>
