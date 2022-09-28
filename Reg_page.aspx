<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg_page.aspx.cs" Inherits="SwimmingPoolAndGymManagement.Reg_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <style>
        body
        {
            background-color : aqua ;
        }
        #form1
        {
            border-radius : 25px;
            height : 550px;
            width : 500px;
            margin-left : auto ;
            margin-right : auto ;
            margin-top :100px ;
            margin-bottom : 80px;
            background-color :antiquewhite ;
        }
    </style>
</head>
<body title="select">
    <form id="form1" runat="server">
        <div>
            <br />
            
            <h2 style="text-align:center ; background-color :white ;height : 50px">
            Swimming Pool & Gym Registration
        </h2>
        </div>

        <div style =" text-align : center ">
            <asp:Label ID="Label6" runat="server" Text="User Name" Font-Bold="True"></asp:Label>
            :
            <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
        </div>

        <br />

        <div style =" text-align : center ">
            <asp:Label ID="Label7" runat="server" Text="Password" Font-Bold="True"></asp:Label>
            &nbsp&nbsp:
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
        </div>

        <br />
       
        <div style =" text-align : center " >
            <asp:Label ID="Label1" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
            :
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>

        <br />

        <div style =" text-align : center " >
            <asp:Label ID="Label2" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
            :
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div>

        <br />

        <div style ="margin-left : 122px "> 
            <asp:Label ID="Label3" runat="server" Text="Gender" Font-Bold="True"></asp:Label>
            &nbsp&nbsp&nbsp&nbsp&nbsp:
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
            </asp:DropDownList>
        </div>

        <br />

        <div style =" text-align : center ">
            <asp:Label ID="Label4" runat="server" Text="Email" Font-Bold="True"></asp:Label>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>

         <br />

        <div style =" text-align : center ">
            <asp:Label ID="Label5" runat="server" Text="Phone No" Font-Bold="True"></asp:Label>
            &nbsp:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>

        <br />
        
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:CheckBox ID="CheckBox1" runat="server" ></asp:CheckBox>
            <asp:Label ID="LabelCheckBox" runat="server" Text="Request to become Admin" Font-Bold="True"></asp:Label>
            
        </div>

        <br />

        <div style =" text-align : center ">
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        </div>

        <br />

        <div style ="text-align : center">
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>

        <br />

        <div style ="text-align : center ">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx"></asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
