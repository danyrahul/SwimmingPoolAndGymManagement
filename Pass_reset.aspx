<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pass_reset.aspx.cs" Inherits="SwimmingPoolAndGymManagement.Pass_reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password Page</title>
    <style>
        body
        {
            background-color : aqua ;
        }
        #form1
        {
            border-radius : 25px;
            height : 550px;
            width : 550px;
            margin-left : auto ;
            margin-right : auto ;
            margin-top :100px ;
            margin-bottom : 80px;
            background-color :antiquewhite ;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />

        <h2 style="text-align:center ; background-color :white ;height : 50px">
            Reset Password
        </h2>


        <br />
        <div style="margin-left :120px">
             <asp:Label ID="Label2" runat="server" Text="UserName : "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" BackColor="White" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Invalid Username!!" Visible ="false"  ForeColor="Red"></asp:Label>
        </div>

        <br />
        <div style="text-align : center ">
             <asp:Button ID="Button3" runat="server" Text="Send OTP" OnClick="Button3_Click" />
        </div>

        <br />
        <div style="margin-left :120px " id="Label6">
             <asp:Label ID="Label3" visible="false" runat="server" Text="Enter OTP : "></asp:Label>
            <asp:TextBox ID="TextBox4"  runat="server" visible="false" BackColor="White" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" visible="false" Text="Validate" OnClick="Button2_Click" />
            <asp:Label ID="Label6" runat="server" visible="false" Text="Incorrect!!" ForeColor="Red"></asp:Label>
        </div>
        
        <br />
        <br />
        
        <div style=" margin-left :120px">
            <asp:Label ID="Label4" runat="server" visible="false" Text="Password :  "></asp:Label>
            &nbsp
            <asp:TextBox ID="TextBox2" runat="server" visible="false" TextMode="Password" BackColor="White" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div>

        <br />
        <br />
        
        <div style=" margin-left :80px ">
            <asp:Label ID="Label5" runat="server" visible="false" Text="Retype Password :"></asp:Label> 
            <asp:TextBox ID="TextBox3" runat="server" visible="false" TextMode="Password" BackColor="White" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:Label id="Label7" runat="server" visible="false" Text="Password Mismatch!!" ForeColor="Red"></asp:Label>
        </div>

        <br />
        <br />
        
        <div style=" text-align : center  ">
            <asp:Button ID="Button1" runat="server" visible="false" Text="Reset Password" OnClick="Button1_Click" />
        </div>

        <br />
        <br />
        
        <div style=" text-align : center  ">
            <asp:Label id="Label8" runat="server" visible="false" Text="Password updates Successfully....."></asp:Label>
        </div>

        <br />

        <div style ="text-align : center ">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx" Visible ="false" ></asp:HyperLink>
        </div>

    </form>
</body>
</html>
